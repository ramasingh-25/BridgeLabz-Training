using System;
using System.Collections.Generic;
using System.Text;

namespace project1.methods
{
     class LeapYear
    {


        static void Main(string[] args)
        {
            Console.Write("Enter a year: ");
            int year = Convert.ToInt32(Console.ReadLine());

            bool result = IsLeapYear(year);

            if (result)
            {
                Console.WriteLine("Year is a Leap Year");
            }
            else
            {
                Console.WriteLine("Year is not a Leap Year");
            }
        }
        public static bool IsLeapYear(int year)
            {
                
                if (year < 1582)  //for geogian calender
                {
                    return false;
                }   

               //condition to check year is leap or not
                if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
                {
                    return true;
                }

                return false;
            }

            
        }
    }


