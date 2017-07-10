using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Text;
using System.Reflection;

namespace TrainRemoteControl
{
    public delegate void UpBaojingDelegete();
    public partial class MDIParent1 : Form
    {        
        public static UpBaojingDelegete baojingDelegate;
        private int childFormNumber = 0;
      
        public MDIParent1()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        public const int WM_SYSCOMMAND = 0x112;
        public const int SC_MOVE = 0xF012;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SYSCOMMAND)
            {
                if ((int)m.WParam == SC_MOVE)
                    return;
            }

            base.WndProc(ref m);
        } 

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "窗口 " + childFormNumber++;
            childForm.Show();
        }

        //private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}
        //private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    LayoutMdi(MdiLayout.Cascade);
        //}

        //private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    LayoutMdi(MdiLayout.TileVertical);
        //}

        //private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    LayoutMdi(MdiLayout.TileHorizontal);
        //}

        //private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    LayoutMdi(MdiLayout.ArrangeIcons);
        //}

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {
            //TerminalTemperaturex tt = new TerminalTemperaturex();
            //tt.MdiParent = this;
            //tt.Show();
            Form fo2 = FindMdiChildren("TerminalTemperaturex");
            if (fo2 != null)
            {
                fo2.Show();
            }
            else
            {
                fo2 = new TerminalTemperaturex();
                fo2.MdiParent = this;
                fo2.Show();
            }
            fo2.Activate();

            Form fo = FindMdiChildren("Main");
            if (fo != null)
            {
                fo.Show();
            }
            else
            {
                fo = new Main();
                fo.MdiParent = this;
                fo.Show();
            }
            fo.Activate();

           

            this.FormClosed += new FormClosedEventHandler(MDIParent1_FormClosed);
             
        }

        public void MDIParent1_FormClosed(object sender, EventArgs e)
        {

        }
        int hour = -1;
        public void time_Elapsed(object sender, EventArgs e)
        {
            try
            {
                if (label3 != null && this != null)
                {
                    label3.Invoke((MethodInvoker)delegate
                    {
                        label3.Text = "当前时间：" + DateTime.Now.ToString();
                        label3.ForeColor = Color.Blue;
                    });

                    //第一次加载不清除
                    //每隔一小时清除一次
                    if (hour != DateTime.Now.Hour)
                    {
                        ClearMemory();
                        hour = DateTime.Now.Hour;
                    }

                }
            }
            catch (Exception ex)
            {
                return;
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form fo = FindMdiChildren("XunjianForm");
            if (fo != null)
            {
                fo.Show();
            }
            else
            {
                fo = new XunjianForm();
                fo.MdiParent = this;
                fo.Show();
            }
            fo.Activate();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SettingForm sf = new SettingForm();
            sf.ShowDialog();

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
                if (item.Name == name)
                {
                    fo = item;
                    break;
                }

            }
            return fo;
        }
        private void label1_Click(object sender, EventArgs e)
        {

            Form fo = FindMdiChildren("Main");
            if (fo != null)
            {
                fo.Show();
            }
            else
            {
                fo = new Main();
                fo.MdiParent = this;
                fo.Show();
            }
            fo.Activate();
        }

        private void btnTerminalTemp_Click(object sender, EventArgs e)
        {
            Form fo = FindMdiChildren("TerminalTemperaturex");
            if (fo != null)
            {
                fo.Show();
            }
            else
            {
                fo = new TerminalTemperaturex();
                fo.MdiParent = this;
                fo.Show();
            }
            fo.Activate();
        }  

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        //b 报警开关 触发委托；
        public class PublicSwich
        {

            private bool baojingon;
            public bool BaoJingOn
            {

                get { return baojingon; }
                set
                {
                    this.baojingon = value;
                    if (this.baojingon)
                    {

                        if (baojingDelegate != null)
                        {
                            baojingDelegate();
                        }
                    }
                    else
                    {
                        
                    }
                }
            }
        }

        #region 报警闪烁
        bool changefontcolor = false;
        System.Timers.Timer timer = new System.Timers.Timer(1000);

        private void CreateAlarmIndicatorLight()
        {
            timer.Elapsed += new System.Timers.ElapsedEventHandler((o, e) =>
            {
                if (changefontcolor)
                {
                    baojing.Invoke((MethodInvoker)delegate
                    {
                        this.baojing.Text = "";
                    });
                }
                else
                {
                    baojing.Invoke((MethodInvoker)delegate
                    {
                        this.baojing.Text = "报警确认";
                        this.baojing.ForeColor = Color.Red;
                    });
                }
                changefontcolor = !changefontcolor;

            });
           // dam.AlarmFlashContrl += new Action<bool>(AlarmIndicatorLightFlashing);
        }


        protected void AlarmIndicatorLightFlashing(bool alarmState)
        {
            if (alarmState)
            {
                timer.Start();
            }
            else
            {
                timer.Stop();
                baojing.Invoke((MethodInvoker)delegate
                {
                        this.baojing.Text = "报警确认";
                        this.baojing.ForeColor = Color.Black;
                });
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认关闭本系统并关机！", "关机", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Thread thread = new Thread(() =>
                {
                    System.Diagnostics.Process myProcess = new System.Diagnostics.Process();
                    System.Diagnostics.Process.Start("shutdown.exe", "-s -t 5");
                    Application.Exit();
                });
                thread.Start();
            }
        }


        int iCount = 0;
        private void ShutDown(bool off)
        {
            if (off)
            {
                if (iCount > 29)
                {
                    Thread thread = new Thread(() =>
                        {
                            System.Diagnostics.Process myProcess = new System.Diagnostics.Process();
                            System.Diagnostics.Process.Start("shutdown.exe", "-s -t 5");
                            Application.Exit();
                        });
                    thread.Start();
                }
                else
                {
                    iCount++;
                }
            }
            else
                iCount = 0;           
        }

        #endregion


        private void button4_Click(object sender, EventArgs e)
        {
            Form fo = FindMdiChildren("DataPageForm");
            if (fo != null)
            {
                fo.Show();
            }
            else
            {
                fo = new DataPageForm();
                fo.MdiParent = this;
                fo.Show();
            }
            fo.Activate();
        }

        #region 内存回收
        [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
        public static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
        /// <summary>
        /// 释放内存
        /// </summary>
        public static void ClearMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }
        #endregion

        private void MDIParent1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //hook.UninstallKeyBoardHook();                
            }
            catch (System.Exception ex)
            {
                //Utility.FileOperation.WriteLog("[Hook][" + DateTime.Now.ToString() + "]   " + ex.Message + "。Hook关闭错误");              
            }
        }

        private void labelpsw_Click(object sender, EventArgs e)
        {
            Form fo = FindMdiChildren("InputPassWordForm");
            if (fo != null)
            {
                fo.Show();
            }
            else
            {
                fo = new InputPassWordForm();
                fo.MdiParent = this;
                fo.Show();
            }
            
        }


         
    }

     
}
