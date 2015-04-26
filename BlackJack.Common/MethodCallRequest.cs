using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Common
{
    [Serializable]
    public class MethodCallRequest
    {
        public MethodCallRequest()
        {
            Arguments = new List<object>();
        }

        public MethodCallRequest(MethodSignature signature, List<Object> args)
        {
            Signature = signature;
            Arguments = new List<object>();
            Arguments.AddRange(args);
        }
        public MethodSignature Signature { get; set; }
        public List<Object> Arguments { get; set; }
        public override string ToString()
        {
            return String.Format("Method signature: {0}", Signature.ToString());
        }
    }
}
