//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.Constructor
//{
//    class CarRentalSystem
//    {
       
//            public string customerName;
//            public string carModel;
//            public int rentalDays;
//            public double totalCost;

            
//            public CarRentalSystem()     //default constructor 
//            {
//                customerName = "Chitra";
//                carModel = "Sedan";
//                rentalDays = 1;
//                totalCost = CalculateTotalCost();
//            }

           
//            public CarRentalSystem(string CustomerName, string CarModel, int RentalDays)   //parameterized 
//            {
//                customerName = CustomerName;
//                carModel = CarModel;
//                rentalDays = RentalDays;

//            }

            
//            public double CalculateTotalCost()   //calculating cost
//            {
//                double costPerDay = 7000;
//                return rentalDays * costPerDay;
//            }

            
//            public static void Main(string[] args)   //main method
//            {
               
//                CarRentalSystem C1 = new CarRentalSystem();    
//                Console.WriteLine(C1.customerName + "," + C1.carModel + "," + C1.totalCost);

//                CarRentalSystem C2 = new CarRentalSystem("Rama", "ad5", 7);
//                Console.WriteLine(C2.customerName + "," + C2.carModel + "," + C2.totalCost);


//            }


//        }
//    }

