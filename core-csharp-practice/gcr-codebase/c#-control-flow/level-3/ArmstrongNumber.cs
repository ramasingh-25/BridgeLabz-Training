using System;

public class ArmstrongNumber
{
   public static void Main()
    {
	
	
        Console.Write("Enter a number: ");
		
		
		
        int num = Convert.ToInt32(Console.ReadLine());
		
		
        int sum =0;
		
        int orgnum = num;


        while(orgnum != 0)
        {
            int rem =orgnum % 10;
            sum = sum+ (rem * rem * rem);
            orgnum = orgnum / 10;

        }
        if(num == sum)
        {
            Console.WriteLine(num +" is an Armstrong Number");
        }
        else
        {
            Console.WriteLine(num +" is not an Armstrong Number");
        }
        Console.ReadLine();
    }
}