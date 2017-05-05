using System;
using System.Collections.Generic;


namespace TrainRemoteControl.Model
{

    
    //public partial class CriticalData
    //{
    //    public long id { get; set; }
    //    public string lcNum { get; set; }
    //    public int generatorId { get; set; }
    //    public double oilPress { get; set; }
    //    public double waterTemp { get; set; }
    //    public double frequency { get; set; }
    //    public double motorSpeed { get; set; }
    //    public double voltage { get; set; }
    //    public double current { get; set; }
    //    public double motorPower { get; set; }
    //    public double powerFactor { get; set; }
    //    public double oilMass { get; set; }
    //    public int alarmValue { get; set; }
    //    public System.DateTime dateTime { get; set; }

    //    public virtual trainInfo trainInfo { get; set; }
    //}




    public struct CriticalData
    {
        private int generatorId;
        private string lcNum;
        private float oilPress;
        private float waterTemp;
        private float frequency;
        private float motorSpeed;
        private float voltage;
        private float current;///---

        private float motorPower;
        private float powerFactor;
        private float oilMass;
        private int alarmValue;
        private DateTime dateTime;
        private bool run;

        /// <summary>
        /// 下位机序列号
        /// </summary>
        public string LcNum
        {
            get
            {
                return lcNum;
            }
            set
            {
                lcNum = value;
            }
        }
        public float Voltage
        {
            get { return voltage; }
            set { voltage = value; }
        }

        public float _Current
        {
            get { return current; }
            set { current = value; }
        }

        /// <summary>
        /// 发电机编号
        /// </summary>
        public int GeneratorId
        {
            get
            {
                return generatorId;
            }
            set
            {
                generatorId = value;
            }
        }

        /// <summary>
        /// 油压
        /// </summary>
        public float OilPress
        {
            get
            {
                return this.oilPress;
            }
            set
            {
                oilPress = value;
            }
        }

        /// <summary>
        /// 水温
        /// </summary>
        public float WaterTemp
        {
            get
            {
                return waterTemp;
            }
            set
            {
                waterTemp = value;
            }
        }

        /// <summary>
        /// 频率
        /// </summary>
        public float Frequency
        {
            get
            {
                return frequency;
            }
            set
            {
                frequency = value;
            }
        }

        /// <summary>
        /// 发电机转速
        /// </summary>
        public float MotorSpeed
        {
            get
            {
                return motorSpeed;
            }
            set
            {
                motorSpeed = value;
            }
        }

        /// <summary>
        /// 发电机功率
        /// </summary>
        public float MotorPower
        {
            get
            {
                return motorPower;
            }
            set
            {
                motorPower = value;
            }
        }

        /// <summary>
        /// 功率因素
        /// </summary>
        public float PowerFactor
        {
            get
            {
                return powerFactor;
            }
            set
            {
                powerFactor = value;
            }
        }

        /// <summary>
        /// 油箱油量
        /// </summary>
        public float OilMass
        {
            get
            {
                return oilMass;
            }
            set
            {
                oilMass = value;
            }
        }

        /// <summary>
        /// 报警值
        /// </summary>
        public int AlarmValue
        {
            get
            {
                return alarmValue;
            }
            set
            {
                alarmValue = value;
            }
        }

        /// <summary>
        /// 采集时间
        /// </summary>
        public DateTime Date
        {
            get
            {
                return dateTime;
            }
            set
            {
                dateTime = value;
            }
        }

        public bool Run
        {
            get
            {
                return run;
            }
            set
            {
                run = value;
            }
        }

        public CriticalData(string lcNum, int generatorId, float oilPress, float waterTemp, float frequency, float motorSpeed, float voltage, float current, float motorPower, float powerFactor, float oilMass, int alarmValue, DateTime date)
        {
            this.lcNum = lcNum;
            this.generatorId = generatorId;
            this.oilPress = oilPress;
            this.waterTemp = waterTemp;
            this.frequency = frequency;
            this.motorSpeed = motorSpeed;
            this.voltage = voltage;
            this.current = current;
            this.motorPower = motorPower;
            this.powerFactor = powerFactor;
            this.oilMass = oilMass;
            this.alarmValue = alarmValue;
            this.dateTime = date;
            this.run = false;
        }

        public CriticalData(string lcNum, int generatorId, float oilPress, float waterTemp, float frequency, float motorSpeed, float voltage, float current, float motorPower, float powerFactor, float oilMass, int alarmValue, DateTime date, bool run)
        {
            this.lcNum = lcNum;
            this.generatorId = generatorId;
            this.oilPress = oilPress;
            this.waterTemp = waterTemp;
            this.frequency = frequency;
            this.motorSpeed = motorSpeed;
            this.voltage = voltage;
            this.current = current;
            this.motorPower = motorPower;
            this.powerFactor = powerFactor;
            this.oilMass = oilMass;
            this.alarmValue = alarmValue;
            this.dateTime = date;
            this.run = run;
        }
    }
}
