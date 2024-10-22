using BookManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Infrastructure.Persistence
{
    public class BookManagerDbContext : DbContext
    {

        public BookManagerDbContext(DbContextOptions<BookManagerDbContext> options) : base(options)
        {
        }
        public DbSet<Book> Book { get; set; }

        public DbSet<Loans> Loans { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<Devolution> Devolution { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
