using System;

namespace BLL.Infrastructure
{
    public class BLLException : Exception
    {
        public BLLException() { }

        public BLLException(string message) : base(message) { }

        public BLLException(string message, Exception exception) 
            : base(message, exception) { }
    }
}
