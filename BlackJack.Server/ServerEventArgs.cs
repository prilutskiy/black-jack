using System;
using System.Net.Sockets;

namespace BlackJack.Server
{
    public class ServerEventArgs : EventArgs
    {
        public String Message { get; set; }
        public Socket ClientSocket { get; set; }
    }
}