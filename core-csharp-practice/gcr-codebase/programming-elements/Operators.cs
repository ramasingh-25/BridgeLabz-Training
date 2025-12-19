//operators
using System;
public class Operators{
   public static void Main(String[] args){
   
   
    // Arithmatic Operators
	int num1 =20;
	int num2 =30;
	
	Console.WriteLine("Addition:"+(num1+num2));
	Console.WriteLine("Substraction:"+(num1-num2));
	Console.WriteLine("Multiplication:"+(num1*num2));
	Console.WriteLine("Division:"+(num1/num2));
	Console.WriteLine("Modulus:"+(num1%num2));
	
	
	//Relational Operators
	
	
	Console.WriteLine("isEqual " + (num1==num2));
   
   Console.WriteLine("NotEqualsTo " + (num1!=num2));
   
   Console.WriteLine("GreaterThan " + (num1>num2));
   
   Console.WriteLine("LessThan " + (num1<num2));
   
   Console.WriteLine("GreaterThanisEqualto " + (num1>=num2));
   
   Console.WriteLine("LessThanisEqualto " + (num1<=num2));
   
   //Logical Operator
   
   
   bool a=true;
   bool b=false;
   
   Console.WriteLine("Logical And " + (a&&b));
   
   Console.WriteLine("Logical Or " + (a||b));

   Console.WriteLine("Logical Not " + !b);
   
   //Assignment Operator
   
  
   Console.WriteLine("Assignment " + (num1=num2));
   
   Console.WriteLine("AdditionAssignment " + (num1+=num2));
   
   Console.WriteLine("SubtractionAssignment " + (num1-=num2));
   
   Console.WriteLine("MultiplicationAssignment " + (num1*=num2));
   
   Console.WriteLine("DivisonAssignment " + (num1/=num2));
   
   Console.WriteLine("ModuloAssignment " + (num1%=num2));
   
   //Urnary Operator
   
   bool isf = false;
   Console.WriteLine("PreIncrement "+ (++num1));
   
   Console.WriteLine("PreDecrement "+ (--num1));

   Console.WriteLine("PostIncrement "+ (num1++));
   
   Console.WriteLine("PostDecrement "+ (num1--));
   
   Console.WriteLine("LogicalCompliment "+ (isf));
   
   
   //Ternary Operator
   
  int max = (num1 > num2) ? num1 : num2;
   Console.WriteLine(max);
   
   
   //is Operator
   
   String name="Rama";
   
   if(name is String){
   Console.WriteLine("Yes,name is String");
   }
   
   
	
   
	
	
	
}
}