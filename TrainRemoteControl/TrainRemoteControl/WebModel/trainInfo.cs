using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainRemoteControl.WebModel
{
    [Serializable]
    class trainInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public trainInfo()
        {
            this.CriticalData = new HashSet<CriticalData>();
            this.tab_temperature = new HashSet<tab_temperature>();
            this.InspectionRecords = new HashSet<InspectionRecords>();
        }

        public string lcnum { get; set; }
        public string train { get; set; }
        public string route { get; set; }
        public string dhip { get; set; }
        public string belongto { get; set; }
        public string startdate { get; set; }
        public string starttime { get; set; }
        public string backtime { get; set; }
        public Nullable<int> takedays { get; set; }
        public string ipcip { get; set; }
        public Nullable<int> groupid { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CriticalData> CriticalData { get; set; }
        //public virtual group group { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tab_temperature> tab_temperature { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InspectionRecords> InspectionRecords { get; set; }
    }
}
