using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabz.Collections.Senario.HealthCheckProApp
{
    

    class Menu
    {
        public void Start()
        {
            int choice = 0;
            IApiValidator validator = new ApiScannerUtil();

            while (choice != 2)
            {
                Console.WriteLine("=================================");
                Console.WriteLine(" HealthCheckPro - API Validator ");
                Console.WriteLine("=================================");
                Console.WriteLine("1. Scan API & Generate Docs");
                Console.WriteLine("2. Exit");
                Console.Write("Enter your choice : ");

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
                    validator.ScanAndGenerateDocs(typeof(LabTestController));
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Program Closed");
                }
                else
                {
                    Console.WriteLine("Wrong choice, try again");
                }
            }
        }
    }


}
