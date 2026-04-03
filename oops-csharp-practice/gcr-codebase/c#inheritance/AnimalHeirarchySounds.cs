//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.Inheritance
//{
//     class AnimalHeirarchySounds
//    {
//        public virtual void MakeSound()
//        {
//            Console.WriteLine("Animal makes a sound");
//        }
//}
//    class Dog : AnimalHeirarchySounds
//    {
//        public override void MakeSound()
//        {
//            Console.WriteLine("Dog barks");
//        }
//    }
//    class Cat : AnimalHeirarchySounds
//    {
//    public override void MakeSound()
//        {
//            Console.WriteLine("Cat meows");
//        }
//    }

//class Bird : AnimalHeirarchySounds

//    {
//    public override void MakeSound()
//    {
//        Console.WriteLine("Bird Chirps");
//    }
//        public static void Main(string[] args)
//        {
//            AnimalHeirarchySounds m1 = new Dog();
//            AnimalHeirarchySounds m2 = new Cat();
//            AnimalHeirarchySounds m3 = new Bird();
//            m1.MakeSound();

//            m2.MakeSound();
//            m3.MakeSound();
//        }
//}
//}
