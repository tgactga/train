using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainRemoteControl.Model;

namespace TrainRemoteControl.utilclass
{
    class WebServiceUtil
    {

        public static string uploadAlarmRecords(AlarmInfo alarmInfo)
        {
            Program.WriteLog("调用web服务，上传报警信息");

            string ret = Program.g_trainService.SaveTemperature("");
            Program.WriteLog("调用web服务返回：");
            return "1";
        }

        public static string uploadCriticalData(CriticalData criticalData)
        {         
            List<CriticalData> criticalDataList = new List<CriticalData>();
            Program.WriteLog("调用web服务，上传关键数据");          
            string str = System.Text.Encoding.Default.GetString(Program.SerializeObject(criticalDataList));
            Program.g_trainService.SaveCriticalData(str);
            Program.WriteLog("调用web服务返回：");
            return "";
        }

        public static string uploadInspectionRecords(_XJmodel inspection)
        {
            Program.WriteLog("调用web服务，上传巡检信息");
            string ret = Program.g_trainService.SaveInspectionRecord("");
            Program.WriteLog("调用web服务返回：" + ret);
            return "";
        }
        

    }
}
