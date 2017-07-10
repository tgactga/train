using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainRemoteControl.utilclass
{
    class IniVarUtil
    {
        public static void iniXunjianVar()
        {

            Program.g_inspectionRecord.getStatus = " ";
            Program.g_inspectionRecord.getRecordTime = DateTime.Now;
            Program.g_inspectionRecord.getContent = "测试备注";
            Program.g_inspectionRecord.getBjtime = DateTime.Now;
            Program.g_inspectionRecord.getWorker = "张三丰";
            Program.g_inspectionRecord.lcNumber = Program.g_lcNumber;
        }
    }
}
