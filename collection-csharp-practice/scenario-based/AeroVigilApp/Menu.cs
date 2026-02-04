using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabz.Collections.Senario.AeroVigilApp
{

    class Menu
    {
        public void Start()
        {
            int choice = 0;

            while (choice != 2)
            {
                Console.WriteLine(" AeroVigil - Flight Validation ");
                Console.WriteLine("1. Enter Flight Details");
                Console.WriteLine("2. Exit");
                Console.Write("Enter your choice : ");

                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Invalid choice");
                    continue;
                }

                if (choice == 1)
                {
                    try
                    {
                        Console.WriteLine();
                        Console.WriteLine("Enter flight details in below format:");
                        Console.WriteLine("FlightNumber:FlightName:PassengerCount:CurrentFuelLevel");
                        Console.WriteLine("Example:");
                        Console.WriteLine("FL-1234:SpiceJet:250:50000");
                        Console.WriteLine();

                        string input = Console.ReadLine();

                        string[] data = input.Split(':');

                        string flightNumber = data[0];
                        string flightName = data[1];
                        int passengerCount = Convert.ToInt32(data[2]);
                        double fuelLevel = Convert.ToDouble(data[3]);

                        IFlightUtil util = new FlightUtil();

                        util.ValidateFlightNumber(flightNumber);
                        util.ValidateFlightName(flightName);
                        util.ValidatePassengerCount(passengerCount, flightName);

                        double fuelRequired =
                            util.CalculateFuelToFillTank(flightName, fuelLevel);

                        Console.WriteLine(
                            "Fuel required to fill the tank: " +
                            fuelRequired + " liters");
                    }
                    catch (InvalidFlightException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch
                    {
                        Console.WriteLine("Invalid input format");
                    }
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Program terminated");
                }
                else
                {
                    Console.WriteLine("Please select a valid option");
                }

                Console.WriteLine();
            }
        }
    }

}
