using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzDSA.Scenario_based.AddressBookSystem
{
    internal interface IContactable
    {

        void AddContact(AddressBook addressBook, Contact contact);
        void EditContact(AddressBook addressBook, Contact contact, string firstName, string lastName, string address, string city, string state, string zip, string phoneNumber, string eMail);
        Contact ShowContact(AddressBook addressbook, String searchName);
        void DeleteContact(AddressBook addressBook, Contact contact);

        void SortContacts(AddressBook addressBook);
    }
}
