using Microsoft.EntityFrameworkCore;
using FundooNotes.Models;

namespace FundooNotes.NotesService.Data
{
    public class NotesDbContext : DbContext
    {
        public NotesDbContext(DbContextOptions<NotesDbContext> options) : base(options)
        {
        }

        public DbSet<NotesEntity> Notes { get; set; }
    }
}
