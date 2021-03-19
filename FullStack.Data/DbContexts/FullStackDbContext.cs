using FullStack.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FullStack.Data.DbContexts
{
    public class FullStackDbContext: DbContext
    {
        public FullStackDbContext(DbContextOptions<FullStackDbContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Advert> Adverts { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }
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

            modelBuilder.Entity<Advert>().HasData
            (
                new Advert()
                {
                    Id = 1,
                    Header = "2 Bedroom Luxury Apartment",
                    Description = "Cozy and luxurious apartment ideal for newlyweds",
                    Province = "Western Cape",
                    City = "Paarl",
                    Price = 1320000M,
                    Date = new DateTime(2020, 11, 05),
                    State = "Live",
                    UserId = 1
                },
                new Advert()
                {
                    Id = 2,
                    Header = "Large family house that sleeps 6",
                    Description = "Has a big living room and nice view of the city dsfasdfasdfasdfasdfasdfasdfasdf dfasdfasdfasdfasdf adsfasdfasdfasdf",
                    Province = "Free State",
                    City = "Bloemfontein",
                    Price = 1450000M,
                    Date = new DateTime(2021, 02, 25),
                    State = "Hidden",
                    UserId = 1
                },
                new Advert()
                {
                    Id = 3,
                    Header = "Large family house that sleeps 6",
                    Description = "Has a big living room and nice view of the city dsfasdfasdfasdfasdfasdfasdfasdf dfasdfasdfasdfasdf adsfasdfasdfasdf",
                    Province = "Gauteng",
                    City = "Johannesburg",
                    Price = 1450000M,
                    Date = new DateTime(2021, 02, 25),
                    State = "Hidden",
                    UserId = 1
                }
            );

            modelBuilder.Entity<Province>().HasData
            (
                new Province()
                {
                    Id = 1,
                    Name = "Eastern Cape"
                },
                new Province()
                {
                    Id = 2,
                    Name = "Free State"
                },
                new Province()
                {
                    Id = 3,
                    Name = "Gauteng"
                },
                new Province()
                {
                    Id = 4,
                    Name = "KwaZulu-Natal"
                },
                new Province()
                {
                    Id = 5,
                    Name = "Western Cape"
                }
            );

            modelBuilder.Entity<City>().HasData
            (
                new City()
                {
                    Id = 1,
                    Name = "East London",
                    ProvinceId = 1
                },
                new City()
                {
                    Id = 2,
                    Name = "Port Elizabeth",
                    ProvinceId = 1
                },
                new City()
                {
                    Id = 3,
                    Name = "Bloemfontein",
                    ProvinceId = 2
                },
                new City()
                {
                    Id = 4,
                    Name = "Bethlehem",
                    ProvinceId = 2
                },
                new City()
                {
                    Id = 5,
                    Name = "Johannesburg",
                    ProvinceId = 3
                },
                new City()
                {
                    Id = 6,
                    Name = "Soweto",
                    ProvinceId = 3
                },
                new City()
                {
                    Id = 7,
                    Name = "Durban",
                    ProvinceId = 4
                },
                new City()
                {
                    Id = 8,
                    Name = "Pietermaritzburg",
                    ProvinceId = 4
                },
                new City()
                {
                    Id = 9,
                    Name = "Cape Town",
                    ProvinceId = 5
                },
                new City()
                {
                    Id = 10,
                    Name = "Paarl",
                    ProvinceId = 5
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
