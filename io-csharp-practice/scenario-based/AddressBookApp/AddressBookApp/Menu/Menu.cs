using System;
using AddressBookApp.Models;
using AddressBookApp.Services;
using AddressBookApp.Exceptions;
public class Menu
    {
        private readonly AddressBookService _service;

        public Menu()
        {
            _service = new AddressBookService();
        }

        public void ShowMenu()
        {
            while (true)
            {
                PrintMenuOptions();
                Console.Write("Enter your choice: ");

                try
                {
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1: CreateAddressBook(); break;
                        case 2: AddContact(); break;
                        case 3: EditContact(); break;
                        case 4: DeleteContact(); break;
                        case 5: DisplayContacts(); break;
                        case 6: SearchByCity(); break;
                        case 7: SearchByState(); break;
                        case 8: _service.ViewPersonsByCity(); break;
                        case 9: _service.ViewPersonsByState(); break;
                        case 10: _service.CountByCity(); break;
                        case 11: _service.CountByState(); break;
                        case 12: SortContactsByName(); break;
                        case 13: _service.WriteToFile(); break;
                        case 14: _service.WriteToCsv(); break;
                        case 15:_service.ReadFromCsv(); break;
                        case 16:_service.ReadFromFile(); break;
                        case 17:_service.WriteToJson(); break;
                        case 18:_service.ReadFromJson(); break;
                        case 19: 
                        Console.WriteLine("Exiting...");
                        return;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid numeric choice.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        private void PrintMenuOptions()
        {
            Console.WriteLine("\n========= ADDRESS BOOK MENU =========");
            Console.WriteLine("1. Create Address Book    8. View Persons By City");
            Console.WriteLine("2. Add Contact            9. View Persons By State");
            Console.WriteLine("3. Edit Contact           10. Count by City");
            Console.WriteLine("4. Delete Contact         11. Count by State");
            Console.WriteLine("5. Display Contacts       12. Sort Contacts by Name");
            Console.WriteLine("6. Search by City         13. Save to File (TXT)");
            Console.WriteLine("7. Search by State        14. Save to CSV ");
            Console.WriteLine("15. Load from CSV         16. Load From File");
            Console.WriteLine("17. Save to JSON          18. Load from JSON");
            Console.WriteLine("19. Exit");
            Console.WriteLine("====================================");
        }

        private void CreateAddressBook()
        {
            Console.Write("Enter Address Book Name: ");
            string name = Console.ReadLine();
            try { _service.CreateAddressBook(name); }
            catch (ArgumentException ex) { Console.WriteLine(ex.Message); }
        }

        private void AddContact()
        {
            Console.Write("Enter Address Book Name: ");
            string bookName = Console.ReadLine();
            Contact<int> contact = ReadContactDetails();
            _service.AddContact(bookName, contact);
        }

        private void EditContact()
        {
            Console.Write("Enter Address Book Name: ");
            string bookName = Console.ReadLine();
            Console.Write("Enter Contact ID to Edit: ");
            int id = int.Parse(Console.ReadLine());
            Contact<int> updatedContact = ReadContactDetails(id);
            _service.EditContact(bookName, id, updatedContact);
        }

        private void DeleteContact()
        {
            Console.Write("Enter Address Book Name: ");
            string bookName = Console.ReadLine();
            Console.Write("Enter Contact ID to Delete: ");
            int id = int.Parse(Console.ReadLine());
            _service.DeleteContact(bookName, id);
        }

        private void DisplayContacts()
        {
            Console.Write("Enter Address Book Name: ");
            string bookName = Console.ReadLine();
            _service.DisplayContacts(bookName);
        }

        private void SearchByCity()
        {
            Console.Write("Enter City: ");
            _service.SearchByCity(Console.ReadLine());
        }

        private void SearchByState()
        {
            Console.Write("Enter State: ");
            _service.SearchByState(Console.ReadLine());
        }

        private void SortContactsByName()
        {
            Console.Write("Enter Address Book Name: ");
            _service.SortContactsByName(Console.ReadLine());
        }

       private Contact<int> ReadContactDetails(int? fixedId = null)
{
    int id;

    if (fixedId.HasValue)
    {
        id = fixedId.Value;
    }
    else
    {
        Console.Write("Enter ID: ");
        id = int.Parse(Console.ReadLine());
    }

    Console.Write("First Name: ");
    string firstName = Console.ReadLine();

    Console.Write("Last Name: ");
    string lastName = Console.ReadLine();

    Console.Write("Address: ");
    string address = Console.ReadLine();

    Console.Write("City: ");
    string city = Console.ReadLine();

    Console.Write("State: ");
    string state = Console.ReadLine();

    Console.Write("Zip: ");
    string zip = Console.ReadLine();

    Console.Write("Phone Number: ");
    string phone = Console.ReadLine();

    Console.Write("Email: ");
    string email = Console.ReadLine();

    return new Contact<int>(id, firstName, lastName, address, city, state, zip, phone, email);
}

    }