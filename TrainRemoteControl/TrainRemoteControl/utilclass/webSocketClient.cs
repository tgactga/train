using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebSocketSharp;

namespace TrainRemoteControl.utilclass
{
    class webSocketClient
    {
        public static void sedMsg(String sendWebMsg)
        {

            string webSocketURL = "";
            
            webSocketURL = "ws://sort.tjh.com:8080/fzxt_tj/wsServlet"; //服务器地址
           
            using (var ws = new WebSocket(webSocketURL))
            {
                ws.Connect();
                ws.Send(sendWebMsg);
                ws.Close();
            }


        }

    }
}



