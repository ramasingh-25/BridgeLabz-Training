//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.StackQueue
//{
//    internal class SortingStack
//    {
//        public static void Main(string[] args)
//        {
//            Stack<int> stack = new Stack<int>();
//            stack.Push(7);
//            stack.Push(5);
//            stack.Push(4);
//            stack.Push(9);

//            SortStack(stack);

//            Console.WriteLine("Sorted Stack Top to Bottom:");
//            while (stack.Count > 0)
//            {
//                Console.Write(stack.Pop() + " ");
//            }
//        }
//        public static void SortStack(Stack<int> stack)
//        {
//            if (stack.Count == 0)
//                return;

//            int temp = stack.Pop();

//            SortStack(stack);

//            InsertSorted(stack, temp);
//        }


//        private static void InsertSorted(Stack<int> stack, int elements)
//        {
//            if (stack.Count == 0 || stack.Peek() <= elements)
//            {
//                stack.Push(elements);
//                return;
//            }

//            int temp = stack.Pop();
//            InsertSorted(stack, elements);
//            stack.Push(temp);
//        }


        
        
//        }
//    }

