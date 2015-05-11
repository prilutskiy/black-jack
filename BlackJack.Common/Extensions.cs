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
            return response != null /*&& response.MethodCallSucceed*/;
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
        public static T ConvertValue<T>(object value)
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }

        public static ServerRequest RequestToObject(this byte[] bytes)
        {
            using (var stream = new MemoryStream(bytes))
            {
                var ser = new BinaryFormatter();
                var obj = ser.Deserialize(stream) as ServerRequest;
                return obj;
            }
        }
        public static ServerResponse ResponseToObject(this byte[] bytes)
        {
            using (var stream = new MemoryStream(bytes))
            {
                var ser = new BinaryFormatter();
                var obj = ser.Deserialize(stream) as ServerResponse;
                return obj;
            }
        }
        public static byte[] ToByteArray(this Object obj)
        {
            using (var stream = new MemoryStream())
            {
                var ser = new BinaryFormatter();
                ser.Serialize(stream, obj);
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
        public static MethodCallRequest ToMethodCallRequest(this byte[] bytes)
        {
            using (var stream = new MemoryStream(bytes))
            {
                var ser = new BinaryFormatter();
                var obj = ser.Deserialize(stream) as MethodCallRequest;
                return obj;
            }
        }
    }
}
