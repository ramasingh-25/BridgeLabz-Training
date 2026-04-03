//using System;
//using System.Collections.Generic;
//using System.Reflection;
//using System.Text;

//namespace Project5.Reflection.DependencyInjection
//{
//    class DIContainer
//    {
//        public static void InjectDependencies(object target)
//        {
//            Type type = target.GetType();

//            // Scan all fields
//            FieldInfo[] fields = type.GetFields(
//                BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance
//            );

//            foreach (FieldInfo field in fields)
//            {
//                // Check for [Inject] attribute
//                if (field.IsDefined(typeof(InjectAttribute), false))
//                {
//                    // Create dependency instance dynamically
//                    object dependency =
//                        Activator.CreateInstance(field.FieldType);

//                    // Inject dependency
//                    field.SetValue(target, dependency);
//                }
//            }
//        }
//    }
//}
