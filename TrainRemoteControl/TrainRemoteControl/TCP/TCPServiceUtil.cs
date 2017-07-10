using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
  
using System.Threading;
using System.ServiceModel;
using TrainRemoteControl.utilclass;
using TrainRemoteControl.Model;

namespace TrainRemoteControl.TCP
{
    class TCPServiceUtil:MessageService.IMessageServiceCallback
    {
        BuildMsgUtil buildMsg = new BuildMsgUtil();
        private MessageService.MessageServiceClient mService = null;
        private ManualResetEvent _ReConnectEvent = new ManualResetEvent(false);
        public void InitalSevice()
        {
              Thread thr = new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        InstanceContext context = new InstanceContext(this);
                        mService = new MessageService.MessageServiceClient(context);
                       // mService.Register("000002");
                        Program.WriteLog(Program.g_serialNum + "注册");
                        mService.Register(Program.g_serialNum);  //车编号
                        _ReConnectEvent.WaitOne();
                        _ReConnectEvent.Reset();

                    }
                    catch (Exception ex)
                    {
                        Program.WriteLog(Program.g_serialNum+" 说:" + ex.Message);
                        Thread.Sleep(3000);
                        // throw;
                    }

                }
            });
              thr.Start();
        }

        public void SendMsg2Server(int type, string msg)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
            {
                try
                {
                    // string ss = mService.ClientSendMessage(msg);
                    string ss = mService.ClientSendInfo(type, msg);
                    if (ss == "-1")
                    {
                        //记录补发 记录日志
                        SetDisplayMessage("发送失败 记录补发" + msg);
                    }
                    else
                    {
                        SetDisplayMessage(Program.g_serialNum+"发送消息，返回：" + ss);

                    }
                }
                catch (Exception ex)
                {
                    Program.WriteLog("发送报错"+ex.ToString());
                    // 记录日志及消息 补发
                    _ReConnectEvent.Set();//开启重新连接
                    Program.WriteLog("开启重新连接");
                }
            }));


        }
        /// <summary>
        /// 收到服务器消息
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(string message)
        {
            Program.WriteLog(Program.g_serialNum + "收到服务器:" + message);
             
        }

        /// <summary>
        /// 设置显示消息
        /// </summary>
        private void SetDisplayMessage(string message)
        {

            message += string.Format("{0}\r\n{1}\r\n", message, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            Program.WriteLog(message);
             
        }


        #region IMessageServiceCallback 成员

        public string SendMessage(int type, string message)
        {
            Program.WriteLog(type+"接收服务器消息"+message);                   
            string senMsg = "";
            BuildMsgUtil buildMsg = new BuildMsgUtil();
            switch (type.ToString().Trim())
            {

                case "1":   // 实时关键数据
                    Program.WriteLog("服务器请求实时关键数据");
                    senMsg = buildMsg.buildUploadCriticalData(Program.g_criticalDataList);
                    break;
                case "2":
                    Program.WriteLog("服务器请求实时温度数据");
                    senMsg = new BuildMsgUtil().buildUploadTemperatureData(Program.g_tempCellsTerminalList);
                    break;
                case "3":
                    Program.WriteLog("服务器请求巡检数据");
                    senMsg = new BuildMsgUtil().buildXunjianData(Program.g_inspectionRecord);
                    break;
                case "4":
                    Program.WriteLog("服务器请求错误日志");
                    senMsg = "ERRORLOGS";
                    break;
                default:

                    break;


            }
            return senMsg;
           // throw new NotImplementedException();
        }

        #endregion




    }
}
