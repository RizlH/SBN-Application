using System;
using Microsoft.EntityFrameworkCore;
using SBN_Application.Models;

namespace SBN_Application.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<SBN> SBNs { get; set; }
        public DbSet<Asset> Assets { get; set; }

        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Connection string
                optionsBuilder.UseNpgsql("Host=localhost;Database=db_vb2_sbn;Username=postgres;Password=rizal0857");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Konfigurasi Primary Keys
            modelBuilder.Entity<Buyer>().HasKey(b => b.Id_Buyer);
            modelBuilder.Entity<SBN>().HasKey(s => s.Id_Sbn);
            modelBuilder.Entity<Asset>().HasKey(a => a.Id_Asset);

            // Konfigurasi tambahan untuk Buyer
            modelBuilder.Entity<Buyer>(entity =>
            {
                entity.ToTable("Buyers"); 

                entity.Property(b => b.Id_Buyer)
                    .ValueGeneratedOnAdd(); // Auto-increment

                entity.Property(b => b.Nama_Buyer)
                    .HasMaxLength(200);

                entity.Property(b => b.No_Telp)
                    .HasMaxLength(20);

                entity.Property(b => b.Email)
                    .HasMaxLength(100);

                entity.Property(b => b.Alamat)
                    .HasMaxLength(500);

                entity.Property(b => b.No_Rek)
                    .HasMaxLength(50);

                entity.Property(b => b.Created_At)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            // Konfigurasi untuk SBN
            modelBuilder.Entity<SBN>(entity =>
            {
                entity.ToTable("SBN");
                entity.HasKey(s => s.Id_Sbn);
                entity.Property(s => s.Id_Sbn).ValueGeneratedOnAdd();
                entity.Property(s => s.Nama_Sbn).IsRequired().HasMaxLength(100);
                entity.Property(s => s.Kode_Sbn).IsRequired().HasMaxLength(50);
                entity.Property(s => s.Deskripsi).HasMaxLength(500);
                entity.Property(s => s.Tipe_Investor).HasMaxLength(50);
                entity.Property(s => s.Created_At).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            // Konfigurasi untuk Asset
            modelBuilder.Entity<Asset>(entity =>
            {
                entity.ToTable("Assets");
                entity.HasKey(a => a.Id_Asset);

                entity.Property(a => a.Id_Asset)
                    .ValueGeneratedOnAdd();

                entity.Property(a => a.Modal)
                    .IsRequired();

                entity.Property(a => a.Tenor)
                    .IsRequired();

                entity.Property(a => a.Total_Diterima)
                    .HasColumnType("double precision");

                entity.Property(a => a.Created_At)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                // Konfigurasi relasi dengan Buyer
                entity.HasOne(a => a.Buyer)
                    .WithMany()
                    .HasForeignKey(a => a.Id_Buyer)
                    .OnDelete(DeleteBehavior.Restrict);

                // Konfigurasi relasi dengan SBN
                entity.HasOne(a => a.Sbn)
                    .WithMany()
                    .HasForeignKey(a => a.Id_Sbn)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}