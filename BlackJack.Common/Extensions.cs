using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Common
{
    public static class Extensions
    {
        public static readonly String HandshakePhrase = "Handshake";
        public static bool TryRunOverNetwork(this MethodInfo method, Socket socket)
        {
            if (!socket.Connected)
                return false;
            var signature = method.ToMethodSignature();
            //send request
            socket.Send(signature.ToByteArray());
            //get & validate response
            var buffer = new byte[10240];
            var length = socket.Receive(buffer);
            var response = buffer.ToServerResponse();
            return response != null && response.MethodCallSucceed;
        }

        public static MethodSignature ToMethodSignature(this MethodInfo methodInfo)
        {
            var name = methodInfo.Name;
            var type = methodInfo.ReturnType;
            var argTypes = new List<Type>();
            methodInfo.GetParameters().ToList()
                .ForEach(arg => argTypes.Add(arg.ParameterType.GetType()));
            return new MethodSignature(name, argTypes, type);
        }

        public static ServerResponse ToServerResponse(this byte[] bytes)
        {
            using (var stream = new MemoryStream(bytes))
            {
                var ser = new BinaryFormatter();
                var obj = ser.Deserialize(stream) as ServerResponse;
                return obj;
            }
        }

        public static byte[] ToByteArray(this MethodSignature signature)
        {
            using (var stream = new MemoryStream())
            {
                var ser = new BinaryFormatter();
                ser.Serialize(stream, signature);
                var bytes = stream.ToArray();
                return bytes;
            }
        }

        public static MethodSignature ToMethodSignature(this byte[] bytes)
        {
            using (var stream = new MemoryStream(bytes))
            {
                var ser = new BinaryFormatter();
                var obj = ser.Deserialize(stream) as MethodSignature;
                return obj;
            }
        }

        public static bool SendHandshake(this Socket socket)
        {
            try
            {
                var bytes = BitConverter.GetBytes((Int64)(HandshakePhrase.GetHashCode()));
                socket.Send(bytes);
                return true;
            }
            catch (SocketException ex)
            {
                return false;
            }
        }

        public static bool ReceiveHandshake(this Socket socket)
        {
            try
            {
                var bytes = new byte[8];
                var length = socket.Receive(bytes);
                var handshakeHashcode = Convert.ToInt64(bytes);
                return handshakeHashcode.Equals((Int64) (HandshakePhrase.GetHashCode()));
            }
            catch (SocketException ex)
            {
                return false;
            }
        }
    }
}
