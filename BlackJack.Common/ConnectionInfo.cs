using System;

namespace BlackJack.Common
{
    public class ConnectionInfo
    {
        public static String DeafultConfigFilePath = @"blackjack.config";
        public static short DefaultPort = 777;
        public String IpAddress { get; set; }
        public Int16 Port { get; set; }
    }
}