using ContactApp.BLL.Interfaces;
using ContactApp.DAL.Data;
using ContactApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactApp.DAL.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly ContactDbContext context;

    public ContactRepository(ContactDbContext context)
    {
        this.context = context;
    }

    // GET ALL
    public List<Contact> GetAll()
    {
        return context.Contacts
            .AsNoTracking()
            .ToList();
    }

    // GET BY ID
    public Contact? GetById(int id)
    {
        return context.Contacts
            .AsNoTracking()
            .FirstOrDefault(c => c.Id == id);
    }

    // ADD
    public Contact Add(Contact contact)
    {
        context.Contacts.Add(contact);

        context.SaveChanges();

        return contact;
    }

    // UPDATE
    public bool Update(int id, Contact contact)
    {
        var existingContact =
            context.Contacts.FirstOrDefault(c => c.Id == id);

        if (existingContact == null)
        {
            return false;
        }

        existingContact.Name = contact.Name;
        existingContact.Email = contact.Email;
        existingContact.Phone = contact.Phone;

        context.SaveChanges();

        return true;
    }

    // DELETE
    public bool Delete(int id)
    {
        var contact =
            context.Contacts.FirstOrDefault(c => c.Id == id);

        if (contact == null)
        {
            return false;
        }

        context.Contacts.Remove(contact);

        context.SaveChanges();

        return true;
    }
}