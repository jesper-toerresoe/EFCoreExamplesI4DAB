using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EfCoreScaffold.Models;

namespace EfCoreScaffold.Data
{
    public partial class EFCoreMigrationsContext : DbContext
    {
        public EFCoreMigrationsContext()
        {
        }

        public EFCoreMigrationsContext(DbContextOptions<EFCoreMigrationsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<BookAuthors> BookAuthors { get; set; }
        public virtual DbSet<Edition> Edition { get; set; }
        public virtual DbSet<PriceOffer> PriceOffer { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<Voter> Voter { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\E20I4DAB;Initial Catalog=EFCore.Migrations; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(e => new { e.FirstName, e.LastName });
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.Isbn10);

                entity.HasIndex(e => e.Isbn13)
                    .IsUnique();

                entity.HasIndex(e => e.NextBookIsbn10)
                    .IsUnique();

                entity.HasIndex(e => new { e.AuthorFirstName, e.AuthorLastName });

                entity.Property(e => e.Price).HasColumnName("price");

                entity.HasOne(d => d.NextBookIsbn10Navigation)
                    .WithOne(p => p.InverseNextBookIsbn10Navigation)
                    .HasForeignKey<Book>(d => d.NextBookIsbn10)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Book)
                    .HasForeignKey(d => new { d.AuthorFirstName, d.AuthorLastName });
            });

            modelBuilder.Entity<BookAuthors>(entity =>
            {
                entity.HasIndex(e => e.BookIsbn);

                entity.HasIndex(e => new { e.AuthorFirstName, e.AuthorLastName });

                entity.HasOne(d => d.BookIsbnNavigation)
                    .WithMany(p => p.BookAuthors)
                    .HasForeignKey(d => d.BookIsbn);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.BookAuthors)
                    .HasForeignKey(d => new { d.AuthorFirstName, d.AuthorLastName });
            });

            modelBuilder.Entity<Edition>(entity =>
            {
                entity.HasIndex(e => e.BookIsbn10);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.BookIsbn10Navigation)
                    .WithMany(p => p.Edition)
                    .HasForeignKey(d => d.BookIsbn10);
            });

            modelBuilder.Entity<PriceOffer>(entity =>
            {
                entity.HasIndex(e => e.BookIsbn)
                    .IsUnique();

                entity.HasOne(d => d.BookIsbnNavigation)
                    .WithOne(p => p.PriceOffer)
                    .HasForeignKey<PriceOffer>(d => d.BookIsbn);
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasIndex(e => e.BookIsbn);

                entity.HasIndex(e => new { e.VoterFirstName, e.VoterLastName });

                entity.HasOne(d => d.BookIsbnNavigation)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.BookIsbn);

                entity.HasOne(d => d.Voter)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => new { d.VoterFirstName, d.VoterLastName });
            });

            modelBuilder.Entity<Voter>(entity =>
            {
                entity.HasKey(e => new { e.FirstName, e.LastName });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
