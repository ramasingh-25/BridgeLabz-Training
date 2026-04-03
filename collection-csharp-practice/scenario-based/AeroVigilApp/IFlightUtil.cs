using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabz.Collections.Senario.AeroVigilApp
{
    interface IFlightUtil
    {
        bool ValidateFlightNumber(string flightNumber);
        bool ValidateFlightName(string flightName);
        bool ValidatePassengerCount(int passengerCount, string flightName);
        double CalculateFuelToFillTank(string flightName, double currentFuelLevel);
    }

}
