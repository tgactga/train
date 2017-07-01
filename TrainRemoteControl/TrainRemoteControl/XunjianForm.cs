using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TrainRemoteControl.DAl;

namespace TrainRemoteControl
{
    public partial class XunjianForm : Form
    {
        private InspectionRecordDAL dal = new InspectionRecordDAL();
        public XunjianForm()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            InitializeComponent();
        }

        private void XunjianForm_Load(object sender, EventArgs e)
        {
            Program.WriteLog("==========================>>进入XunjianForm（巡检）界面");
            this.Top = 80;
            this.Left = 0;
            //this.label3.Text = "0002";  //车体名称
            dateTimePicker1.Value = DateTime.Now.AddDays(-7);
           this.dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //设置居中
        }

        private void buttonOfdatadb_Click(object sender, EventArgs e)
        {
            new DataPageForm().Show();
            this.Close();
            return;
        }

        //点击 端子温度
        private void btnTerminalTemp_Click(object sender, EventArgs e)
        {
            new TerminalTemperaturex().Show();
            this.Close();
            return;
        }

        private void buttonOfhomepage_Click(object sender, EventArgs e)
        {
            new Main().Show();
            this.Close();
            return;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.dateTimePicker1.Value > this.dateTimePicker2.Value)
            {
                MessageBox.Show(" 不存在该查询区间");
            }
            else
            {
                dataGridView1.DataSource = dal.GetInspectionRecordsByDate(this.dateTimePicker1.Value, this.dateTimePicker2.Value);
                dataGridView1.Columns["getRecordTime"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                dataGridView1.Columns["getBjtime"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

                dataGridView1.Columns[0].HeaderText = "车次";
                dataGridView1.Columns[1].HeaderText = "巡检状态";
                dataGridView1.Columns[2].HeaderText = "计划巡检时间";
                dataGridView1.Columns[2].Width = 140;
                dataGridView1.Columns[3].HeaderText = "巡检时间";
                dataGridView1.Columns["getRecordTime"].Width = 140;
                dataGridView1.Columns[4].HeaderText = "工作人员";
                dataGridView1.Columns[5].HeaderText = "备注";
            }
        }

        private void buttonOfxunjian_Click(object sender, EventArgs e)
        {

        }

       
    }
}
