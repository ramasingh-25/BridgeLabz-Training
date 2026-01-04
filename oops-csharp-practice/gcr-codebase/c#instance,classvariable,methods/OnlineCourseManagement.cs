//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.InstanceVsClass
//{
//    class OnlineCourseManagement
//    {
        
//        public class Course
//        {
//            private string courseName;
//            private int duration;
//            private double fee;
//            private static string instituteName = "Start Name";

//            public Course(string courseName, int duration, double fee)
//            {
//                this.courseName = courseName;
//                this.duration = duration;
//                this.fee = fee;
//            }
//            //method to display course details
//            public void ShowCourseDetails()
//            {
//                Console.WriteLine("Institute Name : " + instituteName);
//                Console.WriteLine("Course Name    : " + courseName);
//                Console.WriteLine("Duration       : " + duration + " months");
//                Console.WriteLine("Course Fee     : ₹" + fee);
//                Console.WriteLine();
//            }
//            public static void UpdateInstituteName(string newInstituteName)
//            {
//                instituteName = newInstituteName;
//            }
//            //main method
//            public static void Main(string[] args)
//            {
//                Course course1 = new Course(".net", 7, 7000);

//                course1.ShowCourseDetails();
//                Course course2 = new Course("Python", 5, 40000);

//                course2.ShowCourseDetails();
//                Console.WriteLine("Updating Institute Name");
//                Course.UpdateInstituteName("BridgeLabz Classes");
//                course1.ShowCourseDetails();
//                course2.ShowCourseDetails();
//            }
//        }
//    }

//}
