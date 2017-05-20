using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TrainRemoteControl.utilclass;
using TrainRemoteControl.Model;
using TrainRemoteControl.BLL;

namespace TrainRemoteControl
{
    public partial class BaseForm : Form
    {
        private int timeCount = 1;
        public BaseForm()
        {
            InitializeComponent();
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            Program.WriteLog("==========================>>进入BaseForm页面");

            timer1.Start();
            string startTime =  "50";
            timeCount = int.Parse(startTime);

            this.timer3_uploadCriticalData.Enabled = true;

            deletOverTimelogs();
        }

       
        private void timer1_Tick(object sender, EventArgs e)
        {
            --timeCount;
            progressBar1.Value += 2;
            if (timeCount == 0)
            {
                timer1.Stop();
                new Main().Show();              
                this.Hide();
            }
        }

        //检测网络状态
        private void timer2_net_Tick(object sender, EventArgs e)
        {
          Program.g_isNetState =  WebServiceUtil.urlIsReach(Program.g_url);
        }

        
        private void timer3_uploadCriticalData_Tick(object sender, EventArgs e)
        {
            Program.g_isNetState = true;
            if (Program.g_isNetState)
            {              
                //Program.WriteLog("查询要上传的关键数据");
                CriticalDataBLL bll = new CriticalDataBLL();
               List<CriticalData> criticalList =  bll.SelectCricialData(Program.g_lcNumber, "1");

               if (criticalList != null && criticalList.Count > 1)
               {
                   Program.WriteLog("上传关键数据");
                   string uploadRet = WebServiceUtil.uploadCriticalData(criticalList);
                   if ("".Equals(uploadRet))
                   {
                       Program.WriteLog("更新关键数据的状态");
                       bll.updateCriticalData(criticalList);

                   }
               }

                //foreach (CriticalData cd in criticalList)
                //{
                
                //     WebServiceUtil.uploadCriticalData(cd);
                //}
            }

        }

        private void deletOverTimelogs()
        {
            //得到D:\javafzxt\Logs"文件夹下所有 
            DirectoryInfo di = new DirectoryInfo(@"D:\train\Logs");
            FileInfo[] fi = di.GetFiles("*.log");

            String shumu = fi.Length.ToString();// 文件的个数
            Program.WriteLog("过期的文件数目：" + shumu);
            DateTime dtNow = DateTime.Now;

            //MiniForm mini = new MiniForm();
            //mini.MiniMizeAppication("cmd");

            foreach (FileInfo tmpfi in fi)
            {
                if (tmpfi.Name != "1.log")
                {
                    //tmpfi.CreationTime;//创建时间
                    TimeSpan ts = dtNow.Subtract(tmpfi.LastWriteTime);
                    if (ts.TotalDays > 7)//距现在30分钟以上    TotalMinutes
                    {
                        tmpfi.Delete();//删除文件
                    }

                }
            }
            Program.WriteLog("成功删除7天之前的日志文件文件");
        }


    }
}
