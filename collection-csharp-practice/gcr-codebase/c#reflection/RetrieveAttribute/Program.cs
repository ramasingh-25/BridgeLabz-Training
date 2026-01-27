//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Project5.Reflection.RetrieveAttribute
//{
//    internal class Program
//    {
//        static void Main()
//        {
//            // Get type information
//            Type type = typeof(Book);

//            // Retrieve Author attribute
//            AuthorAttribute author =
//                (AuthorAttribute)Attribute.GetCustomAttribute(
//                    type,
//                    typeof(AuthorAttribute)
//                );

//            if (author != null)
//            {
//                Console.WriteLine("Author Name: " + author.Name);
//            }
//            else
//            {
//                Console.WriteLine("Author attribute not found.");
//            }
//        }
//    }
//}
