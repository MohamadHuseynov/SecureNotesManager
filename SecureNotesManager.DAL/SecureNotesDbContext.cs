using Microsoft.EntityFrameworkCore;
using SecureNotesManager.Models;

namespace SecureNotesManager.DAL
    {
        public class SecureNotesDbContext : DbContext
        {
            public DbSet<Note> Notes { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseSqlServer("Server=.;Database=SecureNotesDb;Trusted_Connection=True;TrustServerCertificate=True;");
                }
            }
        }
    }




