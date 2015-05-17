using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using BlackJack.Common;
using DevExpress.XtraTab;

namespace BlackJack.Server
{
    public class ServerContext
    {
        public BlackJackRepository AppRepository { get; set; }
        public Queue<Player> ClassicQueue { get; set; }
        public List<Connection> Trusted { get; set; }
        public List<Connection> Untrusted { get; set; }
        public IPEndPoint EndPoint { get; set; }
        public List<Tuple<Player, Player, ServerGameManager>> ClassicGames { get; set; }
        public List<Thread> RunningThreads { get; set; }
        public XtraTabControl TabControl { get; set; }
        public int MaxConnections { get; set; }
    }
}