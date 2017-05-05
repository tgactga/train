using System;
using TrainRemoteControl.Model;
using System.Collections.Generic;

namespace TrainRemoteControl
{
    /// <summary>
    /// 采集
    /// </summary>
    public class DataAcquisition
    {    
        //保存模块1结果
        private float[] resultM1 = null;
        //保存模块2结果
        private float[] resultM2 = null;
        //保存模块3结果
        private float[] resultM3 = null;
        //保存模块4结果
        private uint result75D = 0;

        public DataAcquisition()
        {
            TrainRemoteControl.SerialPortHelper.SerialportSet();
            TrainRemoteControl.SerialPortHelper2.SerialportSet();
        }


        /// <summary>
        /// 获取发电机电压,1号、2号、3号、24V供电电压
        /// </summary>
        /// <returns></returns>
        public float[] GetGeneratorVoltage()
        {
            resultM1 = null;
            resultM2 = null;
            resultM3 = null;
            result75D = 0;
            resultM1 = TrainRemoteControl.SerialPortHelper.ReadAIAll(1);//#01.
            resultM2 = TrainRemoteControl.SerialPortHelper.ReadAIAll(2);//#02.
            resultM3 = TrainRemoteControl.SerialPortHelper.ReadAIAll(3);
            float[] voltage = new float[5] { resultM1[3], resultM1[7], resultM2[3], resultM2[4], resultM3[7] };
            
           //float[] voltage = new float[4] { 17.126f, 0,0, 0 };

            return voltage;
        }

        /// <summary>
        /// 获取公共部分数据
        /// </summary>
        /// <returns></returns>
        public CommonOriginalData GetOriginalCommonData()
        {

            if (resultM3 == null)
            {
                resultM3 = TrainRemoteControl.SerialPortHelper.ReadAIAll(3);
            }
            if (result75D == 0)
            {
                result75D = TrainRemoteControl.SerialPortHelper.ReadDo(4);
            }
            return new CommonOriginalData(resultM3[6], result75D & (1 << 6), (result75D & 1) > 0, (result75D & (1 << 1)) > 0, (result75D & (1 << 5)) > 0);
            //return new CommonOriginalData(0.0f, 0.0f, false, false, false);

        }

        /// <summary>
        /// 获取每个电机特有数据
        /// </summary>
        /// <param name="generatorId">电机号</param>
        /// <param name="voltage">电机输出电压</param>
        /// <returns></returns>
        public PartialOriginalData GetPartialOriginalData(int generatorId, float voltage)
        {
            if (voltage >= 6.0)
            {
                if (result75D == 0)
                {
                    result75D = TrainRemoteControl.SerialPortHelper.ReadDo(4);
                }

                bool oilLeak = false;

                if (resultM3 == null)
                {
                    resultM3 = TrainRemoteControl.SerialPortHelper.ReadAIAll(3);
                }
                if (resultM1 == null)
                {
                    resultM1 = TrainRemoteControl.SerialPortHelper.ReadAIAll(1);

                }
                if (resultM2 == null)
                {
                    resultM2 = TrainRemoteControl.SerialPortHelper.ReadAIAll(2);
                }

                PartialOriginalData pData = null;
                float oilPress;
                float waterTemp;
                float current;
                float frequency;
                float powerFactory;
                switch (generatorId)
                {
                    case 1:
                        oilLeak = (result75D & (1 << 2)) > 0;
                        oilPress = resultM3[1];
                        waterTemp = resultM3[0];
                        current = resultM1[2];
                        frequency = resultM1[1];
                        powerFactory = resultM1[0];
                        pData = new PartialOriginalData(generatorId, voltage, oilPress, waterTemp, current, frequency, powerFactory, oilLeak);
                        break;
                    case 2:
                        oilLeak = (result75D & (1 << 3)) > 0;
                        oilPress = resultM3[3];
                        waterTemp = resultM3[2];
                        current = resultM1[6];
                        frequency = resultM1[5];
                        powerFactory = resultM1[4];
                        pData = new PartialOriginalData(generatorId, voltage, oilPress, waterTemp, current, frequency, powerFactory, oilLeak);
                        break;
                    case 3:
                        oilLeak = (result75D & (1 << 4)) > 0;
                        oilPress = resultM3[5];
                        waterTemp = resultM3[4];
                        current = resultM2[2];
                        frequency = resultM2[1];
                        powerFactory = resultM2[0];
                        pData = new PartialOriginalData(generatorId, voltage, oilPress, waterTemp, current, frequency, powerFactory, oilLeak);
                        break;
                }
                return pData;
            }
            return null;
        }

        /// <summary>
        /// 点亮巡检灯
        /// </summary>
        public void StartFlash()
        {
            TrainRemoteControl.SerialPortHelper.WriteDoBit(4, 1, true);
        }
        /// <summary>
        /// 关闭巡检灯
        /// </summary>
        public void StopFlash()
        {
            TrainRemoteControl.SerialPortHelper.WriteDoBit(4, 1, false);
        }

        /// <summary>
        /// 蜂鸣器鸣叫
        /// </summary>
        public void StartAlarm()
        {
            TrainRemoteControl.SerialPortHelper.WriteDoBit(4, 0, true);
        }

        /// <summary>
        /// 蜂鸣器停止
        /// </summary>
        public void StopAlarm()
        {
            TrainRemoteControl.SerialPortHelper.WriteDoBit(4, 0, false);
        }

        /// <summary>
        /// 获取按钮状态
        /// </summary>
        /// <returns></returns>
        public bool GetBtnStatus()
        {
            return TrainRemoteControl.SerialPortHelper.ReadDoBit(4, 7);
        }

    }


    public class TimperatureAcquisition
    { 
        //0：正常无报警
        //1：温升超限报警——超过允许温差；
        //2：温度超限报警——超过允许最高温；
        //3：故障1报警（传感器短路）
        //4：故障2报警（传感器断开）
        //5：失联（与探测单元通信故障）

        string[] sErrorMsg = new string[] { "正常无报警", "超过允许温差", "超过允许最高温", "传感器短路", "传感器断开", "探测器失联" };

        /// <summary>
        /// 0x2C, 0x01, 0x8A, 0x02 温差 温度限值
        /// 0xFF, 0xFF校验位  
        /// </summary>
        byte[] bRead = new byte[] { 0xA5, 0xA5, 0x08, 0x0D, 0x04, 0x00, 0x2C, 0x01, 0x8A, 0x02, 0xFF, 0xFF, 0x16 };


        /// <summary>
        /// 08
        /// </summary>
        byte[] bTrainNo = new byte[] { 0xA5, 0xA5, 0x00, 0x01, 0x01, 0x00, 0x08, 0xA7, 0x05, 0x16 };


        /// <summary>
        /// 123456
        /// </summary>
        byte[] bSerialNo = new byte[] { 0xA5, 0xA5, 0x08, 0x05, 0x06, 0x00, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x22, 0xB8, 0x16 };

     
        /// <summary>
        /// 读取温度，报警状态
        /// </summary>
        /// <param name="sMaxDvalue"></param>
        /// <param name="sMaxTemp"></param>
        /// <returns></returns>
        public List<CellTerminal> ReadTemperature(string sStation, string sMaxDvalue, string sMaxTemp)
        {
            List<CellTerminal> lstCellTerminal = new List<CellTerminal>();
            byte[] tempRead = bRead;

            sMaxDvalue = (Convert.ToInt16(sMaxDvalue) * 10).ToString("X4");
            sMaxTemp = (Convert.ToInt16(sMaxTemp) * 10).ToString("X4");

            tempRead[2] = Convert.ToByte("0x" + sStation, 16);
            tempRead[6] = Convert.ToByte("0x" + sMaxDvalue.Substring(2, 2), 16);
            tempRead[7] = Convert.ToByte("0x" + sMaxDvalue.Substring(0, 2), 16);
            tempRead[8] = Convert.ToByte("0x" + sMaxTemp.Substring(2, 2), 16);
            tempRead[9] = Convert.ToByte("0x" + sMaxTemp.Substring(0, 2), 16);

            //string sBackInfo = "A9 A9 08 0E FA 00 08 00 36 36 36 36 36 36 15 09 18 16 36 08 01 00 FF 00 02 00 04 01 03 00 07 01 04 00 FF 00 05 00 FF 00 06 00 01 01 07 00 03 01 08 00 04 01 09 00 01 01 "
            //+ "0A 00 01 01 0B 00 06 01 0C 00 03 01 0D 00 01 01 0E 00 01 01 0F 00 01 01 10 00 02 01 11 00 04 01 12 00 01 01 13 00 04 01 14 00 06 01 15 00 05 01 16 00 00 01 17 00 02 01 18 00 02 01 19 00 "
            //+ "FF 00 1A 00 03 01 1B 00 00 01 1C 00 02 01 1D 00 07 01 1E 00 07 01 1F 00 02 01 20 00 04 01 21 00 03 01 22 00 00 01 23 00 02 01 24 00 FF 00 25 00 03 01 26 00 03 01 27 00 04 01 28 00 03 01 "
            //+ "29 00 02 01 2A 00 01 01 2B 00 01 01 2C 00 03 01 2D 00 FF 00 2E 00 00 01 2F 00 FF 00 30 00 01 01 31 00 02 01 32 00 FF 00 33 00 01 01 34 05 00 00 35 05 00 00 36 05 00 00 37 05 00 00 38 05 "
            //+ "00 00 39 05 00 00 64 00 06 01 65 00 0A 01 23 DB 16";

            //char[] c = new char[] { ' ' };

            //string[] dfdf = sBackInfo.Split(c);

            //byte[] bInfomation = new byte[259];

            //for (int i = 0; i < 259; i++)
            //{
            //    bInfomation[i] = (byte)Convert.ToInt32("0x" + dfdf[i], 16);
            //}

            byte[] bInfomation = TrainRemoteControl.SerialPortHelper2.ReadAllTemp(tempRead);

            if (bInfomation.Length != 0)
            {
                for (int i = 0; i < 59; i++)
                {
                    CellTerminal ct=new CellTerminal();
                    ct.n = bInfomation[20 + i * 4];
                    ct.s = bInfomation[21 + i * 4];

                    int iTemp = Convert.ToInt32(bInfomation[23 + i * 4].ToString("X2") + bInfomation[22 + i * 4].ToString("X2"), 16);
                    ct.t = iTemp / 10f;

                    lstCellTerminal.Add(ct);
                }
            }

            //if (DateTime.Now.Second%2==0)
            //{
            //    lstCellTerminal[56].Status = 4;
            //}
            //else
            //{
            //    lstCellTerminal[56].Status = 0;
            //}
            return lstCellTerminal;
        }

        /// <summary>
        /// 设置站号，启动程序时就要设置
        /// </summary>
        /// <param name="sTrainNo"></param>
        public bool SetTrainNo(string sTrainNo)
        {
            bool bSetDone;
            try
            {
                byte[] tempRead = bTrainNo;

                tempRead[6] = Convert.ToByte("0x" + sTrainNo, 16);

                bSetDone = TrainRemoteControl.SerialPortHelper2.SetTrainNo(tempRead);

                return bSetDone;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 设置车厢编号（选择性使用）
        /// </summary>
        /// <param name="sSerialNo"></param>
        public bool SetSerialNo(string sTrainNo, string slcNumber)
        {
            byte[] tempRead = bTrainNo;
            slcNumber=slcNumber.PadLeft(6,'0');
            byte[] array = System.Text.Encoding.ASCII.GetBytes(slcNumber);


            tempRead[2] = Convert.ToByte("0x" + sTrainNo, 16);
            tempRead[6] = array[0];
            tempRead[7] = array[1];
            tempRead[8] = array[2];
            tempRead[9] = array[3];
            tempRead[10] = array[4];
            tempRead[11] = array[5];

            bool bSetDone = TrainRemoteControl.SerialPortHelper2.SetTrainSerialNumber(tempRead);

            return bSetDone;
        }
    }
}
