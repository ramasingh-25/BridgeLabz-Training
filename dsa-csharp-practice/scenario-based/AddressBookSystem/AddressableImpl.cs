using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzDSA.Scenario_based.AddressBookSystem
{
    public class AddressableImpl : IAddressable
    {
        int maxLen = 1000;
        public AddressBook FindBook(AddressBook[] books, String bookName)
        {
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i] != null)
                {
                    if (books[i].bookName == bookName)
                    {
                        return books[i];
                    }
                }

            }
            return null;
        }

        public Contact[] FindByCity(AddressBook[] books, String searchCity)
        {
            Contact[] result = new Contact[1000];
            int count = 0;
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i] != null)
                {
                    for (int j = 0; j < maxLen; j++)
                    {
                        if (books[i].contacts[j] != null)
                        {
                            if (books[i].contacts[j].city == searchCity)
                            {
                                result[count] = books[i].contacts[j];
                                count++;
                            }
                        }
                    }
                }
            }

            return result;
        }

        public Contact[] FindByState(AddressBook[] books, String searchState)
        {
            Contact[] result = new Contact[1000];
            int count = 0;
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i] != null)
                {
                    for (int j = 0; j < maxLen; j++)
                    {
                        if (books[i].contacts[j] != null)
                        {
                            if (books[i].contacts[j].state == searchState)
                            {
                                result[count] = books[i].contacts[j];
                                count++;
                            }
                        }
                    }
                }
            }

            return result;
        }

        public Contact FindByCityAndName(AddressBook[] books, String searchCity, String searchName)
        {
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i] != null)
                {
                    for (int j = 0; j < maxLen; j++)
                    {
                        if (books[i].contacts[j] != null)
                        {
                            if (books[i].contacts[j].city == searchCity && books[i].contacts[j].firstName + " " + books[i].contacts[j].lastName == searchName)
                            {
                                return books[i].contacts[j];
                            }
                        }
                    }
                }
            }
            return null;
        }

        public Contact FindByStateAndName(AddressBook[] books, String searchState, String searchName)
        {
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i] != null)
                {
                    for (int j = 0; j < maxLen; j++)
                    {
                        if (books[i].contacts[j] != null)
                        {
                            if (books[i].contacts[j].state == searchState && books[i].contacts[j].firstName + " " + books[i].contacts[j].lastName == searchName)
                            {
                                return books[i].contacts[j];
                            }
                        }
                    }
                }
            }
            return null;
        }

        public int CountByCity(AddressBook[] books, String searchCity)
        {

            int count = 0;
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i] != null)
                {
                    for (int j = 0; j < maxLen; j++)
                    {
                        if (books[i].contacts[j] != null)
                        {
                            if (books[i].contacts[j].city == searchCity)
                            {
                                count++;
                            }
                        }
                    }
                }
            }

            return count;
        }

        public int CountByState(AddressBook[] books, String searchState)
        {

            int count = 0;
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i] != null)
                {
                    for (int j = 0; j < maxLen; j++)
                    {
                        if (books[i].contacts[j] != null)
                        {
                            if (books[i].contacts[j].state == searchState)
                            {
                                count++;
                            }
                        }
                    }
                }
            }

            return count;
        }

    }
}
