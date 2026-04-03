//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgelabzCollection.Queue
//{
   
//        class Patient
//        {
//            public string Name { get; set; }
//            public int Severity { get; set; }

//            public Patient(string name, int severity)
//            {
//                Name = name;
//                Severity = severity;
//            }
//        }

//        class HospitalTriageSystem
//        {
//            static void Main()
//            {

//                PriorityQueue<Patient, int> triageQueue =
//                    new PriorityQueue<Patient, int>();
//                triageQueue.Enqueue(new Patient("John", 3), -3);
//                triageQueue.Enqueue(new Patient("Alice", 5), -5);
//                triageQueue.Enqueue(new Patient("Bob", 2), -2);
//                Console.WriteLine("Treatment Order:");
//                while (triageQueue.Count > 0)
//                {
//                    Patient p = triageQueue.Dequeue();
//                    Console.WriteLine(p.Name);
//                }
//            }
//        }
//    }
