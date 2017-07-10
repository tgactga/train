using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrainRemoteControl.test
{
    public partial class TestMoreWindows : Form
    {
        public TestMoreWindows()
        {
            InitializeComponent();
            
        }
         
        private void TestMoreWindows_Load(object sender, EventArgs e)
        {
            TestForm1   t1 = new TestForm1();
            t1.MdiParent = this;
            t1.Show();

            TestForm1 t2 = new TestForm1();
            t2.MdiParent = this;
            t2.Show();  
        }
  

        //切换到窗口1
        private void button1_Click(object sender, EventArgs e)
        {

            Form fo = FindMdiChildren("TestForm1");
            if (fo != null)
            {
                fo.Show();
             }
            else
            {
                fo = new TestForm1();
                fo.MdiParent = this;
                fo.Show();
            }
            fo.Activate();
        }
 
               
         //切换到窗口2
        private void button2_Click(object sender, EventArgs e)
        {
            Form fo = FindMdiChildren("TestForm2");
            if (fo != null)
            {
                fo.Show();
            }
            else
            {
                fo = new TestForm2();
                fo.MdiParent = this;
                fo.Show();
            }
            fo.Activate();

        }


         /// <summary>
        /// 根据窗体名获取相应窗体对象
        /// </summary>
        /// <param name="name">string</param>
        /// <returns>Form</returns>
        public Form FindMdiChildren(string name)
        {
            Form fo = null;
            foreach (Form item in this.MdiChildren)
            {
               
                if (item.Text == name)
                {
                    fo = item;
                    break;
                }

            }
            return fo;
        }



    }
}