//using System;
//using System.Collections.Generic;
//using System.Reflection;
//using System.Text;

//namespace Project5.Reflection.CustomerObjectMapper
//{
//    internal class CustomerObject
//    {
       
    
//        // Model class
//        class Student
//        {
//            public int Id;
//            public string Name;
//            public int Age;
//        }

//        // Custom Object Mapper
//        public static T ToObject<T>(Type clazz, Dictionary<string, object> properties)
//        {
//            // Create object dynamically
//            object obj = Activator.CreateInstance(clazz);

//            foreach (var item in properties)
//            {
//                // Get matching field
//                FieldInfo field = clazz.GetField(
//                    item.Key,
//                    BindingFlags.Public | BindingFlags.Instance
//                );

//                if (field != null)
//                {
//                    field.SetValue(obj,
//                        Convert.ChangeType(item.Value, field.FieldType));
//                }
//            }

//            return (T)obj;
//        }

//        static void Main()
//        {
//            Dictionary<string, object> data = new Dictionary<string, object>
//        {
//            { "Id", 101 },
//            { "Name", "Rama" },
//            { "Age", 23 }
//        };

//            Student student = ToObject<Student>(typeof(Student), data);

//            Console.WriteLine(
//                $"Id: {student.Id}, Name: {student.Name}, Age: {student.Age}"
//            );
//        }
//    }

//}
