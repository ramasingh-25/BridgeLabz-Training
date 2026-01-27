using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectFive.Annotation.CachingSystem
{
    public class Calculator
    {
        [CacheResult]
        public int Square(int number)
        {
            Console.WriteLine("Computing result...");
            Thread.Sleep(2000); 
            return number * number;
        }
    }
}
