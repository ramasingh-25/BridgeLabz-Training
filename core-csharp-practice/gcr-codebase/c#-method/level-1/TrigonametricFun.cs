using System;

class TrigonometricFun
{
   //method to alculate trigonometric function

    public static double[] TrigonometricFunctions(double angle)
    {
        
        double radians = angle * Math.PI / 180;  //converting to radian

        double sine = Math.Sin(radians); 


        double cosine = Math.Cos(radians);


        double tangent = Math.Tan(radians);

        return new double[] { sine, cosine, tangent };


    }
    //main method

    static void Main(string[] args)
    {




        Console.Write("Enter angle in degrees: ");
        double angle = double.Parse(Console.ReadLine());

        double[] result = TrigonometricFunctions(angle);



        //printing the value 
        Console.WriteLine("Sine: " + result[0]);
        Console.WriteLine("Cosine: " + result[1]);
        Console.WriteLine("Tangent: " + result[2]);
    }
}
