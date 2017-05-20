using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainRemoteControl.WebModel
{
    [Serializable]
    class CriticalData
    {
        public long id { get; set; }
        public string lcNum { get; set; }
        public int generatorId { get; set; }
        public double oilPress { get; set; }
        public double waterTemp { get; set; }
        public double frequency { get; set; }
        public double motorSpeed { get; set; }
        public double voltage { get; set; }
        public double current { get; set; }
        public double motorPower { get; set; }
        public double powerFactor { get; set; }
        public double oilMass { get; set; }
        public int alarmValue { get; set; }
        public System.DateTime dateTime { get; set; }

        public virtual trainInfo trainInfo { get; set; }
    }
}
