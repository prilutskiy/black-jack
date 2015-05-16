using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BlackJack.Common;

namespace BlackJack.Server
{
    public class ServerContext
    {
        public  Queue<Player> ClassicQueue { get; set; }
        public List<Connection> Trusted { get; set; }
        public List<Connection> Untrusted { get; set; }
        public IPEndPoint EndPoint { get; set; }
        public List<Tuple<Player, Player, ServerGameManager>> ClassicGames { get; set; }
        public List<Thread> RunningThreads { get; set; }
    }
}
