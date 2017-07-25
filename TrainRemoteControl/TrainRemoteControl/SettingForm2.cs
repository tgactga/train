using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using TrainRemoteControl.utilclass;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Net;

namespace TrainRemoteControl
{
    public partial class SettingForm2 : Templete
    {
        [DllImport("User32.dll", EntryPoint = "FindWindow", CharSet = CharSet.Auto)]
        public static extern int FindWindow(String className, String captionName);
        [DllImport("User32.dll", EntryPoint = "ShowWindow", CharSet = CharSet.Auto)]
        public static extern int ShowWindow(int hwnd, int nCmdShow);

        public SettingForm2()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            this.Size = new Size(808, 715);
        }

        private void SettingForm2_Load(object sender, EventArgs e)
        {
            Program.WriteLog("==========================>>进入设置窗口页面（SettingForm2）");

            this.txtDeadline.Text = Program.g_deadline;
            this.txtDeadline.Tag = Program.g_deadline;
            this.txtInspectionInterval.Text = Program.g_inspectionInterval;
            this.txtInspectionInterval.Tag = Program.g_inspectionInterval;
            this.txtLocalListenPort.Text = Program.g_localListenPort;
            this.txtLocalListenPort.Tag = Program.g_localListenPort;
            this.txtPwd.Text = Program.g_localVadioPassword;
            this.txtPwd.Tag = Program.g_localVadioPassword;
            this.txtSerialNum.Text = Program.g_serialNum;
            this.txtSerialNum.Tag = Program.g_serialNum;
            this.txtTrain.Text = Program.g_train;
            this.txtTrain.Tag = Program.g_train;
            this.txtUserName.Text = Program.g_localVadioUsername;
            this.txtUserName.Tag = Program.g_localVadioUsername;
            this.txtVcrIP.Text = Program.g_localVedioIp;
            this.txtVcrIP.Tag = Program.g_localVedioIp;
            this.txtWebServiceUrl.Text = Program.g_url;
            this.txtWebServiceUrl.Tag = Program.g_url;
            this.txtVcrTcpPort.Text = Program.g_localVedioPort;
            this.txtVcrTcpPort.Tag = Program.g_localVedioPort;
            this.txtConStr.Text = Program.g_connString;
            this.txtConStr.Tag = Program.g_connString;
            this.cmbComPort.Text = Program.g_comPort;
            this.cmbComPort.Tag = Program.g_comPort;

            this.WaterFormula1_textBox.Text = Program.g_waterFormula1;
            this.WaterFormula2_textBox.Text = Program.g_waterFormula2;
            this.WaterFormula3_textBox.Text = Program.g_waterFormula3;
            this.WaterFormula1_textBox.Tag = Program.g_waterFormula1;
            this.WaterFormula2_textBox.Tag = Program.g_waterFormula2;
            this.WaterFormula3_textBox.Tag = Program.g_waterFormula3;

            this.OilFormula1_textBox.Text = Program.g_oilFormula1;
            this.OilFormula2_textBox.Text = Program.g_oilFormula2;
            this.OilFormula3_textBox.Text = Program.g_oilFormula3;
            this.OilFormula1_textBox.Tag = Program.g_oilFormula1;
            this.OilFormula2_textBox.Tag = Program.g_oilFormula2;
            this.OilFormula3_textBox.Tag = Program.g_oilFormula3;

            this.waterAlarm1textBox.Text = Program.g_waterAlarm1Value;
            this.waterAlarm1textBox.Tag = Program.g_waterAlarm1Value;

        }

        //验证用户输入
        private bool Check()
        {
            return true;
        }

        /// <summary>
        /// 更新配置文件
        /// </summary>
        private void UpdateConfig()
        {
            INIClass ini = new INIClass("D://train//train.ini");
            ini.IniWriteValue("TermInfo", "deadline", this.txtDeadline.Text);
            ini.IniWriteValue("TermInfo", "inspectionInterval", this.txtInspectionInterval.Text);
            ini.IniWriteValue("TermInfo", "localListenPort", this.txtLocalListenPort.Text);
            ini.IniWriteValue("TermInfo", "localVedioPwd", this.txtUserName.Text);
            ini.IniWriteValue("TermInfo", "serialNum", this.txtSerialNum.Text);
            ini.IniWriteValue("TermInfo", "train", this.txtTrain.Text);
            ini.IniWriteValue("TermInfo", "localVedioUserName", this.txtUserName.Text);
            ini.IniWriteValue("TermInfo", "localVedioIp", this.txtVcrIP.Text);
            ini.IniWriteValue("TermInfo", "url", this.txtWebServiceUrl.Text);
            ini.IniWriteValue("TermInfo", "localVedioPort", this.txtVcrTcpPort.Text);
            ini.IniWriteValue("TermInfo", "connStringKey", this.txtConStr.Text);
            ini.IniWriteValue("TermInfo", "comPort", this.cmbComPort.Text);

            ini.IniWriteValue("TermInfo", "WaterFormula1 ", this.WaterFormula1_textBox.Text);
            ini.IniWriteValue("TermInfo", "WaterFormula2 ", this.WaterFormula2_textBox.Text);
            ini.IniWriteValue("TermInfo", "WaterFormula3 ", this.WaterFormula3_textBox.Text);
            ini.IniWriteValue("TermInfo", "OilFormula1", this.OilFormula1_textBox.Text);
            ini.IniWriteValue("TermInfo", "OilFormula2", this.OilFormula2_textBox.Text);
            ini.IniWriteValue("TermInfo", "OilFormula3", this.OilFormula3_textBox.Text);

            ini.IniWriteValue("TermInfo", "waterAlarm1Value", this.waterAlarm1textBox.Text);
            
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                UpdateConfig();
            }
            else
            {
                return;
            }
            DialogResult dialogResult = MessageBox.Show("设置更改成功，重启软件生效,是否重启？", "提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                //关闭本软件
                Application.Exit();
                //采用前台线程重启本软件
                Thread thread = new Thread(() =>
                {
                    //清理互斥元
                    bool createdNew = false;
                    Mutex mutex = new Mutex(true, "RemoteControl", out createdNew);
                    mutex.Dispose();
                    //重启软件
                    Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
                });
                thread.Start();

            }
            else
            {
                this.Close();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.txtSerialNum.Text = this.txtSerialNum.Tag.ToString();
            this.txtTrain.Text = this.txtTrain.Tag.ToString();
            this.txtLocalListenPort.Text = this.txtLocalListenPort.Tag.ToString();
            this.txtWebServiceUrl.Text = this.txtWebServiceUrl.Tag.ToString();
            this.txtInspectionInterval.Text = this.txtInspectionInterval.Tag.ToString();
            this.txtDeadline.Text = this.txtDeadline.Tag.ToString();
            this.txtConStr.Text = this.txtConStr.Tag.ToString();
            this.txtVcrIP.Text = this.txtVcrIP.Tag.ToString();
            this.txtVcrTcpPort.Text = this.txtVcrTcpPort.Tag.ToString();
            this.txtUserName.Text = this.txtUserName.Tag.ToString();
            this.txtPwd.Text = this.txtPwd.Tag.ToString();
            this.cmbComPort.SelectedItem = "COM" + this.cmbComPort.Tag.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowWindow(FindWindow("Shell_TrayWnd", null), 5);

            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

     
        //关机
        private void button2_Click(object sender, EventArgs e)
        {
            ProcessStartInfo ps = new ProcessStartInfo();
            ps.FileName = "shutdown.exe";
            ps.Arguments = "-s -t 1";
            Process.Start(ps);
        }
        //重启
        private void button3_Click(object sender, EventArgs e)
        {
            ProcessStartInfo ps = new ProcessStartInfo();
            ps.FileName = "shutdown.exe";
            ps.Arguments = "-r -t 1";
            Process.Start(ps);

        }
        //注销
        private void button4_Click(object sender, EventArgs e)
        {
            ProcessStartInfo ps = new ProcessStartInfo();
            ps.FileName = "shutdown.exe";
            ps.Arguments = "-l -f";
            Process.Start(ps);
        }


        private void txtTrain_TextChanged(object sender, EventArgs e)
        {
            this.labTrainErrorMsg.Visible = false;

        }

        private void txtLocalListenPort_TextChanged(object sender, EventArgs e)
        {
            this.labLocalListenPortErrorMsg.Visible = false;
            int listenPort = 0;
            if (int.TryParse(this.txtLocalListenPort.Text.Trim(), out listenPort))
            {
                if (listenPort < 0 || listenPort > 65535)
                {
                    this.labLocalListenPortErrorMsg.Visible = true;
                }
            }
            else
            {
                this.labLocalListenPortErrorMsg.Visible = true;
            }

        }

        private void txtInspectionInterval_TextChanged(object sender, EventArgs e)
        {
            this.labInspectionIntervalErrorMsg.Visible = false;
            if (!Regex.IsMatch(this.txtDeadline.Text.Trim(), "^\\d+$"))
            {
                this.labInspectionIntervalErrorMsg.Visible = true;
            }
        }

        private void txtDeadline_TextChanged(object sender, EventArgs e)
        {
            this.labDeadlineErrorMsg.Visible = false;
            if (!Regex.IsMatch(this.txtDeadline.Text.Trim(), "^\\d+$"))
            {
                this.labDeadlineErrorMsg.Visible = true;
            }
        }

        private void maintancebutton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("d:\\train\\Maintenance.exe");

        }

        //private void txtVcrIP_TextChanged(object sender, EventArgs e)
        //{
        //    this.labIPErrorMsg.Visible = false;
        //    IPAddress ip = null;
        //    if (!IPAddress.TryParse(this.txtVcrIP.Text.Trim(), out ip))
        //    {
        //        this.labIPErrorMsg.Visible = true;
        //    }

        //}

        //private void txtVcrTcpPort_TextChanged(object sender, EventArgs e)
        //{
        //    this.labVcrTcpPortErrorMsg.Visible = false;
        //    int vcrPort = 0;
        //    if (int.TryParse(this.txtVcrTcpPort.Text.Trim(), out vcrPort))
        //    {
        //        if (vcrPort < 0 || vcrPort > 65535)
        //        {
        //            this.labVcrTcpPortErrorMsg.Visible = true;
        //        }
        //    }
        //    else
        //    {
        //        this.labVcrTcpPortErrorMsg.Visible = true;
        //    }
        //}

        //private void txtSerialNum_TextChanged(object sender, EventArgs e)
        //{
        //    this.labSerialNumErrorMsg.Visible = false;
        //    if (this.txtSerialNum.Text.Trim() == "")
        //    {
        //        this.labSerialNumErrorMsg.Visible = true;
        //    }
        //}

        //private void txtUserName_TextChanged(object sender, EventArgs e)
        //{
        //    this.labUserNameErrorMsg.Visible = false;
        //    if (this.txtUserName.Text.Trim() == "")
        //    {
        //        this.labUserNameErrorMsg.Visible = true;
        //    }
        //}

        //private void txtPwd_TextChanged(object sender, EventArgs e)
        //{
        //    this.labPwdErrorMsg.Visible = false;
        //    if (this.txtPwd.Text.Trim() == "")
        //    {
        //        this.labPwdErrorMsg.Visible = true;
        //    }
        //}




    }
}
