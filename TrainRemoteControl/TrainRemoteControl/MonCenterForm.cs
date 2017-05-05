using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TrainRemoteControl.Model;
 

namespace TrainRemoteControl
{
    public partial class MonCenterForm : Templete
    {      
        public MonCenterForm()
        {            
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
            InitializeComponent();
            //this.FormClosing += new FormClosingEventHandler(MonCenterForm_FormClosing);
            
        }
        private void MonCenterForm_Load(object sender, EventArgs e)
        {
            Program.WriteLog("==========================>>进入MonCenterForm页面");
            

        }
       


        



        
    }
}
