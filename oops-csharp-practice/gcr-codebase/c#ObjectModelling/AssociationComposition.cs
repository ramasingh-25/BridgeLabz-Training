//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.ObjectModelling
//{
//    internal class AssociationComposition
//    {

//        public static void Main(String[] args)
//        {

//            Hospital hospital = new Hospital("Savitri Hospital");


//            Doctor doc1 = new Doctor("Swati");
//            Doctor doc2 = new Doctor("Hemendra");


//            Patient p1 = new Patient("Chitra");
//            Patient p2 = new Patient("Khushi");


//            hospital.AddDoctor(doc1);
//            hospital.AddDoctor(doc2);


//            hospital.AddPatient(p1);
//            hospital.AddPatient(p2);


//            hospital.DisplayHospitalDetails();


//            doc1.Consult(p1);
//            doc1.Consult(p2);
//            doc2.Consult(p1);

//            Console.WriteLine();


//            doc1.ShowPatients();
//            doc2.ShowPatients();
//        }
//        // patient class
//        class Patient
//        {
//            public string Name { get; set; }

//            //constructor
//            public Patient(string entername)
//            {
//                this.Name = entername;
//            }
//        }



//        // anothet class named as Doctor class
//        class Doctor
//        {
//            public string Name { get; set; }
//            private List<Patient> patients = new List<Patient>();


//            //constructor
//            public Doctor(string entername)
//            {
//                this.Name = entername;
//            }


//            public void Consult(Patient patient)
//            {
//                if (!patients.Contains(patient))
//                {
//                    patients.Add(patient);
//                }

//                Console.WriteLine("Doctor " + Name + " is consulting patient " + patient.Name);
//            }

//            public void ShowPatients()
//            {
//                Console.WriteLine("Patients consulted by Dr." + Name);
//                foreach (Patient p in patients)
//                {
//                    Console.WriteLine(p.Name);
//                }
//                Console.WriteLine();
//            }
//        }



//        // another class named as hospital
//        class Hospital
//        {

//            public string HospitalName { get; set; }
//            private List<Doctor> doctors = new List<Doctor>();
//            private List<Patient> patients = new List<Patient>();



//            //constructor
//            public Hospital(string enterhospitalName)
//            {
//                this.HospitalName = enterhospitalName;
//            }



//            public void AddDoctor(Doctor doctor)
//            {
//                doctors.Add(doctor);
//            }



//            public void AddPatient(Patient patient)
//            {
//                patients.Add(patient);
//            }



//            public void DisplayHospitalDetails()
//            {
//                Console.ForegroundColor = ConsoleColor.Yellow;
//                Console.WriteLine(HospitalName);
//                Console.ResetColor();

//                Console.WriteLine("Doctors:");
//                foreach (Doctor d in doctors)
//                {
//                    Console.WriteLine("Dr. " + d.Name);
//                }

//                Console.WriteLine("Patients:");
//                foreach (Patient p in patients)
//                {
//                    Console.WriteLine(p.Name);
//                }

//                Console.WriteLine();
//            }
//        }



       
            
//        }
//    }


