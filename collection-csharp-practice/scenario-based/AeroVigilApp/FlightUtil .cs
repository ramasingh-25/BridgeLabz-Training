using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace BridgeLabz.Collections.Senario.AeroVigilApp
{

    class FlightUtil : IFlightUtil
    {
        public bool ValidateFlightNumber(string flightNumber)
        {
            if (!Regex.IsMatch(flightNumber, "FL-[1-9][0-9]{3}"))
            {
                throw new InvalidFlightException(
                    "The flight number " + flightNumber + " is invalid");
            }

            return true;
        }

        public bool ValidateFlightName(string flightName)
        {
            if (!(flightName == "SpiceJet" ||
                  flightName == "Vistara" ||
                  flightName == "IndiGo" ||
                  flightName == "Air Arabia"))
            {
                throw new InvalidFlightException(
                    "The flight name " + flightName + " is invalid");
            }

            return true;
        }

        public bool ValidatePassengerCount(int passengerCount, string flightName)
        {
            int max = 0;

            if (flightName == "SpiceJet") max = 396;
            else if (flightName == "Vistara") max = 615;
            else if (flightName == "IndiGo") max = 230;
            else if (flightName == "Air Arabia") max = 130;

            if (passengerCount <= 0 || passengerCount > max)
            {
                throw new InvalidFlightException(
                    "The passenger count " + passengerCount +
                    " is invalid for " + flightName);
            }

            return true;
        }

        public double CalculateFuelToFillTank(string flightName, double currentFuelLevel)
        {
            double capacity = 0;

            if (flightName == "SpiceJet") capacity = 200000;
            else if (flightName == "Vistara") capacity = 300000;
            else if (flightName == "IndiGo") capacity = 250000;
            else if (flightName == "Air Arabia") capacity = 150000;

            if (currentFuelLevel < 0 || currentFuelLevel > capacity)
            {
                throw new InvalidFlightException(
                    "Invalid fuel level for " + flightName);
            }

            return capacity - currentFuelLevel;
        }
    }

}
