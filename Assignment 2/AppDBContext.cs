using System;
using Microsoft.EntityFrameworkCore;

namespace Assignment2
{
    public class AppDBContext : DbContext
    {
        // A DbSet represents a table. EF Core uses this property to know
        // about the "Users" table mapped in Entities.cs.
        public DbSet<Entities.User> Users { get; set; }

        // Use an in-memory database instead of a real SQL Server instance.
        // "AppDB" is just the name EF Core uses to identify this in-memory
        // database internally — it isn't a file or server, it only exists
        // while the program is running and resets every time you restart it.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("AppDB");
        }
    }
}