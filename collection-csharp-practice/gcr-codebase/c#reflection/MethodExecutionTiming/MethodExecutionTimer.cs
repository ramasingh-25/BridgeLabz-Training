//using System;
//using System.Diagnostics;
//using System.Reflection;

//namespace Project5.Reflection.MethodExecutionTiming
//{
//    internal class MethodExecutionTimer
//    {
//        static void Main()
//        {
//            Type type = typeof(SampleTasks);
//            object instance = Activator.CreateInstance(type);

//            MethodInfo[] methods = type.GetMethods(
//                BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly
//            );

//            foreach (MethodInfo method in methods)
//            {
//                Stopwatch stopwatch = Stopwatch.StartNew();

//                method.Invoke(instance, null);

//                stopwatch.Stop();

//                Console.WriteLine(
//                    $"Method: {method.Name} | Execution Time: {stopwatch.ElapsedMilliseconds} ms"
//                );
//            }

//        }
//    }
//}
