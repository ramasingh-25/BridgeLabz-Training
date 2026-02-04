using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabz.Collections.Senario.AeroVigilApp
{
    class InvalidFlightException : Exception
    {
        public InvalidFlightException(string message) : base(message)
        {
        }
    }

}
