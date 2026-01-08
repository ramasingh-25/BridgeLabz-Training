//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.Scenario_Based.HospitalManagement
//{
//    public class HospitalPatientManagment
//    {
//        static void Main()
//        {
//            Console.WriteLine("---- HOSPITAL PATIENT MANAGEMENT ----");
//            Console.WriteLine();

           
//            List<Patient> patients = new List<Patient>();
//            patients.Add(new InPatient(101, "Rahul", 54, 6, 2000));
//            patients.Add(new OutPatient(102, "Pushpendra", 40, 4));

//            Console.WriteLine(" PATIENT BILLING");
//            foreach (Patient p in patients)
//            {
//                p.GetPatientDetails();
//                p.AddRecord("Blood test done");
//                p.AddRecord("X-ray taken");

//                double bill = p.CalculateBill();
//                Console.WriteLine("Total Bill: $" + bill);

//                p.ViewRecords();
//                Console.WriteLine("=========================");
//            }

//            Console.ReadKey();
//        }
//    }

//}
//}
