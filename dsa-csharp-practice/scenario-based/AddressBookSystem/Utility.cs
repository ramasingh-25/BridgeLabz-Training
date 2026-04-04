using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzDSA.Scenario_based.AddressBookSystem
{
    public class Utility
    {
        private static string Version = "1.11";
        private static ConsoleColor ColorPrimary = ConsoleColor.Cyan;
        private static ConsoleColor ColorSecondary = ConsoleColor.Magenta;
        private static ConsoleColor ColorText = ConsoleColor.White;

        public static void SetupConsole()
        {
            Console.Title = $"Address Book System | Version {Version} | Dev";
            try { Console.SetWindowSize(90, 30); } catch { }
        }

        public static void PrintLogo()
        {
            Console.Clear();
          
            Console.WriteLine(" Address Book ");
          
            Console.WriteLine($" [Version {Version}]");
            Console.WriteLine("=======");
        
            Console.WriteLine();
        }

        // --- LEVEL 1: BOOK MANAGEMENT MENU ---
        public static void ShowBookMenu()
        {
            
            Console.WriteLine("    [1] CREATE New Address Book");
            Console.WriteLine("    [2] OPEN Existing Address Book");
            Console.WriteLine("    [3] DELETE Address Book");
            Console.WriteLine("    --------------------------------");
            Console.WriteLine("    [4] VIEW ALL by City");
            Console.WriteLine("    [5] VIEW ALL by State");
            Console.WriteLine("    [6] FIND Person by City");
            Console.WriteLine("    [7] FIND Person by State");
            Console.WriteLine("    [8] COUNT by City");
            Console.WriteLine("    [9] COUNT by State");
            Console.WriteLine("    --------------------------------");
            Console.WriteLine("    [10] EXIT Application");
            Console.WriteLine();
           
            Console.Write("    >> Select Option: ");
           
        }

        // --- LEVEL 2: CONTACT MANAGEMENT MENU ---
        public static void ShowContactMenu(string bookName)
        {
            PrintLogo();
            Console.WriteLine($"    CURRENT BOOK: [ {bookName} ]");
            Console.WriteLine("    ----------------------------------------------------------");
            Console.ForegroundColor = ColorText;
            Console.WriteLine("    [1] ADD New Contact");
            Console.WriteLine("    [2] EDIT Existing Contact");
            Console.WriteLine("    [3] DELETE Contact");
            Console.WriteLine("    [4] SORT Contacts by Name"); // New Option
            Console.WriteLine("    [5] BACK to Main Menu");
            Console.WriteLine();
            Console.ForegroundColor = ColorPrimary;
            Console.Write("    >> Select Option: ");
            Console.ResetColor();
        }

        public static Contact CreateContactWithUI()
        {
            PrintLogo();
            Console.ForegroundColor = ColorSecondary;
            Console.WriteLine("    --- ENTER CONTACT DETAILS ---");
            Console.WriteLine();
            string fName = InputField("First Name");
            string lName = InputField("Last Name");
            string addr = InputField("Address");
            string city = InputField("City");
            string state = InputField("State");
            string zip = InputField("Zip Code");
            string phone = InputField("Phone No");
            string email = InputField("Email");

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("    [!] Capturing data...");
            System.Threading.Thread.Sleep(500);
            Console.ResetColor();
            return new Contact(fName, lName, addr, city, state, zip, phone, email);
        }

        public static string GetInput(string prompt)
        {
            Console.WriteLine();
            Console.ForegroundColor = ColorSecondary;
            Console.Write($"    >> {prompt}: ");
            Console.ResetColor();
            return Console.ReadLine();
        }

        public static Contact GetUpdatedContactDetails(Contact existing)
        {
            PrintLogo();
            Console.ForegroundColor = ColorSecondary;
            Console.WriteLine($"    --- EDITING: {existing.firstName} {existing.lastName} ---");
            Console.WriteLine("    (Press ENTER to keep current value)");
            Console.WriteLine();

            string fName = InputEditField("First Name", existing.firstName);
            string lName = InputEditField("Last Name", existing.lastName);
            string addr = InputEditField("Address", existing.address);
            string city = InputEditField("City", existing.city);
            string state = InputEditField("State", existing.state);
            string zip = InputEditField("Zip Code", existing.zip);
            string phone = InputEditField("Phone No", existing.phoneNumber);
            string email = InputEditField("Email", existing.eMail);

            return new Contact(fName, lName, addr, city, state, zip, phone, email);
        }

        public static void PrintCountResult(string label, string name, int count)
        {
            PrintLogo();
            Console.WriteLine("    --- COUNT RESULTS ---");
            Console.WriteLine();
            Console.ForegroundColor = ColorText;
            Console.WriteLine($"    Region Type:  {label}");
            Console.WriteLine($"    Region Name:  {name}");
            Console.WriteLine("    ---------------------------");
            Console.ForegroundColor = ColorPrimary;
            Console.WriteLine($"    TOTAL COUNT:  {count}");
            Console.ResetColor();
        }

        public static void PrintSearchResults(Contact[] results)
        {
            PrintLogo();
            Console.WriteLine("    --- SEARCH RESULTS ---");
            Console.WriteLine();

            bool foundAny = false;
            int count = 1;

            if (results != null)
            {
                foreach (Contact c in results)
                {
                    if (c != null)
                    {
                        Console.WriteLine($"    [{count++}] {c.firstName} {c.lastName} | Phone: {c.phoneNumber} | {c.city}, {c.state}");
                        foundAny = true;
                    }
                }
            }

            if (!foundAny)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("    [!] No contacts found matching that criteria.");
                Console.ResetColor();
            }
        }

        public static void PrintSingleResult(Contact c)
        {
            PrintLogo();
            Console.WriteLine("    --- SEARCH RESULT ---");
            Console.WriteLine();

            if (c != null)
            {
                Console.WriteLine($"    Name:    {c.firstName} {c.lastName}");
                Console.WriteLine($"    Phone:   {c.phoneNumber}");
                Console.WriteLine($"    Email:   {c.eMail}");
                Console.WriteLine($"    Address: {c.address}, {c.city}, {c.state} - {c.zip}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("    [!] Person not found.");
                Console.ResetColor();
            }
        }

        private static string InputField(string label)
        {
            Console.ForegroundColor = ColorPrimary;
            Console.Write($"    {label.PadRight(12)}: ");
            Console.ForegroundColor = ColorText;
            return Console.ReadLine();
        }

        private static string InputEditField(string label, string currentValue)
        {
            Console.ForegroundColor = ColorPrimary;
            Console.Write($"    {label.PadRight(12)} [{currentValue}]: ");
            Console.ForegroundColor = ColorText;
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) return currentValue;
            return input;
        }

        public static void WaitForKey()
        {
            Console.WriteLine();
            Console.WriteLine("    Press any key to continue...");
            Console.ReadKey();
        }
    }
}
