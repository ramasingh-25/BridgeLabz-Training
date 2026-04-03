//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.ObjectModelling
//{
//    internal class AssociationAggregation
//    {
//        static void Main()
//        {

//            School school = new School("St.Marris Convent School");


//            Student st1 = new Student("Chitra ");
//            Student st2 = new Student("Aman");


//            school.AddStudent(st1);
//            school.AddStudent(st2);


//            Course c1 = new Course("Mathematics");
//            Course c2 = new Course("Enhlish Literature");


//            st1.EnrollCourse(c1);
//            st1.EnrollCourse(c2);
//            st2.EnrollCourse(c2);


//            school.ShowStudents();

//            st1.ShowCourses();
//            st2.ShowCourses();

//            c1.DisplayEnrolledStudents();
//            c2.DisplayEnrolledStudents();
//        }
//    }
//}


//class Course
//        {
//            public string CourseName { get; set; }
//            private List<Student> enrolledStudents = new List<Student>();

            
//            public Course(string entercourseName)
//            {
//                this.CourseName = entercourseName;
//            }

            
//            public void AddStudent(Student student)
//            {
//                if (!enrolledStudents.Contains(student))
//                {
//                    enrolledStudents.Add(student);
//                }
//            }

//            public void DisplayEnrolledStudents()
//            {
//                Console.WriteLine("Students enrolled in " + CourseName);
//                foreach (Student s in enrolledStudents)
//                {
//                    Console.WriteLine(s.Name);
//                }
//                Console.WriteLine();
//            }
//        }


       
//        class Student
//        {
//            public string Name { get; set; }
//            private List<Course> courses = new List<Course>();

           
//            public Student(string entername)
//            {
//                this.Name = entername;
//            }

//            public void EnrollCourse(Course course)
//            {
//                if (!courses.Contains(course))
//                {
//                    courses.Add(course);
//                    course.AddStudent(this);
//                }
//            }
    

//            public void ShowCourses()
//            {
//                Console.WriteLine(Name + " is enrolled in");
//                foreach (Course c in courses)
//                {
//                    Console.WriteLine(c.CourseName);
//                }
//                Console.WriteLine();
//            }
//        }


       


//        class School
//        {
//            public string SchoolName { get; set; }
//            private List<Student> students = new List<Student>();

//            public School(string schoolName)
//            {
//                SchoolName = schoolName;
//            }

//            public void AddStudent(Student student)
//            {
//                students.Add(student);
//            }

//            public void ShowStudents()
//            {
//                Console.WriteLine($"Students in {SchoolName}:");
//                foreach (Student s in students)
//                {
//                    Console.WriteLine("- " + s.Name);
//                }
//                Console.WriteLine();
//            }
//        }


    