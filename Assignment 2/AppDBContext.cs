using System;
using Microsoft.EntityFrameworkCore;

namespace Assignment2
{
    public class AppDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("AppDB");
        }
    }
}