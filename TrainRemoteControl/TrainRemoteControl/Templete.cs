using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrainRemoteControl
{
    public partial class Templete : Form
    {       
        public void Show()
        {
            if (Program.singleForm != null && !Program.singleForm.IsDisposed)
            {
                try
                {
                    Program.singleForm.Close();
                    Program.singleForm = null;
                }
                catch (Exception e)
                {
                    Program.WriteLog(e.ToString());
                }
            }
            this.Size = new Size(1024, 715);
            //this.WindowState = FormWindowState.Maximized;
            this.Text = "武汉里瑞工贸有限公司";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(8, 10);
            Program.singleForm = this;
            base.Show();
            Program.WriteLog("Program.singleForm:" + Program.singleForm.Name);
        }

        public void ShowDialog()
        {
            if (Program.singleForm != null && !Program.singleForm.IsDisposed)
            {
                try
                {
                    Program.singleForm.Close();
                    Program.singleForm = null;
                }
                catch (Exception e)
                {
                    Program.WriteLog(e.ToString());
                }
            }
            this.Text = "武汉里瑞工贸有限公司";
            this.StartPosition = FormStartPosition.Manual;
                      
            this.Location = new Point(8, 100);
            Program.singleForm = this;
            base.ShowDialog();
            Program.WriteLog("Program.singleForm:" + Program.singleForm.Name);
        }
        
    }
}
