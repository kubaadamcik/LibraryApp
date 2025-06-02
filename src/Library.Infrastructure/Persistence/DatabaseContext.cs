using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Persistence
{
    public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<BookTransaction> BookTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(e => e.Id)
                .HasAnnotation("Sqlite:Autoincrement", true);

            modelBuilder.Entity<Reader>()
                .Property(e => e.Id)
                .HasAnnotation("Sqlite:Autoincrement", true);

            modelBuilder.Entity<BookTransaction>()
                .Property(e => e.Id)
                .HasAnnotation("Sqlite:Autoincrement", true);

            base.OnModelCreating(modelBuilder);
        }
    }
}