using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Common
{
    /// <summary>
    /// Represents method signature
    /// </summary>
    [Serializable]
    public sealed class MethodSignature
    {
        public MethodSignature()
        {
        }

        public MethodSignature(string methodName, List<Type> parameterTypes, object returnType)
        {
            if (methodName == null)
                throw new NullReferenceException();
            Name = methodName;
            if (parameterTypes != null)
                ParametersTypes = new ReadOnlyCollection<Type>(parameterTypes);
            if (returnType == null)
                throw new NullReferenceException();
            ReturnType = returnType;
        }

        /// <summary>
        /// Name of the method
        /// </summary>
        public String Name
        {
            get; 
            set;
        }

        /// <summary>
        /// List of parameters of the method
        /// </summary>
        public ReadOnlyCollection<Type> ParametersTypes
        {
            get; 
            set;
        }
        /// <summary>
        /// Return type of the method
        /// </summary>
        public Object ReturnType 
        { 
            get; 
            set; 
        }
    }
}
