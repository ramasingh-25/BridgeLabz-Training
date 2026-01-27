//using System;
//using System.Collections.Generic;
//using System.Reflection;
//using System.Text;

//namespace Project5.Reflection.AccessPrivate
//{
//    internal class AccessPrivate
//    {
//        static void Main()
//        {
//            Person person = new Person();

//            // Get Type info
//            Type type = typeof(Person);

//            // Get private field 'age'
//            FieldInfo ageField = type.GetField(
//                "age",
//                BindingFlags.NonPublic | BindingFlags.Instance
//            );

//            // Modify private field value
//            ageField.SetValue(person, 30);

//            // Retrieve private field value
//            int ageValue = (int)ageField.GetValue(person);

//            Console.WriteLine("Age (via Reflection): " + ageValue);

//            // Verify inside class
//            person.ShowAge();
//        }
//    }
//}
