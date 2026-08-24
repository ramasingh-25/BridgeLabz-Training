using FundooApp.ModelLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace FundooApp.RepositoryLayer.Context
{
    public class FundooDbContext : DbContext
    {
        public FundooDbContext(DbContextOptions<FundooDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Label> Labels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Note>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notes)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Many-to-many: Note <-> Label, via an implicit join table (NoteLabel)
            modelBuilder.Entity<Note>()
                .HasMany(n => n.Labels)
                .WithMany(l => l.Notes)
                .UsingEntity(j => j.ToTable("NoteLabels"));

            // A user can't have two labels with the same name
            modelBuilder.Entity<Label>()
                .HasIndex(l => new { l.UserId, l.Name })
                .IsUnique();
        }
    }
}
