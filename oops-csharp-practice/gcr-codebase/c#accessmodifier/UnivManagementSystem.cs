//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.AccessModifier
//{
//    class UnivManagementSystem
//    {
        
//        public int rollNumber; 
        
//        protected string name;  
        
//        private double CGPA;  
        
        
//        public void SetCGPA(double cgpa)
//        {
//            CGPA = cgpa;   
//        }

//        // Method to get CGPA   
//        public double GetCGPA()
//        {
//            return CGPA;
//        }

//        // Method to display details
//        public void ShowDetails()
//        {
//            Console.WriteLine("Roll Number: " + rollNumber);
//            Console.WriteLine("Name: " + name);
//            Console.WriteLine("CGPA: " + CGPA);
//        }

        
//        public void SetName(string studentName)
//        {
//            name = studentName; 
//        }
//    }
//    class PostgraduateStudent
//    {
//        static void Main()
//        {
//            UnivManagementSystem student = new UnivManagementSystem();

//            student.rollNumber = 1;       
//            student.SetName("Rama");       
//            student.SetCGPA(8.5);          

//            student.ShowDetails();

              
//        }
//    }


//}