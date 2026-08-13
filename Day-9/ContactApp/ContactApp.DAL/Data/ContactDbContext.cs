using ContactApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactApp.DAL.Data;

public class ContactDbContext : DbContext
{
    public ContactDbContext(
        DbContextOptions<ContactDbContext> options)
        : base(options)
    {
    }

    public DbSet<Contact> Contacts { get; set; }
}