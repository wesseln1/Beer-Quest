using System;
using System.Collections.Generic;
using System.Text;
using Beer_Quest.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Beer_Quest.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Brewery> Brewery { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Drink> Drink { get; set; }
        public DbSet<DrinkType> DrinkType { get; set; }
        public DbSet<UserType> UserType { get; set; }
        public DbSet<Cheer> Cheer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Create a new user for Identity Framework
            ApplicationUser user = new ApplicationUser
            {
                FirstName = "admin",
                LastName = "admin",
                Phone = "(989)464-5890",
                DateOfBirth = "04-29-1997",
                UserTypeId = 1,
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                Id = "00000000-ffff-ffff-ffff-ffffffffffff"
            };
            var passwordHash = new Microsoft.AspNetCore.Identity.PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            // Creating UserTypes
            modelBuilder.Entity<UserType>().HasData(
                new UserType()
                {
                    Id = 1,
                    UserTypeName = "Admin"
                },
                new UserType()
                {
                    Id = 2,
                    UserTypeName = "Brew Admin"
                },
                new UserType()
                {
                    Id = 3,
                    UserTypeName = "Non-Admin"
                });

            // Creating all the breweries
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery()
                {
                    Id = 1,
                    Name = "Tennessee Brew Works",
                    Address = "809 Ewing Ave",
                    City = "Nashville",
                    ZipCode = 37203,
                    Phone = "(615)436-0050",
                    CheersCount = 0,
                    UserId = user.Id
                },
                new Brewery()
                {
                    Id = 2,
                    Name = "Czans",
                    City = "Nashville",
                    Address = "505 Lea Ave, Nashville",
                    ZipCode = 37203,
                    Phone = "(615)748-1399",
                    CheersCount = 0,
                    UserId = user.Id
                },
                new Brewery()
                {
                    Id = 3,
                    Name = "Yee Haw",
                    City = "Nashville",
                    Address = "423 6th Ave S",
                    ZipCode = 37203,
                    Phone = "(615)647-8272",
                    CheersCount = 0,
                    UserId = user.Id
                },
                new Brewery()
                {
                    Id = 4,
                    Name = "Jackalope",
                    City = "Nashville",
                    Address = "701 8th Ave S",
                    ZipCode = 37203,
                    Phone = "(615)873-4313",
                    CheersCount = 0,
                    UserId = user.Id
                }
            );

            modelBuilder.Entity<Drink>().HasData(
               // Drinks for Tennessee Brew Works
               new Drink()
               {
                   Id = 1,
                   Name = "State Park Blonde",
                   AlcoholPercent = 4.5,
                   DrinkTypeId = 1,
                   BreweryId = 1,
                   HouseFav = true
               },
               new Drink()
               {
                   Id = 2,
                   Name = "Hippies and Cowboys",
                   AlcoholPercent = 6.0,
                   DrinkTypeId = 2,
                   BreweryId = 1,
                   HouseFav = true
               },
                new Drink()
                {
                    Id = 3,
                    Name = "Southern Wit",
                    AlcoholPercent = 5.1,
                    DrinkTypeId = 3,
                    BreweryId = 1,
                    HouseFav = false
                },
                new Drink()
                {
                    Id = 4,
                    Name = "1927 IPA",
                    AlcoholPercent = 7.5,
                    DrinkTypeId = 2,
                    BreweryId = 1,
                    HouseFav = false
                },
                new Drink()
                {
                    Id = 5,
                    Name = "Extra Easy Ale",
                    AlcoholPercent = 5.25,
                    DrinkTypeId = 4,
                    BreweryId = 1,
                    HouseFav = false
                },
                new Drink()
                {
                    Id = 6,
                    Name = "Cutaway Rye IPA",
                    AlcoholPercent = 6.0,
                    DrinkTypeId = 2,
                    BreweryId = 1,
                    HouseFav = false
                },
                new Drink()
                {
                    Id = 7,
                    Name = "Secret City Imperial IPA",
                    AlcoholPercent = 10.0,
                    DrinkTypeId = 5,
                    BreweryId = 1,
                    HouseFav = false
                },
                new Drink()
                {
                    Id = 8,
                    Name = "Colts Bolts",
                    AlcoholPercent = 10.0,
                    DrinkTypeId = 6,
                    BreweryId = 1,
                    HouseFav = false
                },
                new Drink()
                {
                    Id = 9,
                    Name = "Old Burton Extra (OBE)",
                    AlcoholPercent = 8.5,
                    DrinkTypeId = 7,
                    BreweryId = 1,
                    HouseFav = false
                },
                new Drink()
                {
                    Id = 10,
                    Name = "Key of Lime",
                    AlcoholPercent = 5.0,
                    DrinkTypeId = 8,
                    BreweryId = 1,
                    HouseFav = false
                },
                new Drink()
                {
                    Id = 11,
                    Name = "Basil Ryeman",
                    AlcoholPercent = 8.0,
                    DrinkTypeId = 9,
                    BreweryId = 1,
                    HouseFav = false
                },
                new Drink()
                {
                    Id = 12,
                    Name = "Hopped and Devoted",
                    AlcoholPercent = 5.4,
                    DrinkTypeId = 10,
                    BreweryId = 1,
                    HouseFav = false
                },
                new Drink()
                {
                    Id = 13,
                    Name = "Mild Davis",
                    AlcoholPercent = 4.5,
                    DrinkTypeId = 11,
                    BreweryId = 1,
                    HouseFav = false
                },
                new Drink()
                {
                    Id = 14,
                    Name = "Pie Town Session Porter",
                    AlcoholPercent = 4.9,
                    DrinkTypeId = 12,
                    BreweryId = 1,
                    HouseFav = false
                },
                new Drink()
                {
                    Id = 15,
                    Name = "Session IPA",
                    AlcoholPercent = 4.2,
                    DrinkTypeId = 13,
                    BreweryId = 1,
                    HouseFav = false
                },
                new Drink()
                {
                    Id = 16,
                    Name = "Czann's Oatmeal Stout",
                    AlcoholPercent = 6.2,
                    DrinkTypeId = 4,
                    BreweryId = 2,
                    HouseFav = false
                },
                new Drink()
                {
                    Id = 17,
                    Name = "Czann’s Dunkelweizen",
                    AlcoholPercent = 5.5,
                    DrinkTypeId = 4,
                    BreweryId = 2,
                    HouseFav = false
                },
                new Drink()
                {
                    Id = 18,
                    Name = "Czann's Blonde",
                    AlcoholPercent = 4.25,
                    DrinkTypeId = 17,
                    BreweryId = 2,
                    HouseFav = false
                },
                new Drink()
                {
                    Id = 19,
                    Name = "Czann's Pale Ale",
                    AlcoholPercent = 5.25,
                    DrinkTypeId = 16,
                    BreweryId = 2,
                    HouseFav = false
                },
                new Drink()
                {
                    Id = 20,
                    Name = "Czann's IPA",
                    AlcoholPercent = 6.2,
                    DrinkTypeId = 18,
                    BreweryId = 2,
                    HouseFav = false
                },
                new Drink()
                {
                    Id = 21,
                    Name = "Pale Ale",
                    AlcoholPercent = 5.7,
                    DrinkTypeId = 19,
                    BreweryId = 3,
                    HouseFav = false
                },
                new Drink()
                {
                    Id = 22,
                    Name = "Eighty",
                    AlcoholPercent = 5.0,
                    DrinkTypeId = 20,
                    BreweryId = 3,
                    HouseFav = false
                },
                new Drink()
                {
                    Id = 23,
                    Name = "Dunkel",
                    AlcoholPercent = 5.5,
                    DrinkTypeId = 21,
                    BreweryId = 3,
                    HouseFav = true
                },
                new Drink()
                {
                    Id = 24,
                    Name = "IPA",
                    AlcoholPercent = 6.7,
                    DrinkTypeId = 18,
                    BreweryId = 3,
                    HouseFav = false
                },
                new Drink()
                {
                    Id = 25,
                    Name = "Thunder Ann",
                    AlcoholPercent = 5.5,
                    DrinkTypeId = 19,
                    BreweryId = 4,
                    HouseFav = false
                },
                new Drink()
                {
                    Id = 26,
                    Name = "Bearwalker",
                    AlcoholPercent = 5.0,
                    DrinkTypeId = 22,
                    BreweryId = 4,
                    HouseFav = true
                },
                new Drink()
                {
                    Id = 27,
                    Name = "Sarka",
                    AlcoholPercent = 4.8,
                    DrinkTypeId = 23,
                    BreweryId = 4,
                    HouseFav = false
                },
                new Drink()
                {
                    Id = 28,
                    Name = "Rompo Red Rye",
                    AlcoholPercent = 5.6,
                    DrinkTypeId = 23,
                    BreweryId = 4,
                    HouseFav = false
                },
                new Drink()
                {
                    Id = 29,
                    Name = "Fennario",
                    AlcoholPercent = 7.2,
                    DrinkTypeId = 2,
                    BreweryId = 4,
                    HouseFav = false
                }
            );

            modelBuilder.Entity<DrinkType>().HasData(
               new DrinkType()
               {
                   Id = 1,
                   Name = "American Blonde Ale"
               },
                new DrinkType()
                {
                    Id = 2,
                    Name = "India Pale Ale"
                },
                new DrinkType()
                {
                    Id = 3,
                    Name = "Belgian-Style White/Witbier"
                },
                new DrinkType()
                {
                    Id = 4,
                    Name = "English-Style Pub Ale"
                },
                new DrinkType()
                {
                    Id = 5,
                    Name = "Imperial India Pale Ale"
                },
                new DrinkType()
                {
                    Id = 6,
                    Name = "Imperial Stout"
                },
                new DrinkType()
                {
                    Id = 7,
                    Name = "Tenn Whisky Barrel-Aged English Strong Ale"
                },
                new DrinkType()
                {
                    Id = 8,
                    Name = "Key Lime Hazy India Pale Ale"
                },
                new DrinkType()
                {
                    Id = 9,
                    Name = "Saison / Farmhouse Ale"
                },
                new DrinkType()
                {
                    Id = 10,
                    Name = "Hazy Pale Ale"
                },
                new DrinkType()
                {
                    Id = 11,
                    Name = "English-Style Mild Ale"
                },
                new DrinkType()
                {
                    Id = 12,
                    Name = "American Session Porter"
                },
                new DrinkType()
                {
                    Id = 13,
                    Name = "Session India Pale Ale"
                },
                new DrinkType()
                {
                    Id = 14,
                    Name = "Stout"
                },
                new DrinkType()
                {
                    Id = 15,
                    Name = "Dark Wheat"
                },
                new DrinkType()
                {
                    Id = 16,
                    Name = "Pale Ale"
                },
                new DrinkType()
                {
                    Id = 17,
                    Name = "Blonde Ale"
                },
                new DrinkType()
                {
                    Id = 18,
                    Name = "IPA"
                },
                new DrinkType()
                {
                    Id = 19,
                    Name = "American Pale Ale"
                },
                new DrinkType()
                {
                    Id = 20,
                    Name = "Scottish Style Ale"
                },
                new DrinkType()
                {
                    Id = 21,
                    Name = "Dark Lager"
                },
                new DrinkType()
                {
                    Id = 22,
                    Name = "Maple Brown Ale"
                },
                new DrinkType()
                {
                    Id = 23,
                    Name = "Bohemian Pilsner"
                },
                new DrinkType()
                {
                    Id = 24,
                    Name = "Red Rye Ale"
                }
            );
        }
    }
}
