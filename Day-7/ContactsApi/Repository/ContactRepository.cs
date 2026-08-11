using ContactApp.Model;

namespace ContactApp.Repository;

public class ContactRepository
{
    private readonly List<Contact> contacts = new()
    {
        new Contact
        {
            Id = 1,
            Name = "Rama Singh",
            Email = "rama@gmail.com",
            Phone = "9876543210"
        },

        new Contact
        {
            Id = 2,
            Name = "Amit Kumar",
            Email = "amit@gmail.com",
            Phone = "9876543211"
        }
    };


    public List<Contact> GetAll()
    {
        return contacts;
    }


    public Contact? GetById(int id)
    {
        return contacts.FirstOrDefault(c => c.Id == id);
    }


    public Contact Add(Contact contact)
    {
        contact.Id = contacts.Count == 0
            ? 1
            : contacts.Max(c => c.Id) + 1;

        contacts.Add(contact);

        return contact;
    }


    public bool Update(int id, Contact updatedContact)
    {
        Contact? existingContact = GetById(id);

        if (existingContact == null)
        {
            return false;
        }

        existingContact.Name = updatedContact.Name;
        existingContact.Email = updatedContact.Email;
        existingContact.Phone = updatedContact.Phone;

        return true;
    }


    public bool Delete(int id)
    {
        Contact? contact = GetById(id);

        if (contact == null)
        {
            return false;
        }

        contacts.Remove(contact);

        return true;
    }
}