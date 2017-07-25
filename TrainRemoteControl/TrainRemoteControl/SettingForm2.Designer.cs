namespace TrainRemoteControl
{
    partial class SettingForm2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.labLocalListenPortErrorMsg = new System.Windows.Forms.Label();
            this.txtWebServiceUrl = new System.Windows.Forms.TextBox();
            this.txtLocalListenPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labSerialNumErrorMsg = new System.Windows.Forms.Label();
            this.labTrainErrorMsg = new System.Windows.Forms.Label();
            this.txtTrain = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSerialNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtConStr = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.labDeadlineErrorMsg = new System.Windows.Forms.Label();
            this.labInspectionIntervalErrorMsg = new System.Windows.Forms.Label();
            this.txtDeadline = new System.Windows.Forms.TextBox();
            this.txtInspectionInterval = new System.Windows.Forms.TextBox();
            this.cmbComPort = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtVcrTcpPort = new System.Windows.Forms.TextBox();
            this.txtVcrIP = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.OilFormula3_textBox = new System.Windows.Forms.TextBox();
            this.OilFormula2_textBox = new System.Windows.Forms.TextBox();
            this.OilFormula3_label = new System.Windows.Forms.Label();
            this.OilFormula2_label = new System.Windows.Forms.Label();
            this.OilFormula1_textBox = new System.Windows.Forms.TextBox();
            this.OilFormula1_label = new System.Windows.Forms.Label();
            this.WaterFormula3_textBox = new System.Windows.Forms.TextBox();
            this.WaterFormula3_label = new System.Windows.Forms.Label();
            this.WaterFormula2_textBox = new System.Windows.Forms.TextBox();
            this.WaterFormula2_label = new System.Windows.Forms.Label();
            this.WaterFormula1_textBox = new System.Windows.Forms.TextBox();
            this.WaterFormula1_label = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.waterAlarm1textBox = new System.Windows.Forms.TextBox();
            this.waterAlarm1label = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.maintancebutton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Font = new System.Drawing.Font("宋体", 9F);
            this.tabControl1.Location = new System.Drawing.Point(2, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(831, 402);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Tag = "";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.labLocalListenPortErrorMsg);
            this.tabPage1.Controls.Add(this.txtWebServiceUrl);
            this.tabPage1.Controls.Add(this.txtLocalListenPort);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.labSerialNumErrorMsg);
            this.tabPage1.Controls.Add(this.labTrainErrorMsg);
            this.tabPage1.Controls.Add(this.txtTrain);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtSerialNum);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(823, 376);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "车辆信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // labLocalListenPortErrorMsg
            // 
            this.labLocalListenPortErrorMsg.ForeColor = System.Drawing.Color.Red;
            this.labLocalListenPortErrorMsg.Location = new System.Drawing.Point(9, 250);
            this.labLocalListenPortErrorMsg.Name = "labLocalListenPortErrorMsg";
            this.labLocalListenPortErrorMsg.Size = new System.Drawing.Size(194, 33);
            this.labLocalListenPortErrorMsg.TabIndex = 17;
            this.labLocalListenPortErrorMsg.Text = "*设置错误，必须为0到65535之间的数字";
            // 
            // txtWebServiceUrl
            // 
            this.txtWebServiceUrl.Location = new System.Drawing.Point(9, 314);
            this.txtWebServiceUrl.Name = "txtWebServiceUrl";
            this.txtWebServiceUrl.Size = new System.Drawing.Size(194, 21);
            this.txtWebServiceUrl.TabIndex = 16;
            // 
            // txtLocalListenPort
            // 
            this.txtLocalListenPort.Location = new System.Drawing.Point(90, 226);
            this.txtLocalListenPort.Name = "txtLocalListenPort";
            this.txtLocalListenPort.Size = new System.Drawing.Size(100, 21);
            this.txtLocalListenPort.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 283);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "远端服务器URL:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "TCP监听端口:";
            // 
            // labSerialNumErrorMsg
            // 
            this.labSerialNumErrorMsg.AutoSize = true;
            this.labSerialNumErrorMsg.ForeColor = System.Drawing.Color.Red;
            this.labSerialNumErrorMsg.Location = new System.Drawing.Point(68, 79);
            this.labSerialNumErrorMsg.Name = "labSerialNumErrorMsg";
            this.labSerialNumErrorMsg.Size = new System.Drawing.Size(71, 12);
            this.labSerialNumErrorMsg.TabIndex = 12;
            this.labSerialNumErrorMsg.Text = "*不可为空！";
            // 
            // labTrainErrorMsg
            // 
            this.labTrainErrorMsg.ForeColor = System.Drawing.Color.Red;
            this.labTrainErrorMsg.Location = new System.Drawing.Point(7, 138);
            this.labTrainErrorMsg.Name = "labTrainErrorMsg";
            this.labTrainErrorMsg.Size = new System.Drawing.Size(196, 37);
            this.labTrainErrorMsg.TabIndex = 11;
            this.labTrainErrorMsg.Text = "*设置错误，格式为\"起始地--目的地";
            // 
            // txtTrain
            // 
            this.txtTrain.Location = new System.Drawing.Point(68, 113);
            this.txtTrain.Name = "txtTrain";
            this.txtTrain.Size = new System.Drawing.Size(135, 21);
            this.txtTrain.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "车次";
            // 
            // txtSerialNum
            // 
            this.txtSerialNum.Location = new System.Drawing.Point(68, 44);
            this.txtSerialNum.Name = "txtSerialNum";
            this.txtSerialNum.Size = new System.Drawing.Size(135, 21);
            this.txtSerialNum.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "车号";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtConStr);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.labDeadlineErrorMsg);
            this.tabPage2.Controls.Add(this.labInspectionIntervalErrorMsg);
            this.tabPage2.Controls.Add(this.txtDeadline);
            this.tabPage2.Controls.Add(this.txtInspectionInterval);
            this.tabPage2.Controls.Add(this.cmbComPort);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(823, 376);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "设置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtConStr
            // 
            this.txtConStr.Location = new System.Drawing.Point(30, 271);
            this.txtConStr.Multiline = true;
            this.txtConStr.Name = "txtConStr";
            this.txtConStr.Size = new System.Drawing.Size(195, 45);
            this.txtConStr.TabIndex = 20;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(32, 250);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(107, 12);
            this.label12.TabIndex = 19;
            this.label12.Text = "数据库连接字符串:";
            // 
            // labDeadlineErrorMsg
            // 
            this.labDeadlineErrorMsg.ForeColor = System.Drawing.Color.Red;
            this.labDeadlineErrorMsg.Location = new System.Drawing.Point(32, 183);
            this.labDeadlineErrorMsg.Name = "labDeadlineErrorMsg";
            this.labDeadlineErrorMsg.Size = new System.Drawing.Size(191, 33);
            this.labDeadlineErrorMsg.TabIndex = 18;
            this.labDeadlineErrorMsg.Text = "*设置错误，必须为数字且小于巡检间隔值";
            this.labDeadlineErrorMsg.Visible = false;
            // 
            // labInspectionIntervalErrorMsg
            // 
            this.labInspectionIntervalErrorMsg.ForeColor = System.Drawing.Color.Red;
            this.labInspectionIntervalErrorMsg.Location = new System.Drawing.Point(28, 127);
            this.labInspectionIntervalErrorMsg.Name = "labInspectionIntervalErrorMsg";
            this.labInspectionIntervalErrorMsg.Size = new System.Drawing.Size(193, 18);
            this.labInspectionIntervalErrorMsg.TabIndex = 17;
            this.labInspectionIntervalErrorMsg.Text = "*设置错误，必须为数字";
            // 
            // txtDeadline
            // 
            this.txtDeadline.Location = new System.Drawing.Point(104, 152);
            this.txtDeadline.Name = "txtDeadline";
            this.txtDeadline.Size = new System.Drawing.Size(121, 21);
            this.txtDeadline.TabIndex = 16;
            // 
            // txtInspectionInterval
            // 
            this.txtInspectionInterval.Location = new System.Drawing.Point(104, 93);
            this.txtInspectionInterval.Name = "txtInspectionInterval";
            this.txtInspectionInterval.Size = new System.Drawing.Size(121, 21);
            this.txtInspectionInterval.TabIndex = 15;
            // 
            // cmbComPort
            // 
            this.cmbComPort.FormattingEnabled = true;
            this.cmbComPort.Location = new System.Drawing.Point(104, 37);
            this.cmbComPort.Name = "cmbComPort";
            this.cmbComPort.Size = new System.Drawing.Size(121, 20);
            this.cmbComPort.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "巡检间隔:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "晚检时限:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "串口:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.txtPwd);
            this.tabPage3.Controls.Add(this.txtUserName);
            this.tabPage3.Controls.Add(this.txtVcrTcpPort);
            this.tabPage3.Controls.Add(this.txtVcrIP);
            this.tabPage3.Controls.Add(this.label16);
            this.tabPage3.Controls.Add(this.label17);
            this.tabPage3.Controls.Add(this.label18);
            this.tabPage3.Controls.Add(this.label19);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(823, 376);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "硬盘录像机";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(133, 250);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 24;
            this.label6.Text = "*密码不能为空!";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(133, 179);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 12);
            this.label13.TabIndex = 23;
            this.label13.Text = "*用户名不能为空";
            // 
            // label14
            // 
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(16, 117);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(215, 29);
            this.label14.TabIndex = 22;
            this.label14.Text = "*设置错误，必须为0到65535之间的数字";
            // 
            // label15
            // 
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(16, 61);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(215, 23);
            this.label15.TabIndex = 21;
            this.label15.Text = "*设置格式错误 例192.168.22.32";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(131, 217);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(100, 21);
            this.txtPwd.TabIndex = 20;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(131, 149);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 21);
            this.txtUserName.TabIndex = 19;
            // 
            // txtVcrTcpPort
            // 
            this.txtVcrTcpPort.Location = new System.Drawing.Point(131, 93);
            this.txtVcrTcpPort.Name = "txtVcrTcpPort";
            this.txtVcrTcpPort.Size = new System.Drawing.Size(100, 21);
            this.txtVcrTcpPort.TabIndex = 18;
            // 
            // txtVcrIP
            // 
            this.txtVcrIP.Location = new System.Drawing.Point(131, 34);
            this.txtVcrIP.Name = "txtVcrIP";
            this.txtVcrIP.Size = new System.Drawing.Size(100, 21);
            this.txtVcrIP.TabIndex = 17;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(16, 96);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(113, 12);
            this.label16.TabIndex = 16;
            this.label16.Text = "硬盘录像机Tcp端口:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(16, 158);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 12);
            this.label17.TabIndex = 15;
            this.label17.Text = "用户名:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(16, 226);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 12);
            this.label18.TabIndex = 14;
            this.label18.Text = "密码:";
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(16, 38);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(83, 12);
            this.label19.TabIndex = 13;
            this.label19.Text = "硬盘录像机IP:";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.OilFormula3_textBox);
            this.tabPage4.Controls.Add(this.OilFormula2_textBox);
            this.tabPage4.Controls.Add(this.OilFormula3_label);
            this.tabPage4.Controls.Add(this.OilFormula2_label);
            this.tabPage4.Controls.Add(this.OilFormula1_textBox);
            this.tabPage4.Controls.Add(this.OilFormula1_label);
            this.tabPage4.Controls.Add(this.WaterFormula3_textBox);
            this.tabPage4.Controls.Add(this.WaterFormula3_label);
            this.tabPage4.Controls.Add(this.WaterFormula2_textBox);
            this.tabPage4.Controls.Add(this.WaterFormula2_label);
            this.tabPage4.Controls.Add(this.WaterFormula1_textBox);
            this.tabPage4.Controls.Add(this.WaterFormula1_label);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(823, 376);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "公式设置";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // OilFormula3_textBox
            // 
            this.OilFormula3_textBox.Location = new System.Drawing.Point(117, 313);
            this.OilFormula3_textBox.Name = "OilFormula3_textBox";
            this.OilFormula3_textBox.Size = new System.Drawing.Size(436, 21);
            this.OilFormula3_textBox.TabIndex = 11;
            // 
            // OilFormula2_textBox
            // 
            this.OilFormula2_textBox.Location = new System.Drawing.Point(117, 270);
            this.OilFormula2_textBox.Name = "OilFormula2_textBox";
            this.OilFormula2_textBox.Size = new System.Drawing.Size(436, 21);
            this.OilFormula2_textBox.TabIndex = 10;
            // 
            // OilFormula3_label
            // 
            this.OilFormula3_label.AutoSize = true;
            this.OilFormula3_label.Location = new System.Drawing.Point(30, 322);
            this.OilFormula3_label.Name = "OilFormula3_label";
            this.OilFormula3_label.Size = new System.Drawing.Size(65, 12);
            this.OilFormula3_label.TabIndex = 9;
            this.OilFormula3_label.Text = "机组三油压";
            // 
            // OilFormula2_label
            // 
            this.OilFormula2_label.AutoSize = true;
            this.OilFormula2_label.Location = new System.Drawing.Point(30, 270);
            this.OilFormula2_label.Name = "OilFormula2_label";
            this.OilFormula2_label.Size = new System.Drawing.Size(65, 12);
            this.OilFormula2_label.TabIndex = 8;
            this.OilFormula2_label.Text = "机组二油压";
            // 
            // OilFormula1_textBox
            // 
            this.OilFormula1_textBox.Location = new System.Drawing.Point(117, 218);
            this.OilFormula1_textBox.Name = "OilFormula1_textBox";
            this.OilFormula1_textBox.Size = new System.Drawing.Size(436, 21);
            this.OilFormula1_textBox.TabIndex = 7;
            // 
            // OilFormula1_label
            // 
            this.OilFormula1_label.AutoSize = true;
            this.OilFormula1_label.Location = new System.Drawing.Point(30, 221);
            this.OilFormula1_label.Name = "OilFormula1_label";
            this.OilFormula1_label.Size = new System.Drawing.Size(65, 12);
            this.OilFormula1_label.TabIndex = 6;
            this.OilFormula1_label.Text = "机组一油压";
            // 
            // WaterFormula3_textBox
            // 
            this.WaterFormula3_textBox.Location = new System.Drawing.Point(117, 153);
            this.WaterFormula3_textBox.Name = "WaterFormula3_textBox";
            this.WaterFormula3_textBox.Size = new System.Drawing.Size(436, 21);
            this.WaterFormula3_textBox.TabIndex = 5;
            // 
            // WaterFormula3_label
            // 
            this.WaterFormula3_label.AutoSize = true;
            this.WaterFormula3_label.Location = new System.Drawing.Point(30, 162);
            this.WaterFormula3_label.Name = "WaterFormula3_label";
            this.WaterFormula3_label.Size = new System.Drawing.Size(65, 12);
            this.WaterFormula3_label.TabIndex = 4;
            this.WaterFormula3_label.Text = "机组三水温";
            // 
            // WaterFormula2_textBox
            // 
            this.WaterFormula2_textBox.Location = new System.Drawing.Point(117, 90);
            this.WaterFormula2_textBox.Name = "WaterFormula2_textBox";
            this.WaterFormula2_textBox.Size = new System.Drawing.Size(436, 21);
            this.WaterFormula2_textBox.TabIndex = 3;
            // 
            // WaterFormula2_label
            // 
            this.WaterFormula2_label.AutoSize = true;
            this.WaterFormula2_label.Location = new System.Drawing.Point(30, 99);
            this.WaterFormula2_label.Name = "WaterFormula2_label";
            this.WaterFormula2_label.Size = new System.Drawing.Size(65, 12);
            this.WaterFormula2_label.TabIndex = 2;
            this.WaterFormula2_label.Text = "机组二水温";
            // 
            // WaterFormula1_textBox
            // 
            this.WaterFormula1_textBox.Location = new System.Drawing.Point(117, 38);
            this.WaterFormula1_textBox.Name = "WaterFormula1_textBox";
            this.WaterFormula1_textBox.Size = new System.Drawing.Size(436, 21);
            this.WaterFormula1_textBox.TabIndex = 1;
            // 
            // WaterFormula1_label
            // 
            this.WaterFormula1_label.AutoSize = true;
            this.WaterFormula1_label.Location = new System.Drawing.Point(30, 41);
            this.WaterFormula1_label.Name = "WaterFormula1_label";
            this.WaterFormula1_label.Size = new System.Drawing.Size(65, 12);
            this.WaterFormula1_label.TabIndex = 0;
            this.WaterFormula1_label.Text = "机组一水温";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.waterAlarm1textBox);
            this.tabPage5.Controls.Add(this.waterAlarm1label);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(823, 376);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "报警值设置";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // waterAlarm1textBox
            // 
            this.waterAlarm1textBox.Location = new System.Drawing.Point(138, 45);
            this.waterAlarm1textBox.Name = "waterAlarm1textBox";
            this.waterAlarm1textBox.Size = new System.Drawing.Size(121, 21);
            this.waterAlarm1textBox.TabIndex = 16;
            // 
            // waterAlarm1label
            // 
            this.waterAlarm1label.AutoSize = true;
            this.waterAlarm1label.Location = new System.Drawing.Point(40, 48);
            this.waterAlarm1label.Name = "waterAlarm1label";
            this.waterAlarm1label.Size = new System.Drawing.Size(71, 12);
            this.waterAlarm1label.TabIndex = 12;
            this.waterAlarm1label.Text = "水温报警值:";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.Location = new System.Drawing.Point(48, 504);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(97, 52);
            this.button4.TabIndex = 12;
            this.button4.Text = "注销";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(175, 505);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 52);
            this.button3.TabIndex = 11;
            this.button3.Text = "重启";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(306, 505);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 52);
            this.button2.TabIndex = 10;
            this.button2.Text = "关机";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(306, 434);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 52);
            this.button1.TabIndex = 9;
            this.button1.Text = "关闭程序";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("宋体", 12F);
            this.btnReset.Location = new System.Drawing.Point(175, 434);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(99, 52);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("宋体", 12F);
            this.btnSubmit.Location = new System.Drawing.Point(48, 434);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(97, 52);
            this.btnSubmit.TabIndex = 7;
            this.btnSubmit.Text = "确认修改";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // maintancebutton
            // 
            this.maintancebutton.Font = new System.Drawing.Font("宋体", 12F);
            this.maintancebutton.Location = new System.Drawing.Point(427, 434);
            this.maintancebutton.Name = "maintancebutton";
            this.maintancebutton.Size = new System.Drawing.Size(97, 52);
            this.maintancebutton.TabIndex = 13;
            this.maintancebutton.Text = "维护界面";
            this.maintancebutton.UseVisualStyleBackColor = true;
            this.maintancebutton.Click += new System.EventHandler(this.maintancebutton_Click);
            // 
            // SettingForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 561);
            this.Controls.Add(this.maintancebutton);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.tabControl1);
            this.Name = "SettingForm2";
            this.Text = "SettingForm2";
            this.Load += new System.EventHandler(this.SettingForm2_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label labSerialNumErrorMsg;
        private System.Windows.Forms.Label labTrainErrorMsg;
        private System.Windows.Forms.TextBox txtTrain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSerialNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labDeadlineErrorMsg;
        private System.Windows.Forms.Label labInspectionIntervalErrorMsg;
        private System.Windows.Forms.TextBox txtDeadline;
        private System.Windows.Forms.TextBox txtInspectionInterval;
        private System.Windows.Forms.ComboBox cmbComPort;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label labLocalListenPortErrorMsg;
        private System.Windows.Forms.TextBox txtWebServiceUrl;
        private System.Windows.Forms.TextBox txtLocalListenPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtConStr;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtVcrTcpPort;
        private System.Windows.Forms.TextBox txtVcrIP;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label WaterFormula1_label;
        private System.Windows.Forms.TextBox WaterFormula1_textBox;
        private System.Windows.Forms.Label WaterFormula2_label;
        private System.Windows.Forms.TextBox WaterFormula2_textBox;
        private System.Windows.Forms.Label WaterFormula3_label;
        private System.Windows.Forms.TextBox WaterFormula3_textBox;
        private System.Windows.Forms.Label OilFormula1_label;
        private System.Windows.Forms.TextBox OilFormula1_textBox;
        private System.Windows.Forms.Label OilFormula3_label;
        private System.Windows.Forms.Label OilFormula2_label;
        private System.Windows.Forms.TextBox OilFormula3_textBox;
        private System.Windows.Forms.TextBox OilFormula2_textBox;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TextBox waterAlarm1textBox;
        private System.Windows.Forms.Label waterAlarm1label;
        private System.Windows.Forms.Button maintancebutton;
    }
}