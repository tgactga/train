using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO.Ports;
using System.Threading;

namespace TrainRemoteControl
{
    public static class SerialPortHelper2
    {
        //增加温度读取串口
        private static object obj = new object();
        //串口号
        private static readonly byte comPort = byte.Parse(Program.g_comPortTemperature);
        private const uint baudrate = 9600;
        private const short slot = -1;
        private const short checksum = 0;

        private const short timeout = 100;

        private const short aiTotalChannel = 8;
        private const short doTotalChannel = 16;

        private static char[] c = new char[] { '+', '-', '\r' };
        private static SerialPort sp = new SerialPort("COM" + comPort, (int)baudrate, Parity.None, 8, StopBits.One);

        public static void SerialportSet()
        {
            sp.Handshake = Handshake.RequestToSend;
            sp.ReadTimeout = 5000;
        }


        /// <summary>
        /// 计算CRC校验码
        /// </summary>
        /// <param name="sour"></param>
        /// <returns></returns>
        private static byte[] CRCCalculate(byte[] sour)
        {
            byte[] bCrc = new byte[2];
            uint wCrc;

            try
            {
                wCrc = CRCCalculate(sour, sour.Length - 3);//crc 2  ,0x16 1

                string sCrc = wCrc.ToString("x").PadLeft(4, '0');

                if (sCrc.Length == 4)
                {
                    bCrc[0] = Convert.ToByte("0x" + sCrc.Substring(2, 2), 16);
                    bCrc[1] = Convert.ToByte("0x" + sCrc.Substring(0, 2), 16);
                }
            }
            catch
            {
                return sour;
            }

            sour[sour.Length - 3] = bCrc[0];
            sour[sour.Length - 2] = bCrc[1];

            return sour;
        }

        //校验
        private static uint CRCCalculate(byte[] sour, int len)
        {
            uint wCrc;
            int i, j;

            wCrc = 0xFFFF;

            for (i = 0; i < len; i++)
            {
                wCrc ^= sour[i];
                for (j = 0; j < 8; j++)
                {
                    uint iBool = wCrc & 0x01;
                    if (iBool == 1)
                    {
                        wCrc >>= 1;
                        wCrc ^= 0xA001;
                    }
                    else
                    {
                        wCrc >>= 1;
                    }
                }
            }
            return wCrc;
        }


        //打开串口
        private static bool Open()
        {
            try
            {
                if (!sp.IsOpen)
                {
                    sp.Open();
                }
                sp.ReadExisting();
                Program.g_isOpenTempCom = true;
                return true;
            }
            catch (System.Exception ex)
            {
                Program.WriteLog("打开串口失败  "+ex.ToString());
                Program.g_isOpenTempCom = false;
                return false;
            }
        }


        /// <summary>
        /// 设置车厢编号1，2,3....
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool SetTrainNo(byte[] value)
        {
            byte[] bReceive = new byte[10];

            try
            {
                lock (obj)
                {
                    if (Open())
                    {
                        value = CRCCalculate(value);

                        sp.ReadExisting();
                        sp.Write(value, 0, value.Length);
                        Thread.Sleep(200);
                        sp.Read(bReceive, 0, bReceive.Length);
                        if (bReceive[0] == 169 && bReceive[1] == 169 & bReceive[bReceive.Length - 1] == 22)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Program.WriteLog(ex.ToString());
            }
            finally
            {
                //Close();
            }

            return false;
        }

        //厂编号，如998111
        public static bool SetTrainSerialNumber(byte[] value)
        {
            byte[] bReceive = new byte[9];

            try
            {
                lock (obj)
                {
                    if (Open())
                    {
                        value = CRCCalculate(value);

                        sp.ReadExisting();
                        sp.Write(value, 0, value.Length);
                        Thread.Sleep(200);
                        sp.Read(bReceive, 0, bReceive.Length);
                        if (bReceive[0] == 169 && bReceive[1] == 169 & bReceive[bReceive.Length - 1] == 22)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                //Close();
            }

            return false;
        }

        //设置系统时间
        public static bool SetTime()
        {
            return false;
        }

        public static byte[] ReadAllTemp(byte[] value)
        {
            byte[] bReceive = new byte[259];
            byte[] bReceive2 = new byte[260];

            try
            {
                //lock (obj)
                //{
                    if (Open())
                    {
                        value = CRCCalculate(value);

                        sp.ReadExisting();
                        sp.Write(value, 0, value.Length);
                        Thread.Sleep(2000);
                        sp.Read(bReceive2, 0, bReceive2.Length);
                        for (int i = 0; i < 259; i++)
                            bReceive[i] = bReceive2[i + 1];
                        if (bReceive[0] == 169 && bReceive[1] == 169 & bReceive[bReceive.Length - 1] == 22)
                        {
                            return bReceive;
                        }
                        else
                        {
                            return new byte[0];
                        }
                    }
                //}
            }
            catch (Exception ex)
            {
                Program.WriteLog(""+ex.ToString());
            }
            finally
            {
                //Close();
            }

            return new byte[0];
        }

    }
}
