using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Common
{
    public class Connection : IDisposable
    {
        private const String HandshakePhrase = "Handshake";
        public Connection(Socket socket)
        {
            Socket = socket;
            if (!Socket.Connected)
                throw new InvalidOperationException("Socket is not connected");
        }

        public Player PlayerInstance { get; set; }
        public Socket Socket { get; private set; }

        public  bool SendHandshake()
        {
            try
            {
                var bytes = BitConverter.GetBytes((Int64)(HandshakePhrase.GetHashCode()));
                Socket.Send(bytes);
                return true;
            }
            catch (SocketException ex)
            {
                return false;
            }
        }

        public bool ReceiveHandshake()
        {
            try
            {
                var bytes = new byte[8];
                var length = Socket.Receive(bytes);
                var handshakeHashcode = BitConverter.ToInt64(bytes,0);
                return handshakeHashcode.Equals((Int64)(HandshakePhrase.GetHashCode()));
            }
            catch (SocketException ex)
            {
                return false;
            }
        }

        public void Dispose()
        {
            Socket.Close();
        }

        ~Connection()
        {
            Dispose();   
        }

        public ServerRequest ReceiveRequest()
        {
            return null;
        }

        public void SendResponse(ServerResponse response)
        {
            
        }
    }
}
