namespace TrainRemoteControl
{
    partial class SettingForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labSerialNumErrorMsg = new System.Windows.Forms.Label();
            this.labTrainErrorMsg = new System.Windows.Forms.Label();
            this.txtTrain = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSerialNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labLocalListenPortErrorMsg = new System.Windows.Forms.Label();
            this.txtWebServiceUrl = new System.Windows.Forms.TextBox();
            this.txtLocalListenPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labDeadlineErrorMsg = new System.Windows.Forms.Label();
            this.labInspectionIntervalErrorMsg = new System.Windows.Forms.Label();
            this.txtConStr = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDeadline = new System.Windows.Forms.TextBox();
            this.txtInspectionInterval = new System.Windows.Forms.TextBox();
            this.cmbComPort = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labPwdErrorMsg = new System.Windows.Forms.Label();
            this.labUserNameErrorMsg = new System.Windows.Forms.Label();
            this.labVcrTcpPortErrorMsg = new System.Windows.Forms.Label();
            this.labIPErrorMsg = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtVcrTcpPort = new System.Windows.Forms.TextBox();
            this.txtVcrIP = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lab = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labSerialNumErrorMsg);
            this.groupBox1.Controls.Add(this.labTrainErrorMsg);
            this.groupBox1.Controls.Add(this.txtTrain);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtSerialNum);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(215, 170);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "车辆信息";
            // 
            // labSerialNumErrorMsg
            // 
            this.labSerialNumErrorMsg.AutoSize = true;
            this.labSerialNumErrorMsg.ForeColor = System.Drawing.Color.Red;
            this.labSerialNumErrorMsg.Location = new System.Drawing.Point(68, 71);
            this.labSerialNumErrorMsg.Name = "labSerialNumErrorMsg";
            this.labSerialNumErrorMsg.Size = new System.Drawing.Size(71, 12);
            this.labSerialNumErrorMsg.TabIndex = 6;
            this.labSerialNumErrorMsg.Text = "*不可为空！";
            // 
            // labTrainErrorMsg
            // 
            this.labTrainErrorMsg.ForeColor = System.Drawing.Color.Red;
            this.labTrainErrorMsg.Location = new System.Drawing.Point(7, 130);
            this.labTrainErrorMsg.Name = "labTrainErrorMsg";
            this.labTrainErrorMsg.Size = new System.Drawing.Size(196, 37);
            this.labTrainErrorMsg.TabIndex = 5;
            this.labTrainErrorMsg.Text = "*设置错误，格式为\"起始地--目的地";
            // 
            // txtTrain
            // 
            this.txtTrain.Location = new System.Drawing.Point(68, 105);
            this.txtTrain.Name = "txtTrain";
            this.txtTrain.Size = new System.Drawing.Size(135, 21);
            this.txtTrain.TabIndex = 3;
            this.txtTrain.TextChanged += new System.EventHandler(this.txtTrain_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "车次";
            // 
            // txtSerialNum
            // 
            this.txtSerialNum.Location = new System.Drawing.Point(68, 36);
            this.txtSerialNum.Name = "txtSerialNum";
            this.txtSerialNum.Size = new System.Drawing.Size(135, 21);
            this.txtSerialNum.TabIndex = 1;
            this.txtSerialNum.TextChanged += new System.EventHandler(this.txtSerialNum_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "车号";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labLocalListenPortErrorMsg);
            this.groupBox2.Controls.Add(this.txtWebServiceUrl);
            this.groupBox2.Controls.Add(this.txtLocalListenPort);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 202);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(215, 179);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "通信设置";
            // 
            // labLocalListenPortErrorMsg
            // 
            this.labLocalListenPortErrorMsg.ForeColor = System.Drawing.Color.Red;
            this.labLocalListenPortErrorMsg.Location = new System.Drawing.Point(9, 60);
            this.labLocalListenPortErrorMsg.Name = "labLocalListenPortErrorMsg";
            this.labLocalListenPortErrorMsg.Size = new System.Drawing.Size(194, 33);
            this.labLocalListenPortErrorMsg.TabIndex = 4;
            this.labLocalListenPortErrorMsg.Text = "*设置错误，必须为0到65535之间的数字";
            // 
            // txtWebServiceUrl
            // 
            this.txtWebServiceUrl.Location = new System.Drawing.Point(9, 124);
            this.txtWebServiceUrl.Name = "txtWebServiceUrl";
            this.txtWebServiceUrl.Size = new System.Drawing.Size(194, 21);
            this.txtWebServiceUrl.TabIndex = 3;
            // 
            // txtLocalListenPort
            // 
            this.txtLocalListenPort.Location = new System.Drawing.Point(90, 36);
            this.txtLocalListenPort.Name = "txtLocalListenPort";
            this.txtLocalListenPort.Size = new System.Drawing.Size(100, 21);
            this.txtLocalListenPort.TabIndex = 2;
            this.txtLocalListenPort.TextChanged += new System.EventHandler(this.txtLocalListenPort_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "远端服务器URL:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "TCP监听端口:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labDeadlineErrorMsg);
            this.groupBox3.Controls.Add(this.labInspectionIntervalErrorMsg);
            this.groupBox3.Controls.Add(this.txtConStr);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txtDeadline);
            this.groupBox3.Controls.Add(this.txtInspectionInterval);
            this.groupBox3.Controls.Add(this.cmbComPort);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(233, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(219, 307);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "设置";
            // 
            // labDeadlineErrorMsg
            // 
            this.labDeadlineErrorMsg.ForeColor = System.Drawing.Color.Red;
            this.labDeadlineErrorMsg.Location = new System.Drawing.Point(20, 179);
            this.labDeadlineErrorMsg.Name = "labDeadlineErrorMsg";
            this.labDeadlineErrorMsg.Size = new System.Drawing.Size(191, 33);
            this.labDeadlineErrorMsg.TabIndex = 10;
            this.labDeadlineErrorMsg.Text = "*设置错误，必须为数字且小于巡检间隔值";
            this.labDeadlineErrorMsg.Visible = false;
            // 
            // labInspectionIntervalErrorMsg
            // 
            this.labInspectionIntervalErrorMsg.ForeColor = System.Drawing.Color.Red;
            this.labInspectionIntervalErrorMsg.Location = new System.Drawing.Point(16, 123);
            this.labInspectionIntervalErrorMsg.Name = "labInspectionIntervalErrorMsg";
            this.labInspectionIntervalErrorMsg.Size = new System.Drawing.Size(193, 18);
            this.labInspectionIntervalErrorMsg.TabIndex = 9;
            this.labInspectionIntervalErrorMsg.Text = "*设置错误，必须为数字";
            // 
            // txtConStr
            // 
            this.txtConStr.Location = new System.Drawing.Point(16, 238);
            this.txtConStr.Multiline = true;
            this.txtConStr.Name = "txtConStr";
            this.txtConStr.Size = new System.Drawing.Size(195, 45);
            this.txtConStr.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 217);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(107, 12);
            this.label12.TabIndex = 7;
            this.label12.Text = "数据库连接字符串:";
            // 
            // txtDeadline
            // 
            this.txtDeadline.Location = new System.Drawing.Point(92, 148);
            this.txtDeadline.Name = "txtDeadline";
            this.txtDeadline.Size = new System.Drawing.Size(121, 21);
            this.txtDeadline.TabIndex = 6;
            this.txtDeadline.TextChanged += new System.EventHandler(this.txtDeadline_TextChanged);
            // 
            // txtInspectionInterval
            // 
            this.txtInspectionInterval.Location = new System.Drawing.Point(92, 89);
            this.txtInspectionInterval.Name = "txtInspectionInterval";
            this.txtInspectionInterval.Size = new System.Drawing.Size(121, 21);
            this.txtInspectionInterval.TabIndex = 5;
            this.txtInspectionInterval.TextChanged += new System.EventHandler(this.txtInspectionInterval_TextChanged);
            // 
            // cmbComPort
            // 
            this.cmbComPort.FormattingEnabled = true;
            this.cmbComPort.Location = new System.Drawing.Point(92, 33);
            this.cmbComPort.Name = "cmbComPort";
            this.cmbComPort.Size = new System.Drawing.Size(121, 20);
            this.cmbComPort.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "巡检间隔:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "晚检时限:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "串口:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.labPwdErrorMsg);
            this.groupBox4.Controls.Add(this.labUserNameErrorMsg);
            this.groupBox4.Controls.Add(this.labVcrTcpPortErrorMsg);
            this.groupBox4.Controls.Add(this.labIPErrorMsg);
            this.groupBox4.Controls.Add(this.txtPwd);
            this.groupBox4.Controls.Add(this.txtUserName);
            this.groupBox4.Controls.Add(this.txtVcrTcpPort);
            this.groupBox4.Controls.Add(this.txtVcrIP);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.lab);
            this.groupBox4.Location = new System.Drawing.Point(458, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(253, 300);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "硬盘录像机设置";
            // 
            // labPwdErrorMsg
            // 
            this.labPwdErrorMsg.AutoSize = true;
            this.labPwdErrorMsg.ForeColor = System.Drawing.Color.Red;
            this.labPwdErrorMsg.Location = new System.Drawing.Point(133, 243);
            this.labPwdErrorMsg.Name = "labPwdErrorMsg";
            this.labPwdErrorMsg.Size = new System.Drawing.Size(89, 12);
            this.labPwdErrorMsg.TabIndex = 12;
            this.labPwdErrorMsg.Text = "*密码不能为空!";
            // 
            // labUserNameErrorMsg
            // 
            this.labUserNameErrorMsg.AutoSize = true;
            this.labUserNameErrorMsg.ForeColor = System.Drawing.Color.Red;
            this.labUserNameErrorMsg.Location = new System.Drawing.Point(133, 172);
            this.labUserNameErrorMsg.Name = "labUserNameErrorMsg";
            this.labUserNameErrorMsg.Size = new System.Drawing.Size(95, 12);
            this.labUserNameErrorMsg.TabIndex = 11;
            this.labUserNameErrorMsg.Text = "*用户名不能为空";
            // 
            // labVcrTcpPortErrorMsg
            // 
            this.labVcrTcpPortErrorMsg.ForeColor = System.Drawing.Color.Red;
            this.labVcrTcpPortErrorMsg.Location = new System.Drawing.Point(16, 110);
            this.labVcrTcpPortErrorMsg.Name = "labVcrTcpPortErrorMsg";
            this.labVcrTcpPortErrorMsg.Size = new System.Drawing.Size(215, 29);
            this.labVcrTcpPortErrorMsg.TabIndex = 10;
            this.labVcrTcpPortErrorMsg.Text = "*设置错误，必须为0到65535之间的数字";
            // 
            // labIPErrorMsg
            // 
            this.labIPErrorMsg.ForeColor = System.Drawing.Color.Red;
            this.labIPErrorMsg.Location = new System.Drawing.Point(16, 54);
            this.labIPErrorMsg.Name = "labIPErrorMsg";
            this.labIPErrorMsg.Size = new System.Drawing.Size(215, 23);
            this.labIPErrorMsg.TabIndex = 9;
            this.labIPErrorMsg.Text = "*设置格式错误 例192.168.22.32";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(131, 210);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(100, 21);
            this.txtPwd.TabIndex = 8;
            this.txtPwd.TextChanged += new System.EventHandler(this.txtPwd_TextChanged);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(131, 142);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 21);
            this.txtUserName.TabIndex = 7;
            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            // 
            // txtVcrTcpPort
            // 
            this.txtVcrTcpPort.Location = new System.Drawing.Point(131, 86);
            this.txtVcrTcpPort.Name = "txtVcrTcpPort";
            this.txtVcrTcpPort.Size = new System.Drawing.Size(100, 21);
            this.txtVcrTcpPort.TabIndex = 6;
            this.txtVcrTcpPort.TextChanged += new System.EventHandler(this.txtVcrTcpPort_TextChanged);
            // 
            // txtVcrIP
            // 
            this.txtVcrIP.Location = new System.Drawing.Point(131, 27);
            this.txtVcrIP.Name = "txtVcrIP";
            this.txtVcrIP.Size = new System.Drawing.Size(100, 21);
            this.txtVcrIP.TabIndex = 5;
            this.txtVcrIP.TextChanged += new System.EventHandler(this.txtVcrIP_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 89);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 12);
            this.label11.TabIndex = 4;
            this.label11.Text = "硬盘录像机Tcp端口:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 151);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 12);
            this.label10.TabIndex = 3;
            this.label10.Text = "用户名:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 219);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 12);
            this.label9.TabIndex = 2;
            this.label9.Text = "密码:";
            // 
            // lab
            // 
            this.lab.Location = new System.Drawing.Point(16, 31);
            this.lab.Name = "lab";
            this.lab.Size = new System.Drawing.Size(83, 12);
            this.lab.TabIndex = 1;
            this.lab.Text = "硬盘录像机IP:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button4);
            this.groupBox5.Controls.Add(this.button3);
            this.groupBox5.Controls.Add(this.button2);
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Controls.Add(this.btnReset);
            this.groupBox5.Controls.Add(this.btnSubmit);
            this.groupBox5.Location = new System.Drawing.Point(234, 326);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(477, 124);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "操作";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.Location = new System.Drawing.Point(111, 79);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "注销";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(212, 79);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "重启";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(307, 79);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "关机";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(307, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "关闭程序";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(211, 32);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(111, 32);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 1;
            this.btnSubmit.Text = "确认修改";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.label15);
            this.groupBox6.Controls.Add(this.textBox1);
            this.groupBox6.Controls.Add(this.textBox2);
            this.groupBox6.Controls.Add(this.textBox3);
            this.groupBox6.Controls.Add(this.textBox4);
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Controls.Add(this.label17);
            this.groupBox6.Controls.Add(this.label18);
            this.groupBox6.Controls.Add(this.label19);
            this.groupBox6.Location = new System.Drawing.Point(458, 19);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(253, 300);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "硬盘录像机设置";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(133, 243);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "*密码不能为空!";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(133, 172);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 12);
            this.label13.TabIndex = 11;
            this.label13.Text = "*用户名不能为空";
            // 
            // label14
            // 
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(16, 110);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(215, 29);
            this.label14.TabIndex = 10;
            this.label14.Text = "*设置错误，必须为0到65535之间的数字";
            // 
            // label15
            // 
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(16, 54);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(215, 23);
            this.label15.TabIndex = 9;
            this.label15.Text = "*设置格式错误 例192.168.22.32";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(131, 210);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 8;
            this.textBox1.TextChanged += new System.EventHandler(this.txtPwd_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(131, 142);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 7;
            this.textBox2.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(131, 86);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 21);
            this.textBox3.TabIndex = 6;
            this.textBox3.TextChanged += new System.EventHandler(this.txtVcrTcpPort_TextChanged);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(131, 27);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 21);
            this.textBox4.TabIndex = 5;
            this.textBox4.TextChanged += new System.EventHandler(this.txtVcrIP_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(16, 89);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(113, 12);
            this.label16.TabIndex = 4;
            this.label16.Text = "硬盘录像机Tcp端口:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(16, 151);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 12);
            this.label17.TabIndex = 3;
            this.label17.Text = "用户名:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(16, 219);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 12);
            this.label18.TabIndex = 2;
            this.label18.Text = "密码:";
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(16, 31);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(83, 12);
            this.label19.TabIndex = 1;
            this.label19.Text = "硬盘录像机IP:";
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 462);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "SettingForm";
            this.Text = "设置窗口";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTrain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSerialNum;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDeadline;
        private System.Windows.Forms.TextBox txtInspectionInterval;
        private System.Windows.Forms.ComboBox cmbComPort;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtVcrTcpPort;
        private System.Windows.Forms.TextBox txtVcrIP;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lab;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtWebServiceUrl;
        private System.Windows.Forms.TextBox txtLocalListenPort;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtConStr;
        private System.Windows.Forms.Label labTrainErrorMsg;
        private System.Windows.Forms.Label labLocalListenPortErrorMsg;
        private System.Windows.Forms.Label labDeadlineErrorMsg;
        private System.Windows.Forms.Label labInspectionIntervalErrorMsg;
        private System.Windows.Forms.Label labIPErrorMsg;
        private System.Windows.Forms.Label labVcrTcpPortErrorMsg;
        private System.Windows.Forms.Label labSerialNumErrorMsg;
        private System.Windows.Forms.Label labPwdErrorMsg;
        private System.Windows.Forms.Label labUserNameErrorMsg;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
    }
}