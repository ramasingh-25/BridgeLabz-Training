using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace BridgeLabz.Collections.Senario.EventTrackerApp
{

    class AuditScannerUtil : IAuditScanner
    {
        public void GenerateAuditLogs(Type targetClass)
        {
            Console.WriteLine();
            Console.WriteLine("Scanning class : " + targetClass.Name);
            Console.WriteLine("Generated JSON Logs");
            Console.WriteLine("----------------------------");

            MethodInfo[] methods =
                targetClass.GetMethods(BindingFlags.Public |
                                        BindingFlags.Instance |
                                        BindingFlags.DeclaredOnly);

            foreach (MethodInfo method in methods)
            {
                object[] auditAttr =
                    method.GetCustomAttributes(typeof(AuditTrailAttribute), false);

                if (auditAttr.Length == 0)
                {
                    continue;
                }

                AuditTrailAttribute audit =
                    (AuditTrailAttribute)auditAttr[0];

                string jsonLog =
                    "{\n" +
                    "  \"eventName\" : \"" + method.Name + "\",\n" +
                    "  \"actionType\" : \"" + audit.ActionType + "\",\n" +
                    "  \"performedBy\" : \"" + audit.PerformedBy + "\",\n" +
                    "  \"timestamp\" : \"" + DateTime.Now + "\"\n" +
                    "}";

                Console.WriteLine(jsonLog);
                Console.WriteLine();
            }
        }
    }

}
