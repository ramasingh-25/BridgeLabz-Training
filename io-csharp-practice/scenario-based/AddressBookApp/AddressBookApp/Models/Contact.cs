using System;

namespace AddressBookApp.Models
{
    // Generic Contact Model
    public class Contact<T>
    {
        public T Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public Contact(T id, string firstName, string lastName, string address,
                       string city, string state, string zip,
                       string phoneNumber, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            City = city;
            State = state;
            Zip = zip;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public void Display()
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"ID         : {Id}");
            Console.WriteLine($"Name       : {FirstName} {LastName}");
            Console.WriteLine($"Address    : {Address}");
            Console.WriteLine($"City       : {City}");
            Console.WriteLine($"State      : {State}");
            Console.WriteLine($"Zip        : {Zip}");
            Console.WriteLine($"Phone No.  : {PhoneNumber}");
            Console.WriteLine($"Email      : {Email}");
            Console.WriteLine("--------------------------------------------------");
        }
    }
}
