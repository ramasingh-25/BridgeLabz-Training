//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.OopsAssignment.VehicleRent
//{
//    class VehicleRentalSystem
//    {
//        public static void Main(string[] args)
//        {

//            Vehicle[] vehicles = new Vehicle[3];


//            Bike bike = new Bike();
//            bike.VehicleNumber = "UP85MN459";
//            bike.Type = "Bike";
//            bike.RentalRate = 800;
//            bike.InsurancePolicyNumber = "BIKE-INS-45";


//            Car car = new Car();
//            car.VehicleNumber = "CAR405";
//            car.Type = "Car";
//            car.RentalRate = 6000;
//            car.InsurancePolicyNumber = "CAR-INS-67";



//            Truck truck = new Truck();
//            truck.VehicleNumber = "TRUCK405";
//            truck.Type = "Truck";
//            truck.RentalRate = 11000;
//            truck.InsurancePolicyNumber = "TRUCK-INS-85";

//            vehicles[0] = car;
//            vehicles[1] = bike;
//            vehicles[2] = truck;

//            VehicleProcessor processor = new VehicleProcessor();
//            processor.displayVehicles(vehicles, 3);

//        }
//    }
//}
