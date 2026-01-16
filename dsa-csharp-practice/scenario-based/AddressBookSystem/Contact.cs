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

        public void ShowContact()
        {
            Console.WriteLine("First Name - " + FirstName);
            Console.WriteLine("Last Name - " + LastName);
            Console.WriteLine("Address - " + Address);
            Console.WriteLine("City - " + City);
            Console.WriteLine("State - " + State);
            Console.WriteLine("Zip - " + Zip);
            Console.WriteLine("Phone Number - " + PhoneNumber);
            Console.WriteLine("Email - " + Email);
        }
        // UC-2: Edit Contact
        public void EditContact()
        {
            Console.WriteLine("\nEnter New Details");

            Console.Write("First Name: ");
            FirstName = Console.ReadLine();

            Console.Write("Last Name: ");
            LastName = Console.ReadLine();

            Console.Write("Address: ");
            Address = Console.ReadLine();

            Console.Write("City: ");
            City = Console.ReadLine();

            Console.Write("State: ");
            State = Console.ReadLine();

            Console.Write("Zip: ");
            Zip = Console.ReadLine();

            Console.Write("Phone Number: ");
            PhoneNumber = Console.ReadLine();

            Console.Write("Email: ");
            Email = Console.ReadLine();

            Console.WriteLine("✅ Contact updated successfully");
        }

       
    }

}
