//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.Constructor
//{
//     class Book
//    {
//            public string title;
//            public string author;
//            public double price;

//            public Book() // defaault constructor by compiler
//            {
//                price = 0.0;
//                author = "unkown";
//                title = "unkown";
//            }

//            public Book(string Title, string Author, double Price)   //parameterized constructor
        
//        {
//            title = Title;
//                author = Author;
//                price = Price;
//            }

           

//            public static void Main(string[] args)  //main method
//            {
//                Book B1 = new Book();

//                Console.WriteLine("Default Constructor value");
//                Console.WriteLine(B1.title + "," + B1.author + "," + B1.price);

//                Console.WriteLine("Parameterized Constructor value");
//                Book B2 = new Book("harry-potter", "Rama", 500);

//                Console.WriteLine(B2.title + "," + B2.author + "," + B2.price);



//            }


//        }
//    }

