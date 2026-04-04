using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzDSA.Scenario_based.AddressBookSystem
{
    public class ContactableImpl : IContactable
    {
        int maxLen = 1000;
        public void AddContact(AddressBook addressBook, Contact contact)
        {

            for (int i = 0; i < maxLen; i++)
            {
                if (addressBook.contacts[i] != null)
                {
                    if (addressBook.contacts[i].firstName + " " + addressBook.contacts[i].lastName == contact.firstName + " " + contact.lastName)
                    {
                        Console.WriteLine("Contact with this name already exists!");
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (addressBook.contacts[i] == null)
                {
                    addressBook.contacts[i] = contact;
                    Console.WriteLine("Contact Added...");
                    break;
                }
                else if (i == maxLen - 1)
                {
                    Console.WriteLine("Contact List is Full, create another addressbook.");
                    break;
                }
                else
                {
                    continue;
                }
            }


        }

        public void EditContact(AddressBook addressBook, Contact contact, string firstName, string lastName, string address, string city, string state, string zip, string phoneNumber, string eMail)
        {
            for (int i = 0; i < maxLen; i++)
            {
                if (addressBook.contacts[i] == contact)
                {
                    addressBook.contacts[i].firstName = firstName;
                    addressBook.contacts[i].lastName = lastName;
                    addressBook.contacts[i].address = address;
                    addressBook.contacts[i].city = city;
                    addressBook.contacts[i].state = state;
                    addressBook.contacts[i].zip = zip;
                    addressBook.contacts[i].phoneNumber = phoneNumber;
                    addressBook.contacts[i].eMail = eMail;
                    break;
                }
            }
        }

        public Contact ShowContact(AddressBook addressBook, String searchName)
        {
            for (int i = 0; i < maxLen; i++)
            {
                if (addressBook.contacts[i] != null)
                {
                    if (addressBook.contacts[i].firstName + " " + addressBook.contacts[i].lastName == searchName)
                    {
                        return addressBook.contacts[i];
                        break;
                    }
                }

            }
            return null;
        }

        public void DeleteContact(AddressBook addressBook, Contact contact)
        {
            for (int i = 0; i < maxLen; i++)
            {
                if (addressBook.contacts[i] == contact)
                {
                    addressBook.contacts[i] = null;
                    break;
                }

            }
        }

        public void SortContacts(AddressBook addressBook)
        {
            for (int i = 0; i < maxLen - 1; i++)
            {
                bool swapped = false;
                for (int j = 0; j < maxLen - i - 1; j++)
                {
                    Contact c1 = addressBook.contacts[j];
                    Contact c2 = addressBook.contacts[j + 1];

                    if (c1 == null && c2 != null)
                    {
                        addressBook.contacts[j] = c2;
                        addressBook.contacts[j + 1] = null;
                        swapped = true;
                    }
                    else if (c1 != null && c2 != null)
                    {
                        string name1 = c1.firstName + " " + c1.lastName;
                        string name2 = c2.firstName + " " + c2.lastName;

                        if (string.Compare(name1, name2, StringComparison.OrdinalIgnoreCase) > 0)
                        {
                            addressBook.contacts[j] = c2;
                            addressBook.contacts[j + 1] = c1;
                            swapped = true;
                        }
                    }
                }
                if (!swapped) break;
            }
        }
    }
}
