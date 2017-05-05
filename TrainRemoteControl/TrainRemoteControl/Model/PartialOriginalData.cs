
namespace TrainRemoteControl
{
    public class PartialOriginalData
    {
        private int generatorId;

        public int GeneratorId
        {
            get { return generatorId; }
        }
        private float voltage;

        public float Voltage
        {
            get { return voltage; }
        }
        private float oilPress;//油压

        public float OilPress
        {
            get { return oilPress; }
        }
        private float waterTemp;//冷却水温

        public float WaterTemp
        {
            get { return waterTemp; }
        }
        private float current;//w电流

        public float _Current
        {
            get { return this.current; }
        }
        private float frequency;//频率

        public float Frequency
        {
            get { return frequency; }
        }
        private float powerFactor;//功率因子

        public float PowerFactor
        {
            get { return powerFactor; }
        }
        private bool oilLeak;//油压

        public bool OilLeak
        {
            get { return oilLeak; }
        }

        public PartialOriginalData(int gId, float voltage, float oilPress, float waterTemp, float current, float frequency, float powerFactor, bool oilLeak)
        {
            this.generatorId = gId;
            this.voltage = voltage;
            this.oilPress = oilPress;
            this.waterTemp = waterTemp;
            this.current = current;
            this.frequency = frequency;
            this.powerFactor=powerFactor;
            this.oilLeak = oilLeak;
        }
    }


    public class CellTerminal
    {
        private float temperature;
        private int status;
        private int no;

        public float t//温度
        {
            get 
            {
                return temperature;
            }
            set
            {
                this.temperature = value;
            }
        }

        public int s//状态值0-5
        {
            get
            {
                return status;
            }
            set
            {
                this.status = value;
            }
        }

        public int n //序号
        {
            get
            {
                return no;
            }
            set
            {
                this.no = value;
            }
        }
    }
}
