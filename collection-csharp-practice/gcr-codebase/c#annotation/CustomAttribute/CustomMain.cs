using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ProjectFive.Annotation.CustomAttribute
{
    public class CustomMain
    {
       public static void Main(string[] args)
        {
            Type type = typeof(TaskManager);

            MethodInfo method = type.GetMethod("CompleteTask");

            TaskInfo attr =  (TaskInfo)Attribute.GetCustomAttribute( method, typeof(TaskInfo));

            Console.WriteLine("Priority: " + attr.Priority);

            Console.WriteLine("Assigned To: " + attr.AssignedTo);
        }
    }
}

