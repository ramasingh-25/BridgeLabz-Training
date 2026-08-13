using ContactApp.Entities;

namespace ContactApp.DAL.Interfaces;

public interface IContactRepository
{
    List<Contact> GetAll();

    Contact? GetById(int id);

    Contact Add(Contact contact);

    bool Update(int id, Contact contact);

    bool Delete(int id);
}
