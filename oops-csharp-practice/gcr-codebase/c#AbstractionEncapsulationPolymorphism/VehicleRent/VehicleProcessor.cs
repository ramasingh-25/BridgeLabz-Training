//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.OopsAssignment.VehicleRent
//{
//    public class VehicleProcessor
//    {
//        public void displayVehicles(Vehicle[] vehicles, int days)
//        {
//            for (int i = 0; i < vehicles.Length; i++)
//            {
//                double rentalCost = vehicles[i].CalculateRentalCost(days);
//                double insuranceCost = 0;

//                if (vehicles[i] is IInsurable insurable)
//                {
//                    insuranceCost = insurable.calculateInsurance();
//                }

//                Console.WriteLine("Vehicle Type(Bike,Car,Truck) : " + vehicles[i].Type);
//                Console.WriteLine("Rental Cost of vehicle       : " + rentalCost);
//                Console.WriteLine("Insurance of vehicle         : " + insuranceCost);

//            }
//        }

//    }
//}
