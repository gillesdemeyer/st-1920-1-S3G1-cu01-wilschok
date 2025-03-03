﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.WebAPI.Models
{
    public class BookServiceContext : DbContext
    {
        public BookServiceContext(DbContextOptions<BookServiceContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Singularize table names
            modelBuilder.Entity<Publisher>()
            .ToTable("Publisher")
            .HasData(
            new Publisher
            {
                Id = 1,
                Name = "IT-publishers",
                Country = "UK"
            },
            new Publisher
            {
                Id = 2,
                Name = "FoodBooks",
                Country = "Sweden"
            }
            );
            modelBuilder.Entity<Author>()
                .ToTable("Author")
                .HasData(
                new Author
                {
                    Id = 1,
                    FirstName = "James",
                    LastName = "Sharp",
                    BirthDate = new DateTime(1980, 5, 20)
                },
                new Author
                {
                    Id = 2,
                    FirstName = "Sophie",
                    LastName = "Netty",
                    BirthDate = new DateTime(1992, 3, 4)
                },
                new Author
                {
                    Id = 3,
                    FirstName = "Elisa",
                    LastName = "Yammy",
                    BirthDate = new DateTime(1996, 8, 12)
                });
            // using ANONYMOUS CLASS to construct Books in Db (AuthorId and PublisherId are no real properties)
            modelBuilder.Entity<Book>()
            .ToTable("Book")
            .HasData(
            new 
            {
                Id = 1,
                ISBN = "123456789",
                Title = "Learning C#",
                NumberOfPages = 420,
                FileName = "book1.jpg",
                AuthorId = 1,
                PublisherId = 1,
                Price = 24.00m,
                Year = "2019"
            },
            new
            {
                Id = 2,
                ISBN = "45689132",
                Title = "Mastering Linq",
                NumberOfPages = 360,
                FileName = "book2.jpg",
                AuthorId = 2,
                PublisherId = 1,
                Price = 25.99m,
                Year = "2018"
            },
            new
            {
                Id = 3,
                ISBN = "15856135",
                Title = "Mastering Xamarin",
                NumberOfPages = 360,
                FileName = "book3.jpg",
                AuthorId = 1,
                PublisherId = 1,
                Price = 49.00m,
                Year = "2017"
            },
            new
            {
                Id = 4,
                ISBN = "56789564",
                Title = "Exploring ASP.Net Core 2.0",
                NumberOfPages = 360,
                FileName = "book1.jpg",
                AuthorId = 2,
                PublisherId = 1,
                Price = 60.00m,
                Year = "2019"
            },
            new
            {
                Id = 5,
                ISBN = "234546684",
                Title = "Unity Game Development",
                NumberOfPages = 420,
                FileName = "book2.jpg",
                AuthorId = 2,
                PublisherId = 1,
                Price = 19.00m,
                Year = "2014"
            },
            new
            {
                Id = 6,
                ISBN = "789456258",
                Title = "Cooking is fun",
                NumberOfPages = 40,
                FileName = "book3.jpg",
                AuthorId = 3,
                PublisherId = 2,
                Price = 50.00m,
                Year = "2018"
            },
            new
            {
                Id = 7,
                ISBN = "94521546",
                Title = "Secret recipes",
                NumberOfPages = 53,
                FileName = "book3.jpg",
                AuthorId = 3,
                PublisherId = 2,
                Price = 25.00m,
                Year = "2016"
            });

            modelBuilder.Entity<Publisher>()
            .Property(p => p.Created)
            .HasDefaultValueSql("GETDATE()")
            .ValueGeneratedOnAddOrUpdate();

            modelBuilder.Entity<Author>()
            .Property(p => p.Created)
            .HasDefaultValueSql("GETDATE()")
            .ValueGeneratedOnAddOrUpdate();

            modelBuilder.Entity<Book>()
            .Property(p => p.Created)
            .HasDefaultValueSql("GETDATE()")
            .ValueGeneratedOnAddOrUpdate();

        }

        

        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }



}
