using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Text;
using System.Reflection;
using TrainRemoteControl.BLL;
using TrainRemoteControl.utilclass;
using TrainRemoteControl.TCP;
using TrainRemoteControl.Model;

namespace TrainRemoteControl
{
    public delegate void UpBaojingDelegete();
    public partial class MDIParent1 : Form
    {        
        public static UpBaojingDelegete baojingDelegate;
        private int childFormNumber = 0;

        TCPServiceUtil tcputil = new TCPServiceUtil();
        BuildMsgUtil buildMsg = new BuildMsgUtil();

        public MDIParent1()
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        public const int WM_SYSCOMMAND = 0x112;
        public const int SC_MOVE = 0xF012;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SYSCOMMAND)
            {
                if ((int)m.WParam == SC_MOVE)
                    return;
            }

            base.WndProc(ref m);
        } 

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "窗口 " + childFormNumber++;
            childForm.Show();
        }

        //private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}
        //private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    LayoutMdi(MdiLayout.Cascade);
        //}

        //private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    LayoutMdi(MdiLayout.TileVertical);
        //}

        //private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    LayoutMdi(MdiLayout.TileHorizontal);
        //}

        //private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    LayoutMdi(MdiLayout.ArrangeIcons);
        //}

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {       

            tcputil.InitalSevice(); //注册tcp连接

            Form fo2 = FindMdiChildren("TerminalTemperaturex");
            if (fo2 != null)
            {
                fo2.Show();
            }
            else
            {
                fo2 = new TerminalTemperaturex();
                fo2.MdiParent = this;
                fo2.Show();
            }
            fo2.Activate();

            Form fo = FindMdiChildren("Main");
            if (fo != null)
            {
                fo.Show();
            }
            else
            {
                fo = new Main();
                fo.MdiParent = this;
                fo.Show();
            }
            fo.Activate();

            this.FormClosed += new FormClosedEventHandler(MDIParent1_FormClosed);

            System.Timers.Timer t = new System.Timers.Timer();
            t.Elapsed += new System.Timers.ElapsedEventHandler(t_Elapsed);
            t.Interval = 1000 * Convert.ToInt16(2);
            t.Enabled = true;
             
        }

         //检测网络状态  报到 
        void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //加锁检查数据库和发送MSMQ
            lock (this)
            {
                Program.WriteLog("报到");
                tcputil.SendMsg2Server(1, Program.g_serialNum);  //2s 报到一次    
            }
        }

        public void MDIParent1_FormClosed(object sender, EventArgs e)
        {

        }
        int hour = -1;
        
        //点击巡检记录
        private void button1_Click_1(object sender, EventArgs e)
        {
            Form fo = FindMdiChildren("XunjianForm");
            if (fo != null)
            {
                fo.Show();
            }
            else
            {
                fo = new XunjianForm();
                fo.MdiParent = this;
                fo.Show();
            }
            fo.Activate();
        }

         
        /// <summary>
        /// 根据窗体名获取相应窗体对象
        /// </summary>
        /// <param name="name">string</param>
        /// <returns>Form</returns>
        public Form FindMdiChildren(string name)
        {
            Form fo = null;
            foreach (Form item in this.MdiChildren)
            {
                if (item.Name == name)
                {
                    fo = item;
                    break;
                }

            }
            return fo;
        }
        private void label1_Click(object sender, EventArgs e)
        {

            Form fo = FindMdiChildren("Main");
            if (fo != null)
            {
                fo.Show();
            }
            else
            {
                fo = new Main();
                fo.MdiParent = this;
                fo.Show();
            }
            fo.Activate();
        }

        private void btnTerminalTemp_Click(object sender, EventArgs e)
        {
            Form fo = FindMdiChildren("TerminalTemperaturex");
            if (fo != null)
            {
                fo.Show();
            }
            else
            {
                fo = new TerminalTemperaturex();
                fo.MdiParent = this;
                fo.Show();
            }
            fo.Activate();
        }  
 
  
        //点击数据库
        private void button4_Click(object sender, EventArgs e)
        {
            Form fo = FindMdiChildren("DataPageForm");
            if (fo != null)
            {
                fo.Show();
            }
            else
            {
                fo = new DataPageForm();
                fo.MdiParent = this;
                fo.Show();
            }
            fo.Activate();
        }

        #region 内存回收
        [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
        public static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
        /// <summary>
        /// 释放内存
        /// </summary>
        public static void ClearMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }
        #endregion

        private void MDIParent1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //hook.UninstallKeyBoardHook();                
            }
            catch (System.Exception ex)
            {
                //Utility.FileOperation.WriteLog("[Hook][" + DateTime.Now.ToString() + "]   " + ex.Message + "。Hook关闭错误");              
            }
        }

        //设置界面
        private void labelpsw_Click(object sender, EventArgs e)
        {
            Form fo = FindMdiChildren("InputPassWordForm");
            if (fo != null)
            {
                fo.Show();
            }
            else
            {
                fo = new InputPassWordForm();
                fo.MdiParent = this;
                fo.Show();
            }
            fo.Activate();
            
        }

        int uploadTimeCount = 0;
        int readtempTimeCount = 0;
        //定时采集数据，读取温度，上传数据
        private void gatherAndReadData_timer_Tick(object sender, EventArgs e)
        {
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

            if (uploadTimeCount == 8)   //4s上传关键数据
            {
                uploadTimeCount = 0;
                if (Program.g_isNetState)
                {
                    Program.WriteLog(" TCP通信，上传关键数据");
                    string upStr = new BuildMsgUtil().buildUploadCriticalData(Program.g_criticalDataList);
                    tcputil.SendMsg2Server(2, upStr);
                    Program.WriteLog(" 上传关键数据调用成功");

                    //Program.WriteLog(" TCP通信，上传温度数据");
                    //string uptempStr = new BuildMsgUtil().buildUploadTemperatureData(Program.g_tempCellsTerminalList);
                    //tcputil.SendMsg2Server(3, uptempStr);
                    //Program.WriteLog(" 上传温度数据调用成功");
                }

            }

        }

        private DateTime planTime; //巡检计划时间
        //检测是否按下巡检按钮  
        private void xunjian_timer_Tick(object sender, EventArgs e)
        {
            dataAcquisitionMana.StartListenBtnStatus(); //开始监听按钮
            //判断巡检按钮是否按下
            dataAcquisitionMana.PressButtonEvent += new Action(() =>
            {
                Program.WriteLog("按下巡检按钮");
                //设置本次巡检时间
                Program.g_inspectionRecord.getRecordTime = DateTime.Now;
                //判断是否晚检
                Program.g_inspectionRecord.getStatus = Program.g_inspectionRecord.getRecordTime.Value.Subtract(planTime).TotalMilliseconds > int.Parse(Program.g_laterInterval) ? "晚检" : "已检";

                Program.g_isInspected = true;

                Thread.Sleep(2000);
            });

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
                            //Type t = typeof(CriticalData);
                            //System.Reflection.PropertyInfo[] properties = t.GetProperties();

                            //foreach (System.Reflection.PropertyInfo info in properties)
                            //{
                            //    Program.WriteLog("name=" + info.Name + ";" + "type=" + info.PropertyType.Name + ";value=" + Program.ini.GetObjectPropertyValue<CriticalData>(cd, info.Name) + "<br />");
                            //}
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
                        //bll.GetCricialDataToDataBase(criticalData);  //保存数据
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
