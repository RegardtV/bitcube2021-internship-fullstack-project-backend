using FullStack.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FullStack.Data.DbContexts
{
    public class UserDbContext: DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed the database with dummy data
            modelBuilder.Entity<User>().HasData
            (
                new User()
                {
                    Id = 1,
                    FirstName = "Regardt",
                    LastName = "Visagie",
                    Email = "regardtvisagie@gmail.com",
                    Password = "Reg14061465"
                }
               );

            base.OnModelCreating(modelBuilder);
        }
    }
}
