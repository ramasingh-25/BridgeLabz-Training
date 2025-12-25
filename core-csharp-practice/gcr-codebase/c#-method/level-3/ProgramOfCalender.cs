using System;
using System.Collections.Generic;
using System.Text;

namespace project1.method
{
     class  ProgramOfCalender{

       

     static string MonthName(int month)
        {
            string[] monthNames = {"", "January", "February", "March", "April",
                               "May", "June", "July", "August", "September",
                               "October", "November", "December"};

            return monthNames[month];
        }
        
        static bool IsLeapYear(int year)        //check leap year

        {
            if (year % 400 == 0)
            {
                return true;
            }
            if (year % 100 == 0)
            {
                return false;
            }
            if (year % 4 == 0)
            {
                return true;
            }
            return false;
        }

        
        static int NumberOfDays(int month, int year)    // number of days in a month
        {
            int[] daysInMonth = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            
            if (month == 2 && IsLeapYear(year))    // Check February in a leap year
            {
                return 29;
            }
            return daysInMonth[month];
        }

        
        static int FirstDay(int month, int year)     //using Gregorian calendar algorithm


        {
            int d = 1;     // First day of the month
            int m = month;
            int y = year;


            int y0 = y - (14 - m) / 12;
            int x = y0 + y0 / 4 - y0 / 100 + y0 / 400;
            int m0 = m + 12 * ((14 - m) / 12) - 2;
            int d0 = (d + x + (31 * m0) / 12) % 7;

            return d0;
        }


        static void Calendar(int month, int year)


        {


            string monthName = MonthName(month);
            Console.WriteLine("\n    {0} {1}", monthName, year);
            Console.WriteLine(" Sun Mon Tue Wed Thu Fri Sat");


            int firstDay = FirstDay(month, year);


            int numberOfDays = NumberOfDays(month, year);

            for (int i = 0; i < firstDay; i++)
            {
                Console.Write("    ");
            }


            for (int day = 1; day <= numberOfDays; day++)
            {
                Console.Write("{0,4}", day);

                // Move to next line after Saturday
                if ((day + firstDay) % 7 == 0)
                {

                    Console.WriteLine();


                }
            }


            Console.WriteLine("\n");
        }
        public static void Main()
        {

            Console.Write("Enter month and year (e.g., 07 2005): ");    // input from user

            string[] input = Console.ReadLine().Split(' ');
            int month = int.Parse(input[0]);
            int year = int.Parse(input[1]);


            Calendar(month, year);        // Display the calendar
        }
    }

}

