using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BlackJack.Common
{
    /// <summary>
    ///     Represents method signature
    /// </summary>
    [Serializable]
    public sealed class MethodSignature
    {
        public MethodSignature()
        {
        }

        public MethodSignature(string methodName, List<Type> parameterTypes, Type returnType)
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
        ///     Name of the method
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        ///     List of parameters of the method
        /// </summary>
        public ReadOnlyCollection<Type> ParametersTypes { get; set; }

        /// <summary>
        ///     Return type of the method
        /// </summary>
        public Type ReturnType { get; set; }

        public override string ToString()
        {
            var parameters = "";
            for (var i = 0; i < ParametersTypes.Count; i++)
                parameters += String.Format("{0}: {1}\n", i + 1, ParametersTypes[i]);

            return String.Format("Method name: {0}\nReturn type: {1}\nParameters types: {2}", Name, ReturnType,
                parameters);
        }
    }
}