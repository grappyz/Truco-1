using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace TCG
{
    [Serializable]
    public class TrucoException : Exception
    {
        public TrucoException()
        {
        }

        public TrucoException(string message) : base(message)
        {
        }

        public TrucoException(string message, Exception inner) : base(message, inner)
        {
        }

        protected TrucoException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
