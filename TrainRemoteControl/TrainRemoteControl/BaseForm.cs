using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TrainRemoteControl.utilclass;
using TrainRemoteControl.Model;
using TrainRemoteControl.BLL;
using TrainRemoteControl.TCP;

namespace TrainRemoteControl
{
    public partial class BaseForm : Form
    {
        private int timeCount = 1;
        public BaseForm()
        {
            InitializeComponent();
        }
        TCPServiceUtil tcputil = new TCPServiceUtil();
        BuildMsgUtil buildMsg = new BuildMsgUtil();
        private void BaseForm_Load(object sender, EventArgs e)
        {
            Program.WriteLog("==========================>>进入BaseForm页面");
            timer1.Start();
            string startTime =  "5";
            timeCount = int.Parse(startTime);
            IniVarUtil.iniXunjianVar();
            tcputil.InitalSevice(); //注册tcp连接
            deletOverTimelogs();
            deletOverTimeData();
        }

       
        private void timer1_Tick(object sender, EventArgs e)
        {
            --timeCount;
            progressBar1.Value += 2;
            if (timeCount == 0)
            {
                timer1.Stop();
                new MDIParent1().Show();              
                this.Hide();
                 
            }
        }

        int netTimeCount = 0;
        int uploadTimeCount = 0;
        int readtempTimeCount = 0;
        //检测网络状态  报到
        private void timer2_net_Tick(object sender, EventArgs e)
        {
            
            netTimeCount++;
            readtempTimeCount++;
            uploadTimeCount++;
            //采集关键数据
            gatherCriticalData();
            //读取温度数据
            if (readtempTimeCount == 8)  //4s 读取温度数据
            {
                readtempTimeCount = 0;
                readTemperature();
            }
            if (netTimeCount == 4)
            {
                netTimeCount = 0;
                tcputil.SendMsg2Server(1, Program.g_serialNum);  //2s 报到一次
            }
            if (uploadTimeCount == 8)   //4s上传关键数据
            {
                uploadTimeCount = 0;
                if (Program.g_isNetState)
                {
                    Program.WriteLog(" TCP通信，上传关键数据");
                    string upStr = new BuildMsgUtil().buildUploadCriticalData(Program.g_criticalDataList);
                    tcputil.SendMsg2Server(2, upStr);
                    Program.WriteLog(" 上传关键数据调用成功");

                    Program.WriteLog(" TCP通信，上传温度数据");
                    string uptempStr = new BuildMsgUtil().buildUploadTemperatureData(Program.g_tempCellsTerminalList);
                    tcputil.SendMsg2Server(3, uptempStr);
                    Program.WriteLog(" 上传温度数据调用成功");
                }

            }
        }

       
       
        private void deletOverTimelogs()
        {
            //得到D:\javafzxt\Logs"文件夹下所有 
            DirectoryInfo di = new DirectoryInfo(@"D:\train\Logs");
            FileInfo[] fi = di.GetFiles("*.log");

            String shumu = fi.Length.ToString();// 文件的个数
            Program.WriteLog("过期的文件数目：" + shumu);
            DateTime dtNow = DateTime.Now;

            //MiniForm mini = new MiniForm();
            //mini.MiniMizeAppication("cmd");

            foreach (FileInfo tmpfi in fi)
            {
                if (tmpfi.Name != "1.log")
                {
                    //tmpfi.CreationTime;//创建时间
                    TimeSpan ts = dtNow.Subtract(tmpfi.LastWriteTime);
                    if (ts.TotalDays > 7)//距现在30分钟以上    TotalMinutes
                    {
                        tmpfi.Delete();//删除文件
                    }

                }
            }
            Program.WriteLog("成功删除7天之前的日志文件文件");
            
        }

        private void deletOverTimeData()
        {
            // delete    FROM CriticalData    where   saveTime  > '2017-05-21 15:27:19'
            DateTime dt = DateTime.Now; 
            CriticalDataBLL bll = new CriticalDataBLL();
            DateTime datetime = dt.AddMonths(-1);  
            if (bll.deleteCricialData(Program.g_lcNumber, datetime))
            {
                Program.WriteLog("清理过期的数据库数据");
            }
           
        }

        DataAcquisitionManager dataAcquisitionMana = new DataAcquisitionManager();
        DataAcquisition da = new DataAcquisition();
        public event Action<bool> PowerShutDownEvent;//断电事件
        int a1 = 0;
        int a2 = 0;
        int a3 = 0;
        int a4 = 0; //发送电机状态计数
        int timesCount = 120; //标示1分钟报存关键数据
        CriticalDataBLL bll = new CriticalDataBLL();
        //采集关键数据
        private void gatherCriticalData()
        {
            //初始化报警值
            int oldAlarmValue = 0;
            int alarm = 0;
            //初始化电机状态
            string oldGeneratorStatus = "";//其实int或者byte最好
            try
            {
                //DataAcquisitionManager dataAcquisitionMana = new DataAcquisitionManager();
                //DataAcquisition da = new DataAcquisition();
                //获取公共数据
                CommonOriginalData commonData = da.GetOriginalCommonData();
                //获取油量值
                float oilMass = (float)((commonData.OilMass - 5.03) * 1525 / 0.726);

                //采集三个电机的电压值，判断是否处于开机状态
                float[] voltageArray = da.GetGeneratorVoltage();

                if (PowerShutDownEvent != null)
                {
                    bool off = false;
                    if (voltageArray[4] > 0.5)
                    {
                        off = true;
                    }
                    PowerShutDownEvent(off);
                }

                bool started1 = voltageArray[0] >= 6.0;
                bool started2 = voltageArray[1] >= 6.0;
                bool started3 = voltageArray[2] >= 6.0;
                //如果电机处于打开状态进行数据采集
                //获取三个电机的关键数据

                if (started1 || started2 || started3)
                {
                    string gsStr = "";
                    gsStr += started1 ? "1" : "0";
                    gsStr += started2 ? "1" : "0";
                    gsStr += started3 ? "1" : "0";

                    if (gsStr != oldGeneratorStatus)
                    {
                        oldGeneratorStatus = gsStr;
                    }

                    AlarmInfo alarmInfo = new AlarmInfo();
                    //设置相关报警值              
                    alarmInfo.FireAlarm = dataAcquisitionMana.judgeFireAlarm(commonData.FireAlarmValue);
                    alarmInfo.BatteryVoltage = commonData.BattaryVoltage;
                    alarmInfo.UpOilPlace = commonData.UpOilPlace;
                    alarmInfo.UpWaterPlace = commonData.UpWaterPlace;

                    int alarmValue1 = 0;
                    int alarmValue2 = 0;
                    int alarmValue3 = 0;
                    DateTime saveNowTime = DateTime.Now;
                    //一号电机数据采集
                    if (started1)
                    {
                        CriticalData cd = dataAcquisitionMana.GetCriticalData(oilMass, 1, alarmInfo.AlarmValue, voltageArray[0], voltageArray[3]);
                        cd.LcNum = Program.g_serialNum;//列车编号
                        cd.Run = true;
                        cd.SaveNowTime = saveNowTime;
                        cd.Isuploadstate = "1";
                        Program.g_criticalDataList[0] = cd;
                        a1++;
                        if (a1 > timesCount)
                        {
                            Program.WriteLog("保存一号电机关键数据");
                            bll.GetCricialDataToDataBase(cd);  //保存数据
                            a1 = 0;
                        }
                        //showCriticalData(cd);

                        //如果具有报警，且报警灯处于停止状态，通知UI报警灯闪烁

                        alarmValue1 = cd.AlarmValue;
                        if (cd.AlarmValue > 0 && !Program.g_isflashed)
                        {
                            Program.WriteLog("报警值为：" + cd.AlarmValue);
                            Program.g_isflashed = true;//标示报警灯已经处于闪烁状态                        
                            da.StartAlarm(); //开始报警                       
                        }
                    }
                    else
                    {
                        Program.WriteLog("一号电机未开机");
                        CriticalData criticalData = new CriticalData(Program.g_serialNum, 1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, DateTime.Now, saveNowTime, false, "1");
                        Program.g_criticalDataList[0] = criticalData;
                        //showCriticalData(criticalData);
                    }
                    //二号电机数据采集
                    if (started2)
                    {
                        CriticalData cd = dataAcquisitionMana.GetCriticalData(oilMass, 2, alarmInfo.AlarmValue, voltageArray[1], voltageArray[3]);
                        cd.LcNum = Program.g_serialNum;//列车编号
                        cd.Run = true;
                        cd.SaveNowTime = saveNowTime;
                        cd.Isuploadstate = "1";
                        Program.g_criticalDataList[1] = cd;
                        a2++;
                        if (a2 > timesCount)
                        {
                            Program.WriteLog("保存二号电机关键数据");
                            bll.GetCricialDataToDataBase(cd);  //保存数据
                            a2 = 0;
                        }
                        //showCriticalData(cd);
                        //如果具有报警，且报警灯处于停止状态，通知UI报警灯闪烁                    
                        alarmValue2 = cd.AlarmValue;
                        if (cd.AlarmValue > 0 && !Program.g_isflashed)
                        {
                            Program.WriteLog("报警值为：" + cd.AlarmValue);
                            Program.g_isflashed = true;//标示报警灯已经处于闪烁状态                        
                            da.StartAlarm(); //开始报警                       
                        }
                    }
                    else
                    {
                        Program.WriteLog("二号电机未开机");
                        Program.g_criticalDataList[1] = new CriticalData(Program.g_serialNum, 1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, DateTime.Now, saveNowTime, false, "1");
                        //showCriticalData(criticalData);
                    }
                    //三号电机数据采集
                    if (started3)
                    {
                        CriticalData cd = dataAcquisitionMana.GetCriticalData(oilMass, 3, alarmInfo.AlarmValue, voltageArray[2], voltageArray[3]);
                        cd.LcNum = Program.g_serialNum;//列车编号
                        cd.Run = true;
                        cd.SaveNowTime = saveNowTime;
                        cd.Isuploadstate = "1";

                        Program.g_criticalDataList[2] = cd;
                        a3++;
                        if (a3 > timesCount)
                        {
                            Program.WriteLog("保存三号电机关键数据");
                            bll.GetCricialDataToDataBase(cd);  //保存数据
                            a3 = 0;
                        }
                        //showCriticalData(cd);
                        //如果具有报警，且报警灯处于停止状态，通知UI报警灯闪烁                     
                        alarmValue2 = cd.AlarmValue;
                        if (cd.AlarmValue > 0 && !Program.g_isflashed)
                        {
                            Program.WriteLog("报警值为：" + cd.AlarmValue);
                            Program.g_isflashed = true;//标示报警灯已经处于闪烁状态                        
                            da.StartAlarm(); //开始报警                       
                        }
                    }
                    else
                    {
                        Program.WriteLog("三号电机未开机");
                        Program.g_criticalDataList[2] = new CriticalData(Program.g_serialNum, 1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, DateTime.Now, saveNowTime, false, "1");
                        //showCriticalData(criticalData);
                    }


                    //将三个电机报警值合并
                    int newAlarmValue = alarmValue1 | alarmValue2 | alarmValue3;
                    //报警值只有15个，确保前16位为0
                    newAlarmValue = (newAlarmValue << 16) >> 16;

                    //CriticalDataHandle(cdList);
                    //如果报警值发生变化发送到服务器
                    if (newAlarmValue != oldAlarmValue)
                    {
                        oldAlarmValue = newAlarmValue;
                        alarm = oldAlarmValue;
                        //comManger.AsyncSendAlarm(newAlarmValue);//mark
                    }

                    ///如果报警清除，关闭报警灯
                    if (newAlarmValue == 0 && Program.g_isflashed)
                    {
                        Program.WriteLog("清除报警值");
                        Program.g_isflashed = false;
                        da.StopAlarm();

                    }

                }
                else
                {
                    for (int i = 1; i < 4; i++)
                    {
                        CriticalData criticalData = new CriticalData(Program.g_serialNum, i, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, DateTime.Now, DateTime.Now, false, "1");
                        //界面显示
                    }

                    if (oldGeneratorStatus != "000")
                    {
                        oldGeneratorStatus = "000";
                    }
                    alarm = oldAlarmValue;
                }

                a4++;
                if (a4 > 15)
                {
                    a4 = 0;
                    //comManger.AsyncSendGs(oldGeneratorStatus, alarm); //向服务器发送数据
                }
            }
            catch (Exception error)
            {
                Program.WriteLog("采集关键数据出错" + error.ToString());
            }
        }
        

        //读取温度
        private void readTemperature()
        {
            if (Program.g_isOpenTempCom)
            {
                Program.WriteLog("读取温度数据");
                Program.g_tempCellsTerminalList = dataAcquisitionMana.DoReadTemp();
                Program.WriteLog(Program.ScriptSerialize(Program.g_tempCellsTerminalList));
            }
        }
    }
}
