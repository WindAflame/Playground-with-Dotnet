using CrudExample.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudExample.AppDataContext
{
    public class CrudDbContext : DbContext
    {

        public DbSet<Book> Book { get; set; }

        public string DbPath { get; }

        public CrudDbContext()
        {
            DbPath = "../datastore/books.db";
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }
    }
}
