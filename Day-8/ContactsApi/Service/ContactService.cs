using ContactApp.Model;
using ContactApp.Repository;

namespace ContactApp.Service;

public class ContactService
{
    private readonly ContactRepository repository;

    public ContactService(ContactRepository repository)
    {
        this.repository = repository;
    }


    public List<Contact> GetAllContacts()
    {
        return repository.GetAll();
    }


    public Contact? GetContactById(int id)
    {
        return repository.GetById(id);
    }


    public Contact AddContact(Contact contact)
    {
        return repository.Add(contact);
    }


    public bool UpdateContact(int id, Contact contact)
    {
        return repository.Update(id, contact);
    }


    public bool DeleteContact(int id)
    {
        return repository.Delete(id);
    }
}