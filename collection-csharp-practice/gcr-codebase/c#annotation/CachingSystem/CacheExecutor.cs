using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ProjectFive.Annotation.CachingSystem
{
    public class CacheExecutor
    {

        private static Dictionary<string, object> cache =
            new Dictionary<string, object>();

        public static object Execute(object target, string methodName, object[] parameters)
        {
            Type type = target.GetType();
            MethodInfo method = type.GetMethod(methodName);

            
            if (!Attribute.IsDefined(method, typeof(CacheResult)))
            {
                return method.Invoke(target, parameters);
            }

            
            string key = methodName + "_" + string.Join("_", parameters);

           
            if (cache.ContainsKey(key))
            {
                Console.WriteLine("Returning cached result...");
                return cache[key];
            }

            
            object result = method.Invoke(target, parameters);
            cache[key] = result;

            return result;
        }
    }
}
