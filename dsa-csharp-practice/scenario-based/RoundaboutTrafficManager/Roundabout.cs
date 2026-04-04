//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.Scenario_based.RoundaboutTrafficManager
//{
   
//        class Roundabout : ITraffic
//        {
//            private Vehicle last;
//            public void AddCar(string carNo)
//            {

//                Vehicle newCar = new Vehicle(carNo);
//                if (last == null)
//                {
//                    last = newCar;
//                    last.Next = last;
//                }
//                else
//                {
//                    newCar.Next = last.Next;
//                    last.Next = newCar;
//                    last = newCar;
//                }
//                Console.WriteLine("Car entered roundabout");
//            }

//            public void RemoveCar()
//            {
//                if (last == null)
//                {
//                    Console.WriteLine("Roundabout empty");
//                    return;
//                }
//                Vehicle first = last.Next;
//                if (first == last)
//                {
//                    Console.WriteLine("Car exited: " + first.CarNumber);
//                    last = null;
//                }
//                else
//                {
//                    Console.WriteLine("Car exited " + first.CarNumber);
//                    last.Next = first.Next;
//                }
//            }
//            public void ShowRoundabout()
//            {
//                if (last == null)
//                {

//                    Console.WriteLine("No cars in roundabout");
//                    return;

//                }

//                Vehicle temp = last.Next;
//                Console.Write("Roundabout Cars ");
//                do
//                {
//                    Console.Write(temp.CarNumber + " ");
//                    temp = temp.Next;
//                }
//                while (temp != last.Next);
//                Console.WriteLine("BACK");

//            }
//        }
//    }
