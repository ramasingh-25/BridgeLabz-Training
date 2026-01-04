//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.Inheritance
//{
//    internal class VehicleandTransportSystem
//    {
        
//            public int MaxSpeed;
//            public string energySource;

//            public VehicleandTransportSystem(int MaxSpeed, string energySource)
//            {
//                this.MaxSpeed = MaxSpeed;
//                this.energySource = energySource;
//            }

//            public virtual void ShowDetails()
//            {
//                Console.WriteLine("Top Speed        : " + MaxSpeed);
//                Console.WriteLine("Energy Source    : " + energySource);
//            }
//        }

//        class Sedan : VehicleandTransportSystem
//        {
//            public int seatCount;

//            public Sedan(int MaxSpeed, string energySource, int seatCount)
//                : base(MaxSpeed, energySource)
//            {
//                this.seatCount = seatCount;
//            }

//            public override void ShowDetails()
//            {
//                base.ShowDetails();
//                Console.WriteLine("Total Seats      : " + seatCount);
//            }
//        }

//        class CargoTruck : VehicleandTransportSystem
//        {
//            public int loadLimit;

//            public CargoTruck(int MaxSpeed, string energySource, int loadLimit)
//                : base(MaxSpeed, energySource)
//            {
//                this.loadLimit = loadLimit;
//            }

//            public override void ShowDetails()
//            {
//                base.ShowDetails();
//                Console.WriteLine("Load Limit (kg)  : " + loadLimit);
//            }
//        }

//        class TwoWheeler : VehicleandTransportSystem
//        {
//            public bool sideAttachment;

//            public TwoWheeler(int MaxSpeed, string energySource, bool sideAttachment)
//                : base(MaxSpeed, energySource)
//            {
//                this.sideAttachment = sideAttachment;
//            }

//            public override void ShowDetails()
//            {
//                base.ShowDetails();
//                Console.WriteLine("Side Attachment  : " + sideAttachment);
//            }
//        }

//        class TransportRunner
//        {
//            static void Main(string[] args)

//            {

//                Console.WriteLine("Provide Sedan info (Speed, Fuel, Seat Count)");

//                int sedanSpeed = int.Parse(Console.ReadLine());

//                string sedanFuel = Console.ReadLine();

//                int sedanSeats = int.Parse(Console.ReadLine());

//                Console.WriteLine("\nProvide Cargo Truck info (Speed, Fuel, Load Limit)");


//                int truckSpeed = int.Parse(Console.ReadLine());

//                string truckFuel = Console.ReadLine();

//                int loadKg = int.Parse(Console.ReadLine());

//                Console.WriteLine("\nProvide Two Wheeler info (Speed, Fuel, Side Attachment true/false)");

//                int bikeSpeed = int.Parse(Console.ReadLine());

//                string bikeFuel = Console.ReadLine();

//                bool hasAttachment = bool.Parse(Console.ReadLine());

//                VehicleandTransportSystem[] fleet = new VehicleandTransportSystem[3];

//                fleet[0] = new Sedan(sedanSpeed, sedanFuel, sedanSeats);
//                fleet[1] = new CargoTruck(truckSpeed, truckFuel, loadKg);
//                fleet[2] = new TwoWheeler(bikeSpeed, bikeFuel, hasAttachment);

//                Console.WriteLine("\nTRANSPORT DETAILS");

//                foreach (VehicleandTransportSystem item in fleet)
//                {
//                    item.ShowDetails();

//                    Console.WriteLine();

//                }
//            }
//        }
//    }
