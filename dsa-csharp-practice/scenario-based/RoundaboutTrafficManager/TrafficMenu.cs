//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.Scenario_based.RoundaboutTrafficManager
//{
//    internal class TrafficMenu
//    {
//        public void ShowMenu()
//        {
//            Roundabout roundabout = new Roundabout();
//            WaitingQueue queue = new WaitingQueue(5);

//            while (true)
//            {
//                Console.WriteLine("PRESS 1: For Add Car to Queue");
//                Console.WriteLine("PRESS 2: For Move Car to Roundabout");
//                Console.WriteLine("PRESS 3: For Remove Car from Roundabout");
//                Console.WriteLine("PRESS 4: For Show Roundabout");
//                Console.WriteLine("PRESS 5: For Exit");
//                int ch = int.Parse(Console.ReadLine());
//                if (ch == 1)
//                {
//                    Console.Write("Enter car number: ");
//                    queue.AddToQueue(Console.ReadLine());
//                }
//                else if (ch == 2)
//                {
//                    if (!queue.IsEmpty())
//                        roundabout.AddCar(queue.RemoveFromQueue());
//                    else
//                        Console.WriteLine("No cars waiting");
//                }
//                else if (ch == 3)
//                {
//                    roundabout.RemoveCar();
//                }
//                else if (ch == 4)
//                {
//                    roundabout.ShowRoundabout();
//                }
//                else if (ch == 5)
//                {
//                    return;
//                }
//                else
//                {
//                    Console.WriteLine("Wrong choice");
//                }
//            }
//        }
//    }
//}
