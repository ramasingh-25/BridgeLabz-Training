//DATATYPE
using System;

public class DataType{

  public static void Main(String[] args){
   int a =15;
   Console.WriteLine(a);
   

   double b= 30.33;
  Console.WriteLine(b);
   
   long c= 50000;
   Console.WriteLine(c);
   
   char ch = 'R';
   Console.WriteLine(ch);
   
   bool isT = true;
   Console.WriteLine(isT);
   
   float d = 2.5f;
   Console.WriteLine(d);
   
   String  name = "rama";
   Console.WriteLine(name);
   
   //Implicit Typecasting
   
   //int to long
   
    int x= 200;
    long y = x;
	Console.WriteLine(y);
	
   
   //double to int
   
     double e =a;
	 Console.WriteLine(e);
   
   //Explicit Typecasting
   
   double num = 12.55;
   int n =(int)num;
   Console.WriteLine(n);
   
}

}