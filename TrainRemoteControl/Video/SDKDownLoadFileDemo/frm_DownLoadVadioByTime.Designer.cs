namespace SDKDownLoadFileDemo
{
    partial class frm_DownLoadVadioByTime
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
            this.grbMain = new System.Windows.Forms.GroupBox();
            this.txtFileName2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDirSelect = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDirPath2 = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.psbMain = new System.Windows.Forms.ToolStripProgressBar();
            this.cmbChannelSelect = new System.Windows.Forms.ComboBox();
            this.txtTimeEnd = new System.Windows.Forms.TextBox();
            this.txtTimeStart = new System.Windows.Forms.TextBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtChannelID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDevName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.grbMain.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbMain
            // 
            this.grbMain.Controls.Add(this.label7);
            this.grbMain.Controls.Add(this.txtFileName2);
            this.grbMain.Controls.Add(this.label5);
            this.grbMain.Controls.Add(this.btnDirSelect);
            this.grbMain.Controls.Add(this.label6);
            this.grbMain.Controls.Add(this.txtDirPath2);
            this.grbMain.Controls.Add(this.statusStrip1);
            this.grbMain.Controls.Add(this.cmbChannelSelect);
            this.grbMain.Controls.Add(this.txtTimeEnd);
            this.grbMain.Controls.Add(this.txtTimeStart);
            this.grbMain.Controls.Add(this.dtpEnd);
            this.grbMain.Controls.Add(this.dtpStart);
            this.grbMain.Controls.Add(this.btnCancel);
            this.grbMain.Controls.Add(this.btnOK);
            this.grbMain.Controls.Add(this.label4);
            this.grbMain.Controls.Add(this.txtChannelID);
            this.grbMain.Controls.Add(this.label3);
            this.grbMain.Controls.Add(this.label2);
            this.grbMain.Controls.Add(this.txtDevName);
            this.grbMain.Controls.Add(this.label1);
            this.grbMain.Location = new System.Drawing.Point(12, 12);
            this.grbMain.Name = "grbMain";
            this.grbMain.Size = new System.Drawing.Size(678, 301);
            this.grbMain.TabIndex = 2;
            this.grbMain.TabStop = false;
            // 
            // txtFileName2
            // 
            this.txtFileName2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtFileName2.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.txtFileName2.Location = new System.Drawing.Point(139, 175);
            this.txtFileName2.Name = "txtFileName2";
            this.txtFileName2.Size = new System.Drawing.Size(409, 21);
            this.txtFileName2.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.Location = new System.Drawing.Point(23, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "录像保存文件名：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnDirSelect
            // 
            this.btnDirSelect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDirSelect.Location = new System.Drawing.Point(554, 136);
            this.btnDirSelect.Name = "btnDirSelect";
            this.btnDirSelect.Size = new System.Drawing.Size(90, 21);
            this.btnDirSelect.TabIndex = 21;
            this.btnDirSelect.Text = "目录选择";
            this.btnDirSelect.UseVisualStyleBackColor = true;
            this.btnDirSelect.Click += new System.EventHandler(this.btnDirSelect_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.Location = new System.Drawing.Point(23, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 16);
            this.label6.TabIndex = 20;
            this.label6.Text = "录像保存目录：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDirPath2
            // 
            this.txtDirPath2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDirPath2.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.txtDirPath2.Location = new System.Drawing.Point(139, 136);
            this.txtDirPath2.Name = "txtDirPath2";
            this.txtDirPath2.Size = new System.Drawing.Size(409, 21);
            this.txtDirPath2.TabIndex = 19;
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.psbMain});
            this.statusStrip1.Location = new System.Drawing.Point(3, 274);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(672, 24);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(56, 19);
            this.toolStripStatusLabel1.Text = "下载进度";
            // 
            // psbMain
            // 
            this.psbMain.Name = "psbMain";
            this.psbMain.Size = new System.Drawing.Size(600, 18);
            this.psbMain.Step = 1;
            this.psbMain.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // cmbChannelSelect
            // 
            this.cmbChannelSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChannelSelect.FormattingEnabled = true;
            this.cmbChannelSelect.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.cmbChannelSelect.Location = new System.Drawing.Point(87, 70);
            this.cmbChannelSelect.Name = "cmbChannelSelect";
            this.cmbChannelSelect.Size = new System.Drawing.Size(101, 20);
            this.cmbChannelSelect.TabIndex = 16;
            this.cmbChannelSelect.SelectedIndexChanged += new System.EventHandler(this.cmbChannelSelect_SelectedIndexChanged);
            // 
            // txtTimeEnd
            // 
            this.txtTimeEnd.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.txtTimeEnd.Location = new System.Drawing.Point(492, 66);
            this.txtTimeEnd.Name = "txtTimeEnd";
            this.txtTimeEnd.Size = new System.Drawing.Size(56, 21);
            this.txtTimeEnd.TabIndex = 15;
            this.txtTimeEnd.Text = "12:01:01";
            // 
            // txtTimeStart
            // 
            this.txtTimeStart.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.txtTimeStart.Location = new System.Drawing.Point(492, 18);
            this.txtTimeStart.Name = "txtTimeStart";
            this.txtTimeStart.Size = new System.Drawing.Size(56, 21);
            this.txtTimeStart.TabIndex = 14;
            this.txtTimeStart.Text = "12:01:01";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(382, 66);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(108, 21);
            this.dtpEnd.TabIndex = 13;
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(382, 18);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(108, 21);
            this.dtpStart.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(169, 231);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 26);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(34, 231);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(70, 26);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "确认";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(301, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "结束时间:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtChannelID
            // 
            this.txtChannelID.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.txtChannelID.Location = new System.Drawing.Point(194, 70);
            this.txtChannelID.Name = "txtChannelID";
            this.txtChannelID.Size = new System.Drawing.Size(45, 21);
            this.txtChannelID.TabIndex = 5;
            this.txtChannelID.Text = "0";
            this.txtChannelID.Visible = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(297, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "开始时间:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(2, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "通道ID:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDevName
            // 
            this.txtDevName.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.txtDevName.Location = new System.Drawing.Point(87, 22);
            this.txtDevName.Name = "txtDevName";
            this.txtDevName.Size = new System.Drawing.Size(123, 21);
            this.txtDevName.TabIndex = 1;
            this.txtDevName.Text = "test";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "设备名:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(412, 245);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 24;
            this.label7.Text = "label7";
            // 
            // frm_DownLoadVadioByTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 315);
            this.Controls.Add(this.grbMain);
            this.Name = "frm_DownLoadVadioByTime";
            this.Text = "视频快捷导出";
            this.Load += new System.EventHandler(this.frm_DownLoadVadioByTime_Load);
            this.grbMain.ResumeLayout(false);
            this.grbMain.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbMain;
        public System.Windows.Forms.ComboBox cmbChannelSelect;
        public System.Windows.Forms.TextBox txtTimeEnd;
        public System.Windows.Forms.TextBox txtTimeStart;
        public System.Windows.Forms.DateTimePicker dtpEnd;
        public System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.FolderBrowserDialog fbdMain;
        public System.Windows.Forms.TextBox txtChannelID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtDevName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar psbMain;
        private System.Windows.Forms.TextBox txtFileName2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDirSelect;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDirPath2;
        private System.Windows.Forms.Label label7;
    }
}