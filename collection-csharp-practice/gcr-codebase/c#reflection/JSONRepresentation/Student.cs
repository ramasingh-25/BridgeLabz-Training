//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Project5.Reflection.JSONRepresentation
//{
//    using System.Reflection;

//    class Program
//    {
//        // Sample model
//        class Student
//        {
//            public int Id;
//            public string Name;
//            public int Age;
//        }

//        // Method to generate JSON-like string using Reflection
//        static string ToJson(object obj)
//        {
//            Type type = obj.GetType();
//            FieldInfo[] fields = type.GetFields(
//                BindingFlags.Public | BindingFlags.Instance
//            );

//            StringBuilder json = new StringBuilder();
//            json.Append("{ ");

//            for (int i = 0; i < fields.Length; i++)
//            {
//                FieldInfo field = fields[i];
//                object value = field.GetValue(obj);

//                json.Append($"\"{field.Name}\": ");

//                if (value is string)
//                    json.Append($"\"{value}\"");
//                else
//                    json.Append(value);

//                if (i < fields.Length - 1)
//                    json.Append(", ");
//            }

//            json.Append(" }");
//            return json.ToString();
//        }

//        static void Main()
//        {
//            Student student = new Student
//            {
//                Id = 101,
//                Name = "Rama",
//                Age = 23
//            };

//            string json = ToJson(student);
//            Console.WriteLine(json);
//        }
//    }

//}
