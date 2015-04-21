using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Common;

namespace BlackJack.NetworkTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            var tcpClient = new TcpClient();
            tcpClient.Connect("127.0.0.1", 777);
            using (var connection = new Connection(tcpClient.Client))
            {
                var success = connection.ReceiveHandshake();
                var s = (MethodInfo.GetCurrentMethod() as MethodInfo).ToMethodSignature();
                connection.SendMethodCallRequest(new MethodCallRequest(s, new List<object>()));
                var response = connection.ReceiveResponse();
                Console.WriteLine(response.Message);
                Console.ReadLine();
            }
        }
    }
}
