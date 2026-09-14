using Microsoft.EntityFrameworkCore;
using FundooNotes.Models;

namespace FundooNotes.IdentityService.Data
{
    public class IdentityDbContext : DbContext
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
