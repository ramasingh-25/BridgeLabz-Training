using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ProjectFive.Annotation.TodoAttribute
{
    public class MainProgram
    {
        public static void Main(string[] args)
        {
            Type type = typeof(ProjectTask);
            MethodInfo[] methods = type.GetMethods(
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            foreach (MethodInfo method in methods)
            {
                TodoAttribute todo =
                    (TodoAttribute)Attribute.GetCustomAttribute(
                        method, typeof(TodoAttribute));

                if (todo != null)
                {
                    Console.WriteLine("Method: " + method.Name);
                    Console.WriteLine(" Task: " + todo.Task);
                    Console.WriteLine(" Assigned To: " + todo.AssignedTo);
                    Console.WriteLine(" Priority: " + todo.Priority);
                    Console.WriteLine();
                }
            }
        }
    }
}
