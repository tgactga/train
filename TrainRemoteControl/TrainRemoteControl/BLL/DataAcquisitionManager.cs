using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainRemoteControl.Model;
using TrainRemoteControl.utilclass;
using System.Threading;

namespace TrainRemoteControl.BLL
{
    class DataAcquisitionManager
    {
        private TimperatureAcquisition ta = new TimperatureAcquisition();
        private DataAcquisition da = new DataAcquisition(); //采集数据对象
        private static string[] WaterFormula = new string[3] { Program.g_waterFormula1, Program.g_waterFormula1, Program.g_waterFormula1 };
        private static string[] OilFormula = new string[3] { Program.g_oilFormula1, Program.g_oilFormula1, Program.g_oilFormula1 };
        
        private Expression[] WaterExpression = new Expression[3];//水温计算类
        private Expression[] OilExpression = new Expression[3];//计算类
        int[] newIndex = new int[]
        {
            3,4,
            2,5,
            1,6,
            9,10,
            8,11,
            7,12,
            39,38,37,

            15,16,
            14,17,
            13,18,
            21,22,
            20,23,
            19,24,
            48,47,46,

            27,28,
            26,29,
            25,30,
            33,34,
            32,35,
            31,36,
            57,56,55,

            //40,41,42,43,44,45,
            //49,50,51,52,53,54,
            42,45,41,44,40,43,
            51,54,50,53,49,52    

        };
        public DataAcquisitionManager()
        {
            for (int i = 0; i < 3; i++)
            {
                if (WaterFormula[i] != "")
                {
                    WaterExpression[i] = new Expression(WaterFormula[i]);
                }
                if (OilFormula[i] != "")
                {
                    OilExpression[i] = new Expression(OilFormula[i]);
                }
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// 获取电机关键数据
        /// </summary>
        /// <param name="oilMass">油量</param>
        /// <param name="generatorId">电机号</param>
        /// <param name="alarmValue">公共报警值</param>
        /// <param name="voltage">电压</param>
        /// <returns>关键数据</returns>
        public CriticalData GetCriticalData(float oilMass, int generatorId, int alarmValue, float voltage, float voltage24V)
        {
            PartialOriginalData partialOriginalData = da.GetPartialOriginalData(generatorId, voltage);
            CriticalData criticalData = new CriticalData();
            AlarmInfo alarmInfo1 = new AlarmInfo();
            alarmInfo1.AlarmValue = alarmValue;
            criticalData.GeneratorId = generatorId;
            criticalData.Date = DateTime.Now;
            criticalData._Current = CurrentConvert(partialOriginalData._Current);
            criticalData.Frequency = FrequencyConvert(partialOriginalData.Frequency);
            criticalData.OilMass = oilMass;
            criticalData.OilPress = OilPressConvert(partialOriginalData.GeneratorId, partialOriginalData.OilPress, voltage24V);
            criticalData.PowerFactor = PowerFactorConvert(partialOriginalData.PowerFactor);
            criticalData.Voltage = voltageConvert(partialOriginalData.Voltage);
            criticalData.WaterTemp = WaterTempConvert(partialOriginalData.GeneratorId, partialOriginalData.WaterTemp, voltage24V);//2 parameter
            criticalData.MotorPower = GetMotorPower(criticalData.Voltage, criticalData._Current);
            criticalData.MotorSpeed = GetMotorSpeed(criticalData.Frequency);
            switch (generatorId)
            {
                case 1:
                    alarmInfo1.AlarmMS1 = judgeAlarmMS(criticalData.MotorSpeed);
                    alarmInfo1.AlarmOP1 = judgeOilPress(criticalData.OilPress);
                    alarmInfo1.AlarmWT1 = judgeAlarmWT(criticalData.WaterTemp);
                    alarmInfo1.OilLeak1 = partialOriginalData.OilLeak;
                    break;
                case 2:
                    alarmInfo1.AlarmMS2 = judgeAlarmMS(criticalData.MotorSpeed);
                    alarmInfo1.AlarmOP2 = judgeOilPress(criticalData.OilPress);
                    alarmInfo1.AlarmWT2 = judgeAlarmWT(criticalData.WaterTemp);
                    alarmInfo1.OilLeak2 = partialOriginalData.OilLeak;
                    break;
                case 3:
                    alarmInfo1.AlarmMS3 = judgeAlarmMS(criticalData.MotorSpeed);
                    alarmInfo1.AlarmOP3 = judgeOilPress(criticalData.OilPress);
                    alarmInfo1.AlarmWT3 = judgeAlarmWT(criticalData.WaterTemp);
                    alarmInfo1.OilLeak3 = partialOriginalData.OilLeak;
                    break;
            }
            criticalData.AlarmValue = alarmInfo1.AlarmValue;

            return criticalData;
        }


        public List<CellTerminal>  DoReadTemp()
        {            
            // List<CellTerminal> cellsTerminal = null;
            while (true)
            {              
                List<CellTerminal> cellsTerminal = ta.ReadTemperature(Program.g_stationNo, Program.g_axDvalue, Program.g_maxTemp);
                List<CellTerminal> tempCellsTerminal = new List<CellTerminal>();

                if (cellsTerminal.Count == 59)
                {
                    for (int i = 0; i < 57; i++)
                    {
                        cellsTerminal[newIndex[i] - 1].n = (i + 1);
                        tempCellsTerminal.Add(cellsTerminal[newIndex[i] - 1]);
                    }
                    cellsTerminal[57].n = 100;
                    tempCellsTerminal.Add(cellsTerminal[57]);
                    cellsTerminal[58].n = 101;
                    tempCellsTerminal.Add(cellsTerminal[58]);

                    return tempCellsTerminal;
                    //TemperatureDataHandle(tempCellsTerminal);

                    //Thread.Sleep(Convert.ToInt32(Program.g_readTempTime));
                }

                Thread.Sleep(1000);           

            }
        }









        /// <summary>
        /// 开始监听按钮状态
        /// </summary>
        public void StartListenBtnStatus()
        {
            //bCheck = true;
        }

        /// <summary>
        /// 判断烟火报警
        /// </summary>
        /// <param name="fireAlarmValue"></param>
        /// <returns></returns>
        public bool judgeFireAlarm(float fireAlarmValue)
        {
            //return false;
            return fireAlarmValue > 0;
        }




        /// <summary>
        /// 油压转化
        /// </summary>
        /// <param name="oilPress"></param>
        /// <returns></returns>
        private float OilPressConvert(int id, float oilPress, float voltageTemp)
        {
            float oil;

            if (voltageTemp < 0.5 || oilPress < 0.5)
            {
                oil = 0;
            }
            else
            {
                oil = (float)Math.Round(OilExpression[id - 1].Compute((double)oilPress, (double)voltageTemp * 5.1), 2);
            }

            return oil;
        }
        //水温 转化
        private float WaterTempConvert(int id, float waterTemp, float voltageTemp)
        {
            float water;

            if (voltageTemp < 0.5 || waterTemp < 0.5)
            {
                water = 0;
            }
            else
            {
                water = (float)Math.Round(WaterExpression[id - 1].Compute((double)waterTemp, (double)voltageTemp * 5.1), 2);
            }

            return water;
        }

        private float FrequencyConvert(float frequency)
        {
            return (float)Math.Round(frequency > 4 ? (frequency - 4) * 65 / 16 : 0, 2);

        }

        private float voltageConvert(float voltage)
        {
            return (float)Math.Round((voltage - 4) * 500 / 16, 2);
        }

        private float CurrentConvert(float current)
        {
            float newCurrent = current > 4 ? (current - 4) * 800 / 16 : 0;//存疑，转化结果为负值，待求教
            return (float)Math.Round(newCurrent, 2);
        }


        private float PowerFactorConvert(float powerFactor)//存疑，待求教<4.0||>20转化为1
        {
            double newPF;
            if (powerFactor < 4.0)
            {
                newPF = 1;
            }
            else
                if (powerFactor <= 12)
                {
                    newPF = (powerFactor - 4) * 0.5 / 8 + 0.5;
                }
                else
                    if (powerFactor < 20)
                    {
                        newPF = (20 - powerFactor) * 0.5 / 8 + 0.5;
                    }
                    else
                    {
                        newPF = 1;
                    }
            return (float)Math.Round(newPF, 2);

        }

        private float GetMotorSpeed(float CriticalDataFrequency)
        {
            return (float)Math.Round(CriticalDataFrequency * 30, 2);
        }

        private float GetMotorPower(float voltage, float current)
        {
            return (float)Math.Round(voltage * current / 1000 * 1.732, 2);
        }


        /// <summary>
        /// 判断油管泄露
        /// </summary>
        /// <param name="oilLeak"></param>
        /// <returns></returns>
        //private bool judgeOilLeak(int oilLeak)
        //{
        //    throw new Exception();
        //}

        /// <summary>
        /// 油压报警判断
        /// </summary>
        /// <param name="oilPress"></param>
        /// <returns></returns>
        private bool judgeOilPress(float oilPress)
        {
            return oilPress > 0 && oilPress < 1.8;//2
        }

        /// <summary>
        /// 水温报警
        /// </summary>
        /// <returns></returns>
        private bool judgeAlarmWT(float waterTemp)
        {
            return waterTemp > 93;//90
        }

        private bool judgeAlarmMS(float motorSpeed)
        {
            return motorSpeed > 1750;
        }



    }
}
