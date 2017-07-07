namespace TrainRemoteControl
{
    partial class MDIParent1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            try
            {
                base.Dispose(disposing);
            }
            catch (System.Exception)
            {

                return;
            }
            
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIParent1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelpsw = new System.Windows.Forms.Label();
            this.btnTerminalTemp = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lbtitle = new System.Windows.Forms.Label();
            this.baojing = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.welcome = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.Label();
            this.lbname = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.labelpsw);
            this.panel1.Controls.Add(this.btnTerminalTemp);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lbtitle);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(796, 50);
            this.panel1.TabIndex = 4;
            // 
            // labelpsw
            // 
            this.labelpsw.Location = new System.Drawing.Point(3, 0);
            this.labelpsw.Name = "labelpsw";
            this.labelpsw.Size = new System.Drawing.Size(94, 40);
            this.labelpsw.TabIndex = 12;
            this.labelpsw.Text = "※";
            this.labelpsw.Click += new System.EventHandler(this.labelpsw_Click);
            // 
            // btnTerminalTemp
            // 
            this.btnTerminalTemp.Location = new System.Drawing.Point(560, 10);
            this.btnTerminalTemp.Name = "btnTerminalTemp";
            this.btnTerminalTemp.Size = new System.Drawing.Size(75, 30);
            this.btnTerminalTemp.TabIndex = 11;
            this.btnTerminalTemp.Text = "端子温度";
            this.btnTerminalTemp.UseVisualStyleBackColor = true;
            this.btnTerminalTemp.Click += new System.EventHandler(this.btnTerminalTemp_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(398, 10);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 30);
            this.button4.TabIndex = 10;
            this.button4.Text = "数据库";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 30);
            this.button2.TabIndex = 8;
            this.button2.Text = "系统设置";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(479, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "巡检作业";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // lbtitle
            // 
            this.lbtitle.AutoSize = true;
            this.lbtitle.Font = new System.Drawing.Font("新宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbtitle.ForeColor = System.Drawing.Color.DimGray;
            this.lbtitle.Location = new System.Drawing.Point(98, 12);
            this.lbtitle.Name = "lbtitle";
            this.lbtitle.Size = new System.Drawing.Size(292, 29);
            this.lbtitle.TabIndex = 0;
            this.lbtitle.Text = "发电车远程控制系统";
            // 
            // baojing
            // 
            this.baojing.AutoSize = true;
            this.baojing.BackColor = System.Drawing.Color.Transparent;
            this.baojing.Location = new System.Drawing.Point(351, 9);
            this.baojing.Name = "baojing";
            this.baojing.Size = new System.Drawing.Size(53, 12);
            this.baojing.TabIndex = 3;
            this.baojing.Text = "报警确认";
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.baojing);
            this.panel3.Controls.Add(this.welcome);
            this.panel3.Controls.Add(this.username);
            this.panel3.Controls.Add(this.lbname);
            this.panel3.Location = new System.Drawing.Point(1, 49);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(796, 30);
            this.panel3.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(696, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "首页";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(461, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "label3";
            // 
            // welcome
            // 
            this.welcome.AutoSize = true;
            this.welcome.BackColor = System.Drawing.Color.Transparent;
            this.welcome.Location = new System.Drawing.Point(169, 9);
            this.welcome.Name = "welcome";
            this.welcome.Size = new System.Drawing.Size(137, 12);
            this.welcome.TabIndex = 2;
            this.welcome.Text = "您好，欢迎使用本系统！";
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.BackColor = System.Drawing.Color.Transparent;
            this.username.Location = new System.Drawing.Point(95, 9);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(17, 12);
            this.username.TabIndex = 1;
            this.username.Text = "xx";
            this.username.Visible = false;
            // 
            // lbname
            // 
            this.lbname.AutoSize = true;
            this.lbname.BackColor = System.Drawing.Color.Transparent;
            this.lbname.Location = new System.Drawing.Point(44, 9);
            this.lbname.Name = "lbname";
            this.lbname.Size = new System.Drawing.Size(53, 12);
            this.lbname.TabIndex = 0;
            this.lbname.Text = "用户名：";
            this.lbname.Visible = false;
            // 
            // MDIParent1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(794, 631);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MDIParent1";
            this.Text = "武汉里瑞工程贸易有限公司";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MDIParent1_FormClosing);
            this.Load += new System.EventHandler(this.MDIParent1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbtitle;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label username;
        private System.Windows.Forms.Label lbname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label baojing;
        private System.Windows.Forms.Label welcome;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnTerminalTemp;
        private System.Windows.Forms.Label labelpsw;
    }
}



