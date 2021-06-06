// <copyright file="AppDbContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Library.Repositories
{
    using Library.Models;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// This class must inherit DbContext, a class EF Core uses to map your models to database tables.
    /// </summary>
    public class AppDbContext : DbContext
    {

        /// <summary>
        /// These properties are sets (collections of unique objects) that map models to database tables.
        /// </summary>
        public DbSet<Reader> Readers { get; set; }

        /// <summary>
        /// These properties are sets (collections of unique objects) that map models to database tables.
        /// </summary>
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// The constructor we added to this class is responsible for passing the database configuration 
        /// to the base class through dependency injection.
        /// </summary>
        /// <param name="options"></param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// This method is using the feature called Fluent API to specify the database mapping.
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Reader>().ToTable("Readers");
            builder.Entity<Reader>().HasKey(p => p.Id);
            builder.Entity<Reader>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Reader>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Reader>().Property(p => p.DOB).IsRequired();
            builder.Entity<Reader>().HasMany(p => p.Books).WithOne(p => p.Reader).HasForeignKey(p => p.ReaderId);

            // Seeding the data.
            builder.Entity<Reader>().HasData
            (
                new Reader { Id = 10, Name = "John", DOB = new System.DateTime(1985, 12 ,24, 05, 30, 12) }, // Id set manually due to in-memory provider
                new Reader { Id = 11, Name = "Christopher", DOB = new System.DateTime(1981, 01, 21, 12, 02, 00) }
            );

            builder.Entity<Book>().ToTable("Books");
            builder.Entity<Book>().HasKey(p => p.Id);
            builder.Entity<Book>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Book>().Property(p => p.Title).IsRequired().HasMaxLength(50);
            builder.Entity<Book>().Property(p => p.ISBN).IsRequired();
            builder.Entity<Book>().Property(p => p.CheckOutDate);
            builder.Entity<Book>().Property(p => p.Lost);

            // Seeding the data.
            builder.Entity<Book>().HasData
            (
                new Book
                {
                    Id = 10,
                    Title = "Computer Science Using Python",
                    ISBN = "1001",
                    CheckOutDate = new System.DateTime(2021,02,15,08,30,10),
                    ReaderId = 10,
                    Lost = false
                },
                new Book
                {
                    Id = 11,
                    Title = "The Pragmatic Programmer",
                    ISBN = "1002",
                    CheckOutDate = new System.DateTime(2021, 03, 09, 08, 30, 10),
                    ReaderId = 10,
                    Lost = false
                },
                new Book
                {
                    Id = 12,
                    Title = "Modern Operating Systems",
                    ISBN = "1003",
                    CheckOutDate = new System.DateTime(2021, 03, 09, 08, 30, 10),
                    ReaderId = 11,
                    Lost = false
                },
                new Book
                {
                    Id = 13,
                    Title = "C# Programming",
                    ISBN = "1004",
                    CheckOutDate = new System.DateTime(2021, 04, 21, 08, 30, 10),
                    ReaderId = 11,
                    Lost = false
                }
            );
        }
    }
}
