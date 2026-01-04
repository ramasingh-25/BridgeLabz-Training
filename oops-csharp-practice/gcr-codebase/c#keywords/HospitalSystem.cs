//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.Sealed
//{
//     class Patient
//    {
//      //defining attributes for hospital managemet 
//        public static string HospitalName = "City Care Hospital";
//        private static int totalPatients = 0;
//        public readonly int PatientID;
//        public string Name;
//        public int Age;
//        public string Ailment;
//       //parameterized constructor
//        public Patient(string Name, int Age, int PatientID, string Ailment)
//        {
//            this.Name = Name;
//            this.Age = Age;
//            this.PatientID = PatientID;
//            this.Ailment = Ailment;
//            totalPatients++;
//        }
//        //method to calculate total patient
//        public static int TotalPatients()
//        {
//            return totalPatients;
//        }
//        public void ShowPatientDetails(object patient)
//        {
//            if (patient is Patient)
//            {
//                Console.WriteLine("Hospital Name : " + HospitalName);
//                Console.WriteLine("Patient Name  : " + Name);
//                Console.WriteLine("Age           : " + Age);
//                Console.WriteLine("Patient ID    : " + PatientID);
//                Console.WriteLine("Ailment       : " + Ailment);
//            }
//            else
//            {
//                Console.WriteLine("Invalid patient object");
//            }
//        }
//    }

//    class HospitalSystem
//    {
//        //main method
//        static void Main(string[] args)
//        {
//            Patient patient1 = new Patient("Rama", 21, 501, "ColdFever");
//            Patient patient2 = new Patient("Chitra", 25, 502, "SevereInjuries");

//            patient1.ShowPatientDetails(patient1);
//            Console.WriteLine();

//            patient2.ShowPatientDetails(patient2);
//            Console.WriteLine();

//            Console.WriteLine("Total Patients Admitted: " + Patient.TotalPatients());
//        }
//    }
//}


