using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace project1.array
{
     class GradesPercentage
    {
   
    
static void Main()
        {
            Console.WriteLine("Enter number of students ");
            int n = int.Parse(Console.ReadLine());    //taking inputs from user


            // marks for 3 subjects


            int[] physics = new int[n];
            int[] chemistry = new int[n];
            int[] maths = new int[n];
            double[] percentage = new double[n];
            char[] grade = new char[n];


            //iterating through for loop to print the students marks

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Student {i + 1}");

                Console.Write("Physics marks: ");

                physics[i] = int.Parse(Console.ReadLine());

                if (physics[i] < 0) { i--; continue; }

                Console.Write("Chemistry marks: ");
                chemistry[i] = int.Parse(Console.ReadLine());
                if (chemistry[i] < 0) { i--; continue; }

                Console.Write("Maths marks: ");

                maths[i] = int.Parse(Console.ReadLine());

                if (maths[i] < 0) { i--; continue; }

                percentage[i] = (physics[i] + chemistry[i] + maths[i]) / 3.0;   // calculate the percentage
              
                // grades according to the marks
              


                if (percentage[i] >= 80)
                    grade[i] = 'A';


                else if (percentage[i] >= 70)
                    grade[i] = 'B';


                else if (percentage[i] >= 60)
                    grade[i] = 'C';

                else if (percentage[i] >= 50)
                    grade[i] = 'D';

                else if (percentage[i] >= 40)
                    grade[i] = 'E';

                else
                    grade[i] = 'R';
            }


            // iterating to print the result

            for (int i = 0; i < n; i++) 
            {
                Console.WriteLine($" Physics={physics[i]}, Chemistry={chemistry[i]}, Maths={maths[i]}, Percentage={percentage[i]}, Grade={grade[i]}");
            }
        }
}

}



