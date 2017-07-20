using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TrainRemoteControl.dao;

namespace TrainRemoteControl
{
    public partial class DataPageForm : Form
    {
        public DataPageForm()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 80);
            InitializeComponent();
        }
        DataTable t1 = new DataTable();
        DataTable t2 = new DataTable();
        DataTable t3 = new DataTable();
        displayCommdao dao = new displayCommdao();
        private void DataPageForm_Load(object sender, EventArgs e)
        {
            Program.WriteLog("=========================>>进入DataPageForm页面");
           
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            backgroundWorker1.RunWorkerAsync();

        }
        //private void buttonOfxunjian_Click(object sender, EventArgs e)
        //{
        //    new XunjianForm().Show();
        //    this.Hide();
        //    return;
        //}

        //private void buttonOfhomepage_Click(object sender, EventArgs e)
        //{
        //    new Main().Show();
        //    this.Hide();
        //    return;
        //}

        ////点击 端子温度
        //private void btnTerminalTemp_Click(object sender, EventArgs e)
        //{
        //    new TerminalTemperaturex().Show();
        //    this.Hide();
        //    return;
        //}

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            t1 = dao.getdjDatatable("1", 0,300); //1号机组
            t2 = dao.getdjDatatable("2", 0, 300);
            t3 = dao.getdjDatatable("3", 0, 300);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dataGridView1.DataSource = t1;
            dataGridView3.DataSource = t2;
            dataGridView5.DataSource = t3;
        }

      

        
       
    }
}
