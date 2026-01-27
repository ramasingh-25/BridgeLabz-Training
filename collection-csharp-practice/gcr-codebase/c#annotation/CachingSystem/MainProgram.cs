using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectFive.Annotation.CachingSystem
{
   public class MainProgram
    {
        public static void Main(string[] args)
        {
            Calculator calc = new Calculator();

            Console.WriteLine(CacheExecutor.Execute(calc, "Square", new object[] { 5 }));
            Console.WriteLine(CacheExecutor.Execute(calc, "Square", new object[] { 5 })); //
            Console.WriteLine(CacheExecutor.Execute(calc, "Square", new object[] { 6 }));
        }
    }
}
