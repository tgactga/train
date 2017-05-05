using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Net;
 
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO.Ports;
using System.Threading;
using TrainRemoteControl.utilclass;

namespace TrainRemoteControl
{
    public partial class SettingForm : Templete
    {
        #region 配置文件中的键
        private const string serialNumKey = "serialNum";
        private const string trainKey = "checi";
        private const string localListenPortKey = "localListenPort";
        private const string urlKey = "url";
        private const string inspectionIntervalKey = "inspectionInterval";
        private const string deadlineKey = "laterInterval";
        private const string comPortKey = "comPort";
        private const string localVedioIpKey = "LocalVadioIp";
        private const string localVedioPortKey = "LocalVadioPort";
        private const string localVedioUserNameKey = "LocalVadioUsername";
        private const string localVedioPwdKey = "LocalVadioPassword";
        private const string connStringKey = "connString";
        #endregion

        [DllImport("User32.dll", EntryPoint = "FindWindow", CharSet = CharSet.Auto)]
        public static extern int FindWindow(String className, String captionName);
        [DllImport("User32.dll", EntryPoint = "ShowWindow", CharSet = CharSet.Auto)]
        public static extern int ShowWindow(int hwnd, int nCmdShow);

        //[DllImport("imm32.dll", EntryPoint = "ImmGetContext")]
        //public static extern IntPtr ImmGetContext(IntPtr hwnd);
        //[DllImport("imm32.dll", EntryPoint = "ImmGetConversionStatus")]
        //public static extern bool ImmGetConversionStatus(IntPtr himc, ref IntPtr lpdw, ref IntPtr lpdw2
        //);
        //[DllImport("imm32.dll", EntryPoint = "ImmSetConversionStatus")]
        //public static extern bool ImmSetConversionStatus(IntPtr himc, IntPtr dw1, IntPtr dw2
        //);

        //[DllImport("imm32.dll", EntryPoint = "ImmReleaseContext")]
        //public static extern int ImmReleaseContext(IntPtr hwnd, IntPtr himc
        //);

        public SettingForm()
        {
            //this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
        }
        /// <summary>
        /// 在load事件中读取显示配置文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingForm_Load(object sender, EventArgs e)
        {          
            this.txtDeadline.Text = Program.g_deadline;
            this.txtDeadline.Tag = Program.g_deadline;
            this.txtInspectionInterval.Text = Program.g_inspectionInterval;
            this.txtInspectionInterval.Tag = Program.g_inspectionInterval;
            this.txtLocalListenPort.Text = Program.g_localListenPort;
            this.txtLocalListenPort.Tag = Program.g_localListenPort;
            this.txtPwd.Text = Program.g_localVedioPwd;
            this.txtPwd.Tag = Program.g_localVedioPwd;
            this.txtSerialNum.Text = Program.g_serialNum;
            this.txtSerialNum.Tag = Program.g_serialNum;
            this.txtTrain.Text = Program.g_train;
            this.txtTrain.Tag = Program.g_train;
            this.txtUserName.Text = Program.g_localVedioUserName;
            this.txtUserName.Tag = Program.g_localVedioUserName;
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

             //备份初始配置
            // config.Savs(Environment.CurrentDirectory + "\\AppConfigBak.xml", ConfigurationSaveMode.Full, false);
            #region
            //string[] portNa
            //ortNames();
            //foreach (string portName in portNames)
            //{
            //    this.cmbComPort.Items.Add(portName);
            //    if (portName.Contains(this.cmbComPort.Tag.ToString()))
            //    {
            //        cmbComPort.SelectedItem = portName;
            //    }
            //}
           
            //ini.IniWriteValue("TermInfo", "deadlin            AppSettings.Settings[deadlineKey].Value);
            //ini.IniWriteValue("TermInfo", "deadlin            AppSettings.Settings[deadlineKey].Value);
            //ini.IniWriteValue("TermInfo", "inspect            ", config.AppSettings.Settings[inspectionIntervalKey].Value);
            //ini.IniWriteValue("TermInfo", "inspect            ", config.AppSettings.Settings[inspectionIntervalKey].Value);
            //ini.IniWriteValue("TermInfo", "localLi            config.AppSettings.Settings[localListenPortKey].Value);
            //ini.IniWriteValue("TermInfo", "localLi            config.AppSettings.Settings[localListenPortKey].Value);
            //ini.IniWriteValue("TermInfo", "localVe            nfig.AppSettings.Settings[localVedioPwdKey].Value);

            //ini.IniWriteValue("TermInfo", "serialN            .AppSettings.Settings[serialNumKey].Value);

            //ini.IniWriteValue("TermInfo", "trainKe            Settings.Settings[trainKey].Value);

            //ini.IniWriteValue("TermInfo", "localVe            ", config.AppSettings.Settings[localVedioUserNameKey].Value);
            //ini.IniWriteValue("TermInfo", "localVe            ", config.AppSettings.Settings[localVedioUserNameKey].Value);
            //ini.IniWriteValue("TermInfo", "localVe            fig.AppSettings.Settings[localVedioIpKey].Value);
            //ini.IniWriteValue("TermInfo", "localVe            fig.AppSettings.Settings[localVedioIpKey].Value);
            //ini.IniWriteValue("TermInfo", "urlKey"            ttings.Settings[urlKey].Value);
            //ini.IniWriteValue("TermInfo", "urlKey"            ttings.Settings[urlKey].Value);
            //ini.IniWriteValue("TermInfo", "deadlin            AppSettings.Settings[localVedioPortKey].Value);
            //ini.IniWriteValue("TermInfo", "localVe            onfig.AppSettings.Settings[localVedioPortKey].Value);
            //ini.IniWriteValue("TermInfo", "connStr            g.ConnectionStrings.ConnectionStrings[connStringKey].ConnectionString);
            //ini.IniWriteValue("TermInfo", "connStr            g.ConnectionStrings.ConnectionStrings[connStringKey].ConnectionString);
            //ini.IniWriteValue("TermInfo", "comPort            ppSettings.Settings[comPortKey].Value);

            #endregion



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

        /// <summary>
        /// 更新配置文件
        /// </summary>
        private void UpdateConfig()
        {
             INIClass ini = new INIClass("D://train//train.ini"); 
            ini.IniWriteValue("TermInfo", "deadline",this.txtDeadline.Text);
            ini.IniWriteValue("TermInfo", "inspectionInterval",this.txtInspectionInterval.Text);
            ini.IniWriteValue("TermInfo", "localListenPort",this.txtLocalListenPort.Text);
            ini.IniWriteValue("TermInfo", "localVedioPwd", this.txtPwd.Text);
            ini.IniWriteValue("TermInfo", "serialNum",this.txtSerialNum.Text);
            ini.IniWriteValue("TermInfo", "train",this.txtTrain.Text);
            ini.IniWriteValue("TermInfo", "localVedioUserName", this.txtUserName.Text);
            ini.IniWriteValue("TermInfo", "localVedioIp", this.txtVcrIP.Text);
            ini.IniWriteValue("TermInfo", "url", this.txtWebServiceUrl.Text);
            ini.IniWriteValue("TermInfo", "localVedioPort", this.txtVcrTcpPort.Text);
            ini.IniWriteValue("TermInfo", "connStringKey", this.txtConStr.Text);
            ini.IniWriteValue("TermInfo", "comPort", this.cmbComPort.Text);           
        }
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        //验证用户输入
        private bool Check()
        {

            return true;
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

        private void txtVcrIP_TextChanged(object sender, EventArgs e)
        {
            this.labIPErrorMsg.Visible = false;
            IPAddress ip = null;
            if (!IPAddress.TryParse(this.txtVcrIP.Text.Trim(), out ip))
            {
                this.labIPErrorMsg.Visible = true;
            }

        }

        private void txtVcrTcpPort_TextChanged(object sender, EventArgs e)
        {
            this.labVcrTcpPortErrorMsg.Visible = false;
            int vcrPort = 0;
            if (int.TryParse(this.txtVcrTcpPort.Text.Trim(), out vcrPort))
            {
                if (vcrPort < 0 || vcrPort > 65535)
                {
                    this.labVcrTcpPortErrorMsg.Visible = true;
                }
            }
            else
            {
                this.labVcrTcpPortErrorMsg.Visible = true;
            }
        }

        private void txtSerialNum_TextChanged(object sender, EventArgs e)
        {
            this.labSerialNumErrorMsg.Visible = false;
            if (this.txtSerialNum.Text.Trim() == "")
            {
                this.labSerialNumErrorMsg.Visible = true;
            }
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            this.labUserNameErrorMsg.Visible = false;
            if (this.txtUserName.Text.Trim() == "")
            {
                this.labUserNameErrorMsg.Visible = true;
            }
        }

        private void txtPwd_TextChanged(object sender, EventArgs e)
        {
            this.labPwdErrorMsg.Visible = false;
            if (this.txtPwd.Text.Trim() == "")
            {
                this.labPwdErrorMsg.Visible = true;
            }
        }
        public const int IME_CMODE_SOFTKBD = 0x80;
        private void btnTouchKeyboard_Click(object sender, EventArgs e)
        {
            //打开软件盘
            ProcessStartInfo si = new ProcessStartInfo("osk.exe");
            Process.Start(si);
            

            //IntPtr hwndInput = ImmGetContext(this.Handle);
            //IntPtr dw1 = IntPtr.Zero;
            //IntPtr dw2 = IntPtr.Zero;
            //bool isSuccess = ImmGetConversionStatus(hwndInput, ref dw1, ref dw2);
            //if (isSuccess)
            //{
            //    int intTemp = dw1.ToInt32() & IME_CMODE_SOFTKBD;
            //    if (intTemp > 0)
            //        dw1 = (IntPtr)(dw1.ToInt32() ^ IME_CMODE_SOFTKBD);
            //    else
            //        dw1 = (IntPtr)(dw1.ToInt32() );
            //}
            //isSuccess = ImmSetConversionStatus(hwndInput, dw1, dw2);
            //ImmReleaseContext(this.Handle, hwndInput);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Close();
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
    }
}
