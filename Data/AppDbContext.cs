using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SBN_Application.Models;

namespace SBN_Application.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<SBN> SBNs { get; set; }
        public DbSet<Asset> Assets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=db_vb2_sbn;Username=postgres;Password=rizal0857");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Buyer>().HasKey(b => b.Id_Buyer);
            modelBuilder.Entity<SBN>().HasKey(s => s.Id_Sbn);
            modelBuilder.Entity<Asset>().HasKey(a => a.Id_Asset);
        }



    }
}
