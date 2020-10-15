using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EFCoreScaffoldAdv.Models;

namespace EFCoreScaffoldAdv.Data
{
    public partial class TernaryTesterContext : DbContext
    {
        public TernaryTesterContext()
        {
        }

        public TernaryTesterContext(DbContextOptions<TernaryTesterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bil> Bil { get; set; }
        public virtual DbSet<GarageAnlaeg> GarageAnlaeg { get; set; }
        public virtual DbSet<StaarI> StaarI { get; set; }
        public virtual DbSet<Vaerksted> Vaerksted { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\E20I4DAB;Initial Catalog=TernaryTester; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bil>(entity =>
            {
                entity.Property(e => e.BilId).HasColumnName("BilID");

                entity.Property(e => e.EjerNavn).IsRequired();

                entity.Property(e => e.Telf)
                    .IsRequired()
                    .HasColumnName("Telf.")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<GarageAnlaeg>(entity =>
            {
                entity.HasKey(e => e.GarageId)
                    .HasName("pk_GarageAnlaeg");

                entity.Property(e => e.GarageId).HasColumnName("GarageID");

                entity.Property(e => e.Navn).IsRequired();
            });

            modelBuilder.Entity<StaarI>(entity =>
            {
                entity.HasKey(e => new { e.GarageId, e.BilId })
                    .HasName("pk_STAAR_I");

                entity.ToTable("STAAR_I");

                entity.Property(e => e.GarageId).HasColumnName("GarageID");

                entity.Property(e => e.BilId).HasColumnName("BilID");

                entity.Property(e => e.VaerkstedsId).HasColumnName("VaerkstedsID");

                entity.HasOne(d => d.Bil)
                    .WithMany(p => p.StaarI)
                    .HasForeignKey(d => d.BilId)
                    .HasConstraintName("fk_STAAR_I2");

                entity.HasOne(d => d.Garage)
                    .WithMany(p => p.StaarI)
                    .HasForeignKey(d => d.GarageId)
                    .HasConstraintName("fk_STAAR_I");

                entity.HasOne(d => d.Vaerksteds)
                    .WithMany(p => p.StaarI)
                    .HasForeignKey(d => d.VaerkstedsId)
                    .HasConstraintName("fk_STAAR_I3");
            });

            modelBuilder.Entity<Vaerksted>(entity =>
            {
                entity.HasKey(e => e.VaerkstedsId)
                    .HasName("pk_Vaerksted");

                entity.Property(e => e.VaerkstedsId).HasColumnName("VaerkstedsID");

                entity.Property(e => e.Vnavn)
                    .IsRequired()
                    .HasColumnName("VNavn");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
