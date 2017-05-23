using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using DHNetSDK;                         //大华网络SDK(C#)
 

namespace DaHuaNetSDKSample
{
    public delegate void ActiveVadioHandle();
    public partial class SingleVideoDisplayForm : Form
    {
        public static ActiveVadioHandle activevadioHandle;
        #region << 变量定义 >>
        /// <summary>
        /// 设备用户登录ＩＤ
        /// </summary>
        private int pLoginID;
        /// <summary>
        /// 程序消息提示Title
        /// </summary>
        private const string pMsgTitle = "武汉里瑞视频监控系统";
        /// <summary>
        /// 最后操作信息显示格式
        /// </summary>
        private const string pErrInfoFormatStyle = "代码:errcode;\n描述:errmSG.";
        /// <summary>
        /// 当前回放的文件信息
        /// </summary>
        NET_RECORDFILE_INFO fileInfo;
        /// <summary>
        /// 播放方式
        /// </summary>
        private int playBy = 0;
        /// <summary>
        /// 实时播放句柄保存
        /// </summary>
        private int pRealPlayHandle;
        /// <summary>
        /// 回放句柄保存
        /// </summary>
        private int[] pPlayBackHandle;
        /// <summary>
        /// 回放通道号
        /// </summary>
        private int pPlayBackChannelID;
        /// <summary>
        /// 上次点击的PictureBox控件
        /// </summary>
        private PictureBox oldPicRealPlay;
        /// <summary>
        /// 当前点击的PictureBox控件
        /// </summary>
        private PictureBox picRealPlay;
        //private fDisConnect disConnect;
        //private NET_DEVICEINFO deviceInfo;
        //int UpComputerPort = 60000;
        //ushort LowerComputerport = 60000;
        public string strStart = StringUtil.ConvertString("一号电机实时监视开始");
        public string strStop = StringUtil.ConvertString("二号电机实时监视结束");

        string IP;
        ushort Port;
        string Username;
        string Password;
        int b;
        #endregion
        public SingleVideoDisplayForm()
        {
            InitializeComponent();
        }
        public SingleVideoDisplayForm(string a, ushort b, string c, string d, int e)
        {
            this.IP = a;
            this.Port = b;
            this.Username = c;
            this.Password = d;
            this.b = e;
            InitializeComponent();

        }
        private void SingleVideoDisplayForm_Load(object sender, EventArgs e)
        {

            picRealPlay1.Visible = false;
            picRealPlay2.Visible = false;
            picRealPlay3.Visible = false;
            picRealPlay4.Visible = false;
            picRealPlay5.Visible = false;
            picRealPlay6.Visible = false;

            switch (b)
            {
                case 0: groupBox1.Text = "一号电机视频监控"; break;
                case 1: groupBox1.Text = "二号电机视频监控"; break;
                case 2: groupBox1.Text = "三号电机视频监控"; break;
                case 3: groupBox1.Text = "控制室视频监控"; break;
                case 4: groupBox1.Text = "过道视频监控"; break;
                default:
                    break;
            }


            int[] pPlayBackHandle;

            NET_DEVICEINFO deviceInfo;
            fDisConnect disConnect;

            disConnect = new fDisConnect(DisConnectEvent);
            //DHClient.initialized = false;
            DHClient.DHInit(disConnect, IntPtr.Zero);
            DHClient.DHSetEncoding(LANGUAGE_ENCODING.gb2312);//字符编码格式设置，默认为gb2312字符编码，如果为其他字符编码请设置            

            deviceInfo = new NET_DEVICEINFO();
            int error = 0;
            pLoginID = DHClient.DHLogin(IP, Port, Username, Password, out deviceInfo, out error);


            if (pLoginID != 0)
            {
                pPlayBackHandle = new int[5];
                //画面按钮有效性控制
                btnPlayByRecordFile.Enabled = true;
                RealPlay(true, b);
            }
            else
            {
                MessageBox.Show(DHClient.LastOperationInfo.ToString(pErrInfoFormatStyle), pMsgTitle);

            }
            gpbPlayBackControl.Enabled = false;
            picRealPlay6.VisibleChanged += new EventHandler((o, j) =>
            {
                if (picRealPlay6.Visible==false)
                {
                    gpbPlayBackControl.Enabled = false;
                    btnPlayBackByTime.Enabled = true;
                    btnPlayByRecordFile.Enabled = true;

                }
                else
                {//如果回放激活
                    gpbPlayBackControl.Enabled = true;

                   
                }
            });
        }
        #region 按钮代码

        private void btnVideo1_Click(object sender, EventArgs e)
        {
            bool a = true;

            picRealPlay3.Visible = false;
            picRealPlay4.Visible = false;
            picRealPlay5.Visible = false;
            groupBox1.Text = "一号电机视频监控";

            picRealPlay2.Visible = false;
            picRealPlay6.Visible = false;
            RealPlay(a, 0);
            TimePlay.Enabled = false;

        }

        private void btnVideo2_Click(object sender, EventArgs e)
        {
            picRealPlay1.Visible = false;
            picRealPlay3.Visible = false;
            picRealPlay4.Visible = false;
            picRealPlay5.Visible = false;
            picRealPlay6.Visible = false;
            bool a = true;
            groupBox1.Text = "二号电机视频监控";
            TimePlay.Enabled = true;
            RealPlay(a, 1);
        }

        private void btnVideo3_Click(object sender, EventArgs e)
        {
            bool a = true;
            groupBox1.Text = "三号电机视频监控";
            picRealPlay1.Visible = false;
            picRealPlay2.Visible = false;
            picRealPlay4.Visible = false;
            picRealPlay5.Visible = false;
            picRealPlay6.Visible = false;
            TimePlay.Enabled = true;
            RealPlay(a, 2);
        }

        private void btnControlroom_Click(object sender, EventArgs e)
        {
            bool a;
            groupBox1.Text = "控制室视频监控";
            picRealPlay1.Visible = false;
            picRealPlay2.Visible = false;
            picRealPlay3.Visible = false;
            picRealPlay5.Visible = false;
            picRealPlay6.Visible = false;
            a = true;
            RealPlay(a, 3);
            TimePlay.Enabled = true;
        }

        private void btnAisle_Click(object sender, EventArgs e)
        {
            bool a;
            groupBox1.Text = "过道视频监控";
            TimePlay.Enabled = true;
            picRealPlay1.Visible = false;
            picRealPlay2.Visible = false;
            picRealPlay3.Visible = false;
            picRealPlay4.Visible = false;
            picRealPlay6.Visible = false;
            a = true;
            RealPlay(a, 4);
        }
        #endregion 按钮代码

        private void RealPlay(bool a, int b)
        {
            if (a)
            {
                switch (b)
                {
                    case 0://通道0的实时监视
                        pRealPlayHandle = DHClient.DHRealPlay(pLoginID, 0, picRealPlay1.Handle);
                        picRealPlay1.Visible = true;
                        break;
                    case 1://通道1的实时监视
                        pRealPlayHandle = DHClient.DHRealPlay(pLoginID, 1,  picRealPlay2.Handle);
                        picRealPlay2.Visible = true;
                        break;
                    case 2://通道2的实时监视
                        pRealPlayHandle = DHClient.DHRealPlay(pLoginID, 2,picRealPlay3.Handle);
                        picRealPlay3.Visible = true;
                        break;
                    case 3://通道3的实时监视
                        pRealPlayHandle = DHClient.DHRealPlay(pLoginID, 3, picRealPlay4.Handle);
                        picRealPlay4.Visible = true;
                        break;
                    case 4://通道4的实时监视
                        pRealPlayHandle = DHClient.DHRealPlay(pLoginID, 4, picRealPlay5.Handle);
                        picRealPlay5.Visible = true;
                        break;
                }
            }
            else
            {
                DHClient.DHStopRealPlay(pRealPlayHandle);
                picRealPlay1.Refresh();
            }
        }

        private void TimePlay_Tick(object sender, EventArgs e)
        {
            DHClient.DHStopRealPlay(pRealPlayHandle);
            picRealPlay1.Refresh();
        }

        private void SingleVideoDisplayForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DHClient.DHLogout( pLoginID);
            //DHClient.DHCleanup();
        }
        /// <summary>
        /// 按时间回放按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlayBackByTime_Click(object sender, EventArgs e)
        {
            playBy = 1;
            frm_PlayBackByTimeSet fPBSet = new frm_PlayBackByTimeSet();
            fPBSet.cmbChannelSelect.Items.Clear();
            for (int i = 0; i < 5; i++)
            {
                fPBSet.cmbChannelSelect.Items.Add(i.ToString());
            }
            fileInfo = new NET_RECORDFILE_INFO();
            int fileCount = 0;
            bool blnQueryRecordFile = false;

            fPBSet.ShowDialog();
            if (fPBSet.blnOKEnter == true)
            {
                DateTime startTime = fPBSet.dtpStart.Value;
                DateTime endTime = fPBSet.dtpEnd.Value;
                if (startTime.Date >= endTime.Date)
                {
                    MessageBox.Show("开始日期不在结束日期设置前，请重新设置！", pMsgTitle);
                }
                else
                {
                    blnQueryRecordFile = DHClient.DHQueryRecordFile(pLoginID, int.Parse(fPBSet.txtChannelID.Text.ToString()), RECORD_FILE_TYPE.ALLRECORDFILE,
                                                                    startTime, endTime, null, ref fileInfo, Marshal.SizeOf(typeof(NET_RECORDFILE_INFO)), out  fileCount, 5000, false);//按时间回放
                    if (blnQueryRecordFile == true)
                    {
                        if (picRealPlay == null)
                        {
                            picRealPlay = picRealPlay6;
                        }
                        pPlayBackHandle = new int[5];
                        picRealPlay1.Visible = false;
                        picRealPlay2.Visible = false;
                        picRealPlay3.Visible = false;
                        picRealPlay4.Visible = false;
                        picRealPlay5.Visible = false;
                        picRealPlay6.Visible = true;

                        pPlayBackChannelID = int.Parse(fPBSet.txtChannelID.Text.ToString());
                        pPlayBackHandle[pPlayBackChannelID] = DHClient.DHPlayBackByTime(pLoginID, pPlayBackChannelID, startTime, endTime, picRealPlay.Handle, null, IntPtr.Zero);
                        if (pPlayBackHandle[pPlayBackChannelID] == 0)
                        {
                            MessageBox.Show("按时间回放失败！", pMsgTitle);
                        }
                        else
                        {
                            btnPlay.Text = "||";

                            btnVideo1.Enabled = false;
                            btnVideo2.Enabled = false;
                            btnVideo3.Enabled = false;
                            btnAisle.Enabled = false;
                            btnControlroom.Enabled = false;
                            groupVadioDownload.Enabled = false;
                            //画面按钮有效性控制
                            btnPlayBackByTime.Enabled = false;
                            gpbPlayBackControl.Enabled = true;
                            btnPlay.Enabled = true;
                            btnSlow.Enabled = true;
                            btnStop.Enabled = true;
                            btnFast.Enabled = true;
                            btnSetpPlayS.Enabled = true;
                            hsbPlayBack.Enabled = true;
                            btnPlayByRecordFile.Enabled = false;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 单步播放按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (DHClient.DHPlayBackControl(pPlayBackHandle[pPlayBackChannelID], PLAY_CONTROL.StepPlay) == true)//单步播放开始
                {
                    btnStepPlayE.Enabled = true;
                }
                else
                {
                    MessageBox.Show("单步播放错误！", pMsgTitle);
                }
            }
            catch
            {
                MessageBox.Show(DHClient.LastOperationInfo.ToString(pErrInfoFormatStyle), pMsgTitle);
            }

        }

        /// <summary>
        /// 步进播放停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStepPlayE_Click(object sender, EventArgs e)
        {
            try
            {
                if (DHClient.DHPlayBackControl(pPlayBackHandle[pPlayBackChannelID], PLAY_CONTROL.StepStop) == false)//单步播放停止
                {
                    MessageBox.Show("单步播放停止错误！", pMsgTitle);
                }

            }
            catch
            {
                MessageBox.Show(DHClient.LastOperationInfo.ToString(pErrInfoFormatStyle), pMsgTitle);
            }
            btnStepPlayE.Enabled = false;
        }

        /// <summary>
        /// 快放按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFast_Click(object sender, EventArgs e)
        {
            //停止步进播放
            if (btnStepPlayE.Enabled == true)
            {
                btnStepPlayE_Click(null, null);
            }
            DHClient.DHPlayBackControl(pPlayBackHandle[pPlayBackChannelID], PLAY_CONTROL.Fast);//快放控制
        }

        /// <summary>
        /// 拖放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hsbPlayBack_ValueChanged(object sender, EventArgs e)
        {
            //停止步进播放
            if (btnStepPlayE.Enabled == true)
            {
                btnStepPlayE_Click(null, null);
            }

            #region << 拖拽功能 >>

            switch (playBy)//播放方式0:按文件播放;1:按时间播放
            {
                case 0://按文件播放:按字节偏移播放回放
                    DHClient.DHPlayBackControl(pPlayBackHandle[pPlayBackChannelID], PLAY_CONTROL.SeekByBit, (uint)(hsbPlayBack.Value * (fileInfo.size / 100)));
                    break;
                case 1://按时间播放:按时间编移播放回放
                    DHClient.DHPlayBackControl(pPlayBackHandle[pPlayBackChannelID], PLAY_CONTROL.SeekByTime,
                                                (uint)(hsbPlayBack.Value * ((fileInfo.endtime.ToDateTime().TimeOfDay.TotalSeconds - fileInfo.starttime.ToDateTime().TimeOfDay.TotalSeconds) / 100)));
                    break;
            }

            #endregion
        }

        /// <summary>
        /// 设备断开连接处理
        /// </summary>
        /// <param name="lLoginID"></param>
        /// <param name="pchDVRIP"></param>
        /// <param name="nDVRPort"></param>
        /// <param name="dwUser"></param>
        private void DisConnectEvent(int lLoginID, StringBuilder pchDVRIP, int nDVRPort, IntPtr dwUser)
        {
            //设备断开连接处理            
            MessageBox.Show("设备用户断开连接", pMsgTitle);
        }
        /// <summary>
        /// 抓图处理代码
        /// </summary>
        /// <param name="hPlayHandle">播放句柄</param>
        /// <param name="bmpPath">图像促存路径</param>
        private void CapturePicture(int hPlayHandle, string bmpPath)
        {
            if (DHClient.DHCapturePicture(hPlayHandle, bmpPath))
            {
                //抓图成功处理
                MessageBox.Show("抓图成功!  图片路径："+bmpPath, pMsgTitle);
            }
            else
            {
                //抓图失败处理
                MessageBox.Show("抓图失败!", pMsgTitle);
            }
        }
        /// <summary>
        /// 抓图按钮按下
        /// </summary>
        /// <param name="hPlayHandle"></param>
        private void CapturePicture(int hPlayHandle)
        {
            string bmpPath = Application.StartupPath + @"\DH_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".bmp";
            //抓图处理
            CapturePicture(hPlayHandle, bmpPath);
        }

        #region << 窗口控制　与功能无关 >>

        /// <summary>
        /// 图像控件单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picRealPlay_Click(object sender, EventArgs e)
        {
            if (btnPlayBackByTime.Enabled == true || btnPlayByRecordFile.Enabled == true)
            {
                if (oldPicRealPlay != null)
                {
                    oldPicRealPlay.BackColor = SystemColors.Control;
                }

                picRealPlay = (PictureBox)sender;
                picRealPlay.BackColor = SystemColors.ActiveBorder;
                oldPicRealPlay = picRealPlay;
            }
        }
        #endregion
        /// <summary>
        /// 抓图按钮按下处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCapturePicture2_Click(object sender, EventArgs e)
        {
            CapturePicture(pPlayBackHandle[pPlayBackChannelID]);
        }
        /// <summary>
        /// 抓图按钮按下处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCapturePicture_Click(object sender, EventArgs e)
        {
            CapturePicture(pRealPlayHandle);
        }


        /// <summary>
        /// 按文件回放按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnPlayByRecordFile_Click(object sender, EventArgs e)
        {
            playBy = 0;
            frm_PlayBackByFileSet fpf = new frm_PlayBackByFileSet();
            fpf.gLoginID = pLoginID;
            fpf.cmbChannelSelect.Items.Clear();

            for (int i = 0; i < 5; i++)
            {
                fpf.cmbChannelSelect.Items.Add(i.ToString());
            }
            fpf.ShowDialog(this);
            if (fpf.blnOKEnter == true)
            {
                groupBox1.Text = "视频回放";
                if (picRealPlay == null)
                {
                    picRealPlay = picRealPlay6;
                }
                pPlayBackChannelID = int.Parse(fpf.txtChannelID.Text.ToString());
                fileInfo = fpf.gFileInfo;
                //**********按文件回放**********
                //自己定义长度
                pPlayBackHandle = new int[5];

                picRealPlay1.Visible = false;
                picRealPlay2.Visible = false;
                picRealPlay3.Visible = false;
                picRealPlay4.Visible = false;
                picRealPlay5.Visible = false;
                picRealPlay6.Visible = true;

                pPlayBackHandle[pPlayBackChannelID] = DHClient.DHPlayBackByRecordFile(pLoginID, ref fileInfo, picRealPlay.Handle, null, IntPtr.Zero);
                //******************************
                if (pPlayBackHandle[pPlayBackChannelID] == 0)
                {
                    MessageBox.Show("按时间回放失败！", pMsgTitle);
                }
                else
                {
                    //**********画面控制代码**********
                    btnPlay.Text = "||";

                    btnVideo1.Enabled = false;
                    btnVideo2.Enabled = false;
                    btnVideo3.Enabled = false;
                    btnAisle.Enabled = false;
                    btnControlroom.Enabled = false;
                    groupVadioDownload.Enabled = false;
                    //画面按钮有效性控制
                    btnPlayBackByTime.Enabled = false;
                    gpbPlayBackControl.Enabled = true;
                    btnPlay.Enabled = true;
                    btnSlow.Enabled = true;
                    btnStop.Enabled = true;
                    btnFast.Enabled = true;
                    btnSetpPlayS.Enabled = true;
                    hsbPlayBack.Enabled = true;
                    btnPlayByRecordFile.Enabled = false;
                    //*********************************
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (DHClient.DHPlayBackControl(pPlayBackHandle[pPlayBackChannelID], PLAY_CONTROL.Stop) == false)//停止回放
            {
                MessageBox.Show("停止回放失败！", pMsgTitle);
            }
            groupBox1.Text = "请重新请求视频信号";
            btnVideo1.Enabled = true;
            btnVideo2.Enabled = true;
            btnVideo3.Enabled = true;
            btnAisle.Enabled = true;
            btnControlroom.Enabled = true;
            groupVadioDownload.Enabled = true;
            //画面按钮有效性控制
            gpbPlayBackControl.Enabled = false;
            btnPlay.Enabled = false;
            btnSlow.Enabled = false;
            btnStop.Enabled = false;
            btnFast.Enabled = false;
            btnSetpPlayS.Enabled = false;
            hsbPlayBack.Enabled = false;
            btnPlayBackByTime.Enabled = true;
            btnPlayByRecordFile.Enabled = true;
            if (picRealPlay != null)
            {
                picRealPlay.Refresh();
                picRealPlay.BackColor = SystemColors.Control;
            }
            else
            {
                picRealPlay1.Refresh();
                picRealPlay.BackColor = SystemColors.Control;
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            //停止步进播放
            if (btnStepPlayE.Enabled == true)
            {
                btnStepPlayE_Click(null, null);
            }
            switch (btnPlay.Text.ToString())
            {
                case ">"://播放控制
                    if (DHClient.DHPlayBackControl(pPlayBackHandle[pPlayBackChannelID], PLAY_CONTROL.Play) == true)//播放
                    {
                        btnPlay.Text = "||";
                    }
                    break;
                case "||"://暂停控制
                    if (DHClient.DHPlayBackControl(pPlayBackHandle[pPlayBackChannelID], PLAY_CONTROL.Pause) == true)//暂停
                    {
                        btnPlay.Text = ">";
                    }
                    break;
            }
        }

        private void btnSetpPlayS_Click(object sender, EventArgs e)
        {
            try
            {
                if (DHClient.DHPlayBackControl(pPlayBackHandle[pPlayBackChannelID], PLAY_CONTROL.StepPlay) == true)//单步播放开始
                {
                    btnStepPlayE.Enabled = true;
                }
                else
                {
                    MessageBox.Show("单步播放错误！", pMsgTitle);
                }
            }
            catch
            {
                MessageBox.Show(DHClient.LastOperationInfo.ToString(pErrInfoFormatStyle), pMsgTitle);
            }
        }

        private void btnSlow_Click(object sender, EventArgs e)
        {
            //停止步进播放
            if (btnStepPlayE.Enabled == true)
            {
                btnStepPlayE_Click(null, null);
            }

            DHClient.DHPlayBackControl(pPlayBackHandle[pPlayBackChannelID], PLAY_CONTROL.Slow);//慢放控制
        }

        private void btnStepPlayE_Click_1(object sender, EventArgs e)
        {

        }

        private void btnVadioDown_Click(object sender, EventArgs e)
        {
            SDKDownLoadFileDemo.frm_Main frmDown = new SDKDownLoadFileDemo.frm_Main(pLoginID);
            frmDown.Show();
        }

        private void btnCatchImg_Click(object sender, EventArgs e)
        {
            CapturePicture(pRealPlayHandle);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
