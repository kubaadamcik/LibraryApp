using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Persistence
{
    public class AppDatabaseContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options) : base(options)
        {

        }
    }
}
