//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.StackQueue
//{
//   public class StockSpan
//    {
        
        
//            //For each day in a stock price array,
//            //calculate the span
//            public static int[] CalculateSpan(int[] prices)
//            {
//                int length = prices.Length;

//                int[] span = new int[length];

//                Stack<int> stack = new Stack<int>();


//                for (int i = 0; i < length; i++)
//                {

//                    while (stack.Count > 0 && prices[stack.Peek()] <= prices[i])
//                    {
//                        stack.Pop();
//                    }


//                    span[i] = (stack.Count == 0) ? (i + 1) : (i - stack.Peek());


//                    stack.Push(i);
//                }

//                return span;
//            }

//            //Main method
//            public static void Main(string[] args)
//            {
//                int[] prices = { 30, 45, 20, 54, 10, 40, 32 };
//                int[] result = CalculateSpan(prices);

//                Console.WriteLine("Stock Spans:");
//                foreach (int s in result)
//                {
//                    Console.Write(s + " ");
//                }
//            }
//        }

//    }

