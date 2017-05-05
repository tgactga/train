namespace TrainRemoteControl
{
    partial class DataPageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataPageForm));
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridView5 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTerminalTemp = new System.Windows.Forms.Button();
            this.buttonOfdatadb = new System.Windows.Forms.Button();
            this.buttonOfhomepage = new System.Windows.Forms.Button();
            this.buttonOfxunjian = new System.Windows.Forms.Button();
            this.lbtitle = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "label4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(3, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "车号:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(3, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "车次:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabControl1.Location = new System.Drawing.Point(5, 58);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(58, 10);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(985, 617);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(158)));
            this.tabPage1.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tabPage1.Location = new System.Drawing.Point(4, 36);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(977, 577);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "一号电机报表";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(962, 534);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView3);
            this.tabPage2.Location = new System.Drawing.Point(4, 36);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(977, 537);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "二号电机报表";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(6, 6);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowTemplate.Height = 23;
            this.dataGridView3.Size = new System.Drawing.Size(775, 375);
            this.dataGridView3.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridView5);
            this.tabPage3.Location = new System.Drawing.Point(4, 36);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(977, 537);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "三号电机报表";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView5
            // 
            this.dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView5.Location = new System.Drawing.Point(6, 6);
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.RowTemplate.Height = 23;
            this.dataGridView5.Size = new System.Drawing.Size(778, 378);
            this.dataGridView5.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnTerminalTemp);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.buttonOfdatadb);
            this.panel1.Controls.Add(this.buttonOfhomepage);
            this.panel1.Controls.Add(this.buttonOfxunjian);
            this.panel1.Controls.Add(this.lbtitle);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(992, 50);
            this.panel1.TabIndex = 6;
            // 
            // btnTerminalTemp
            // 
            this.btnTerminalTemp.Location = new System.Drawing.Point(667, 10);
            this.btnTerminalTemp.Name = "btnTerminalTemp";
            this.btnTerminalTemp.Size = new System.Drawing.Size(75, 30);
            this.btnTerminalTemp.TabIndex = 11;
            this.btnTerminalTemp.Text = "端子温度";
            this.btnTerminalTemp.UseVisualStyleBackColor = true;
            this.btnTerminalTemp.Click += new System.EventHandler(this.btnTerminalTemp_Click);
            // 
            // buttonOfdatadb
            // 
            this.buttonOfdatadb.Location = new System.Drawing.Point(505, 10);
            this.buttonOfdatadb.Name = "buttonOfdatadb";
            this.buttonOfdatadb.Size = new System.Drawing.Size(75, 30);
            this.buttonOfdatadb.TabIndex = 10;
            this.buttonOfdatadb.Text = "数据库";
            this.buttonOfdatadb.UseVisualStyleBackColor = true;
            // 
            // buttonOfhomepage
            // 
            this.buttonOfhomepage.Location = new System.Drawing.Point(755, 10);
            this.buttonOfhomepage.Name = "buttonOfhomepage";
            this.buttonOfhomepage.Size = new System.Drawing.Size(75, 30);
            this.buttonOfhomepage.TabIndex = 1;
            this.buttonOfhomepage.Text = "首页";
            this.buttonOfhomepage.UseVisualStyleBackColor = true;
            this.buttonOfhomepage.Click += new System.EventHandler(this.buttonOfhomepage_Click);
            // 
            // buttonOfxunjian
            // 
            this.buttonOfxunjian.Location = new System.Drawing.Point(586, 10);
            this.buttonOfxunjian.Name = "buttonOfxunjian";
            this.buttonOfxunjian.Size = new System.Drawing.Size(75, 30);
            this.buttonOfxunjian.TabIndex = 1;
            this.buttonOfxunjian.Text = "巡检作业";
            this.buttonOfxunjian.UseVisualStyleBackColor = true;
            this.buttonOfxunjian.Click += new System.EventHandler(this.buttonOfxunjian_Click);
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
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // DataPageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 687);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "DataPageForm";
            this.Text = "DataPageForm";
            this.Load += new System.EventHandler(this.DataPageForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnTerminalTemp;
        private System.Windows.Forms.Button buttonOfdatadb;
        private System.Windows.Forms.Button buttonOfhomepage;
        private System.Windows.Forms.Button buttonOfxunjian;
        private System.Windows.Forms.Label lbtitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridView5;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}