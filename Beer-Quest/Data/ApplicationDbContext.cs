﻿using System;
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
                PhoneNumber = "(989)464-5890",
                DateOfBirth = "04-29-1997",
                UserTypeId = 1,
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
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
                    ImagePath = "tennesseeBrewWorks.png",
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
                    ImagePath = "czanns.jpeg",
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
                    ImagePath = "yee_haw.jpg",
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
                    ImagePath = "jackalope.jpg",
                    UserId = user.Id
                },
                new Brewery()
                {
                    Id = 11,
                    Name = "Fat Bottom Brewering Co",
                    City = "Nashville",
                    Address = "800 44th Ave N",
                    ZipCode = 37209,
                    Phone = "(615) 678-5715",
                    CheersCount = 0,
                    ImagePath = "fatBottom.png",
                    UserId = user.Id
                },
                new Brewery()
                {
                    Id = 12,
                    Name = "Harding House Brewing Co",
                    City = "Nashville",
                    Address = "904 51st Ave N",
                    ZipCode = 37209,
                    Phone = "(615) 678-1047",
                    CheersCount = 0,
                    ImagePath = "hardingHouse.png",
                    UserId = user.Id
                },
                new Brewery()
                {
                    Id = 13,
                    Name = "TailGate Brewery",
                    City = "Nashville",
                    Address = "7300 Charlotte Pike",
                    ZipCode = 37209,
                    Phone = "(615) 861-9842",
                    CheersCount = 0,
                    ImagePath = "tailgate_brewery.jpeg",
                    UserId = user.Id
                },
                new Brewery()
                {
                    Id = 14,
                    Name = "Brewhouse 100",
                    City = "Nashville",
                    Address = "8098 TN-100",
                    ZipCode = 37221,
                    Phone = "(615) 673-2981",
                    CheersCount = 0,
                    ImagePath = "brewhouse100.jpeg",
                    UserId = user.Id
                },
                new Brewery()
                {
                    Id = 15,
                    Name = "Little Harpeth Brewing",
                    City = "Nashville",
                    Address = "30 Oldham St",
                    ZipCode = 37213,
                    Phone = "(615) 942-7066",
                    CheersCount = 0,
                    ImagePath = "littleHarpeth.png",
                    UserId = user.Id
                },
                new Brewery()
                {
                    Id = 16,
                    Name = "New Heights Brewing Company",
                    City = "Nashville",
                    Address = "928 5th Ave S",
                    ZipCode = 37203,
                    Phone = "(615) 490-6901",
                    CheersCount = 0,
                    ImagePath = "newHeights.jpeg",
                    UserId = user.Id
                },
                new Brewery()
                {
                    Id = 17,
                    Name = "Turtle Anarchy Brewing Co",
                    City = "Nashville",
                    Address = "5901 California Ave Suite 105",
                    ZipCode = 37209,
                    Phone = "N/A",
                    CheersCount = 0,
                    ImagePath = "turtle.png",
                    UserId = user.Id
                },
                new Brewery()
                {
                    Id = 18,
                    Name = "Bearded Iris Brewing",
                    City = "Nashville",
                    Address = "101 Van Buren St",
                    ZipCode = 37208,
                    Phone = "(615) 928-7988",
                    CheersCount = 0,
                    ImagePath = "beardedIris2.png",
                    UserId = user.Id
                },
                new Brewery()
                {
                    Id = 19,
                    Name = "Smith & Lentz Brewing",
                    City = "Nashville",
                    Address = "903 Main St",
                    ZipCode = 37206,
                    Phone = "(615) 436-2195",
                    CheersCount = 0,
                    ImagePath = "smithLentz.png",
                    UserId = user.Id
                },
                new Brewery()
                {
                    Id = 20,
                    Name = "Sierra Nevada Brewing Co.",
                    City = "Chico",
                    Address = "1075 East 20th Street",
                    ZipCode = 95928,
                    Phone = "(530) 893-3520",
                    CheersCount = 0,
                    ImagePath = "sierraNevada.jpeg",
                    UserId = user.Id
                },
                new Brewery()
                {
                    Id = 21,
                    Name = "Gambrinus Company",
                    City = "San Antonio",
                    Address = "14800 San Pedro, Third Floor",
                    ZipCode = 78232,
                    Phone = "(210) 490-9128",
                    CheersCount = 0,
                    ImagePath = "gambrinus.jpeg",
                    UserId = user.Id
                },
                new Brewery()
                {
                    Id = 22,
                    Name = "New Belgium Brewing Company",
                    City = "Fort Collins",
                    Address = "500 Linden St",
                    ZipCode = 80524,
                    Phone = "(970) 221-0524",
                    CheersCount = 0,
                    ImagePath = "newBelgium.png",
                    UserId = user.Id
                },
                new Brewery()
                {
                    Id = 23,
                    Name = "CANarchy",
                    City = "Longmont",
                    Address = "1640 S Sunset St",
                    ZipCode = 80501,
                    Phone = "(303) 776-1914",
                    CheersCount = 0,
                    ImagePath = "CANarchy.png",
                    UserId = user.Id
                },
                new Brewery()
                {
                    Id = 24,
                    Name = "Bells",
                    City = "Kalamazoo",
                    Address = "355 E. Kalamazoo Ave",
                    ZipCode = 49007,
                    Phone = "(269) 382-2332",
                    CheersCount = 0,
                    ImagePath = "bells.png",
                    UserId = user.Id
                }
                //new Brewery()
                //{
                //    Id = 25,
                //    Name = "New Belgium Brewing Company",
                //    City = "Fort Collins",
                //    Address = "500 Linden St",
                //    ZipCode = 80524,
                //    Phone = "(970) 221-0524",
                //    CheersCount = 0,
                //    ImagePath = "newBelgium.png",
                //    UserId = user.Id
                //},
                //new Brewery()
                //{
                //    Id = 26,
                //    Name = "New Belgium Brewing Company",
                //    City = "Fort Collins",
                //    Address = "500 Linden St",
                //    ZipCode = 80524,
                //    Phone = "(970) 221-0524",
                //    CheersCount = 0,
                //    ImagePath = "newBelgium.png",
                //    UserId = user.Id
                //},
                //new Brewery()
                //{
                //    Id = 27,
                //    Name = "New Belgium Brewing Company",
                //    City = "Fort Collins",
                //    Address = "500 Linden St",
                //    ZipCode = 80524,
                //    Phone = "(970) 221-0524",
                //    CheersCount = 0,
                //    ImagePath = "newBelgium.png",
                //    UserId = user.Id
                //},
                //new Brewery()
                //{
                //    Id = 28,
                //    Name = "New Belgium Brewing Company",
                //    City = "Fort Collins",
                //    Address = "500 Linden St",
                //    ZipCode = 80524,
                //    Phone = "(970) 221-0524",
                //    CheersCount = 0,
                //    ImagePath = "newBelgium.png",
                //    UserId = user.Id
                //},
                //new Brewery()
                //{
                //    Id = 29,
                //    Name = "New Belgium Brewing Company",
                //    City = "Fort Collins",
                //    Address = "500 Linden St",
                //    ZipCode = 80524,
                //    Phone = "(970) 221-0524",
                //    CheersCount = 0,
                //    ImagePath = "newBelgium.png",
                //    UserId = user.Id
                //},
                //new Brewery()
                //{
                //    Id = 30,
                //    Name = "New Belgium Brewing Company",
                //    City = "Fort Collins",
                //    Address = "500 Linden St",
                //    ZipCode = 80524,
                //    Phone = "(970) 221-0524",
                //    CheersCount = 0,
                //    ImagePath = "newBelgium.png",
                //    UserId = user.Id
                //},
                //new Brewery()
                //{
                //    Id = 31,
                //    Name = "New Belgium Brewing Company",
                //    City = "Fort Collins",
                //    Address = "500 Linden St",
                //    ZipCode = 80524,
                //    Phone = "(970) 221-0524",
                //    CheersCount = 0,
                //    ImagePath = "newBelgium.png",
                //    UserId = user.Id
                //},
                //new Brewery()
                //{
                //    Id = 32,
                //    Name = "New Belgium Brewing Company",
                //    City = "Fort Collins",
                //    Address = "500 Linden St",
                //    ZipCode = 80524,
                //    Phone = "(970) 221-0524",
                //    CheersCount = 0,
                //    ImagePath = "newBelgium.png",
                //    UserId = user.Id
                //},
                //new Brewery()
                //{
                //    Id = 33,
                //    Name = "New Belgium Brewing Company",
                //    City = "Fort Collins",
                //    Address = "500 Linden St",
                //    ZipCode = 80524,
                //    Phone = "(970) 221-0524",
                //    CheersCount = 0,
                //    ImagePath = "newBelgium.png",
                //    UserId = user.Id
                //},
                //new Brewery()
                //{
                //    Id = 34,
                //    Name = "New Belgium Brewing Company",
                //    City = "Fort Collins",
                //    Address = "500 Linden St",
                //    ZipCode = 80524,
                //    Phone = "(970) 221-0524",
                //    CheersCount = 0,
                //    ImagePath = "newBelgium.png",
                //    UserId = user.Id
                //},
                //new Brewery()
                //{
                //    Id = 35,
                //    Name = "New Belgium Brewing Company",
                //    City = "Fort Collins",
                //    Address = "500 Linden St",
                //    ZipCode = 80524,
                //    Phone = "(970) 221-0524",
                //    CheersCount = 0,
                //    ImagePath = "newBelgium.png",
                //    UserId = user.Id
                //},
                //new Brewery()
                //{
                //    Id = 36,
                //    Name = "New Belgium Brewing Company",
                //    City = "Fort Collins",
                //    Address = "500 Linden St",
                //    ZipCode = 80524,
                //    Phone = "(970) 221-0524",
                //    CheersCount = 0,
                //    ImagePath = "newBelgium.png",
                //    UserId = user.Id
                //}, 
                //new Brewery()
                //{
                //    Id = 37,
                //    Name = "New Belgium Brewing Company",
                //    City = "Fort Collins",
                //    Address = "500 Linden St",
                //    ZipCode = 80524,
                //    Phone = "(970) 221-0524",
                //    CheersCount = 0,
                //    ImagePath = "newBelgium.png",
                //    UserId = user.Id
                //}
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
