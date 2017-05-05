using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Net;
using System.Collections.Specialized;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace TrainRemoteControl.utilclass
{
    class ComputerInfo
    {
        public static string getLocalMac()
        {
            string mac = null;
            ManagementObjectSearcher query = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection queryCollection = query.Get();
            foreach (ManagementObject mo in queryCollection)
            {
                if (mo["IPEnabled"].ToString() == "True")
                    mac = mo["MacAddress"].ToString();
            }
            return (mac);
        }

        public static string GetLocalIpv4()
        {
            //事先不知道ip的个数，数组长度未知，因此用StringCollection储存
            IPAddress[] localIPs;
            localIPs = Dns.GetHostAddresses(Dns.GetHostName());
            StringCollection IpCollection = new StringCollection();
            foreach (IPAddress ip in localIPs)
            {
                //根据AddressFamily判断是否为ipv4,如果是InterNetWork则为ipv6
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    IpCollection.Add(ip.ToString());
            }
            string[] IpArray = new string[IpCollection.Count];
            IpCollection.CopyTo(IpArray, 0);
            return IpArray[0];
        }

        public static string GetUserName()
        {
            try
            {
                string st = "";
                ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {

                    st = mo["UserName"].ToString();

                }
                moc = null;
                mc = null;
                return st;
            }
            catch
            {
                return "unknow";
            }
             
        }


         /// <summary>
           /// 用于检查IP地址或域名是否可以使用TCP/IP协议访问(使用Ping命令),true表示Ping成功,false表示Ping失败 
           /// </summary>
           /// <param name="strIpOrDName">输入参数,表示IP地址或域名</param>
           /// <returns></returns>
           public static bool PingIpOrDomainName(string strIpOrDName)
           {
               try
               {
                   Ping objPingSender = new Ping();
                   PingOptions objPinOptions = new PingOptions();
                   objPinOptions.DontFragment = true;
                   string data = "";
                   byte[] buffer = Encoding.UTF8.GetBytes(data);
                   int intTimeout = 120;
                   PingReply objPinReply = objPingSender.Send(strIpOrDName, intTimeout, buffer, objPinOptions);
                   string strInfo = objPinReply.Status.ToString();
                   if (strInfo == "Success")
                   {
                       return true;
                   }
                   else
                   {
                       return false;
                   }
               }
               catch (Exception)
               {
                   return false;
               }
           }
       







    }
}
