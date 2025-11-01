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
                // Connection string - Ganti sesuai dengan konfigurasi database Anda
                optionsBuilder.UseNpgsql("Host=localhost;Database=db_vb2_sbn;Username=postgres;Password=admin123");
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
                entity.ToTable("Buyers"); // Pastikan nama tabel sesuai

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
        }
    }
}