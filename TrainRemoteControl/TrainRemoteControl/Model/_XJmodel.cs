using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainRemoteControl.Model
{
    public class _XJmodel
    {
        public string lcNumber
        { get; set; }
        /// <summary>
        /// 巡检状态 已检 未检 晚检
        /// </summary>
        public string getStatus
        { get; set; }
        /// <summary>
        /// 蜂鸣
        /// </summary>
        //public bool getFm
        //{ get; set; }
        /// <summary>
        /// 蜂鸣器启动时间（应检时间）
        /// </summary>
        public DateTime getBjtime
        { get; set; }
        /// <summary>
        /// 记录时间
        /// </summary>
        public DateTime? getRecordTime
        { get; set; }
        /// <summary>
        /// 巡检人
        /// </summary>
        public string getWorker
        { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string getContent
        { get; set; }
    }
}
