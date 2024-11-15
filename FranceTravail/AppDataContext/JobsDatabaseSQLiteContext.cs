using Microsoft.EntityFrameworkCore;

namespace FranceTravail.AppDataContext
{
    public class JobsDatabaseSQLiteContext : DbContext
    {

        public DbSet<Models.Job> Jobs { get; set; }
        public string DbPath { get; }

        public JobsDatabaseSQLiteContext()
        {
            DbPath = "Datastore/jobs.db";
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }
    }
}
