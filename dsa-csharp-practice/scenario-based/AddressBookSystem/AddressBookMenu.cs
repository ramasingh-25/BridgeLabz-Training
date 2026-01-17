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
                Console.WriteLine("2. Edit Contact by Name (UC-5)");
                Console.WriteLine("3. Delete Contact");
                Console.WriteLine("4. Display Contact");
                Console.WriteLine("5. Exit");
                Console.Write("Enter choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        addressBook.AddContact();
                        break;

                    case 2:
                        addressBook.EditContactByName();
                        break;

                    case 3:
                        addressBook.DeleteContact();
                        break;

                    case 4:
                        addressBook.DisplayContact();
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
