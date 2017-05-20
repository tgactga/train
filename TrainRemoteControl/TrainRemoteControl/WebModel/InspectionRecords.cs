using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainRemoteControl.WebModel
{
    [Serializable]
    class InspectionRecords
    {
        public int id { get; set; }
        public string lcNum { get; set; }
        public int status { get; set; }
        public System.DateTime planTime { get; set; }
        public Nullable<System.DateTime> recordTime { get; set; }
        public string worker { get; set; }
        public string remarks { get; set; }

        public virtual trainInfo trainInfo { get; set; }

    }
}
