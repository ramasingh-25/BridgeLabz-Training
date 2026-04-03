//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Project5.Reflection.DynamicallyCreateProject
//{
//    internal class Program
//    {
//        static void Main()
//        {
//            // Get type information
//            Type type = typeof(Student);

//            // Create instance without 'new'
//            object obj = Activator.CreateInstance(type);

//            // Cast to Student
//            Student student = (Student)obj;

//            student.Id = 101;
//            student.Name = "Rama";

//            student.Display();
//        }
//    }
//}
