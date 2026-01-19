using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzDSA.Scenario_based.AddressBookSystem
{
    internal class AddressBookMain
    {

        static AddressBook[] bookShelf = new AddressBook[10];
        static IAddressable bookManager = new AddressableImpl();
        static IContactable contactManager = new ContactableImpl();

        public static void Main(String[] args)
        {
            Utility.SetupConsole();
            bool appRunning = true;

            while (appRunning)
            {
                Utility.PrintLogo();
                Utility.ShowBookMenu(); // Show Level 1 Menu
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": // CREATE NEW BOOK
                        string newName = Utility.GetInput("Enter New Book Name");
                        if (bookManager.FindBook(bookShelf, newName) != null)
                        {
                            Console.WriteLine("    [!] A book with this name already exists.");
                        }
                        else
                        {
                            AddNewBookToShelf(newName);
                        }
                        Utility.WaitForKey();
                        break;

                    case "2": // OPEN BOOK
                        string openName = Utility.GetInput("Enter Book Name to Open");
                        AddressBook selectedBook = bookManager.FindBook(bookShelf, openName);

                        if (selectedBook != null)
                        {
                            ManageBookContacts(selectedBook);
                        }
                        else
                        {
                            Console.WriteLine("    [!] Book not found.");
                            Utility.WaitForKey();
                        }
                        break;

                    case "3": // DELETE BOOK
                        string delName = Utility.GetInput("Enter Book Name to DELETE");
                        DeleteBookFromShelf(delName);
                        Utility.WaitForKey();
                        break;

                    case "4": // SEARCH ALL BY CITY (List)
                        string cityQuery = Utility.GetInput("Enter City to Search");
                        Contact[] cityResults = bookManager.FindByCity(bookShelf, cityQuery);
                        Utility.PrintSearchResults(cityResults);
                        Utility.WaitForKey();
                        break;

                    case "5": // SEARCH ALL BY STATE (List)
                        string stateQuery = Utility.GetInput("Enter State to Search");
                        Contact[] stateResults = bookManager.FindByState(bookShelf, stateQuery);
                        Utility.PrintSearchResults(stateResults);
                        Utility.WaitForKey();
                        break;

                    case "6": // FIND PERSON BY CITY (Single)
                        string citySearch = Utility.GetInput("Enter City");
                        string nameSearchCity = Utility.GetInput("Enter Person Name");

                        Contact resultByCity = bookManager.FindByCityAndName(bookShelf, citySearch, nameSearchCity);
                        Utility.PrintSingleResult(resultByCity);
                        Utility.WaitForKey();
                        break;

                    case "7": // FIND PERSON BY STATE (Single)
                        string stateSearch = Utility.GetInput("Enter State");
                        string nameSearchState = Utility.GetInput("Enter Person Name");

                        Contact resultByState = bookManager.FindByStateAndName(bookShelf, stateSearch, nameSearchState);
                        Utility.PrintSingleResult(resultByState);
                        Utility.WaitForKey();
                        break;

                    case "8": // COUNT BY CITY
                        string cityCountTarget = Utility.GetInput("Enter City to Count");
                        int cityCount = bookManager.CountByCity(bookShelf, cityCountTarget);
                        Utility.PrintCountResult("City", cityCountTarget, cityCount);
                        Utility.WaitForKey();
                        break;

                    case "9": // COUNT BY STATE
                        string stateCountTarget = Utility.GetInput("Enter State to Count");
                        int stateCount = bookManager.CountByState(bookShelf, stateCountTarget);
                        Utility.PrintCountResult("State", stateCountTarget, stateCount);
                        Utility.WaitForKey();
                        break;

                    case "10": // EXIT
                        appRunning = false;
                        break;

                    default:
                        Console.WriteLine("    Invalid Option.");
                        break;
                }
            }
        }

        // --- LEVEL 2: MANAGING CONTACTS INSIDE A BOOK ---
        private static void ManageBookContacts(AddressBook currentBook)
        {
            bool inBook = true;
            while (inBook)
            {
                Utility.ShowContactMenu(currentBook.bookName);
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": // ADD Contact
                        Contact newContact = Utility.CreateContactWithUI();
                        contactManager.AddContact(currentBook, newContact);
                        Utility.WaitForKey();
                        break;

                    case "2": // EDIT Contact
                        string searchEdit = Utility.GetInput("Enter Name to Edit");
                        Contact editTarget = contactManager.ShowContact(currentBook, searchEdit);
                        if (editTarget != null)
                        {
                            Contact updated = Utility.GetUpdatedContactDetails(editTarget);
                            contactManager.EditContact(currentBook, editTarget,
                                updated.firstName, updated.lastName, updated.address,
                                updated.city, updated.state, updated.zip,
                                updated.phoneNumber, updated.eMail);
                            Console.WriteLine("    [!] Contact Updated.");
                        }
                        else Console.WriteLine("    [!] Not Found.");
                        Utility.WaitForKey();
                        break;

                    case "3": // DELETE Contact
                        string searchDel = Utility.GetInput("Enter Name to Delete");
                        Contact delTarget = contactManager.ShowContact(currentBook, searchDel);
                        if (delTarget != null)
                        {
                            contactManager.DeleteContact(currentBook, delTarget);
                            Console.WriteLine("    [!] Contact Deleted.");
                        }
                        else Console.WriteLine("    [!] Not Found.");
                        Utility.WaitForKey();
                        break;

                    case "4": // SORT Contacts (New Feature)
                        contactManager.SortContacts(currentBook);
                        Console.WriteLine("    [!] Contacts Sorted Successfully.");
                        Console.WriteLine("    --- SORTED LIST ---");
                        foreach (var c in currentBook.contacts)
                        {
                            if (c != null) Console.WriteLine($"    - {c.firstName} {c.lastName}");
                        }
                        Utility.WaitForKey();
                        break;

                    case "5": // BACK
                        inBook = false;
                        break;
                }
            }
        }

        private static void AddNewBookToShelf(string name)
        {
            for (int i = 0; i < bookShelf.Length; i++)
            {
                if (bookShelf[i] == null)
                {
                    bookShelf[i] = new AddressBook(name);
                    Console.WriteLine($"    [!] Address Book '{name}' Created Successfully.");
                    return;
                }
            }
            Console.WriteLine("    [!] No space left for new books.");
        }

        private static void DeleteBookFromShelf(string name)
        {
            for (int i = 0; i < bookShelf.Length; i++)
            {
                if (bookShelf[i] != null && bookShelf[i].bookName == name)
                {
                    bookShelf[i] = null;
                    Console.WriteLine($"    [!] Address Book '{name}' Deleted.");
                    return;
                }
            }
            Console.WriteLine("    [!] Book not found.");
        }
    }
}

