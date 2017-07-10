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
    public partial class TestSyncContextForm1 : Form
    {
        //共分三步
        //第一步：获取UI线程同步上下文（在窗体构造函数或FormLoad事件中）
        /// <summary>
        /// UI线程的同步上下文
        /// </summary>
        /// 
        SynchronizationContext m_SyncContext = null;

        public TestSyncContextForm1()
        {
            InitializeComponent();

            //获取UI线程同步上下文
            m_SyncContext = SynchronizationContext.Current;
            //Control.CheckForIllegalCrossThreadCalls = false;
        }


        //第二步：定义线程的主体方法
        /// <summary>
        /// 线程的主体方法
        /// </summary>
        private void ThreadProcSafePost()
        {
            //...执行线程任务

            //在线程中更新UI（通过UI线程同步上下文m_SyncContext）
            m_SyncContext.Post(SetTextSafePost, "This text was set safely by SynchronizationContext-Post.");

            //...执行线程其他任务
        }

        //第三步：定义更新UI控件的方法
        /// <summary>
        /// 更新文本框内容的方法
        /// </summary>
        /// <param name="text"></param>
        private void SetTextSafePost(object text)
        {
            this.textBox1.Text = text.ToString();
        }

        private void TestForm1_Load(object sender, EventArgs e)
        {

        }
        Thread demoThread;

        //之后,启动线程
        /// <summary>
        /// 启动线程按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.demoThread = new Thread(new ThreadStart(this.ThreadProcSafePost));
            this.demoThread.Start();

        }
    }
}
