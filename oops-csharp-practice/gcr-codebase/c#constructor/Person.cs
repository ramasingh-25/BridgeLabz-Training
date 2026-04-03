//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.Constructor
//{
//    internal class Person
//    {
//        public string PersonName;
//        public int Age;

        
//        public Person(string name, int age)   //parameterized
//        {
//            PersonName = name;
//            Age = age;
//        }

      
//        public Person(Person other)   //copy constructor
//        {
//                PersonName = other.PersonName;

//            Age = other.Age;
//        }

       
//        public static void Main(string[] args)    //main method
//        {
//            Person P = new Person("Rishita", 18);

//            Person copy = new Person(P);


//            Console.WriteLine("Parameterized Constructor");
//            Console.WriteLine(P.PersonName + " " + P.Age);


//            Console.WriteLine("Copy Constructor");
//            Console.WriteLine(copy.PersonName + " " + copy.Age);
//        }



//    }
//}
   