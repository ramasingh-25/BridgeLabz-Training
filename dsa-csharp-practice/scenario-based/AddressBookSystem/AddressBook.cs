using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzDSA.Scenario_based.AddressBookSystem
{
    using System;

    internal class AddressBook: IContact
    {
        private Contact contact = new Contact();

        // UC-1 / UC-4: Add Contact
        public void AddContact()
        {
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

            Console.WriteLine("✅ Contact added successfully");
        }

        // UC-2: Edit Contact
        public void EditContact()
        {
            if (string.IsNullOrEmpty(contact.FirstName))
            {
                Console.WriteLine("No contact to edit");
                return;
            }

            Console.WriteLine("Enter new details:");
            AddContact();
            Console.WriteLine("✅ Contact updated successfully");
        }

        // UC-3: Delete Contact
        public void DeleteContact()
        {
            contact = new Contact();
            Console.WriteLine("✅ Contact deleted successfully");
        }

        public void DisplayContact()
        {
            contact.ShowContact();
        }
    }
}
