namespace TrainRemoteControl
{
    partial class XunJianTipsForm
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
            this.timer1_downtime = new System.Windows.Forms.Timer(this.components);
            this.xunjian_timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timer1_downtime
            // 
            this.timer1_downtime.Enabled = true;
            this.timer1_downtime.Tick += new System.EventHandler(this.timer1_downtime_Tick);
            // 
            // xunjian_timer
            // 
            this.xunjian_timer.Enabled = true;
            // 
            // XunJianTipsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "XunJianTipsForm";
            this.Text = "XunJianTipsForm";
            this.Load += new System.EventHandler(this.XunJianTipsForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1_downtime;
        private System.Windows.Forms.Timer xunjian_timer;
    }
}