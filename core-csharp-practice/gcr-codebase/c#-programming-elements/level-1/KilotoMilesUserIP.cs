using System;
public class KilotoMilesUserIP{
  public static void Main(String[] args){
  
  
  Console.Write("Enter Distance in km: ");
		
        double km = Convert.ToDouble(Console.ReadLine());
  		
        double miles= km*0.621371f;

        Console.WriteLine("The total miles is  " + miles + " mile for the given " + km + " km" );

        
  }
}