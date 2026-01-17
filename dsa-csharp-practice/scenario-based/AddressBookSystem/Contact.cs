using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzDSA.Scenario_based.AddressBookSystem
{

    internal class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        // UC-3: Delete Contact
        public void DeleteContact()
        {
            FirstName = "";
            LastName = "";
            Address = "";
            City = "";
            State = "";
            Zip = "";
            PhoneNumber = "";
            Email = "";

            Console.WriteLine("✅ Contact deleted successfully");
        }

        public void ShowContact()
        {
            if (string.IsNullOrEmpty(FirstName))
            {
                Console.WriteLine("No contact available");
                return;
            }

            Console.WriteLine("First Name - " + FirstName);
            Console.WriteLine("Last Name - " + LastName);
            Console.WriteLine("Address - " + Address);
            Console.WriteLine("City - " + City);
            Console.WriteLine("State - " + State);
            Console.WriteLine("Zip - " + Zip);
            Console.WriteLine("Phone Number - " + PhoneNumber);
            Console.WriteLine("Email - " + Email);
        }
    }
}