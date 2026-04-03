//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.OopsAssignment.HospitalManagementSystem
//{
//    using System;
//    using System.Collections.Generic;

//    abstract class Patient : IMedicalRecord
//    {
//        // Fields
//        public int patientId;
//        public string name;
//        public int age;

//        // Encapsulated sensitive data
//        protected string diagnosis;
//        protected List<string> medicalHistory = new List<string>();

//        // Constructor
//        public Patient(int patientId, string name, int age, string diagnosis)
//        {
//            this.patientId = patientId;
//            this.name = name;
//            this.age = age;
//            this.diagnosis = diagnosis;
//        }

//        // Abstract method
//        public abstract double CalculateBill();

//        // Concrete method
//        public void GetPatientDetails()
//        {
//            Console.WriteLine($"Patient ID: {patientId}");
//            Console.WriteLine($"Name: {name}");
//            Console.WriteLine($"Age: {age}");
//            Console.WriteLine($"Diagnosis: {diagnosis}");
//        }

//        // Interface methods
//        public void AddRecord(string record)
//        {
//            medicalHistory.Add(record);
//        }

//        public void ViewRecords()
//        {
//            Console.WriteLine("Medical History:");
//            foreach (string record in medicalHistory)
//            {
//                Console.WriteLine("- " + record);
//            }
//        }
//    }

//}
