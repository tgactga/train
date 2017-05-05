using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Configuration;
using DCON_PC_DOTNET;
using System.IO.Ports;

namespace TrainRemoteControl
{
    public static class SerialPortHelper
    {
        private static object obj = new object();
        //串口号
        private static readonly  byte comPort = byte.Parse(Program.g_comPort);
        private const uint baudrate=9600;
        private const short slot=-1;
        private const short checksum=0;
        private const short timeout=100;
        
        private const short aiTotalChannel=8;
        private const short doTotalChannel = 16;

        private static char[] c = new char[] { '+', '-', '\r' };
        private static SerialPort sp = new SerialPort("COM" + comPort, (int)baudrate, Parity.None, 8, StopBits.One);

       
        public static void SerialportSet()
        {
            sp.Handshake = Handshake.RequestToSendXOnXOff;
        }

        //打开串口
        public static bool Open()
        {            
            try
            {
                if (!sp.IsOpen)
                {
                    sp.Open();
                }
                sp.ReadExisting();
                return true;
            }
            catch (System.Exception ex)
            {
                Program.WriteLog(ex.ToString());
                return false;
            }
        }

        //关闭串口
        public static void Close()
        {
            //if (sp.IsOpen)
            //{
            //    sp.Close();
            //}            
        }


        //
        /// <summary>
        /// 读取ai（7017）模块所有数据
        /// </summary>
        /// <param name="iAddress">模块地址</param>
        /// <returns></returns>
        public static float[] ReadAIAll(short iAddress)
        {
            float[] AIValueArray = new float[16];
            string[] rec = null;

            try
            {
                lock (obj)
                {
                    if (Open())
                    {
                        sp.Write("#0" + iAddress.ToString() + "\r");
                        Thread.Sleep(100);
                        rec = sp.ReadExisting().Replace("\r", "").Split(c);
                        if (rec[0] == ">")
                        {
                            for (int i = 1; i < rec.Length; i++)
                            {
                                AIValueArray[i - 1] = float.Parse(rec[i]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Program.WriteLog(ex.ToString());
                return new float[16];
            }
            finally
            {
                Close();
            }

            return AIValueArray;
        }

        /// <summary>
        /// 读取do（7055）模块值
        /// </summary>
        /// <param name="address">模块地址</param>
        /// <returns></returns>

        public static uint ReadDo(short address)
        {
            uint doValue = 0;
            string rec = "";

            try
            {
                lock (obj)
                {
                    if (Open())
                    {
                        sp.Write("@0" + address.ToString()+"\r");//#01cr
                        Thread.Sleep(100);
                        rec = sp.ReadExisting().Replace("\r", "");
                        if (rec!= "")
                        {
                             string strHex = "0x" + rec.Replace(">", "");
                        
                            doValue = Convert.ToUInt16(strHex, 16);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Program.WriteLog(ex.ToString());
            }
            finally
            {
                Close();
            }
            return doValue;
        }

        /// <summary>
        /// 读取某一位的值
        /// </summary>
        /// <param name="address">模块地址</param>
        /// <param name="channelNum">通道号</param>
        /// <returns></returns>
        public static bool ReadDoBit(short address,short channelNum)
        {
            bool result = false;
            string rec = "";

            try
            {
                lock (obj)
                {
                    if (Open())
                    {
                        sp.Write("@0" + address.ToString()+"\r");
                        Thread.Sleep(100);
                        rec = sp.ReadExisting().Replace("\r", "");
                        if (rec != "")
                        {
                            string strHex = "0x" + rec.Replace(">", "").Substring(2, 2);

                            result = Convert.ToString(Convert.ToInt32(strHex, 16), 2).ToString().PadLeft(8, '0').Substring(7 - channelNum, 1) == "1" ? true : false;
                        }
                    }
                }                
            }
            catch (Exception ex)
            {
                Program.WriteLog(ex.ToString());
                result = false;
            }
            finally
            {
                Close();
            }
            return result;
        }

        /// <summary>
        /// 向do模块某一位写入值
        /// </summary>
        /// <param name="address">模块地址</param>
        /// <param name="channelNum">通道号</param>
        /// <param name="value">写入值 true 或false</param>
        public static bool WriteDoBit(short address,short channelNum,bool value)
        {
            bool resualt = false;
            string[] rec = null;
            StringBuilder sb = new StringBuilder();

            sb.Append("#0" + address.ToString() + "A" + channelNum.ToString() + "0");
            sb.Append(value ? "1" : "0");
            try
            {
                lock (obj)
                {
                    if (Open())
                    {
                        sp.Write(sb.ToString()+"\r");
                        Thread.Sleep(100);
                        rec = sp.ReadExisting().Replace("\r", "").Split(c);
                        if (rec[0] == ">")
                        {
                            resualt= true;
                        }
                    }
                }                
            }
            catch (Exception ex)
            {
                Program.WriteLog(ex.ToString());
                resualt= false;
            }
            finally
            {
                Close();
            }
            return resualt;
        }

    }
}
