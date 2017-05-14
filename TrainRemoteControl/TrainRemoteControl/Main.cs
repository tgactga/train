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

namespace TrainRemoteControl
{
    public partial class Main : Templete
    {
        public Main()
        {
            //this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
        }
        private Image redCircle = TrainRemoteControl.Properties.Resources.circl;// Image.FromFile( @"..\..\image\red.png" );//: @"..\..\image\green.png";
        private Image greenCircle = TrainRemoteControl.Properties.Resources.green;//Image.FromFile(@"..\..\image\green.png");
       
        private int countdown = int.Parse(Program.g_inspectionInterval); //倒计时 时间 3600

       

        private void Main_Load(object sender, EventArgs e)
        {
            Program.WriteLog("==========================>>进入主界面（main）");
            this.labTrainNum.Text = Program.g_lcNumber;
            this.labTrains.Text = Program.g_checi;
            //if (Program.g_isAlarm)
            //{
            //    this.baojing.BackColor = Color.Red;                       
            //}      
            //采集关键数据
            gatherCriticalData();
           
        }

        //采集关键数据
        private void gatherCriticalData()
        {
            try
            {
               DataAcquisitionManager dataAcquisitionMana = new DataAcquisitionManager();
               DataAcquisition da = new DataAcquisition();
               //获取公共数据
               CommonOriginalData commonData = da.GetOriginalCommonData();
              //获取油量值
               float oilMass = (float)((commonData.OilMass - 5.03) * 1525 / 0.726);

               //采集三个电机的电压值，判断是否处于开机状态
               float[] voltageArray = da.GetGeneratorVoltage();

               AlarmInfo alarmInfo = new AlarmInfo();
               //设置相关报警值              
               alarmInfo.FireAlarm = dataAcquisitionMana.judgeFireAlarm(commonData.FireAlarmValue);
               //Console.WriteLine("AlarmValue xxxxxxxxxxxxxx"+commonData.FireAlarmValue.ToString());
               alarmInfo.BatteryVoltage = commonData.BattaryVoltage;
               alarmInfo.UpOilPlace = commonData.UpOilPlace;
               alarmInfo.UpWaterPlace = commonData.UpWaterPlace;
                          
                Model.CriticalData cd = dataAcquisitionMana.GetCriticalData(oilMass, 1, alarmInfo.AlarmValue, voltageArray[1], voltageArray[3]);
                showCriticalData(cd);
            }
            catch (Exception error)
            {
                Program.WriteLog("采集关键数据出错"+error.ToString());

            }
        }
        
     
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
            this.labelCurrenttime.Text = "当前时间：" + DateTime.Now + "";
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
            new MonCenterForm().Show();
            this.Close();
            return;
        }


        //显示关键数据
        private void showCriticalData(Model.CriticalData cd)
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
                        this.label7.Text = cd.Run ? "运行" : "停机";
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
                        this.label8.Text = cd.Run ? "运行" : "停机";
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
                        this.label9.Text = cd.Run ? "运行" : "停机";
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
            this.Close();
            return;


        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            DaHuaNetSDKSample.SingleVideoDisplayForm singleVideo = new DaHuaNetSDKSample.SingleVideoDisplayForm(Program.g_LocalVadioIp, ushort.Parse(Program.g_LocalVadioPort), Program.g_LocalVadioUsername, Program.g_LocalVadioPassword, 0);
            singleVideo.Show();
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            DaHuaNetSDKSample.SingleVideoDisplayForm singleVideo = new DaHuaNetSDKSample.SingleVideoDisplayForm(Program.g_LocalVadioIp, ushort.Parse(Program.g_LocalVadioPort), Program.g_LocalVadioUsername, Program.g_LocalVadioPassword, 1);
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
