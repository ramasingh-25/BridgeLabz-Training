using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzDSA.Scenario_based.AddressBookSystem
{
    internal class AddressBookMenu
    {
        
        private AddressBook manager = new AddressBook();
        private IContact addressBook;

        public AddressBookMenu()
        {
            addressBook = new AddressBook();
        }

        public void ShowMenu()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n--- MENU ---");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Edit Contact");
                Console.WriteLine("3. Delete Contact");
                Console.WriteLine("4. Display Contact");
                Console.WriteLine("5. Exit");
                Console.Write("Enter choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        manager.AddContact();
                        break;

                    case 2:
                        manager.EditContact();
                        break;

                    case 3:
                        manager.DeleteContact();
                        break;

                    case 4:
                        manager.DisplayContact();
                        break;

                    case 5:
                        exit = true;
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("❌ Invalid choice");
                        break;
                }
            }
        }
    }

}

