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
    public partial class InputPassWordForm : Templete
    {
        public InputPassWordForm()
        {
            //this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
        }


        TextBox textBox1 = new TextBox();
        Label label4 = new Label();
        TextBox inputTarget = new TextBox();

        private void InputPassWordForm_Load(object sender, EventArgs e)
        {
            Program.WriteLog("==========================>>进入输入密码页面");
            this.label1.Top = Convert.ToInt16((this.Height - this.label1.Height) / 3.2);
            this.label1.Left = Convert.ToInt16((this.Width - this.label1.Width) / 2.65 +30);
            //输入框
            textBox1.Width = 351;
            textBox1.Height = 100;
            textBox1.Font = new Font("微软雅黑", 20);
            textBox1.RightToLeft = RightToLeft.Yes;
            textBox1.BackColor = Color.White;
            textBox1.Text = "";
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.Click += new EventHandler(textBox1_Click);
            textBox1.Top = Convert.ToInt16((this.Height - textBox1.Height) / 2.5);
            textBox1.Left = Convert.ToInt16((this.Width - textBox1.Width) / 1.99);
            this.Controls.Add(textBox1);

            //----------表单验证   文字-----------
            label4.Text = "";
            label4.AutoSize = true;
            label4.Font = new Font("微软雅黑", 14);
            label4.ForeColor = Color.Gray;
            label4.BackColor = Color.Transparent;
            label4.Top = Convert.ToInt16((this.Height - label4.Height) / 2.20);
            label4.Left = Convert.ToInt16((this.Width - label4.Width) / 2.45);
            this.Controls.Add(label4);

            this.button1.Top = Convert.ToInt16((this.Height - this.button1.Height) / 1.15);
            this.button1.Left = Convert.ToInt16((this.Width - this.button1.Width) / 1.5 + 5);


            this.button2.Top = Convert.ToInt16((this.Height - button2.Height) / 1.15);
            button2.Left = Convert.ToInt16((this.Width - button2.Width) / 2.7 - 16);

            inputTarget = textBox1;

            //软键盘
            ImageButton imageButton4 = new ImageButton();
            for (int i = 1; i < 13; i++)
            {
                imageButton4 = new ImageButton();
                string[] str = new string[i];

                imageButton4.NormalImage = Properties.Resources.Upkey;
                imageButton4.DownImage = Properties.Resources.downKey;

                if (i == 10)
                    imageButton4.Text = "清空";
                else if (i == 11)
                    imageButton4.Text = "0";
                else if (i == 12)
                    imageButton4.Text = "修改";
                else
                    imageButton4.Text = i.ToString();

                imageButton4.SizeMode = PictureBoxSizeMode.AutoSize;
                imageButton4.Font = new Font("幼圆", 18, FontStyle.Bold);
                imageButton4.ForeColor = Color.Black;
                imageButton4.BackColor = Color.Transparent;
                imageButton4.MouseClick += new MouseEventHandler(imageButton4_Click);

                double top1 = (this.Height - imageButton4.Height) / 1.95;
                // double to_top = (this.Height - top1) / 3 - imageButton4.Height;
                double left1 = (this.Width - imageButton4.Width) / 2.456;
                //double to_left = (this.Width - left1) / 3 - imageButton4.Width;

                if (i < 4)
                    imageButton4.Top = Convert.ToInt16(top1);

                else if (i < 7)
                    imageButton4.Top = Convert.ToInt16(top1 + imageButton4.Height + 2);
                else if (i < 10)
                    imageButton4.Top = Convert.ToInt16(top1 + imageButton4.Height * 2 + 4);
                else
                    imageButton4.Top = Convert.ToInt16(top1 + imageButton4.Height * 3 + 6);


                if (i == 1 || i == 4 || i == 7 || i == 10)
                    imageButton4.Left = Convert.ToInt16(left1);
                else if (i == 2 || i == 5 || i == 8 || i == 11)
                    imageButton4.Left = Convert.ToInt16(left1 + imageButton4.Width + 2);
                else if (i == 3 || i == 6 || i == 9 || i == 12)
                    imageButton4.Left = Convert.ToInt16(left1 + imageButton4.Width * 2 + 4);

                if (i == 3 || i == 6 || i == 9 || i == 12)
                    Console.WriteLine();
                this.Controls.Add(imageButton4);
            }
            
        }


        void textBox1_Click(object sender, EventArgs e)
        {

        }
        private void imageButton4_Click(object sender, EventArgs e)
        {
            ImageButton bt = (ImageButton)sender;
            if (bt.Text.Equals("修改"))
            {
                if (inputTarget.Text.Length > 0)
                {
                    inputTarget.Text = inputTarget.Text.Substring(0, inputTarget.Text.Length - 1);
                }
                else
                {
                    inputTarget.Text = "";
                }

            }
            else if (bt.Text.Equals("清空"))
            {
                inputTarget.Text = "";
            }
            else
                inputTarget.Text += bt.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ss = textBox1.Text;         
            //MessageBox.Show(ss);
            if (ss.Equals("1"))
            {
                new SettingForm().Show();
                this.Close();
                return;
            }
            else
            {
                MessageBox.Show("密码输入错误！");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Main().Show();
            this.Close();
            return;
        }


    }
}
