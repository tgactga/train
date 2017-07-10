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
            Program.WriteLog("==========================>>进入InspectTipsForm（巡检时间到提示）页面");
            if (!Program.g_isInspected)
            {
                //巡检时间到 上传上次巡检数据
                BuildMsgUtil buildMsgUtil = new BuildMsgUtil();
                buildMsgUtil.buildXunjianData(Program.g_inspectionRecord);
            }

            Program.g_isInspected = false; //初始化
            
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
            Program.g_inspectionRecord.getStatus = "正常";

            BuildMsgUtil buildMsgUtil = new BuildMsgUtil();
            buildMsgUtil.buildXunjianData(Program.g_inspectionRecord);

            this.Close();
            return;
        }

        private void timer1_downtime_Tick(object sender, EventArgs e)
        {
            if (this.count == 0)
            {
                Program.WriteLog("未检");
                timer1_downtime.Enabled = false;
                Program.g_inspectionRecord.getStatus = "未检";
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
