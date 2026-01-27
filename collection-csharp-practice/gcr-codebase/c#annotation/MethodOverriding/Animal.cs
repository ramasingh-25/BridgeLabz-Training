using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectFive.Annotation.MethodOverriding
{
    public class Animal
    {
        public virtual void MakeSound()
        {
            Console.WriteLine("Animal makes a sound");
        }
    }
}

