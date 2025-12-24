using System;
using System.Collections.Generic;
using System.Text;

namespace project1.array
{
    internal class CanVote
    {
        static void Main()


        {

            int[] age = new int[10];
            for (int i = 0; i < age.Length; i++)



            {
                Console.Write("Enter Age of student " + (i + 1) + " :");
                age[i] = Convert.ToInt32(Console.ReadLine());



            }
            Console.WriteLine("Voting Eligibility :");
            for (int i = 0; i < age.Length; i++)


            {
                if (age[i] < 0)
                {
                    Console.WriteLine("Invalid Age");
                }
                else if (age[i] >= 18)
                {
                    Console.WriteLine("The students with age " + age[i] + " can vote.");
                }
                else
                {
                    Console.WriteLine("The students with age " + age[i] + " cannot vote.");
                }
            }

        }
    }


}

