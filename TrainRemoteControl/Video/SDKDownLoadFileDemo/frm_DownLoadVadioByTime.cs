using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using DHNetSDK;
using Utility;

namespace SDKDownLoadFileDemo
{
    public partial class frm_DownLoadVadioByTime : Form
    {

        public bool blnOKEnter = false;

        private DateTime tmStart;
        public DateTime StartTime
        {
            get
            {
                return tmStart;
            }
        }
        /// <summary>
        /// 程序消息提示Title
        /// </summary>
        private const string pMsgTitle = "网络SDK Demo程序";
        private DateTime tmEnd;
        public DateTime EndTime
        {
            get
            {
                return tmEnd;
            }
        }
        public string DownLoadPath;

        public string DownLoadFileName;
        private string downloadfilepathstr;
        public string DownLoadFilePathStr
        {
            get
            {
                return downloadfilepathstr;
            }
        }
        private delegate void fSetProgressPos(int lPlayHandle, UInt32 dwTotalSize, UInt32 dwDownLoadSize);
        private fSetProgressPos setProgressPos;
        /// <summary>
        /// 按时间下载句柄
        /// </summary>
        private int pDownloadHandleByTime;
        /// <summary>
        /// 下载句柄
        /// </summary>
        private int pDownloadHandle;
        private fTimeDownLoadPosCallBack timeDownLoadFun;
        /// <summary>
        /// 下载回调
        /// </summary>
        private fDownLoadPosCallBack downLoadFun;
        /// <summary>
        /// 断开回调
        /// </summary>
        private fDisConnect disConnect;

        private int pLoginID;

        public frm_DownLoadVadioByTime()
        {
            InitializeComponent();
        }
        public frm_DownLoadVadioByTime(int id)
        {
            this.pLoginID = id;
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //if (this.btnOK.Text == "重试")
            //{
            //    setProgressPos = new fSetProgressPos(DownloadProgress);
            //}


            if (txtDirPath2.Text.Trim().Length > 0 && txtFileName2.Text.Trim().Length > 0)
            {
                string strFileName = txtFileName2.Text;

                strFileName = strFileName.ToLower();
                if (!strFileName.EndsWith(".dav"))
                    strFileName += ".dav";
                downloadfilepathstr = txtDirPath2.Text.Trim() + strFileName;
            }
            else
            {
                MessageUtil.ShowMsgBox(StringUtil.ConvertString(DHClient.LastOperationInfo.errMessage, "ErrorMessage"),
                                       StringUtil.ConvertString(pMsgTitle));
            }
            string strTmStart = dtpStart.Text + " " + txtTimeStart.Text;
            string strTmEnd = dtpEnd.Text + " " + txtTimeEnd.Text;

            try
            {
                tmStart = DateTime.Parse(strTmStart);
                tmEnd = DateTime.Parse(strTmEnd);
            }
            catch (System.Exception ex)
            {
                MessageUtil.ShowMsgBox(StringUtil.ConvertString("请输入正确的时间格式!"));
                return;
            }

            if (tmStart >= tmEnd)
            {
                MessageUtil.ShowMsgBox(StringUtil.ConvertString("开始日期不在结束日期前!"));
                return;
            }

            //blnOKEnter = true;


            NET_RECORDFILE_INFO fileInfo = new NET_RECORDFILE_INFO();
            int fileCount = 0;
            bool blnQueryRecordFile = false;
            int pPlayBackChannelID = 0;

        
            DateTime startTime = StartTime;
            DateTime endTime = EndTime;

            //if (int.Parse(txtChannelID.Text.ToString()) == 5)
            //{
            //    for (int i = 0; i < 5; i++)
            //    {
            //        txtChannelID.Text = i.ToString();
            //        label7.Text = "正在下载通道0文件，还剩"+(5-i).ToString()+"个文件";
            //        btnOK_Click(null, null);


            //    }
            //}
            //else
            //{

                blnQueryRecordFile = DHClient.DHQueryRecordFile(pLoginID, int.Parse(txtChannelID.Text.ToString()), RECORD_FILE_TYPE.ALLRECORDFILE,
                                                                startTime, endTime, null, ref fileInfo, Marshal.SizeOf(typeof(NET_RECORDFILE_INFO)), out  fileCount, 5000, false);//按时间回放
                if (blnQueryRecordFile == true)
                {

                    //**********按文件下载**********
                    pPlayBackChannelID = int.Parse(txtChannelID.Text.ToString());
                    //if ( txtDirPath2.Text.Trim().Length > 0 && txtFileName2.Text.Trim().Length > 0)
                    //{

                    //string strFileName = txtFileName2.Text;
                    //strFileName = strFileName.ToLower();
                    //if (!strFileName.EndsWith(".dav"))
                    //    strFileName += ".dav";

                    // 关闭上次上次下载有关资源
                    if (pDownloadHandleByTime != 0)
                    {
                        DHClient.DHStopDownload(pDownloadHandleByTime);
                        pDownloadHandle = 0;
                    }

                    pDownloadHandleByTime = DHClient.DHDownloadByTime(pLoginID, pPlayBackChannelID, 0, startTime
                        , endTime, DownLoadFilePathStr, timeDownLoadFun, IntPtr.Zero);
                    if (pDownloadHandleByTime != 0)
                    {
                        //btnDownLoad2.Tag = "下载中";
                        pDownloadHandle = pDownloadHandleByTime;
                        //btnDownLoad2.Enabled = false;
                        //btnDownLoad1.Enabled = false;
                        //btnStopDownLoad2.Enabled = true;
                        MessageUtil.ShowMsgBox(StringUtil.ConvertString("开始下载！"),
                                               StringUtil.ConvertString(pMsgTitle));

                        //grbMain.Enabled = true;
                    }
                    //else
                    //{
                    //    MessageUtil.ShowMsgBox(StringUtil.ConvertString(DHClient.LastOperationInfo.errMessage, "ErrorMessage"),
                    //                           StringUtil.ConvertString(pMsgTitle));
                    //}
                    //}
                    //else
                    //{
                    //    MessageUtil.ShowMsgBox(StringUtil.ConvertString("请输入有效的录像保存目录和文件名!"),
                    //                           StringUtil.ConvertString(pMsgTitle));
                    //}
                    //*******************************

                }
            //}

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //DHClient.DHStopDownload(lPlayHandle);
            //this.Close();
        }

        private void frm_DownLoadVadioByTime_Load(object sender, EventArgs e)
        {
            disConnect = new fDisConnect(DisConnectEvent);
            DHClient.DHInit(disConnect, IntPtr.Zero);
            downLoadFun = new fDownLoadPosCallBack(DownLoadPosFun);
            timeDownLoadFun = new fTimeDownLoadPosCallBack(TimeDownLoadPosFun);
            setProgressPos = new fSetProgressPos(DownloadProgress);
            for (int i = 0; i < 5; i++)
            {
                cmbChannelSelect.Items.Add(i.ToString());
            }
            
            //cmbChannelSelect.Items.Add("全部");
            cmbChannelSelect.SelectedIndex = 0;
            dtpStart.Value = DateTime.Now.AddDays(-7);

            txtDirPath2.Text = this.DownLoadPath;
            txtFileName2.Text = this.DownLoadFileName;

            Utility.StringUtil.InitControlText(this);
        }

        private void cmbChannelSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtChannelID.Text = cmbChannelSelect.SelectedIndex.ToString();

        }

        private void btnDirSelect_Click(object sender, EventArgs e)
        {
            if (fbdMain.ShowDialog() == DialogResult.OK)
            {
                txtDirPath2.Text = fbdMain.SelectedPath;
            }
        }

        /// <summary>
        /// 设备断开连接处理
        /// </summary>
        /// <param name="lLoginID">登录ID</param>
        /// <param name="pchDVRIP">DVR设备IP</param>
        /// <param name="nDVRPort">DVR设备端口</param>
        /// <param name="dwUser">用户数据</param>
        private void DisConnectEvent(int lLoginID, StringBuilder pchDVRIP, int nDVRPort, IntPtr dwUser)
        {
            //设备断开连接处理          
            MessageUtil.ShowMsgBox(StringUtil.ConvertString("设备用户断开连接"),
                                   StringUtil.ConvertString(pMsgTitle));
        }

        public void TimeDownLoadPosFun(int lPlayHandle, int dwTotalSize, int dwDownLoadSize, int index
          , NET_RECORDFILE_INFO recordfileinfo, IntPtr dwUser)
        {
            try
            {
                this.Invoke(setProgressPos, new object[] { lPlayHandle, (UInt32)dwTotalSize, (UInt32)dwDownLoadSize });

                if (0xFFFFFFFF == (UInt32)dwDownLoadSize || 0xFFFFFFFE == (UInt32)dwDownLoadSize)
                {
                    DHClient.DHStopDownload(lPlayHandle);
                }
            }
            catch (Exception)
            {

            }

        }
        /// <summary>
        /// 下载回调
        /// </summary>
        /// <param name="lPlayHandle">播放句柄</param>
        /// <param name="dwTotalSize">累计大小</param>
        /// <param name="dwDownLoadSize">下载大小</param>
        /// <param name="dwUser">用户数据</param>
        private void DownLoadPosFun(int lPlayHandle, UInt32 dwTotalSize, UInt32 dwDownLoadSize, IntPtr dwUser)
        {
            this.Invoke(setProgressPos, new object[] { lPlayHandle, dwTotalSize, dwDownLoadSize });

            if (0xFFFFFFFF == dwDownLoadSize || 0xFFFFFFFE == dwDownLoadSize)
            {
                DHClient.DHStopDownload(lPlayHandle);
            }
        }
        private void DownloadProgress(int lPlayHandle, UInt32 dwTotalSize, UInt32 dwDownLoadSize)
        {

            if (dwDownLoadSize != 0xFFFFFFFF &&
                dwDownLoadSize != 0xFFFFFFFE &&
                dwDownLoadSize <= dwTotalSize)
            {
                int iPos = (int)((dwDownLoadSize * 100) / dwTotalSize);
                Console.WriteLine(iPos.ToString() + " " + dwDownLoadSize.ToString() + "/" + dwTotalSize.ToString());
                psbMain.Value = iPos;
            }
            else
            {
                if (0xFFFFFFFF == dwDownLoadSize)
                {
                    //btnDownLoad2.Tag = "";
                    psbMain.Value = 0;
                    MessageUtil.ShowMsgBox(StringUtil.ConvertString("下载结束！"));
                    //btnDownLoad1.Enabled = true;
                    //btnDownLoad2.Enabled = true;

                    psbMain.Value = 0;

                    //DHClient.DHStopDownload(lPlayHandle);
                }
                else if (0xFFFFFFFE == dwDownLoadSize)
                {
                    //btnDownLoad2.Tag = "";
                    psbMain.Value = 0;
                    MessageUtil.ShowMsgBox(StringUtil.ConvertString("磁盘空间不足！"));
                    //btnDownLoad1.Enabled = true;
                    //btnDownLoad2.Enabled = true;

                    psbMain.Value = 0;
                    //setProgressPos = new fSetProgressPos(DownloadProgress);
                    setProgressPos -= new fSetProgressPos(DownloadProgress);
                    //this.btnOK.Text = "重试";
                    downLoadFun -= new fDownLoadPosCallBack(DownLoadPosFun);
                    timeDownLoadFun -= new fTimeDownLoadPosCallBack(TimeDownLoadPosFun);
                    this.Close();
                    //DHClient.DHStopDownload(lPlayHandle);
                }
            }
        }
    }
}
