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
                new Reader { Id = 100, Name = "John", DOB = new System.DateTime(1985, 12 ,24) }, // Id set manually due to in-memory provider
                new Reader { Id = 101, Name = "Christopher", DOB = new System.DateTime(1981, 01, 21) }
            );

            builder.Entity<Book>().ToTable("Books");
            builder.Entity<Book>().HasKey(p => p.Id);
            builder.Entity<Book>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Book>().Property(p => p.Title).IsRequired().HasMaxLength(50);
            builder.Entity<Book>().Property(p => p.ISBN).IsRequired();
            builder.Entity<Book>().Property(p => p.CheckOutDate);
            builder.Entity<Book>().Property(p => p.Lost);
        }
    }
}
