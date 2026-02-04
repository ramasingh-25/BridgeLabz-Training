using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace BridgeLabz.Collections.Senario.HealthCheckProApp
{
    class ApiScannerUtil : IApiValidator
    {
        public void ScanAndGenerateDocs(Type controllerType)
        {
            Console.WriteLine();
            Console.WriteLine("Scanning Controller : " + controllerType.Name);
            Console.WriteLine("--------------------------------");

            MethodInfo[] methods =
                controllerType.GetMethods(BindingFlags.Public |
                                          BindingFlags.Instance |
                                          BindingFlags.DeclaredOnly);

            foreach (MethodInfo method in methods)
            {
                object[] publicApi =
                    method.GetCustomAttributes(typeof(PublicAPIAttribute), false);

                object[] auth =
                    method.GetCustomAttributes(typeof(RequiresAuthAttribute), false);

                if (publicApi.Length == 0)
                {
                    Console.WriteLine("WARNING : " + method.Name + " has no PublicAPI attribute");
                    Console.WriteLine();
                    continue;
                }

                PublicAPIAttribute api =
                    (PublicAPIAttribute)publicApi[0];

                Console.WriteLine("Method Name : " + method.Name);
                Console.WriteLine("Description : " + api.Description);

                if (auth.Length > 0)
                {
                    RequiresAuthAttribute a =
                        (RequiresAuthAttribute)auth[0];

                    Console.WriteLine("Access Role : " + a.Role);
                }
                else
                {
                    Console.WriteLine("Access Role : Public");
                }

                Console.WriteLine();
            }
        }
    }

}
