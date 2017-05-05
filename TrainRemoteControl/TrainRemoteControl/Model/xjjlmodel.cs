using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainRemoteControl.Model
{
    class xjjlmodel
    {
        public string lcNumber
        { get; set; }
        public int AllCheckTime
        { get; set; }
        public int CheckTimes
        { get; set; }
        public int NoCheckTimes
        { get; set; }
        public int CheckLateTimes
        { get; set; }
        public double CheckFrequency
        { get; set; }
        public double CheckLateFrequency
        { get; set; }
    }
}
