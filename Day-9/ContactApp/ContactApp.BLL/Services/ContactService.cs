using ContactApp.BLL.Interfaces;
using ContactApp.Entities;

namespace ContactApp.BLL.Services;

public class ContactService : IContactService
{
    private readonly IContactRepository repository;

    public ContactService(IContactRepository repository)
    {
        this.repository = repository;
    }

    // GET ALL CONTACTS
    public List<Contact> GetAllContacts()
    {
        return repository.GetAll();
    }

    // GET CONTACT BY ID
    public Contact? GetContactById(int id)
    {
        return repository.GetById(id);
    }

    // ADD CONTACT
    public Contact AddContact(Contact contact)
    {
        return repository.Add(contact);
    }

    // UPDATE CONTACT
    public bool UpdateContact(int id, Contact contact)
    {
        return repository.Update(id, contact);
    }

    // DELETE CONTACT
    public bool DeleteContact(int id)
    {
        return repository.Delete(id);
    }
}