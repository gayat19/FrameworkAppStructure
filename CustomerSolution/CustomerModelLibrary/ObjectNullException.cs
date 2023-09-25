using System;
using System.Runtime.Serialization;

namespace CustomerModelLibrary
{
    [Serializable]
    internal class ObjectNullException : Exception
    {
        string message;
        public ObjectNullException()
        {
            message = "Object comaperd is null";
        }

        public ObjectNullException(string message) : base(message)
        {
        }

        public override string Message => message;
    }
}