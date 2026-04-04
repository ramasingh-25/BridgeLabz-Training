//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.LinkedList
//{
//     class RoundRobbinAlgorithm
//    {
//        class ProcessNode
//        {
//            public int ProcessId;
//            public int BurstTime;
//            public int RemainingTime;
//            public int Priority;
//            public int WaitingTime;
//            public int TurnAroundTime;
//            public ProcessNode Next;

            
//            public ProcessNode(int pid, int burst, int priority)
//            {
//                this.ProcessId = pid;
//                BurstTime = burst;
//                RemainingTime = burst;
//                Priority = priority;
//                Next = null;
//            }
//        }


//        class RoundRobin
//        {
//            private ProcessNode head;
//            private int timeQuantum;
//            private int totalTime = 0;
//            private int processCount = 0;

//            public RoundRobin(int quantum)
//            {
//                timeQuantum = quantum;
//            }


            
//            public void AddProcess(int pid, int burst, int priority)
//            {
//                ProcessNode newNode = new ProcessNode(pid, burst, priority);

//                if (head == null)
//                {
//                    head = newNode;
//                    newNode.Next = head;
//                }
//                else
//                {
//                    ProcessNode temp = head;
//                    while (temp.Next != head)
//                        temp = temp.Next;

//                    temp.Next = newNode;
//                    newNode.Next = head;
//                }

//                processCount++;
//            }



//            public void Execute()
//            {
//                if (head == null)
//                {
//                    Console.WriteLine("No processes to schedule.");
//                    return;
//                }

//                ProcessNode current = head;
//                ProcessNode prev = null;

//                while (processCount > 0)
//                {
//                    Console.WriteLine($" CPU Time: {totalTime}");
//                    DisplayProcesses();

//                    if (current.RemainingTime > timeQuantum)
//                    {
//                        totalTime += timeQuantum;
//                        current.RemainingTime -= timeQuantum;
//                    }
//                    else
//                    {
//                        totalTime += current.RemainingTime;
//                        current.RemainingTime = 0;
//                        current.TurnAroundTime = totalTime;
//                        current.WaitingTime = current.TurnAroundTime - current.BurstTime;

//                        Console.WriteLine($"Process {current.ProcessId} completed");

//                        RemoveProcess(current, prev);
//                        processCount--;
//                        current = (prev == null) ? head : prev.Next;
//                        continue;
//                    }

//                    prev = current;
//                    current = current.Next;
//                }

//                DisplayAverageTimes();
//            }



//            private void RemoveProcess(ProcessNode current, ProcessNode prev)
//            {
//                if (current == head && current.Next == head)
//                {
//                    head = null;
//                    return;
//                }

//                if (current == head)
//                {
//                    ProcessNode temp = head;
//                    while (temp.Next != head)
//                        temp = temp.Next;

//                    head = head.Next;
//                    temp.Next = head;
//                }
//                else
//                {
//                    prev.Next = current.Next;
//                }
//            }


//            public void DisplayProcesses()
//            {
//                if (head == null)
//                {
//                    Console.WriteLine("No active processes.");
//                    return;
//                }

//                ProcessNode temp = head;
//                do
//                {
//                    Console.WriteLine($"PID: {temp.ProcessId}, Remaining: {temp.RemainingTime}");
//                    temp = temp.Next;
//                } while (temp != head);
//            }



           
//            private void DisplayAverageTimes()
//            {
//                double totalWT = 0, totalTAT = 0;
//                ProcessNode temp = head;

//                Console.WriteLine("Final Results:");

//                if (temp == null)
//                {
//                    Console.WriteLine("All processes completed.");
//                    return;
//                }

//                do
//                {
//                    totalWT += temp.WaitingTime;
//                    totalTAT += temp.TurnAroundTime;
//                    temp = temp.Next;
//                } while (temp != head);

//                Console.WriteLine("Average Waiting Time: " + totalWT / processCount);
//                Console.WriteLine("Average Turnaround Time: " + totalTAT / processCount);
//            }
//        }

        
//            //MAIN METHOD
//            public static void Main(string[] args)
//            {
//                RoundRobin scheduler = new RoundRobin(3);

//                scheduler.AddProcess(1, 5, 10);
//                scheduler.AddProcess(2, 2, 6);
//                scheduler.AddProcess(3, 2, 8);

//                scheduler.Execute();
//            }
//        }
//    }
