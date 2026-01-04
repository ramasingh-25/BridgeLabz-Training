//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.InstanceVsClass
//{
//    internal class RegistrationOfVehicle
//    {

        
//            static void Main(string[] args)
//            {
//                Vehicle vehicle1 = new Vehicle("Chitra Singh", "Truck");
//                Vehicle vehicle2 = new Vehicle("Rama Singh", "Bike");

//                vehicle1.ShowVehicleDetails();
//                vehicle2.ShowVehicleDetails();

//                Vehicle.UpdateRegistrationFee(60000);

//                vehicle1.ShowVehicleDetails();
//                vehicle2.ShowVehicleDetails();
//            }
//        }
//    public class Vehicle
//    {
//        private static float registrationFee = 7000;
//        private string ownerName;
//        private string vehicleType;

//        public Vehicle(string ownerName, string vehicleType)
//        {
//            this.ownerName = ownerName;
//            this.vehicleType = vehicleType;
//        }
//        //method to show vehicle details
//        internal void ShowVehicleDetails()
//        {
//            Console.WriteLine("Here are the vehicle details: ");
//            Console.WriteLine("Owner Name: " + ownerName);
//            Console.WriteLine("Vehicle Type: " + vehicleType);
//            Console.WriteLine("Registration Fee: " + registrationFee);
//        }

//        internal static void UpdateRegistrationFee(float updatedRegistrationFee)
//        {
//            registrationFee = updatedRegistrationFee;
//            Console.WriteLine("Registration Fees Updated");
//        }

//    }
//}

