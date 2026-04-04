//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.StackQueue
//{
//     class ImplementingQueue
//    {
//        //Main Method
//        public static void Main(string[] args)
//        {
//            QueueUsingStacks queue = new QueueUsingStacks();

//            queue.Enqueue(500);
//            queue.Enqueue(600);
//            queue.Enqueue(700);

//            Console.WriteLine("Dequeued: " + queue.Dequeue());

//            Console.WriteLine("Front: " + queue.Peek());

//            Console.WriteLine("Dequeued: " + queue.Dequeue());
//        }
//        class QueueUsingStacks
//        {
//            // Use one stack for enqueue and another stack for dequeue. Transfer elements between stacks as needed.
//            private Stack<int> e1 = new Stack<int>();
//            private Stack<int> d1 = new Stack<int>();


//            public void Enqueue(int x)
//            {
//                e1.Push(x);
//                Console.WriteLine($"{x} enqueued in stack");
//            }



//            public int Dequeue()
//            {
//                if (d1.Count == 0)
//                {
//                    while (e1.Count > 0)
//                    {
//                        d1.Push(e1.Pop());
//                    }
//                }

//                if (d1.Count == 0)
//                {
//                    Console.WriteLine("Queue is empty");
//                    return -1;
//                }

//                return d1.Pop();
//            }




//            public int Peek()
//            {
//                if (d1.Count == 0)
//                {
//                    while (e1.Count > 0)
//                    {
//                        d1.Push(e1.Pop());
//                    }
//                }

//                return e1.Count > 0 ? d1.Peek() : -1;
//            }



//            public bool IsEmpty()
//            {
//                return e1.Count == 0 && d1.Count == 0;
//            }

//        }


          
//        }

//    }

