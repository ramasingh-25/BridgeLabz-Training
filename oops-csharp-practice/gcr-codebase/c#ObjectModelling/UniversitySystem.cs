//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.ObjectModelling
//{
//    internal class UniversitySystem
//    {

//        public static void Main(String[] args)
//        {

//            University univ = new University("GLA University");


//            Student stu1 = new Student("Rishita");
//            Student stu2 = new Student("Monty");


//            Professor pro1 = new Professor("Shail Kumar");
//            Professor pro2 = new Professor("Chirag Patil");


//            Course cor1 = new Course("Science");
//            Course cor2 = new Course("Electronics");


//            univ.AddStudent(stu1);
//            univ.AddStudent(stu2);

//            univ.AddProfessor(pro1);
//            univ.AddProfessor(pro2);

//            univ.AddCourse(cor1);
//            univ.AddCourse(cor2);



//            univ.DisplayUniversityDetails();


//            stu1.EnrollCourse(cor1);
//            stu2.EnrollCourse(cor1);
//            stu2.EnrollCourse(cor2);

//            cor1.AssignProfessor(pro1);
//            cor2.AssignProfessor(pro2);

//            Console.WriteLine();


//            stu1.ShowCourses();
//            stu2.ShowCourses();

//            cor1.DisplayCourseDetails();
//            cor2.DisplayCourseDetails();


//        }
//    }
//    class Student
//        {
//            public string Name { get; set; }
//            private List<Course> courses = new List<Course>();

//            //Constructor
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

//                    Console.WriteLine(Name + " enrolled in " + course.CourseName);
//                }
//            }


//            public void ShowCourses()
//            {
//                Console.WriteLine("Courses enrolled by " + Name);
//                foreach (Course c in courses)
//                {
//                    Console.WriteLine("- " + c.CourseName);
//                }
//                Console.WriteLine();
//            }
//        }


      
//        class Professor
//        {
//            public string Name { get; set; }

           
//            public Professor(string entername)
//            {
//                this.Name = entername;
//            }

//            public void ShowProfessor()
//            {
//                Console.WriteLine("Professor: " + Name);
//            }
//        }


      
//        class Course
//        {
//            public string CourseName { get; set; }
//            private List<Student> students = new List<Student>();
//            private Professor professor;



           
//            public Course(string entercourseName)
//            {
//                this.CourseName = entercourseName;
//            }


//            public void AddStudent(Student student)
//            {
//                if (!students.Contains(student))
//                {
//                    students.Add(student);
//                }
//            }



//            public void AssignProfessor(Professor prof)
//            {
//                professor = prof;
//                Console.WriteLine(prof.Name + " is assigned to teach " + CourseName);
//            }


//            public void DisplayCourseDetails()
//            {
//                Console.WriteLine("Course: " + CourseName);

//                if (professor != null)
//                    Console.WriteLine("Professor: " + professor.Name);

//                Console.WriteLine("Students:");
//                foreach (Student s in students)
//                {
//                    Console.WriteLine(s.Name);
//                }
//                Console.WriteLine();
//            }
//        }


        
//        class University

//        {
//            public string UniversityName { get; set; }

//            private List<Student> students = new List<Student>();

//            private List<Professor> professors = new List<Professor>();

//            private List<Course> courses = new List<Course>();

//            public University(string universityName)
//            {
//                UniversityName = universityName;
//            }

//            public void AddStudent(Student student) => students.Add(student);
//            public void AddProfessor(Professor professor) => professors.Add(professor);
//            public void AddCourse(Course course) => courses.Add(course);

//            public void DisplayUniversityDetails()
//            {
//                Console.WriteLine("University: " + UniversityName);

//                Console.WriteLine("Students:");
//                foreach (Student s in students)
//                    Console.WriteLine(s.Name);



//                Console.WriteLine("Professors:");
//                foreach (Professor p in professors)
//                    Console.WriteLine(p.Name);



//                Console.WriteLine("Courses:");
//                foreach (Course c in courses)
//                    Console.WriteLine(c.CourseName);

//                Console.WriteLine();
//            }
//        }

        
            
//    }


