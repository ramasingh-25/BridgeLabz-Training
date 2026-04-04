//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.StackQueue
//{
//    internal class CircularTourProblem
//    {
//        //Main Method
//        public static void Main(string[] args)
//        {
//            int[] petrol = { 7,8 ,9};
//            int[] distance = { 5, 8, 4 };

//            int start = FindStartingPoint(petrol, distance);

//            Console.WriteLine("Starting Pump Index: " + start);
//        }
//        public static int FindStartingPoint(int[] petrol, int[] distanceToPetrolPump)
//        {
//            int n = petrol.Length;

//            Queue<int> queue = new Queue<int>();

//            int currentPetrol = 0;

//            int i = 0;

//            while (queue.Count < n)
//            {
//                currentPetrol += petrol[i] - distanceToPetrolPump[i];
//                queue.Enqueue(i);



//                while (currentPetrol < 0 && queue.Count > 0)
//                {
//                    int removed = queue.Dequeue();
//                    currentPetrol -= petrol[removed] - distanceToPetrolPump[removed];
//                }

//                i = (i + 1) % n;


//                if (i == 0 && queue.Count == 0)
//                    return -1;
//            }

//            return queue.Peek();
//        }

       
//    }
//}
