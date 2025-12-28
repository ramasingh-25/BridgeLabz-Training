//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace project1.Strings
//{
//    class PrintingNullReferenceException
//    {

//        //main method


//    static void Main() {
//        DemonstrateNullReferenceException();
//    }


//        //method to demonstrate NullReferenceException by accessing a method on a null string.



//        static void DemonstrateNullReferenceException()



//    {


//        try
//        {

//            string msg = null;
            
//            int length = msg.Length;

//            Console.WriteLine("Length of string: " + length);
//        }

//        catch (NullReferenceException ex)

//        {
//            Console.WriteLine("NullReferenceException caught!");
//            Console.WriteLine("Error Message: " + ex.Message);
//        }
//    }    }
//}
