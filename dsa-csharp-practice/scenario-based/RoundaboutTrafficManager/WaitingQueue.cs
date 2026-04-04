//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.Scenario_based.RoundaboutTrafficManager
//{
//    class WaitingQueue
//    {
//        private string[] queue;
//        private int front;
//        private int rear;
//        public WaitingQueue(int size)
//        {
//            queue = new string[size];
//            front = 0;
//            rear = -1;
//        }
//        public void AddToQueue(string car)
//        {
//            if (rear == queue.Length - 1)
//            {
//                Console.WriteLine("Queue Overflow");
//                return;
//            }

//            queue[++rear] = car;
//            Console.WriteLine("Car added to waiting queue");
//        }
//        public string RemoveFromQueue()
//        {
//            if (front > rear)
//            {
//                Console.WriteLine("Queue Underflow");
//                return null;
//            }

//            return queue[front++];
//        }

//        public bool IsEmpty()
//        {
//            return front > rear;
//        }
//    }
//}
