//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.OopsAssignment.Ride_Hailing
//{
//    abstract class Vehical
//    {
//        private int vehicalId;
//        private string driverName;
//        protected double ratePerKm;
//        private string currentLocation;
//        public int VehicalId
//        {
//            get { return vehicalId; }
//            set { vehicalId = value; }
//        }
//        public string DriverName
//        {
//            get { return driverName; }
//            set { driverName = value; }
//        }
//        protected string Location
//        {
//            get { return currentLocation; }
//            set { currentLocation = value; }
//        }
//        public Vehical(int id, string name, double rate)
//        {
//            this.vehicalId = id;
//            this.driverName = name;
//            this.ratePerKm = rate;
//            currentLocation = "Unknown";
//        }
//        public abstract double CalculateFare(double distance);
//        public void GetVehicalDetails()
//        {
//            Console.WriteLine($"Vehical ID: {vehicalId}, Driver Name: {driverName}, Rate per Km: {ratePerKm}");
//        }

//    }
//}
