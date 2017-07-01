using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TrainRemoteControl.DAl;
using System.Configuration;
using TrainRemoteControl.Model;
using TrainRemoteControl.utilclass;
using TrainRemoteControl.BLL;
using DHNetSDK;
using System.Threading;

namespace TrainRemoteControl
{
    public partial class Main : Templete
    {
        public Main()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
        }
        private Image redCircle = TrainRemoteControl.Properties.Resources.circl;// Image.FromFile( @"..\..\image\red.png" );//: @"..\..\image\green.png";
        private Image greenCircle = TrainRemoteControl.Properties.Resources.green;//Image.FromFile(@"..\..\image\green.png");
       
        private int countdown = int.Parse(Program.g_inspectionInterval); //倒计时 时间 3600

        //public event Action EngineStartEvent;//发动机启动事件
        public event Action<bool> PowerShutDownEvent;//断电事件

        /// <summary>
        /// 设备用户登录ＩＤ
        /// </summary>
        private int pLoginID;         
        /// <summary>
        /// 程序消息提示Title
        /// </summary>
        private const string pMsgTitle = "大华网络SDK Demo程序";
        /// <summary>
        /// 最后操作信息显示格式
        /// </summary>
        private const string pErrInfoFormatStyle = "代码:errcode;\n描述:errmSG.";
        /// <summary>
        /// 当前回放的文件信息
        /// </summary>
        //NET_RECORDFILE_INFO fileInfo;
        /// <summary>
        /// 播放方式
        /// </summary>
        //private int playBy = 0;
        /// <summary>
        /// 实时播放句柄保存
        /// </summary>
        private int[] pRealPlayHandle;
        /// <summary>
        /// 回放句柄保存
        /// </summary>
        private int[] pPlayBackHandle;
        /// <summary>
        /// 回放通道号
        /// </summary>
        //private int pPlayBackChannelID;
        /// <summary>
        /// 上次点击的PictureBox控件
        /// </summary>
        //private PictureBox oldPicRealPlay;
        /// <summary>
        /// 当前点击的PictureBox控件
        /// </summary>
        //private PictureBox picRealPlay;
        private fDisConnect disConnect;
        private NET_DEVICEINFO deviceInfo;
        DataAcquisitionManager dataAcquisitionMana = new DataAcquisitionManager();
        DataAcquisition da = new DataAcquisition();
        private void Main_Load(object sender, EventArgs e)
        {
            Program.WriteLog("==========================>>进入主界面（main）");
            this.Top = 80;
            this.Left = 0;
            this.labTrainNum.Text = Program.g_lcNumber;
            this.labTrains.Text = Program.g_checi;
            //if (Program.g_isAlarm)
            //{
            //    this.baojing.BackColor = Color.Red;                       
            //}              
            //实时视频
            RealPlay();           
        }
        //定时采集关键数据
        private void timer_gatherCritical_Tick(object sender, EventArgs e)
        {
           // timer_gatherCritical.Enabled = false;
            //显示关键数据
            showCriticalData(Program.g_criticalDataList[0]);
            showCriticalData(Program.g_criticalDataList[1]);
            showCriticalData(Program.g_criticalDataList[2]);
        }

        /// <summary>
        /// 设备断开连接处理
        /// </summary>
        /// <param name="lLoginID"></param>
        /// <param name="pchDVRIP"></param>
        /// <param name="nDVRPort"></param>
        /// <param name="dwUser"></param>
        private void DisConnectEvent(int lLoginID, StringBuilder pchDVRIP, int nDVRPort, IntPtr dwUser)
        {
            try
            {
                for (int i = 0; i < deviceInfo.byChanNum; i++)
                {
                    DHClient.DHStopRealPlay(pRealPlayHandle[i]);
                }
                DHClient.DHLogout(pLoginID);
                //pLoginID
                pLoginID = 0;
                while (pLoginID == 0)
                {
                    Thread.Sleep(1000);
                    RealPlay();
                }
                //MessageBox.Show("设备用户断开连接", pMsgTitle);
            }
            catch (Exception ex)
            {
                Program.WriteLog("视频设备断开连接处理异常" + ex.ToString());
            }
        }

        //摄像头视频显示
        private void RealPlay()
        {
            disConnect = new fDisConnect(DisConnectEvent);
            DHClient.DHInit(disConnect, IntPtr.Zero);
            DHClient.DHSetEncoding(LANGUAGE_ENCODING.gb2312);//字符编码格式设置，默认为gb2312字符编码，如果为其他字符编码请设置            
            pRealPlayHandle = null;
            deviceInfo = new NET_DEVICEINFO();
            int error = 0;
            pLoginID = DHClient.DHLogin(Program.g_localVedioIp, ushort.Parse(Program.g_localVedioPort), Program.g_localVadioUsername, Program.g_localVadioPassword, out deviceInfo, out error);
            if (pLoginID != 0)
            {
                pPlayBackHandle = new int[deviceInfo.byChanNum];
                //画面按钮有效性控制
                pRealPlayHandle = null;
                pRealPlayHandle = new int[deviceInfo.byChanNum];

                for (int i = 0; i < deviceInfo.byChanNum; i++)
                {
                    switch (i)
                    {
                        case 0://通道0的实时监视
                            pictureBox17.Invoke((MethodInvoker)delegate
                            {
                                pRealPlayHandle[i] = DHClient.DHRealPlay(pLoginID, i, pictureBox17.Handle);
                            });
                            break;
                        case 1://通道1的实时监视
                            pictureBox18.Invoke((MethodInvoker)delegate
                            {
                                pRealPlayHandle[i] = DHClient.DHRealPlay(pLoginID, i, pictureBox18.Handle);
                            });
                            break;
                        case 2://通道2的实时监视
                            pictureBox19.Invoke((MethodInvoker)delegate
                            {
                                pRealPlayHandle[i] = DHClient.DHRealPlay(pLoginID, i, pictureBox19.Handle);
                            });
                            break;
                        case 3://通道3的实时监视
                            pictureBox20.Invoke((MethodInvoker)delegate
                            {
                                pRealPlayHandle[i] = DHClient.DHRealPlay(pLoginID, i, pictureBox20.Handle);
                            });
                            break;
                        case 4://通道4的实时监视
                            pictureBox21.Invoke((MethodInvoker)delegate
                            {
                                pRealPlayHandle[i] = DHClient.DHRealPlay(pLoginID, i, pictureBox21.Handle);
                            });
                            break;
                    }
                }
            }
        }
        int a1 = 0;
        int a2 = 0;
        int a3 = 0;
        int a4 = 0; //发送电机状态计数
        int timesCount = 30; //标示30s上传一次关键数据
        CriticalDataBLL bll = new CriticalDataBLL();
        //采集关键数据
        //private void gatherCriticalData()
        //{
        //    //初始化报警值
        //    int oldAlarmValue = 0;
        //    int alarm = 0;
        //    //初始化电机状态
        //    string oldGeneratorStatus = "";//其实int或者byte最好
        //    try
        //    {
        //       //DataAcquisitionManager dataAcquisitionMana = new DataAcquisitionManager();
        //       //DataAcquisition da = new DataAcquisition();
        //       //获取公共数据
        //       CommonOriginalData commonData = da.GetOriginalCommonData();
        //      //获取油量值
        //       float oilMass = (float)((commonData.OilMass - 5.03) * 1525 / 0.726);

        //       //采集三个电机的电压值，判断是否处于开机状态
        //       float[] voltageArray = da.GetGeneratorVoltage();

        //       if (PowerShutDownEvent != null)
        //       {
        //           bool off = false;
        //           if (voltageArray[4] > 0.5)
        //           {
        //               off = true;
        //           }
        //           PowerShutDownEvent(off);
        //       }

        //       bool started1 = voltageArray[0] >= 6.0;
        //       bool started2 = voltageArray[1] >= 6.0;
        //       bool started3 = voltageArray[2] >= 6.0;
        //       //如果电机处于打开状态进行数据采集
        //         //获取三个电机的关键数据
                
        //       if (started1 || started2 || started3)
        //       {
        //           string gsStr = "";
        //           gsStr += started1 ? "1" : "0";
        //           gsStr += started2 ? "1" : "0";
        //           gsStr += started3 ? "1" : "0";

        //           if (gsStr != oldGeneratorStatus)
        //           {
        //               oldGeneratorStatus = gsStr;
        //           }

        //           AlarmInfo alarmInfo = new AlarmInfo();
        //           //设置相关报警值              
        //           alarmInfo.FireAlarm = dataAcquisitionMana.judgeFireAlarm(commonData.FireAlarmValue);                 
        //           alarmInfo.BatteryVoltage = commonData.BattaryVoltage;
        //           alarmInfo.UpOilPlace = commonData.UpOilPlace;
        //           alarmInfo.UpWaterPlace = commonData.UpWaterPlace;

        //           int alarmValue1 = 0;
        //           int alarmValue2 = 0;
        //           int alarmValue3 = 0;
        //           DateTime saveNowTime = DateTime.Now;
        //           //一号电机数据采集
        //           if (started1)
        //           {
        //               CriticalData cd = dataAcquisitionMana.GetCriticalData(oilMass, 1, alarmInfo.AlarmValue, voltageArray[0], voltageArray[3]);
        //               cd.LcNum = Program.g_serialNum;//列车编号
        //               cd.Run = true;
        //               cd.SaveNowTime = saveNowTime;
        //               cd.Isuploadstate = "1";
        //               a1++;
        //               if (a1 > timesCount)
        //               {
        //                   Program.WriteLog("保存一号电机关键数据");
        //                   bll.GetCricialDataToDataBase(cd);  //保存数据
        //                   a1 = 0;
        //               }
        //               showCriticalData(cd);

        //               //如果具有报警，且报警灯处于停止状态，通知UI报警灯闪烁
                       
        //               alarmValue1 = cd.AlarmValue;
        //               if (cd.AlarmValue > 0 && !Program.g_isflashed)
        //               {
        //                   Program.WriteLog("报警值为：" + cd.AlarmValue);
        //                   Program.g_isflashed = true;//标示报警灯已经处于闪烁状态                        
        //                   da.StartAlarm(); //开始报警                       
        //               }
        //           }
        //           else
        //           {
        //               Program.WriteLog("一号电机未开机");
        //               CriticalData criticalData = new CriticalData(Program.g_serialNum, 1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, DateTime.Now,saveNowTime, false,"1");
        //               showCriticalData(criticalData);
        //           }
        //           //二号电机数据采集
        //           if (started2)
        //           {
        //               CriticalData cd = dataAcquisitionMana.GetCriticalData(oilMass, 2, alarmInfo.AlarmValue, voltageArray[1], voltageArray[3]);
        //               cd.LcNum = Program.g_serialNum;//列车编号
        //               cd.Run = true;
        //               cd.SaveNowTime = saveNowTime;
        //               cd.Isuploadstate = "1";
        //               a2++;
        //               if (a2 > timesCount)
        //               {
        //                   Program.WriteLog("保存二号电机关键数据");
        //                   bll.GetCricialDataToDataBase(cd);  //保存数据
        //                   a2 = 0;
        //               }
        //               showCriticalData(cd);
        //               //如果具有报警，且报警灯处于停止状态，通知UI报警灯闪烁                    
        //               alarmValue2 = cd.AlarmValue;
        //               if (cd.AlarmValue > 0 && !Program.g_isflashed)
        //               {
        //                   Program.WriteLog("报警值为：" + cd.AlarmValue);
        //                   Program.g_isflashed = true;//标示报警灯已经处于闪烁状态                        
        //                   da.StartAlarm(); //开始报警                       
        //               }
        //           }
        //           else
        //           {
        //               Program.WriteLog("二号电机未开机");
        //               CriticalData criticalData = new CriticalData(Program.g_serialNum, 1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, DateTime.Now, saveNowTime, false,"1");
        //               showCriticalData(criticalData);
        //           }
        //           //三号电机数据采集
        //           if (started3)
        //           {
        //               CriticalData cd = dataAcquisitionMana.GetCriticalData(oilMass, 3, alarmInfo.AlarmValue, voltageArray[2], voltageArray[3]);
        //               cd.LcNum = Program.g_serialNum;//列车编号
        //               cd.Run = true;
        //               cd.SaveNowTime = saveNowTime;
        //               cd.Isuploadstate = "1";
        //               a3++;
        //               if (a3 > timesCount)
        //               {
        //                   Program.WriteLog("保存三号电机关键数据");
        //                   bll.GetCricialDataToDataBase(cd);  //保存数据
        //                   a3 = 0;
        //               }
        //               showCriticalData(cd);
        //               //如果具有报警，且报警灯处于停止状态，通知UI报警灯闪烁                     
        //               alarmValue2 = cd.AlarmValue;
        //               if (cd.AlarmValue > 0 && !Program.g_isflashed)
        //               {
        //                   Program.WriteLog("报警值为：" + cd.AlarmValue);
        //                   Program.g_isflashed = true;//标示报警灯已经处于闪烁状态                        
        //                   da.StartAlarm(); //开始报警                       
        //               }
        //           }
        //           else
        //           {
        //               Program.WriteLog("三号电机未开机");
        //               CriticalData criticalData = new CriticalData(Program.g_serialNum, 1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, DateTime.Now, saveNowTime, false, "1");
        //               showCriticalData(criticalData);
        //           }


        //           //将三个电机报警值合并
        //           int newAlarmValue = alarmValue1 | alarmValue2 | alarmValue3;
        //           //报警值只有15个，确保前16位为0
        //           newAlarmValue = (newAlarmValue << 16) >> 16;

        //           //CriticalDataHandle(cdList);
        //           //如果报警值发生变化发送到服务器
        //           if (newAlarmValue != oldAlarmValue)
        //           {
        //               oldAlarmValue = newAlarmValue;
        //               alarm = oldAlarmValue;
        //               //comManger.AsyncSendAlarm(newAlarmValue);//mark
        //           }

        //           ///如果报警清除，关闭报警灯
        //           if (newAlarmValue == 0 && Program.g_isflashed)
        //           {
        //               Program.WriteLog("清除报警值");
        //               Program.g_isflashed = false;
        //               da.StopAlarm();

        //           }

        //       }
        //       else
        //       {
        //           for (int i = 1; i < 4; i++)
        //           {
        //               CriticalData criticalData = new CriticalData(Program.g_serialNum, i, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, DateTime.Now, DateTime.Now, false, "1");
        //                //界面显示
        //           }

        //           if (oldGeneratorStatus != "000")
        //           {
        //               oldGeneratorStatus = "000";
        //           }
        //           alarm = oldAlarmValue;
        //       }

        //       a4++; 
        //       if (a4 > 15)
        //       {
        //           a4 = 0;
        //           //comManger.AsyncSendGs(oldGeneratorStatus, alarm); //向服务器发送数据
        //       }              
        //    }
        //    catch (Exception error)
        //    {
        //        Program.WriteLog("采集关键数据出错"+error.ToString());
        //    }
        //}
        
        private void buttonOfdatadb_Click(object sender, EventArgs e)
        {
            new DataPageForm().Show();
            this.Close();
            return;
        }

        private void buttonOfxunjian_Click(object sender, EventArgs e)
        {
            new XunjianForm().Show();
            this.Close();
            return;
        }

        private void buttonOfhomepage_Click(object sender, EventArgs e)
        {
             
        }

        //巡检倒计时 定时器
        private void timer_coundown_Tick(object sender, EventArgs e)
        {
            //this.labelCurrenttime.Text = "当前时间：" + DateTime.Now + "";
            if (countdown != 0)
            {
                countdown = countdown - 1;
                //int m = countdown / 60000 + (countdown % 60000 > 0 ? 1 : 0);

                this.labelnextxuanjiantime.Invoke((MethodInvoker)delegate
                {
                    this.labelnextxuanjiantime.Text = "离下一次巡检时间：" + (countdown / 60).ToString() + "分钟" + (countdown % 60).ToString() + "秒";
                });
            }
            else
            {
                Program.WriteLog("巡检时间到");
                //调用声音提示，并弹出巡检提示对话框  一段时间后自动消失
                if (!Program.g_isInspected)
                {
                    //new InspectTipsForm().Show();
                    //return;
                }

                countdown = int.Parse(Program.g_inspectionInterval); //倒计时 时间
            }

            //网络状态：
            string netstate = "";
            if (Program.g_isNetState)
            {                
                netstate = "正常";
            }
            else
            {
                netstate = "异常";
            }
            this.netlabel.Text = "网络状态："+netstate;
             
        }

        //确认巡检
        private void button1_Click(object sender, EventArgs e)
        {
            //修改巡检状态
            Program.g_isInspected = true;

            Model._XJmodel inspectionRecord = new Model._XJmodel();
            inspectionRecord.getStatus = "正常";
            inspectionRecord.getRecordTime = DateTime.Now;
            inspectionRecord.getContent = "备注";
            inspectionRecord.getBjtime = DateTime.Now;
            inspectionRecord.getWorker = "张三丰";
            inspectionRecord.lcNumber = "T401";
            InspectionRecordDAL inspect = new InspectionRecordDAL();
            inspect.SaveInspectionRecord(inspectionRecord);
            
            //巡检完后修改状态

        }

        //点击确认报警
        private void baojing_Click(object sender, EventArgs e)
        {
            if (Program.g_isAlarm)
            {
                Program.WriteLog("点击了报警确认");
                //记录报警事件
                Model._XJmodel inspectionRecord = new Model._XJmodel();
                inspectionRecord.getStatus = "异常";
                inspectionRecord.getRecordTime = DateTime.Now;
                inspectionRecord.getContent = "确认报警";
                inspectionRecord.getBjtime = DateTime.Now;
                inspectionRecord.getWorker = "张三丰";
                inspectionRecord.lcNumber = "T401";
                InspectionRecordDAL inspect = new InspectionRecordDAL();
                inspect.SaveInspectionRecord(inspectionRecord);
                //上传报警数据
                //WebServiceUtil.uploadAlarmRecords(inspectionRecord);

                Program.g_isAlarm = false;
            }
        }

        //点击 端子温度
        private void btnTerminalTemp_Click(object sender, EventArgs e)
        {
            //new MonCenterForm().Show();
            new TerminalTemperaturex().Show();
            this.Close();
            return;
        }


        //显示关键数据
        private void showCriticalData( CriticalData  cd )
        {
            //if (obj.ToString() == "x3")
            //{
            //    MessageBox.Show(obj.ToString());
            //}
            //else
            //{
                //Model.CriticalData cd = (CriticalData)obj;

                Model.AlarmInfo alarmInfo = new AlarmInfo(cd.AlarmValue, cd.LcNum);

                try
                {
                    this.labTopOilMass.Text = alarmInfo.UpOilPlace ? "异常" : "正常";
                    this.labWaterTankLevel.Text = alarmInfo.UpWaterPlace ? "异常" : "正常";
                    this.labCellVoltage.Text = alarmInfo.BatteryVoltage ? "异常" : "正常";
                    this.labFireworks.Text = alarmInfo.FireAlarm ? "异常" : "正常";
                    this.pictureBox1.Image = alarmInfo.UpOilPlace ? redCircle : greenCircle;
                    this.pictureBox2.Image = alarmInfo.UpWaterPlace ? redCircle : greenCircle;
                    this.pictureBox3.Image = alarmInfo.BatteryVoltage ? redCircle : greenCircle;
                    this.pictureBox4.Image = alarmInfo.FireAlarm ? redCircle : greenCircle;
                    if (cd.GeneratorId == 1)
                    {
                        this.label14.Text = cd.Frequency == -1 ? "——" : cd.Frequency.ToString("0.00");
                        label16.Text = cd.OilPress == -1 ? "——" : cd.OilPress.ToString("0.00");
                        label18.Text = cd.PowerFactor == -1 ? "——" : cd.PowerFactor.ToString("0.00");
                        label20.Text = cd.WaterTemp == -1 ? "——" : cd.WaterTemp.ToString("0.00");
                        label22.Text = cd.MotorSpeed == -1 ? "——" : cd.MotorSpeed.ToString("0.00");
                        label24.Text = cd.MotorPower == -1 ? "——" : cd.MotorPower.ToString("0.00");
                        label28.Text = cd._Current == -1 ? "——" : cd._Current.ToString("0.00");
                        label30.Text = cd.Frequency == -1 ? "——" : alarmInfo.OilLeak1 ? "报警" : "正常";
                        label26.Text = cd.Voltage == -1 ? "——" : cd.Voltage.ToString();
                        this.pictureBox22.Image = cd.Run ? greenCircle : redCircle;
                        this.label48.Text = cd.Run ? "运行" : "停机";
                        this.pictureBox5.Image = alarmInfo.AlarmOP1 ? redCircle : greenCircle;
                        this.pictureBox6.Image = alarmInfo.AlarmWT1 ? redCircle : greenCircle;
                        this.pictureBox7.Image = alarmInfo.AlarmMS1 ? redCircle : greenCircle;
                        this.pictureBox8.Image = alarmInfo.OilLeak1 ? redCircle : greenCircle;
                    }

                    if (cd.GeneratorId == 2)
                    {
                        this.label40.Text = cd.Frequency == -1 ? "——" : cd.Frequency.ToString("0.00");
                        label39.Text = cd.OilPress == -1 ? "——" : cd.OilPress.ToString("0.00");
                        label38.Text = cd.PowerFactor == -1 ? "——" : cd.PowerFactor.ToString("0.00");
                        label37.Text = cd.WaterTemp == -1 ? "——" : cd.WaterTemp.ToString("0.00");
                        label36.Text = cd.MotorSpeed == -1 ? "——" : cd.MotorSpeed.ToString("0.00");
                        label34.Text = cd.MotorPower == -1 ? "——" : cd.MotorPower.ToString("0.00");
                        label12.Text = cd._Current == -1 ? "——" : cd._Current.ToString("0.00");
                        label11.Text = cd.Frequency == -1 ? "——" : alarmInfo.OilLeak1 ? "报警" : "正常";
                        label32.Text = cd.Voltage == -1 ? "——" : cd.Voltage.ToString();
                        this.pictureBox23.Image = cd.Run ? greenCircle : redCircle;
                        this.label13.Text = cd.Run ? "运行" : "停机";
                        this.pictureBox12.Image = alarmInfo.AlarmOP2 ? redCircle : greenCircle;
                        this.pictureBox9.Image = alarmInfo.AlarmWT2 ? redCircle : greenCircle;
                        this.pictureBox10.Image = alarmInfo.AlarmMS2 ? redCircle : greenCircle;
                        this.pictureBox11.Image = alarmInfo.OilLeak2 ? redCircle : greenCircle;
                    }

                    if (cd.GeneratorId == 3)
                    {
                        this.label60.Text = cd.Frequency == -1 ? "——" : cd.Frequency.ToString("0.00");
                        label59.Text = cd.OilPress == -1 ? "——" : cd.OilPress.ToString("0.00");
                        label58.Text = cd.PowerFactor == -1 ? "——" : cd.PowerFactor.ToString("0.00");
                        label57.Text = cd.WaterTemp == -1 ? "——" : cd.WaterTemp.ToString("0.00");
                        label56.Text = cd.MotorSpeed == -1 ? "——" : cd.MotorSpeed.ToString("0.00");
                        label54.Text = cd.MotorPower == -1 ? "——" : cd.MotorPower.ToString("0.00");
                        label50.Text = cd._Current == -1 ? "——" : cd._Current.ToString("0.00");
                        label49.Text = cd.Frequency == -1 ? "——" : alarmInfo.OilLeak1 ? "报警" : "正常";
                        label52.Text = cd.Voltage == -1 ? "——" : cd.Voltage.ToString();
                        this.pictureBox24.Image = cd.Run ? greenCircle : redCircle;
                       
                        this.label10.Text = cd.Run ? "运行" : "停机";
                        this.pictureBox16.Image = alarmInfo.AlarmOP3 ? redCircle : greenCircle;
                        this.pictureBox13.Image = alarmInfo.AlarmWT3 ? redCircle : greenCircle;
                        this.pictureBox14.Image = alarmInfo.AlarmMS3 ? redCircle : greenCircle;
                        this.pictureBox15.Image = alarmInfo.OilLeak3 ? redCircle : greenCircle;
                    }
                }
                catch
                {
                    return;
                }
            //}
        }








        //隐藏按钮
        private void label2_Click(object sender, EventArgs e)
        {
            new InputPassWordForm().Show();
           
            return;


        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            DaHuaNetSDKSample.SingleVideoDisplayForm singleVideo = new DaHuaNetSDKSample.SingleVideoDisplayForm(Program.g_localVedioIp, ushort.Parse(Program.g_localVedioPort), Program.g_localVadioUsername, Program.g_localVadioPassword, 0);
            singleVideo.Show();
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            DaHuaNetSDKSample.SingleVideoDisplayForm singleVideo = new DaHuaNetSDKSample.SingleVideoDisplayForm(Program.g_localVedioIp, ushort.Parse(Program.g_localVedioPort), Program.g_localVadioUsername, Program.g_localVadioPassword, 1);
            singleVideo.Show();

        }

        //测试报警页面
        private void labelbaojingtest_Click(object sender, EventArgs e)
        {
            new AlarmForm().Show();
            return;

        }

       

      

        
    }
}
