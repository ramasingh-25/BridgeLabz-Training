//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgelabzCollection.ScenarioBased.ParcelTracker
//{
//    class ParcelUtility : IParcelTracker
//    {
//        private ParcelNode head;

//        public ParcelUtility()
//        {
//            head = null;
//        }

//        public void AddStage(string stage)
//        {
//            ParcelNode newNode = new ParcelNode(stage);

//            if (head == null)
//            {
//                head = newNode;
//                return;
//            }

//            ParcelNode temp = head;
//            while (temp.Next != null)
//            {
//                temp = temp.Next;
//            }
//            temp.Next = newNode;
//        }

//        public void AddCheckpoint(string afterStage, string newStage)
//        {
//            ParcelNode temp = head;

//            while (temp != null)
//            {
//                if (temp.Stage == afterStage)
//                {
//                    ParcelNode newNode = new ParcelNode(newStage);
//                    newNode.Next = temp.Next;
//                    temp.Next = newNode;
//                    Console.WriteLine("Checkpoint added.");
//                    return;
//                }
//                temp = temp.Next;
//            }

//            Console.WriteLine("Stage not found.");
//        }

//        public void TrackForward()
//        {
//            if (head == null)
//            {
//                Console.WriteLine("No parcel data found.");
//                return;
//            }

//            ParcelNode temp = head;
//            while (temp != null)
//            {
//                Console.Write(temp.Stage + " -> ");
//                temp = temp.Next;
//            }
//            Console.WriteLine("END");
//        }

//        public void MarkLost(string stage)
//        {
//            ParcelNode temp = head;
//            ParcelNode prev = null;

//            while (temp != null)
//            {
//                if (temp.Stage == stage)
//                {
//                    if (prev == null)
//                        head = temp.Next;
//                    else
//                        prev.Next = temp.Next;

//                    Console.WriteLine("Parcel lost at stage: " + stage);
//                    return;
//                }
//                prev = temp;
//                temp = temp.Next;
//            }

//            Console.WriteLine("Stage not found.");
//        }
//    }
//}
