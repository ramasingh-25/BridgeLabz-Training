using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectFive.Annotation.MethodOverriding
{
    public class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Dog barks");
        }
    }
}
