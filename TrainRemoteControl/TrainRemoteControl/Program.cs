using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text;
using TrainRemoteControl.utilclass;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;
using System.Web.Script.Serialization;
using System.Threading;
using TrainRemoteControl.Model;
using TrainRemoteControl.test;
 

namespace TrainRemoteControl
{
    static class Program
    {
        //web服务        
        public static TrainRemoteControl.TrainWebService.TrainServiceClient g_trainService = new TrainWebService.TrainServiceClient();

        public static  CriticalData [] g_criticalDataList  = new CriticalData [3];
        public static List<CellTerminal> g_tempCellsTerminalList = null;
        public static bool g_isOpenTempCom = true;  //
        public static bool g_isNetState = false;  //网络状态
        public static bool g_isAlarm = false;  //是否报警
        public static bool g_isflashed = false; //是否闪烁报警灯
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

        //温度有关静态变量
        public static String g_stationNo = "";
        public static String g_readTempTime = "";
        public static String g_TemperatureInterval = "";
        public static String g_maxTemp = "";
        public static String g_axDvalue = "";
        
        

        public static String g_waterFormula1 = "";
        public static String g_oilFormula1 = "";
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Process[] ps = Process.GetProcesses();
            foreach (Process item in ps)
            {
                if (item.ProcessName == "TrainRemoteControl")
                {
                    item.Kill();
                }
            }

            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            //Cursor.Hide();//注释鼠标

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BaseForm());
            //Application.Run(new TestMoreWindows());
        }
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            WriteLog("CurrentDomain_UnhandledException: " + sender.GetType().FullName + " " + (e.ExceptionObject as System.Exception).ToString());
           MessageBox.Show ("系统故障,请联系管理人员") ;
             
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            WriteLog("Application_ThreadException: " + sender.GetType().FullName + " " + e.Exception.ToString());
            MessageBox.Show ("系统故障,请联系管理人员") ;
            
        }
        static Program()
        {

            //ini.IniWriteValue("TermInfo", "checi", "T141");
            g_checi = ini.IniReadValue("TermInfo", "checi");//读取车次号  
            //ini.IniWriteValue("TermInfo", "lcNumber", "000002");
            g_lcNumber = ini.IniReadValue("TermInfo", "lcNumber");//读取列车号  
            g_deadline = ini.IniReadValue("TermInfo", "deadline");
            g_inspectionInterval = ini.IniReadValue("TermInfo", "inspectionInterval");
            g_localListenPort = ini.IniReadValue("TermInfo", "localListenPort");

            g_serialNum = ini.IniReadValue("TermInfo", "serialNum");
            g_train = ini.IniReadValue("TermInfo", "train");
            g_url = ini.IniReadValue("TermInfo", "url");

            g_localVadioUsername = ini.IniReadValue("TermInfo", "localVedioUserName");
            g_localVadioPassword = ini.IniReadValue("TermInfo", "localVedioPwd");
            g_localVedioIp = ini.IniReadValue("TermInfo", "localVedioIp");
            g_localVedioPort = ini.IniReadValue("TermInfo", "localVedioPort");


            g_connString = ini.IniReadValue("TermInfo", "connString");

            g_comPort = ini.IniReadValue("TermInfo", "comPort");
            g_comPortTemperature = ini.IniReadValue("TermInfo", "comPortTemperature");
            g_stationNo = ini.IniReadValue("TermInfo", "stationNo");
            g_readTempTime = ini.IniReadValue("TermInfo", "readTempTime");
            g_TemperatureInterval = ini.IniReadValue("TermInfo", "TemperatureInterval");
            g_maxTemp = ini.IniReadValue("TermInfo", "maxTemp");
            g_axDvalue = ini.IniReadValue("TermInfo", "axDvalue");

            g_waterFormula1 = ini.IniReadValue("TermInfo", "WaterFormula1");
            g_oilFormula1 = ini.IniReadValue("TermInfo", "OilFormula1");

            CriticalData cd = new CriticalData(Program.g_serialNum, 1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, DateTime.Now, DateTime.Now, false, "1");
            g_criticalDataList[0] =  cd;
            g_criticalDataList[1] = cd;
            g_criticalDataList[2] = cd;
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

        //对象序列化(用于保存txt文件？？)
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


        //将object转换为string对象
        public static string ScriptSerialize<T>(T t)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(t);
        }

 

         
    }
}
