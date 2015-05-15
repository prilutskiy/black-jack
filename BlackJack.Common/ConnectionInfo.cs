using System;

namespace BlackJack.Common
{
    public class ConnectionInfo
    {
        public static String DeafultConfigFilePath = @"blackjack.config";
        public String IpAddress { get; set; }
        public Int16 Port { get; set; }
    }
}