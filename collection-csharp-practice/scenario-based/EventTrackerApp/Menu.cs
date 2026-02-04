using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabz.Collections.Senario.EventTrackerApp
{

    class Menu
    {
        public void Start()
        {
            int choice = 0;
            IAuditScanner scanner = new AuditScannerUtil();

            while (choice != 2)
            {
                Console.WriteLine("=================================");
                Console.WriteLine(" EventTracker - Auto Audit System ");
                Console.WriteLine("=================================");
                Console.WriteLine("1. Generate Audit JSON Logs");
                Console.WriteLine("2. Exit");
                Console.Write("Enter choice : ");

                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }

                if (choice == 1)
                {
                    scanner.GenerateAuditLogs(typeof(UserActionController));
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Program exited");
                }
                else
                {
                    Console.WriteLine("Wrong choice");
                }
            }
        }
    }

}
