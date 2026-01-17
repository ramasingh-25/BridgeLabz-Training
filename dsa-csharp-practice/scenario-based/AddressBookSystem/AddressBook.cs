using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzDSA.Scenario_based.AddressBookSystem
{
    using System;

    internal class AddressBook : IContact
    {
        private Contact contact = new Contact();

        // 🟢 UC-6: Prevent duplicate contact
        public void AddContact()
        {
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();

            if (!string.IsNullOrEmpty(contact.FirstName) &&
                contact.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("❌ Duplicate contact not allowed");
                return;
            }

            contact.FirstName = firstName;

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

        // UC-5
        public void EditContactByName()
        {
            if (string.IsNullOrEmpty(contact.FirstName))
            {
                Console.WriteLine("No contact to edit");
                return;
            }

            Console.Write("Enter First Name to edit: ");
            string name = Console.ReadLine();

            if (contact.FirstName.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Enter new details:");
                DeleteContact();
                AddContact();
                Console.WriteLine("✅ Contact updated successfully");
            }
            else
            {
                Console.WriteLine("❌ Name not found");
            }
        }

        // UC-3
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