//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace LR.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class InspectionRecords
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
