using System;
   
   class GradeCalc {
  
    static void Main(string[] args) {

        

       Console.WriteLine("Enter marks in Physics: ");    //taking input of marks from user
	   
	   
		
       int physics = int.Parse(Console.ReadLine());
	   
		
       Console.WriteLine("Enter marks in Chemistry: ");
	   
	   
		
       int chemistry = int.Parse(Console.ReadLine());
		
       Console.WriteLine("Enter marks in Maths: ");
	   
	   
		
       int maths = int.Parse(Console.ReadLine());

        
		
        int totalNumber = physics + chemistry + maths;    // Calculate total and percentage
		
        double percentage = totalNumber / 3.0;

        
		
		
        Console.WriteLine("Percentage: " + percentage + "%");  // Display grade



        if (percentage >= 80) {
           Console.WriteLine("Grade: A (Level 4, above agency-normalized standards)");
        }
		
		
		
		else if (percentage >= 70) {
            Console.WriteLine("Grade: B (Level 3, at agency-normalized standards)");
        }
		
		
		else if (percentage >= 60) {
            Console.WriteLine("Grade: C (Level 2, below but approaching agency-normalized standards)");
        }
		
		else if (percentage >= 50) {
            Console.WriteLine("Grade: D (Level 1, well below agency-normalized standards)");
        }
		
		else if (percentage >= 40) {
            Console.WriteLine("Grade: E (Level 1-, too below agency-normalized standards)");
        }
		
		

		else {
            Console.WriteLine("Grade: R (Remedial standards)");
        }
		
       
    }
}