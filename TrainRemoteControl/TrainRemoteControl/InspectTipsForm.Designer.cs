namespace TrainRemoteControl
{
    partial class InspectTipsForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.inspectTipslabel = new System.Windows.Forms.Label();
            this.timer1_downtime = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(175, 283);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 63);
            this.button1.TabIndex = 0;
            this.button1.Text = "确认巡检";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // inspectTipslabel
            // 
            this.inspectTipslabel.AutoSize = true;
            this.inspectTipslabel.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.inspectTipslabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.inspectTipslabel.Location = new System.Drawing.Point(171, 135);
            this.inspectTipslabel.Name = "inspectTipslabel";
            this.inspectTipslabel.Size = new System.Drawing.Size(120, 21);
            this.inspectTipslabel.TabIndex = 1;
            this.inspectTipslabel.Text = "巡检时间到";
            // 
            // timer1_downtime
            // 
            this.timer1_downtime.Tick += new System.EventHandler(this.timer1_downtime_Tick);
            // 
            // InspectTipsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 358);
            this.Controls.Add(this.inspectTipslabel);
            this.Controls.Add(this.button1);
            this.Name = "InspectTipsForm";
            this.Text = "InspectTipsForm";
            this.Load += new System.EventHandler(this.InspectTipsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label inspectTipslabel;
        private System.Windows.Forms.Timer timer1_downtime;
    }
}