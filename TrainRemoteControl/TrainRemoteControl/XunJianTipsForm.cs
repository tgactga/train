using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TrainRemoteControl.utilclass;
using TrainRemoteControl.BLL;
using System.Timers;

namespace TrainRemoteControl
{
    public partial class XunJianTipsForm : Templete
    {
        public XunJianTipsForm()
        {
            InitializeComponent();
            this.Size = new Size(500, 425);            
            this.Text = "巡检提示";
            //this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(120,  120);
        }
        //DataAcquisitionManager dataAcquisitionMana = new DataAcquisitionManager();
        DataAcquisition da = new DataAcquisition();
        Label label01 = new Label();
        int count = 600;
        private void XunJianTipsForm_Load(object sender, EventArgs e)
        {
            Program.WriteLog("==========================>>进入InspectTipsForm（巡检时间到提示）页面");
            Program.g_isShowInspectTipsForm = true;
            if (!Program.g_isInspected)    // 未巡检的时候 上传（如果点击了巡检 直接上传了巡检数据）
            {
                //巡检时间到 上传上次巡检数据
                BuildMsgUtil buildMsgUtil = new BuildMsgUtil();
                buildMsgUtil.buildXunjianData(Program.g_inspectionRecord);
            }

            Program.g_isInspected = false; //初始化

            //蜂鸣器长鸣3s提醒用户巡检时间已到
            da.StartAlarm();
            System.Timers.Timer tt =  new System.Timers.Timer(3000);
            tt.AutoReset = false;
            tt.Enabled = true;
            tt.Elapsed += new System.Timers.ElapsedEventHandler((object sender1, ElapsedEventArgs e1) =>
            {
                da.StopAlarm();
            });

            Label label1 = new Label();
            label1.Text =  "巡检时间到，请巡检";
            label1.AutoSize = true;
            label1.Font = new Font("微软雅黑", 21, FontStyle.Bold);
            label1.ForeColor = Color.Red;
            label1.BackColor = Color.Transparent;
            label1.Location = new System.Drawing.Point(30, 140);
            this.Controls.Add(label1);

            da.StartFlash();
            //点亮巡检灯，通知用户巡检已经完成，5s后关闭巡检灯
            System.Timers.Timer timer = new System.Timers.Timer(5000);
            timer.AutoReset = false;
            timer.Enabled = true;
            timer.Elapsed += new System.Timers.ElapsedEventHandler((object sender1, ElapsedEventArgs e1) =>
            {
                da.StopFlash();
            });
        }

        private void timer1_downtime_Tick(object sender, EventArgs e)
        {
            //判断是否按 下巡检 的按钮


            if (Program.g_isInspected)
            {
                timer1_downtime.Enabled = false;
                //上次巡检数据，关闭巡检界面
                Program.g_isShowInspectTipsForm = false;
                this.Close();
                return;
            }

            if (this.count == 0)
            {
                Program.WriteLog("未检");
                timer1_downtime.Enabled = false;
                Program.g_inspectionRecord.getStatus = "未检";
                Program.g_isShowInspectTipsForm = false;
                this.Close();
                return;
            }
            else
            {
                this.count--;
            }
             
        }
    }
}
