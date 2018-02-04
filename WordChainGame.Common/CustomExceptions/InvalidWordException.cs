using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordChainGame.Common.CustomExceptions
{
    public class InvalidWordException : Exception
    {
        public InvalidWordException()
        {
        }

        public InvalidWordException(string message) : base(message)
        {
        }

        public InvalidWordException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
