//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgelabzCollection.ScenarioBased.ParcelTracker
//{
//    class ParcelMenu
//    {
//        ParcelUtility tracker = new ParcelUtility();

//        public void Start()
//        {
//            tracker.AddStage("Packed");
//            tracker.AddStage("Shipped");
//            tracker.AddStage("In Transit");
//            tracker.AddStage("Delivered");
//            int choice = 0;
//            while (choice != 5)
//            {
//                Console.WriteLine("\n--- Parcel Tracker Menu ---");
//                Console.WriteLine("1. Track Parcel");
//                Console.WriteLine("2. Add Checkpoint");
//                Console.WriteLine("3. Mark Parcel Lost");
//                Console.WriteLine("4. Add Final Stage");
//                Console.WriteLine("5. Exit");
//                Console.Write("Enter choice: ");

//                choice = Convert.ToInt32(Console.ReadLine());

//                switch (choice)
//                {
//                    case 1:
//                        tracker.TrackForward();
//                        break;

//                    case 2:
//                        Console.Write("After which stage: ");
//                        string after = Console.ReadLine();
//                        Console.Write("New checkpoint: ");
//                        string checkpoint = Console.ReadLine();
//                        tracker.AddCheckpoint(after, checkpoint);
//                        break;

//                    case 3:
//                        Console.Write("Enter lost stage: ");
//                        tracker.MarkLost(Console.ReadLine());
//                        break;

//                    case 4:
//                        Console.Write("Enter stage name: ");
//                        tracker.AddStage(Console.ReadLine());
//                        break;

//                    case 5:
//                        Console.WriteLine("Exiting...");
//                        break;

//                    default:
//                        Console.WriteLine("Invalid choice");
//                        break;
//                }
//            }
//        }
//    }
//}