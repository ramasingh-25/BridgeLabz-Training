using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ProjectFive.Annotation.CustomAttribute2
{
    public class MainProgram
    {
        static void Main(string[] args)
        {
            Type type = typeof(Service);
            MethodInfo[] methods = type.GetMethods(
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            foreach (MethodInfo method in methods)
            {
                ImportantMethod attr =
                    (ImportantMethod)Attribute.GetCustomAttribute(
                        method, typeof(ImportantMethod));

                if (attr != null)
                {
                    Console.WriteLine(
                        $"Method: {method.Name}, Importance Level: {attr.Level}");
                }
            }
        }
    }
}

