//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.Sealed
//{
//    internal class VehicleRegistration
//    {
//        static void Main(string[] args)
//        {
//            Vehicle vehicle1 = new Vehicle("Rishita", "Car", "UP8567MN564");
//            Vehicle vehicle2 = new Vehicle("Chitra", "Bike", "UP1676MN54");

//            vehicle1.DisplayVehicleDetails(vehicle1);
//            Console.WriteLine();

//            vehicle2.DisplayVehicleDetails(vehicle2);
//            Console.WriteLine();

//            Vehicle.UpdateRegistrationFee(7000);
//            Console.WriteLine();

//            vehicle1.DisplayVehicleDetails(vehicle1);

//        }
//        public class Vehicle
//        {
//            public static double RegistrationFee = 7000;
//            public readonly string RegistrationNumber;
//            public string OwnerName;
//            public string VehicleType;

//            public Vehicle(string OwnerName, string VehicleType, string RegistrationNumber)
//            {
//                this.OwnerName = OwnerName;
//                this.VehicleType = VehicleType;
//                this.RegistrationNumber = RegistrationNumber;
//            }
//            public static void UpdateRegistrationFee(double newFee)
//            {
//                RegistrationFee = newFee;
//                Console.WriteLine("Updated Registration Fee: " + RegistrationFee);
//            }
//            public void DisplayVehicleDetails(object vehicle)
//            {
//                if (vehicle is Vehicle)
//                {
//                    Console.WriteLine("Owner Name          : " + OwnerName);
//                    Console.WriteLine("Vehicle Type        : " + VehicleType);
//                    Console.WriteLine("Registration Number : " + RegistrationNumber);
//                    Console.WriteLine("Registration Fee    : " + RegistrationFee);
//                }
//                else
//                {
//                    Console.WriteLine("Invalid vehicle object");
//                }
//            }
//        }

        
            
//        }
//    }

