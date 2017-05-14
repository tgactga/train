
namespace TrainRemoteControl.Model
{
    public struct CommonOriginalData
    {
        private float oilMass;//油量

        public float OilMass
        {
            get { return oilMass; }
        }
        private float fireAlarmValue;//烟火报警值

        public float FireAlarmValue
        {
            get { return fireAlarmValue; }
        }
        private bool upOilPlace;//上油箱油位//个人觉得采集处理速度比较重要,而系统处理采用四字节最快，又,struct为值类型，在非迭代，非labma表达式中时，将在栈中分配所需空间，释放及时快速，故将原有byte改为int

        public bool UpOilPlace
        {
            get { return upOilPlace; }
        }
        private bool upWaterPlace;//上水箱水位

        public bool UpWaterPlace
        {
            get { return upWaterPlace; }
        }
        private bool battaryVoltage;//24v储电池电压

        public bool BattaryVoltage
        {
            get { return battaryVoltage; }
        }

        public CommonOriginalData(float oilMass, float fireAlarmValue, bool upOilPlace, bool upWaterPlace, bool battaryVoltage)
        {
            this.oilMass = oilMass;
            this.fireAlarmValue = fireAlarmValue;
            this.upOilPlace = upOilPlace;
            this.upWaterPlace = upWaterPlace;
            this.battaryVoltage = battaryVoltage;
        }

    }
}
