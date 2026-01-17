using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzDSA.Scenario_based.AddressBookSystem
{
    using System;

    internal class AddressBook : IContact
    {
        private Contact contact = new Contact();

        private Contact[] contacts = new Contact[3]; // fixed size array
        private int count = 0;


        // UC-8: Add multiple contacts using ARRAY
        public void AddContact()
        {
            if (count == contacts.Length)
            {
                Console.WriteLine("❌ Address Book is Full");
                return;
            }

            Contact contact = new Contact();

            Console.Write("Enter First Name: ");
            contact.FirstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            contact.LastName = Console.ReadLine();

            Console.Write("Enter City: ");
            contact.City = Console.ReadLine();

            Console.Write("Enter State: ");
            contact.State = Console.ReadLine();

            Console.Write("Enter Phone Number: ");
            contact.PhoneNumber = Console.ReadLine();

            Console.Write("Enter Email: ");
            contact.Email = Console.ReadLine();

            contacts[count] = contact;
            count++;

            Console.WriteLine("✅ Contact added successfully");
        }




        //public void EditContactByName()
        //{
        //    if (string.IsNullOrEmpty(contact.FirstName))
        //    {
        //        Console.WriteLine("No contact to edit");
        //        return;
        //    }

        //    Console.Write("Enter First Name to edit: ");
        //    string name = Console.ReadLine();

        //    if (contact.FirstName.Equals(name, StringComparison.OrdinalIgnoreCase))
        //    {
        //        Console.WriteLine("Enter new details:");
        //        DeleteContact();
        //        AddContact();
        //        Console.WriteLine(" Contact updated successfully");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Name not found");
        //    }
        //}
        // UC-9: View persons by City or State
        public void ViewByCityOrState()
        {
            Console.Write("Enter City or State to view persons: ");
            string input = Console.ReadLine();

            bool found = false;

            for (int i = 0; i < count; i++)
            {
                if (contacts[i].City.Equals(input, StringComparison.OrdinalIgnoreCase) ||
                    contacts[i].State.Equals(input, StringComparison.OrdinalIgnoreCase))
                {
                    contacts[i].ShowContact();
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("❌ No persons found for given City/State");
            }
        }
        public void DeleteContact()
        {
            contact = new Contact();
            Console.WriteLine(" Contact deleted successfully");
        }

        // UC-10: Count persons by City or State
        public void CountByCityOrState()
        {
            Console.Write("Enter City or State to count persons: ");
            string input = Console.ReadLine();

            int total = 0;

            for (int i = 0; i < count; i++)
            {
                if (contacts[i].City.Equals(input, StringComparison.OrdinalIgnoreCase) ||
                    contacts[i].State.Equals(input, StringComparison.OrdinalIgnoreCase))
                {
                    total++;
                }
            }

            Console.WriteLine("Total persons in " + input + " = " + total);
        }


        //public void SearchByCityOrState()
        //{
        //    if (string.IsNullOrEmpty(contact.FirstName))
        //    {
        //        Console.WriteLine("No contact available to search");
        //        return;
        //    }

        //    Console.Write("Enter City or State to search: ");
        //    string searchValue = Console.ReadLine();

        //    if (contact.City.Equals(searchValue, StringComparison.OrdinalIgnoreCase) ||
        //        contact.State.Equals(searchValue, StringComparison.OrdinalIgnoreCase))
        //    {
        //        Console.WriteLine("✅ Contact Found:");
        //        contact.ShowContact();
        //    }
        //    else
        //    {
        //        Console.WriteLine("❌ No contact found for given City/State");
        //    }
        //}

        public void DisplayContact()
        {
            contact.ShowContact();
        }
    }
}