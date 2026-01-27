//using System;
//using System.Collections.Generic;
//using System.Reflection;
//using System.Text;

//namespace Project5.Reflection
//{
//    internal class ReflectionInfo
//    {
       
//        static void Main()
//        {
//            Console.Write("Enter class name (with namespace if any): ");
//            string className = Console.ReadLine();

            
//            Type type = Type.GetType(className);

//            if (type == null)
//            {
//                Console.WriteLine("Class not found!");
//                return;
//            }

//            Console.WriteLine($"\nClass Name: {type.FullName}");

//            Console.WriteLine("\n--- Constructors ---");
//            ConstructorInfo[] constructors = type.GetConstructors();
//            foreach (var ctor in constructors)
//            {
//                Console.WriteLine(ctor);
//            }

            
//            Console.WriteLine("\n--- Fields ---");
//            FieldInfo[] fields = type.GetFields(
//                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static
//            );
//            foreach (var field in fields)
//            {
//                Console.WriteLine($"{field.FieldType.Name} {field.Name}");
//            }

            
//            Console.WriteLine("\n--- Methods ---");
//            MethodInfo[] methods = type.GetMethods(
//                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static
//            );
//            foreach (var method in methods)
//            {
//                Console.WriteLine(method.Name);
//            }
//        }
//    }

//}