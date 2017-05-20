using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainRemoteControl.Model;
using MSXML2;
 

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

        public static string uploadCriticalData(List<CriticalData> criticalDataList)
        {          
            Program.WriteLog("调用web服务，上传关键数据");
            List<TrainRemoteControl.WebModel.CriticalData> cdList = new List<WebModel.CriticalData>();
           
            for (int i = 0; i < criticalDataList.Count;i++)  {
                TrainRemoteControl.WebModel.CriticalData cd  = new WebModel.CriticalData();
                cd.alarmValue = criticalDataList[i].AlarmValue;
                cd.current = criticalDataList[i]._Current;
                cd.dateTime = criticalDataList[i].Date;
                cd.frequency = criticalDataList[i].Frequency;
                cd.generatorId = criticalDataList[i].GeneratorId;
                cd.lcNum = criticalDataList[i].LcNum;
                cd.motorPower = criticalDataList[i].MotorPower;
                cd.motorSpeed = criticalDataList[i].MotorSpeed;
                cd.oilMass = criticalDataList[i].OilMass;
                cd.oilPress = criticalDataList[i].OilPress;
                cd.powerFactor = criticalDataList[i].PowerFactor;
                cd.trainInfo = null;
                cd.voltage = criticalDataList[i].Voltage;
                cd.waterTemp = criticalDataList[i].WaterTemp;
                cdList.Add(cd);
            }

            string str = System.Text.Encoding.Default.GetString(Program.SerializeObject(cdList));
            string  returnret = Program.g_trainService.SaveCriticalData(str);
            if ("0".Equals(returnret))
            {
                Program.WriteLog("调用web服务返回：0  ，调用成功！");
            }           
            return returnret;
        }

        public static string uploadInspectionRecords(_XJmodel inspection)
        {
            Program.WriteLog("调用web服务，上传巡检信息");
            string ret = Program.g_trainService.SaveInspectionRecord("");
            Program.WriteLog("调用web服务返回：" + ret);
            return "";
        }

        public static Boolean urlIsReach(String url)
        {
            if (url == null)
            {
                return false;
            }
            try
            {                 
                XMLHTTP http = new XMLHTTP();
                try
                {
                    http.open("GET", url, false, null, null);
                    http.send(url);
                    int status = http.status;
                    if (status == 200)
                    {                         
                        return true;
                    }
                    else
                    {
                       Program.WriteLog("不可用status:" + status.ToString());
                       return false;
                    }
                }
                catch
                {
                    Console.WriteLine("不可用");
                }
            }
            catch (Exception e)
            {
                Program.WriteLog("异常" + e.ToString());
                return false;
            }
            return false;
        }

    }
}
