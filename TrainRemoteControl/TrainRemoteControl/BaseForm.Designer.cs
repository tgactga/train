namespace TrainRemoteControl
{
    partial class BaseForm
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
            this.components = new System.ComponentModel.Container();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2_net = new System.Windows.Forms.Timer(this.components);
            this.timer3_uploadCriticalData = new System.Windows.Forms.Timer(this.components);
            this.timer_gatherCritical = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(151, 488);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(582, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 50F);
            this.label1.Location = new System.Drawing.Point(139, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(632, 67);
            this.label1.TabIndex = 3;
            this.label1.Text = "发电车远程控制系统";
            // 
            // timer1
            // 
            this.timer1.Interval = 5;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2_net
            // 
            this.timer2_net.Enabled = true;
            this.timer2_net.Interval = 2000;
            this.timer2_net.Tick += new System.EventHandler(this.timer2_net_Tick);
            // 
            // timer3_uploadCriticalData
            // 
            this.timer3_uploadCriticalData.Interval = 60000;
            this.timer3_uploadCriticalData.Tick += new System.EventHandler(this.timer3_uploadCriticalData_Tick);
            // 
            // timer_gatherCritical
            // 
            this.timer_gatherCritical.Enabled = true;
            this.timer_gatherCritical.Interval = 1000;
            this.timer_gatherCritical.Tick += new System.EventHandler(this.timer_gatherCritical_Tick);
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TrainRemoteControl.Properties.Resources.mb1;
            this.ClientSize = new System.Drawing.Size(990, 741);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Location = new System.Drawing.Point(8, 10);
            this.Name = "BaseForm";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.BaseForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2_net;
        private System.Windows.Forms.Timer timer3_uploadCriticalData;
        private System.Windows.Forms.Timer timer_gatherCritical;
    }
}