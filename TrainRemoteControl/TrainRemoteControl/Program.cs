using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text;
using TrainRemoteControl.utilclass;
using System.Runtime.Serialization.Formatters.Binary;
 

namespace TrainRemoteControl
{
    static class Program
    {
        //web服务        
        public static TrainRemoteControl.TrainWebService.TrainServiceClient g_trainService = new TrainWebService.TrainServiceClient();
        public static bool g_isNetState = false;  //网络状态
        public static bool g_isAlarm = false;  //是否报警
        public static bool g_isInspected = false;  //是否巡检
        public static Form singleForm = null;
        public static INIClass ini = new INIClass("D://train//train.ini");
        public static String g_checi = "";
        public static String g_lcNumber = "";
        public static string g_dbPath = "D:\\train\\Demo.db3";

        public static String g_localVedioIp= "";
        public static String g_localVedioPort = "";
        public static String  g_localVadioUsername= "";
        public static String  g_localVadioPassword= "";   
    
        public static String g_comPortTemperature = "";           			   
        public static String g_deadline= "";
        public static String g_inspectionInterval= "";
        public static String g_localListenPort= "";
         
        public static String g_serialNum= "";
        public static String g_train= "";
         
         
        public static String g_url = "";
        
        public static String g_connString= "";
        public static String g_comPort = "";


        public static String g_stationNo = "";
        public static String g_waterFormula1 = "";
        public static String g_oilFormula1 = "";
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BaseForm());
            //Application.Run(new TestFrom());
        }

        static Program()
        {
            
            

            //ini.IniWriteValue("TermInfo", "checi", "T141");
            g_checi = ini.IniReadValue("TermInfo", "checi");//读取车次号  
            //ini.IniWriteValue("TermInfo", "lcNumber", "000002");
            g_lcNumber = ini.IniReadValue("TermInfo", "lcNumber");//读取列车号  
            g_deadline=ini.IniReadValue("TermInfo", "deadline");                      
              g_inspectionInterval=ini.IniReadValue("TermInfo", "inspectionInterval");                   
              g_localListenPort=ini.IniReadValue("TermInfo", "localListenPort");     
                                 
              g_serialNum=ini.IniReadValue("TermInfo", "serialNum");                  
              g_train=ini.IniReadValue("TermInfo", "train");
              g_url = ini.IniReadValue("TermInfo", "url");

              g_localVadioUsername = ini.IniReadValue("TermInfo", "localVedioUserName");
              g_localVadioPassword = ini.IniReadValue("TermInfo", "localVedioPwd");     
              g_localVedioIp=ini.IniReadValue("TermInfo", "localVedioIp");      				
              g_localVedioPort=ini.IniReadValue("TermInfo", "localVedioPort");
              

              g_connString=ini.IniReadValue("TermInfo", "connString");     
              
              g_comPort=ini.IniReadValue("TermInfo", "comPort");
              g_comPortTemperature = ini.IniReadValue("TermInfo", "comPortTemperature");

              g_stationNo = ini.IniReadValue("TermInfo", "stationNo");

              g_waterFormula1 = ini.IniReadValue("TermInfo", "WaterFormula1");
              g_oilFormula1 = ini.IniReadValue("TermInfo", "OilFormula1");
            
          
        }


        // 写日志
        public static void WriteLog(string strLogInfo)
        {
            DateTime dt = DateTime.Now;
            string strLogName = "train" + dt.ToString("yyyy-MM-dd") + ".log";
            try
            {
                if (!Directory.Exists("D:\\train\\Logs"))
                    Directory.CreateDirectory("D:\\train\\Logs");
                FileStream fs = new FileStream("D:\\train\\Logs\\" + strLogName, FileMode.Append);
                StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                if (strLogInfo != "")
                {
                    Console.WriteLine(dt.ToString("HH:mm:ss:fff") + "   " + strLogInfo);
                    sw.WriteLine(dt.ToString("HH:mm:ss:fff") + "   " + strLogInfo);
                }
                sw.Flush();
                sw.Close();
                fs.Close();
            }
            catch (System.Exception error)
            {
                WriteLog(error.Message);
                return;
            }
        }

        //对象序列化
        public static byte[] SerializeObject(object pObj)
        {
            if (pObj == null)
                return null;
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(memoryStream, pObj);
            memoryStream.Position = 0;
            byte[] read = new byte[memoryStream.Length];
            memoryStream.Read(read, 0, read.Length);
            memoryStream.Close();
            return read;
        }
         
    }
}
