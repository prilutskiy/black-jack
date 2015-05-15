using System;
using System.Net.Sockets;

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

        public void Dispose()
        {
            Socket.Close();
        }

        public bool SendHandshake()
        {
            try
            {
                var bytes = BitConverter.GetBytes((Int64) (HandshakePhrase.GetHashCode()));
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
                var handshakeHashcode = BitConverter.ToInt64(bytes, 0);
                return handshakeHashcode.Equals(HandshakePhrase.GetHashCode());
            }
            catch (SocketException ex)
            {
                return false;
            }
        }

        ~Connection()
        {
            Dispose();
        }

        public ServerRequest ReceiveRequest()
        {
            var buffer = new byte[4096];
            Socket.Receive(buffer);
            return buffer.RequestToObject();
        }

        public void SendResponse(ServerResponse response)
        {
            Socket.Send(response.ToByteArray());
        }

        public void SendRequest(ServerRequest request)
        {
            Socket.Send(request.ToByteArray());
        }

        public ServerResponse GetResponse()
        {
            var buffer = new byte[4096];
            Socket.Receive(buffer);
            return buffer.ResponseToObject();
        }
    }
}