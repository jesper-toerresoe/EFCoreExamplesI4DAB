using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using EfCoreScaffold.Models;

namespace EfCoreScaffold.Data
{
  public class MyDbContext : DbContext
  {
    //public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
            //optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EFCore.Migrations;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\E20I4DAB;Initial Catalog=EFCore.Migrations; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            //optionsBuilder.UseSqlServer("Data Source=127.0.0.1,1433;Database=BookStore2;User ID=SA;Password=12345678Aa#;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // Author
      modelBuilder.Entity<Author>().HasKey(a => new { a.FirstName, a.LastName });

      // Book
      modelBuilder.Entity<Book>().HasKey(b => b.Isbn10);
      modelBuilder.Entity<Book>().HasIndex(b => b.Isbn13).IsUnique();
      modelBuilder.Entity<Book>().HasCheckConstraint("constraint_pages_positive", "'pages' > 0");
      modelBuilder.Entity<Book>() // One to one
          .HasOne<PriceOffer>(b => b.PriceOffer)
          .WithOne(po => po.Book)
          .HasForeignKey<PriceOffer>(po => po.BookIsbn);
      modelBuilder.Entity<Book>() // One to many
          .HasMany<Review>(b => b.Reviews)
          .WithOne(r => r.Book)
          .HasForeignKey(r => r.BookIsbn);
      modelBuilder.Entity<Book>()
        .HasOne(b => b.PrimaryAuthor)
        .WithMany(a => a.Books)
        .HasForeignKey(b => new { b.AuthorFirstName, b.AuthorLastName });
      modelBuilder.Entity<Book>()
        .HasOne(b => b.NextBook)
        .WithOne(b => b.PreviousBook)
        .HasForeignKey<Book>(b => b.NextBookIsbn10)
        .IsRequired(false);

      // PriceOffer

      // Reivew
      modelBuilder.Entity<Review>()
        .HasOne(r => r.Voter)
        .WithMany(v => v.Reviewers)
        .HasForeignKey(r => new { r.VoterFirstName, r.VoterLastName });

      // BookAuthors (many to many)
      modelBuilder.Entity<BookAuthors>()
          .HasOne(ba => ba.Book)
          .WithMany(b => b.BookAuthors)
          .HasForeignKey(ba => ba.BookIsbn);
      modelBuilder.Entity<BookAuthors>()
          .HasOne(ba => ba.Author)
          .WithMany(a => a.BookAuthors)
          .HasForeignKey(ba => new { ba.AuthorFirstName, ba.AuthorLastName });

      // Voter
      modelBuilder.Entity<Voter>().HasKey(v => new { v.FirstName, v.LastName });

      // Edition
      modelBuilder.Entity<Edition>()
          .HasCheckConstraint("constraint_edition",
                              "'name' = 'paperback' OR 'name' = 'e-book' OR 'name' = 'hardback' OR 'name' = 'audio'");
      modelBuilder.Entity<Edition>()
        .HasOne(e => e.Book)
        .WithMany(b => b.Editions)
        .HasForeignKey(e => e.BookIsbn10);

    }

  }
}