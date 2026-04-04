using System.Collections.Generic;

namespace AddressBookApp.Models
{
    // Generic Address Book Model
    // Each AddressBook contains a list of contacts
    public class AddressBookModel<T>
    {
        public string AddressBookName { get; set; }
        public List<Contact<T>> Contacts { get; set; }

        public AddressBookModel(string addressBookName)
        {
            AddressBookName = addressBookName;
            Contacts = new List<Contact<T>>();
        }
    }
}
