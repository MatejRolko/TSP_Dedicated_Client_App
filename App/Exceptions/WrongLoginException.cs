using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Exceptions
{
    public class WrongLoginException : Exception
    {
        public WrongLoginException()
        { }

        public WrongLoginException(string message)
            : base(message)
        { }

        public WrongLoginException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
