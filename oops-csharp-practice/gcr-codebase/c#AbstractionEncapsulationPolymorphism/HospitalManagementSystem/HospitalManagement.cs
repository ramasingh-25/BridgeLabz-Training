//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.OopsAssignment.HospitalManagementSystem
//{
//    class HospitalManagement
//    {
//        static void Main(string[] args)
//        {
//            // Polymorphism: Patient reference
//            Patient patient1 = new InPatient(201, "Rama", 54, "Typhoid", 5, 3000);
//            Patient patient2 = new OutPatient(102, "Anita", 30, "Fracture", 400);


           
//            patient1.AddRecord("Surgery scheduled");
//            patient1.AddRecord("X-Ray done");

            
//            patient2.AddRecord("Prescribed medication");
//            patient2.AddRecord("Blood test");

//            DisplayPatientBill(patient1);
//            Console.WriteLine();
//            DisplayPatientBill(patient2);
//        }

//        static void DisplayPatientBill(Patient patient)
//        {
//            patient.GetPatientDetails();
//            patient.ViewRecords();
//            Console.WriteLine("Total Bill: ₹" + patient.CalculateBill());
//        }
//    }

//}
