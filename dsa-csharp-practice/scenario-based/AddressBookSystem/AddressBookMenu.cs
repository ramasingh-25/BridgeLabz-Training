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
                Console.WriteLine("--- MENU ---");
                Console.WriteLine("1. Add Contact");
                //Console.WriteLine("2. Edit Contact by Name");
                //Console.WriteLine("3. Delete Contact");
                //Console.WriteLine("4. Search by City/State");
                Console.WriteLine("5. Display Contact");
                Console.WriteLine("6. Exit");
                Console.Write("Enter choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        addressBook.AddContact();
                        break;

                    //case 2:
                    //    addressBook.EditContactByName();
                    //    break;

                    //case 3:
                    //    addressBook.DeleteContact();
                    //    break;

                    case 4:
                        addressBook.DisplayContact();
                        break;

                    //case 5:
                    //    addressBook.SearchByCityOrState();
                    //    break;

                    case 6:
                        exit = true;
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

    }
}
