//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Project5.Reflection.Configuration
//{
//    using System;
//    using System.Reflection;

//    class Configuration
//    {
//        private static string API_KEY = "DEFAULT_KEY";

//        public static void ShowKey()
//        {
//            Console.WriteLine("API_KEY (inside class): " + API_KEY);
//        }
//    }

//    class Program
//    {
//        static void Main()
//        {
//            // Get type information
//            Type type = typeof(Configuration);

//            // Get private static field 'API_KEY'
//            FieldInfo apiKeyField = type.GetField(
//                "API_KEY",
//                BindingFlags.NonPublic | BindingFlags.Static
//            );

//            // Safety check (important)
//            if (apiKeyField == null)
//            {
//                Console.WriteLine("Field not found!");
//                return;
//            }

//            // Modify static field value (null because it's static)
//            apiKeyField.SetValue(null, "NEW_SECRET_KEY");

//            // Retrieve static field value
//            string apiKeyValue = (string)apiKeyField.GetValue(null);

//            Console.WriteLine("API_KEY (via Reflection): " + apiKeyValue);

//            // Verify from inside class
//            Configuration.ShowKey();
//        }
//    }

//}
