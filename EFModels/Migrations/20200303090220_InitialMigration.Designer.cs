﻿// <auto-generated />
using System;
using EfCoreScaffold.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EfCoreScaffold.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20200303090220_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFModels.Models.Author", b =>
                {
                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FirstName", "LastName");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("EFModels.Models.Book", b =>
                {
                    b.Property<int>("Isbn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PublishedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.HasKey("Isbn");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("EFModels.Models.BookAuthors", b =>
                {
                    b.Property<int>("BookAuthorsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthorFirstName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AuthorLastName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("BookIsbn")
                        .HasColumnType("int");

                    b.HasKey("BookAuthorsId");

                    b.HasIndex("BookIsbn");

                    b.HasIndex("AuthorFirstName", "AuthorLastName");

                    b.ToTable("BookAuthors");
                });

            modelBuilder.Entity("EFModels.Models.PriceOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookIsbn")
                        .HasColumnType("int");

                    b.Property<float>("NewPrice")
                        .HasColumnType("real");

                    b.Property<string>("PromotionText")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookIsbn")
                        .IsUnique();

                    b.ToTable("PriceOffer");
                });

            modelBuilder.Entity("EFModels.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookIsbn")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumStars")
                        .HasColumnType("int");

                    b.Property<string>("Votername")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookIsbn");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("EFModels.Models.BookAuthors", b =>
                {
                    b.HasOne("EFModels.Models.Book", "Book")
                        .WithMany("BookAuthors")
                        .HasForeignKey("BookIsbn")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFModels.Models.Author", "Author")
                        .WithMany("BookAuthors")
                        .HasForeignKey("AuthorFirstName", "AuthorLastName");
                });

            modelBuilder.Entity("EFModels.Models.PriceOffer", b =>
                {
                    b.HasOne("EFModels.Models.Book", "Book")
                        .WithOne("PriceOffer")
                        .HasForeignKey("EFModels.Models.PriceOffer", "BookIsbn")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFModels.Models.Review", b =>
                {
                    b.HasOne("EFModels.Models.Book", "Book")
                        .WithMany("Reviews")
                        .HasForeignKey("BookIsbn")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
