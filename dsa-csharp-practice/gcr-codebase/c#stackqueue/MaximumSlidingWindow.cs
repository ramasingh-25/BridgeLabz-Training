//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.StackQueue
//{
//    internal class MaximumSlidingWindow
//    {
//        public static int[] SlidingWindow(int[] nums, int windowsize)
//        {
//            if (nums.Length == 0 || windowsize == 0)
//                return new int[0];

//            LinkedList<int> dequeue = new LinkedList<int>();

//            int n = nums.Length;

//            int[] results = new int[n - windowsize + 1];

//            int index = 0;

//            for (int i = 0; i < n; i++)
//            {

//                if (dequeue.Count > 0 && dequeue.First.Value <= i - windowsize)
//                    dequeue.RemoveFirst();


//                while (dequeue.Count > 0 && nums[dequeue.Last.Value] <= nums[i])
//                    dequeue.RemoveLast();


//                dequeue.AddLast(i);


//                if (i >= k - 1)
//                    results[index++] = nums[dequeue.First.Value];
//            }

//            return results;
//        }

//        //MAIN METHOD
//        public static void Main(string[] arg)
//        {
//            int[] array = { 7,3,4,5,1,8,9,10 };

//            int windowsize = 4;

//            int[] result = SlidingWindow(array, k);

//            Console.WriteLine("Sliding Window Maximum:");
//            foreach (int val in result)
//            {
//                Console.Write(val + " ");
//            }
//        }
//    }
//}
