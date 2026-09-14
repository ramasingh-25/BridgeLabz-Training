using Microsoft.EntityFrameworkCore;
using FundooNotes.Models.Entities;

namespace FundooNotes.LabelService.Data
{
    public class LabelDbContext : DbContext
    {
        public LabelDbContext(DbContextOptions<LabelDbContext> options) : base(options)
        {
        }

        public DbSet<LabelEntity> Labels { get; set; }
    }
}
