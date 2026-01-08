//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.LinkedList
//{
//    public class CircularLinkedList
//    {
//        public static void Main(string[] args)
//        {
//            TaskScheduler scheduler = new TaskScheduler();

//            scheduler.AddAtEnd(3, "Meeting with trainer", 1, "18-01-2026");
//            scheduler.AddAtEnd(2, "Project presentation", 2, "19-01-2026");
//            scheduler.AddAtBeginning(1, "Completing Assignment", 1, "16-01-2026");

//            Console.WriteLine("All Tasks:");
//            scheduler.DisplayAll();
//            Console.WriteLine();

//            Console.WriteLine("Next Tasks (Dining Philospher):");
//            scheduler.ViewNextTask();
//            scheduler.ViewNextTask();
//            scheduler.ViewNextTask();
//            Console.WriteLine();

//            Console.WriteLine("Search by Priority:");
//            scheduler.SearchByPriority(1);
//            Console.WriteLine();

//            Console.WriteLine("Remove Task:");
//            scheduler.RemoveByTaskId(2);
//            Console.WriteLine();

//            Console.WriteLine("Now Final Task List:");
//            scheduler.DisplayAll();
//        }
//        class TaskNode
//        {
//            public int TaskId;
//            public string TaskName;
//            public int Priority;
//            public string DueDate;
//            public TaskNode Next;

//            //constructor
//            public TaskNode(int taskId, string taskName, int priority, string dueDate)
//            {
//                this.TaskId = taskId;
//                this.TaskName = taskName;
//                this.Priority = priority;
//                this.DueDate = dueDate;
//                Next = null;
//            }
//        }

//        //Add a task at the beginning, end, or at a specific position in the circular list.
//        class TaskScheduler
//        {
//            private TaskNode head;
//            private TaskNode current;

//            public void AddAtBeginning(int id, string name, int priority, string dueDate)
//            {
//                TaskNode newNode = new TaskNode(id, name, priority, dueDate);

//                if (head == null)
//                {
//                    head = current = newNode;
//                    newNode.Next = head;
//                    return;
//                }

//                TaskNode temp = head;
//                while (temp.Next != head)
//                {
//                    temp = temp.Next;
//                }

//                newNode.Next = head;
//                temp.Next = newNode;
//                head = newNode;
//            }




//            public void AddAtEnd(int id, string name, int priority, string dueDate)
//            {
//                TaskNode newNode = new TaskNode(id, name, priority, dueDate);

//                if (head == null)
//                {
//                    head = current = newNode;
//                    newNode.Next = head;
//                    return;
//                }

//                TaskNode temp = head;
//                while (temp.Next != head)
//                {
//                    temp = temp.Next;
//                }

//                temp.Next = newNode;
//                newNode.Next = head;
//            }




//            public void AddAtPosition(int position, int id, string name, int priority, string dueDate)
//            {
//                if (position <= 1 || head == null)
//                {
//                    AddAtBeginning(id, name, priority, dueDate);
//                    return;
//                }

//                TaskNode temp = head;
//                for (int i = 1; i < position - 1 && temp.Next != head; i++)
//                {
//                    temp = temp.Next;
//                }

//                TaskNode newNode = new TaskNode(id, name, priority, dueDate);
//                newNode.Next = temp.Next;
//                temp.Next = newNode;
//            }



//            //Remove a task by Task ID.
//            public void RemoveByTaskId(int id)
//            {
//                if (head == null)
//                {
//                    Console.WriteLine("No tasks available.");
//                    return;
//                }

//                TaskNode temp = head;
//                TaskNode prev = null;

//                do
//                {
//                    if (temp.TaskId == id)
//                    {
//                        if (prev != null)
//                            prev.Next = temp.Next;
//                        else
//                        {
//                            TaskNode last = head;
//                            while (last.Next != head)
//                                last = last.Next;

//                            head = head.Next;
//                            last.Next = head;
//                        }

//                        if (current == temp)
//                            current = temp.Next;

//                        Console.WriteLine("Task removed successfully.");
//                        return;
//                    }

//                    prev = temp;
//                    temp = temp.Next;

//                } while (temp != head);

//                Console.WriteLine("Task not found.");
//            }


//            //View the current task and move to the next task in the circular list.
//            public void ViewNextTask()
//            {
//                if (current == null)
//                {
//                    Console.WriteLine("No tasks available.");
//                    return;
//                }

//                Console.WriteLine($"Current Task → ID: {current.TaskId}, Name: {current.TaskName}, Priority: {current.Priority}, Due: {current.DueDate}");
//                current = current.Next;
//            }


//            //Display all tasks in the list starting from the head node.
//            public void DisplayAll()
//            {
//                if (head == null)
//                {
//                    Console.WriteLine("No tasks available.");
//                    return;
//                }

//                TaskNode temp = head;
//                do
//                {
//                    Console.WriteLine($"ID: {temp.TaskId}, Name: {temp.TaskName}, Priority: {temp.Priority}, Due: {temp.DueDate}");
//                    temp = temp.Next;
//                } while (temp != head);
//            }



//            //Search for a task by Priority.
//            public void SearchByPriority(int priority)
//            {
//                if (head == null)
//                {
//                    Console.WriteLine("No tasks available.");
//                    return;
//                }

//                TaskNode temp = head;
//                bool found = false;

//                do
//                {
//                    if (temp.Priority == priority)
//                    {
//                        Console.WriteLine($"ID: {temp.TaskId}, Name: {temp.TaskName}, Due: {temp.DueDate}");
//                        found = true;
//                    }
//                    temp = temp.Next;
//                } while (temp != head);

//                if (!found)
//                    Console.WriteLine("No tasks found with this priority.");
//            }
//        }

        
            
//        }
//    }





    
