using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Exceptions
{
    public class NoWinnerFoundException : Exception
    {
        public NoWinnerFoundException() : base("Es wurde kein Gewinner gefunden!")
        {

        }

        public NoWinnerFoundException(string message) : base(message)
        {

        }
    }
}