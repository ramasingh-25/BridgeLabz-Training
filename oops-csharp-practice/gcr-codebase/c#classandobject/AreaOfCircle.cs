//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.ClassAndObject
//{
//     class AreaOfCircle
//    {
//        double radius;
//        double CalculatingArea;
//        double circumferenceOfCircle;


//        public AreaOfCircle(double enteredRadius)
//        {

//            this.radius = enteredRadius;

//        }
//        //method to calculate area of circle
//        void CalculateAreaAndCircumference()
//        {
//            CalculatingArea = 3.14 * (radius * radius);
//            circumferenceOfCircle = 2 * 3.14 * radius;

//        }

//        //method to display the area of circle
//        void ShowAreaAndCircumference()
//        {
//            Console.WriteLine("Area and circumference of circle are given below");
//            Console.WriteLine("Area Of Circle is: " + CalculatingArea);
//            Console.WriteLine("Circumference Of circle is : " + circumferenceOfCircle);

//        }
//        static void Main(string[] args)
//        {
//            AreaOfCircle radius1 = new AreaOfCircle(5);
//            radius1.CalculateAreaAndCircumference();
//            radius1.ShowAreaAndCircumference();

//        }
//    }
//}
