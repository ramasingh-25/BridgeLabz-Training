using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzDSA.Scenario_based.AddressBookSystem
{
    using System;

    internal class AddressBook
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book System");

            Contact contact = new Contact();

            Console.Write("Enter First Name: ");
            contact.FirstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            contact.LastName = Console.ReadLine();

            Console.Write("Enter Address: ");
            contact.Address = Console.ReadLine();

            Console.Write("Enter City: ");
            contact.City = Console.ReadLine();

            Console.Write("Enter State: ");
            contact.State = Console.ReadLine();

            Console.Write("Enter Zip: ");
            contact.Zip = Console.ReadLine();

            Console.Write("Enter Phone Number: ");
            contact.PhoneNumber = Console.ReadLine();

            Console.Write("Enter Email: ");
            contact.Email = Console.ReadLine();

            Console.WriteLine("\n--- Contact Details ---");
            contact.ShowContact();
            Console.Write("\nDo you want to edit contact? (yes/no): ");
            string choice = Console.ReadLine();


            //uc2 -Edit Contact


            if (choice.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                contact.EditContact();
                Console.WriteLine("\n--- Updated Contact ---");
                contact.ShowContact();
            }
        }
    }
}