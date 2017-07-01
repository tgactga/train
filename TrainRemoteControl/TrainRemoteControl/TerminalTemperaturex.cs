using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace TrainRemoteControl
{
    public partial class TerminalTemperaturex : Form
    {
        private WindowsFormsSynchronizationContext windowSyncContext = new WindowsFormsSynchronizationContext();
        private SendOrPostCallback postCallBak;
        private Image redCircle = TrainRemoteControl.Properties.Resources.circl;// Image.FromFile( @"..\..\image\red.png" );//: @"..\..\image\green.png";
        private Image greenCircle = TrainRemoteControl.Properties.Resources.green;//Image.FromFile(@"..\..\image\green.png");
        
        Label[] lbTemperature;
        Label[] lbStatus;
        PictureBox[] pbAlarm;


        public TerminalTemperaturex()
        {
            InitializeComponent();
        }

        //protected override void OnActivated(EventArgs e)
        //{
        //    //注册同步上下文调用委托委托
        //    postCallBak += showTempData;
        //    //MDIParent1.dam.SetShowTerminalTemperature(windowSyncContext, postCallBak);           
        //    base.OnActivated(e);
        //}

        //protected override void OnDeactivate(EventArgs e)
        //{
        //    postCallBak -= showTempData;
        //    base.OnDeactivate(e);
        //}

        private void TerminalTemperature_FormClosed(object sender, FormClosedEventArgs e)
        {
            //postCallBak -= showTempData;
        }

        private void TerminalTemperature_Load(object sender, EventArgs e)
        {
            this.Top = 80;
            this.Left = 0;

            #region 控件集合
            lbTemperature = new Label[] 
            {   label34, label43, 
                label46,label48, 
                label49, label51, 
                label58, label60, 
                label61, label63, 
                label68, label70, 
                label35, label235, label236,

                label136,label135,
                label134,label133,
                label132,label131,
                label130,label129,
                label128,label127,
                label126,label125,
                label167,label237,label238,

                label203,label202,
                label201,label200,
                label199,label198,
                label197,label196,
                label195,label194,
                label193,label192,
                label234,label239,label240,

                label15,label16,label17,label18,label19,label20,
                label24,label23,label22,label21,label5,label4,
            };

            pbAlarm = new PictureBox[]
            {
                pictureBox9,pictureBox3,
                pictureBox8,pictureBox5,
                pictureBox17,pictureBox6,
                pictureBox21,pictureBox11,
                pictureBox26,pictureBox16,
                pictureBox36,pictureBox18,
                pictureBox1,pictureBox2,pictureBox4,

                pictureBox39,pictureBox25,
                pictureBox38,pictureBox24,
                pictureBox37,pictureBox23,
                pictureBox35,pictureBox22,
                pictureBox28,pictureBox20,
                pictureBox27,pictureBox19,
                pictureBox42,pictureBox41,pictureBox40,

                pictureBox54,pictureBox48,
                pictureBox53,pictureBox47,
                pictureBox52,pictureBox46,
                pictureBox51,pictureBox45,
                pictureBox50,pictureBox44,
                pictureBox49,pictureBox43,
                pictureBox57,pictureBox56,pictureBox55,

                pictureBox34,pictureBox33,pictureBox29,pictureBox32,pictureBox30,pictureBox31,
                pictureBox15,pictureBox14,pictureBox13,pictureBox12,pictureBox10,pictureBox7
            };

            lbStatus = new Label[]
            {
                label241,label247,
                label242,label248,
                label243,label249,
                label244,label250,
                label245,label251,
                label246,label252,
                label253,label254,label255,

                label256,label262,
                label257,label263,
                label258,label264,
                label259,label265,
                label260,label266,
                label261,label267,
                label268,label269,label270,

                label271,label277,
                label272,label278,
                label273,label279,
                label274,label280,
                label275,label281,
                label276,label282,
                label283,label284,label285,

                label286,label287,label288,label289,label290,label291,
                label292,label293,label294,label295,label296,label297
            };
            #endregion
           

            for (int i = 0; i < lbStatus.Length; i++)
            {
                if (i < lbStatus.Length - 12)
                {
                    pbAlarm[i].Location = new Point(0, 0);
                    lbStatus[i].Location = new Point(3, 2);
                    lbStatus[i].BackColor = Color.Red;
                    lbStatus[i].SendToBack();
                }
                else
                {
                    lbStatus[i].SendToBack();
                }
                lbStatus[i].Text = "";
                lbTemperature[i].Text = "";
            }
        }


        private void timer_showtemp_Tick(object sender, EventArgs e)
        {
            if (Program.g_tempCellsTerminalList != null)
            {
                showTempData(Program.g_tempCellsTerminalList);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < pbAlarm.Length; i++)
            //{
            //    pbAlarm[i].Image = redCircle;
            //    Thread.Sleep(500);
            //    Application.DoEvents();
            //}
        }


        private void showTempData(List<CellTerminal> cells)
        {
            //List<Model.CellTerminal> cells = (List<Model.CellTerminal>)obj;

            for (int i = 0; i < cells.Count-2; i++)
            {
                lbStatus[i].Text = cells[i].s == 0 ? "" : cells[i].s.ToString();
                if (cells[i].s == 0)
                {
                    lbStatus[i].SendToBack();
                }
                else
                {
                    lbStatus[i].BringToFront();
                }

                pbAlarm[i].Image = cells[i].s == 0 ? greenCircle : redCircle;
                lbTemperature[i].Text = cells[i].t.ToString();
            }

            lbRoomTemp.Text = cells[cells.Count - 2].t.ToString();
            lbLocker.Text = cells[cells.Count - 1].t.ToString();

            label298.Text = "刷新时间：" + DateTime.Now.ToString("HH:mm:ss");
        }

        private void buttonOfdatadb_Click(object sender, EventArgs e)
        {
            new DataPageForm().Show();
            this.Close();
            return;
        }

        private void buttonOfxunjian_Click(object sender, EventArgs e)
        {
            new XunjianForm().Show();
            this.Close();
            return;
        }

        private void btnTerminalTemp_Click(object sender, EventArgs e)
        {

        }

        private void buttonOfhomepage_Click(object sender, EventArgs e)
        {
            new Main().Show();
            this.Close();
            return;

        }

       

    }
}
