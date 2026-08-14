using Microsoft.EntityFrameworkCore;
using AddressBookWeb.Models;
using AddressBookWeb.Repository.Data;

namespace AddressBookWeb.Repository.Repositories
{
    public class AddressBookRepository : IAddressBookRepository
    {
        private readonly AppDbContext _context;

        public AddressBookRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AddressBook>> GetAllAsync()
        {
            return await _context.Addressbooks.ToListAsync();
        }

        public async Task<AddressBook?> GetByIdAsync(int id)
        {
            return await _context.Addressbooks.FindAsync(id);
        }

        public async Task<AddressBook> AddAsync(AddressBook addressBook)
        {
            _context.Addressbooks.Add(addressBook);
            await _context.SaveChangesAsync();
            return addressBook;
        }

        public async Task<AddressBook?> UpdateAsync(AddressBook addressBook)
        {
            var existing = await _context.Addressbooks.FindAsync(addressBook.Id);
            if (existing == null)
            {
                return null;
            }

            existing.Name = addressBook.Name;
            existing.PhoneNumber = addressBook.PhoneNumber;
            existing.Email = addressBook.Email;
            existing.Address = addressBook.Address;
            existing.City = addressBook.City;
            existing.State = addressBook.State;
            existing.ZipCode = addressBook.ZipCode;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.Addressbooks.FindAsync(id);
            if (existing == null)
            {
                return false;
            }

            _context.Addressbooks.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}