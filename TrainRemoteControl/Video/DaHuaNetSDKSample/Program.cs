using System;
using System.Windows.Forms;
namespace DaHuaNetSDKSample
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
             StringUtil.AppName = @"DaHuaNetSDKSample";

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frm_MainC());
        }
    }
}