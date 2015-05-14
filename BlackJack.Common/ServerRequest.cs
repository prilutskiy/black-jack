using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Common
{
    [Serializable]
    public class ServerRequest
    {
        public MethodCallRequest RequestedMethod { get; set; }
        public ServerMessageType RequestType { get; set; }
        public Credentials Credentials { get; set; }
        public GameType GameType { get; set; }
    }
}
