using System;

namespace AddressBookApp.Exceptions
{
    // Custom exception when a contact is not found
    public class ContactNotFoundException : Exception
    {
        public ContactNotFoundException(string message) : base(message)
        {
        }
    }
}
