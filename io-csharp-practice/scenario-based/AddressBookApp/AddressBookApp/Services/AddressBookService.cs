
using AddressBookApp.Models;
using AddressBookApp.Exceptions;

namespace AddressBookApp.Services
{
    public class AddressBookService
    {
        // Multiple AddressBooks stored using Dictionary
        private readonly Dictionary<string, AddressBookModel<int>> addressBooks;

        public AddressBookService()
        {
            addressBooks = new Dictionary<string, AddressBookModel<int>>(StringComparer.OrdinalIgnoreCase);
        }

        // 1. Create Address Book
        public void CreateAddressBook(string name)
        {
            if (addressBooks.ContainsKey(name))
                throw new ArgumentException("Address Book with this name already exists.");

            addressBooks[name] = new AddressBookModel<int>(name);
            Console.WriteLine($"Address Book '{name}' created successfully.");
        }

        // Get AddressBook by Name
        private AddressBookModel<int> GetAddressBook(string name)
        {
            if (!addressBooks.ContainsKey(name))
                throw new ArgumentException("Address Book does not exist. Create it first.");

            return addressBooks[name];
        }

        // 2. Add Contact
        public void AddContact(string bookName, Contact<int> contact)
        {
            var book = GetAddressBook(bookName);

            if (book.Contacts.Any(c => c.Id == contact.Id))
                throw new ArgumentException("Contact with same ID already exists.");

            book.Contacts.Add(contact);
            Console.WriteLine("Contact added successfully.");
        }

        // 3. Edit Contact
        public void EditContact(string bookName, int id, Contact<int> updatedContact)
        {
            var book = GetAddressBook(bookName);
            var existing = book.Contacts.FirstOrDefault(c => c.Id == id);

            if (existing == null)
                throw new ContactNotFoundException("Contact not found.");

            existing.FirstName = updatedContact.FirstName;
            existing.LastName = updatedContact.LastName;
            existing.Address = updatedContact.Address;
            existing.City = updatedContact.City;
            existing.State = updatedContact.State;
            existing.Zip = updatedContact.Zip;
            existing.PhoneNumber = updatedContact.PhoneNumber;
            existing.Email = updatedContact.Email;

            Console.WriteLine("Contact updated successfully.");
        }

        // 4. Delete Contact
        public void DeleteContact(string bookName, int id)
        {
            var book = GetAddressBook(bookName);
            var contact = book.Contacts.FirstOrDefault(c => c.Id == id);

            if (contact == null)
                throw new ContactNotFoundException("Contact not found.");

            book.Contacts.Remove(contact);
            Console.WriteLine("Contact deleted successfully.");
        }

        // 5. Display Contacts
        public void DisplayContacts(string bookName)
        {
            var book = GetAddressBook(bookName);

            if (book.Contacts.Count == 0)
            {
                Console.WriteLine("No contacts found.");
                return;
            }

            foreach (var contact in book.Contacts)
                contact.Display();
        }

        // 6. Search by City
        public void SearchByCity(string city)
        {
            var result = addressBooks.Values
                .SelectMany(b => b.Contacts)
                .Where(c => c.City.Equals(city, StringComparison.OrdinalIgnoreCase))
                .ToList();

            DisplaySearchResult(result, $"Contacts in City: {city}");
        }

        // 7. Search by State
        public void SearchByState(string state)
        {
            var result = addressBooks.Values
                .SelectMany(b => b.Contacts)
                .Where(c => c.State.Equals(state, StringComparison.OrdinalIgnoreCase))
                .ToList();

            DisplaySearchResult(result, $"Contacts in State: {state}");
        }

        // 8. View Persons By City
        public void ViewPersonsByCity()
        {
            var grouped = addressBooks.Values
                .SelectMany(b => b.Contacts)
                .GroupBy(c => c.City);

            foreach (var group in grouped)
            {
                Console.WriteLine($"\nCity: {group.Key}");
                foreach (var person in group)
                    person.Display();
            }
        }

        // 9. View Persons By State
        public void ViewPersonsByState()
        {
            var grouped = addressBooks.Values
                .SelectMany(b => b.Contacts)
                .GroupBy(c => c.State);

            foreach (var group in grouped)
            {
                Console.WriteLine($"\nState: {group.Key}");
                foreach (var person in group)
                    person.Display();
            }
        }

        // 10. Count by City
        public void CountByCity()
        {
            var count = addressBooks.Values
                .SelectMany(b => b.Contacts)
                .GroupBy(c => c.City)
                .Select(g => new { City = g.Key, Total = g.Count() });

            Console.WriteLine("\nCount By City:");
            foreach (var item in count)
                Console.WriteLine($"{item.City} : {item.Total}");
        }

        // 11. Count by State
        public void CountByState()
        {
            var count = addressBooks.Values
                .SelectMany(b => b.Contacts)
                .GroupBy(c => c.State)
                .Select(g => new { State = g.Key, Total = g.Count() });

            Console.WriteLine("\nCount By State:");
            foreach (var item in count)
                Console.WriteLine($"{item.State} : {item.Total}");
        }

        // 12. Sort Contacts by Name
        public void SortContactsByName(string bookName)
        {
            var book = GetAddressBook(bookName);

            var sorted = book.Contacts
                .OrderBy(c => c.FirstName)
                .ThenBy(c => c.LastName)
                .ToList();

            Console.WriteLine("Contacts sorted by name:");
            foreach (var contact in sorted)
                contact.Display();
        }

        // Helper Method
        private void DisplaySearchResult(List<Contact<int>> contacts, string header)
        {
            Console.WriteLine($"\n{header}");

            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts found.");
                return;
            }

            foreach (var contact in contacts)
                contact.Display();
        }
    
    private string filePath = "AddressBookData.txt";

// UC 13: Write Address Book Data to File
public void WriteToFile()
{
    try
    {
        using (StreamWriter sw = new StreamWriter(filePath))
        {
            foreach (var book in addressBooks.Values)
            {
                sw.WriteLine($"--- Address Book: {book.AddressBookName} ---");
                foreach (var contact in book.Contacts)
                {
                    // Writing contact data in a comma-separated format for easy parsing
                    sw.WriteLine($"{contact.Id},{contact.FirstName},{contact.LastName},{contact.Address},{contact.City},{contact.State},{contact.Zip},{contact.PhoneNumber},{contact.Email}");
                }
            }
        }
        Console.WriteLine("Data successfully saved to file.");
    }
    catch (IOException ex)
    {
        Console.WriteLine($"An error occurred while writing to the file: {ex.Message}");
    }
}

// UC 13: Read Address Book Data from File
public void ReadFromFile()
{
    if (!File.Exists(filePath))
    {
        Console.WriteLine("No existing data file found.");
        return;
    }

    try
    {
        string[] lines = File.ReadAllLines(filePath);
        string currentBookName = "";

        foreach (string line in lines)
        {
            if (line.StartsWith("--- Address Book:"))
            {
                // Extracting book name
                currentBookName = line.Replace("--- Address Book: ", "").Replace(" ---", "").Trim();
                
                // Create book if it doesn't exist in memory yet
                if (!addressBooks.ContainsKey(currentBookName))
                {
                    addressBooks[currentBookName] = new AddressBookModel<int>(currentBookName);
                }
            }
            else if (!string.IsNullOrWhiteSpace(line))
            {
                string[] data = line.Split(',');
                if (data.Length == 9)
                {
                    int id = int.Parse(data[0]);
                    var book = addressBooks[currentBookName];

                    // OPTION 2 LOGIC: Only add if the ID is not already present
                    if (!book.Contacts.Any(c => c.Id == id))
                    {
                        var contact = new Contact<int>(
                            id, data[1], data[2], data[3], 
                            data[4], data[5], data[6], data[7], data[8]
                        );
                        book.Contacts.Add(contact);
                    }
                    else
                    {
                        Console.WriteLine($"Skipping duplicate Contact ID: {id} in '{currentBookName}'.");
                    }
                }
            }
        }
        Console.WriteLine("Data synchronization from file complete.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
    }
}
    }
}
