using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace project1.methods;

 class SimpleInterest
{
    
    
    static void Main(string[] args)


    {

        
        Console.WriteLine("Enter Principle");   
        double pv = Convert.ToDouble(Console.ReadLine());  //taking input from user

       
        Console.WriteLine("Enter Rate");
        double r = Convert.ToDouble(Console.ReadLine());  //taking rate value from user

        
        Console.WriteLine("Enter Time");  //input time
        double t = Convert.ToDouble(Console.ReadLine());


        
        double simpleInterest = CalculateSimpleInterest(pv, r, t);    //calculating simple interest value

        Console.WriteLine($"Simple Interst is : {simpleInterest}");

    }

    static double CalculateSimpleInterest(double pv, double r, double t)
    {
        return (pv * r * t) / 100;

    }
}