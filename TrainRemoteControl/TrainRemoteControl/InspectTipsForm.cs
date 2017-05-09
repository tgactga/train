using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TrainRemoteControl.DAl;
using TrainRemoteControl.utilclass;

namespace TrainRemoteControl
{
    public partial class InspectTipsForm : Form
    {
        public InspectTipsForm()
        {
            InitializeComponent();
        }

        //-------------页面倒计时设置------------0
        Label label01 = new Label();
        int count = 30;

        private void InspectTipsForm_Load(object sender, EventArgs e)
        {
            Program.WriteLog("==========================>>进入InspectTipsForm页面");
            //=================================定时器====================================
            label01.Text = this.count + "";
            label01.AutoSize = true;
            label01.Font = new Font("微软雅黑", 21, FontStyle.Bold);
            label01.ForeColor = Color.White;
            label01.BackColor = Color.Transparent;
            label01.Location = new System.Drawing.Point(100, 100);
            this.Controls.Add(label01);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Program.WriteLog("点击确认巡检，上传巡检数据");
            Program.g_isInspected = true;
            Model._XJmodel inspectionRecord = new Model._XJmodel();
            inspectionRecord.getStatus = "正常";
            inspectionRecord.getRecordTime = DateTime.Now;
            inspectionRecord.getContent = "备注";
            inspectionRecord.getBjtime = DateTime.Now;
            inspectionRecord.getWorker = "张三丰";
            inspectionRecord.lcNumber = "T401";
            InspectionRecordDAL inspect = new InspectionRecordDAL();
            inspect.SaveInspectionRecord(inspectionRecord);

            //上传 数据
            WebServiceUtil.uploadInspectionRecords(inspectionRecord);
        }

        private void timer1_downtime_Tick(object sender, EventArgs e)
        {
            if (this.count == 0)
            {
                timer1_downtime.Enabled = false;                
                this.Close();
                return;
            }
            else
            {
                this.count--;
                label01.Text = this.count + "";
            }
        }

      
    }
}
