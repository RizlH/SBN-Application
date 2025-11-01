using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SBN_Application.Data;
using SBN_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace SBN_Application.Services
{
    public class BuyerService
    {
        private readonly AppDbContext _db;

        public BuyerService(AppDbContext db) => _db = db;

        // Get buyer by ID
        public async Task<Buyer?> GetBuyer(int buyerId)
        {
            var buyer = await _db.Buyers.AsNoTracking().FirstOrDefaultAsync(
                x => x.Id_Buyer == buyerId);
            return buyer;
        }

        // Set data for GridView with formatted display
        public object SetGridView()
        {
            var grid = _db.Buyers.OrderBy(x => x.Nama_Buyer)
                .Select(x => new
                {
                    x.Id_Buyer,
                    x.Nama_Buyer,
                    x.No_Telp,
                    x.Email,
                    x.Alamat,
                    x.No_Rek,
                    x.Created_At
                }).ToList();
            return grid;
        }

        // Find buyer by ID (synchronous)
        public Buyer? FindById(int id)
        {
            return _db.Buyers.FirstOrDefault(x => x.Id_Buyer == id);
        }

        // Find buyer by name
        public Buyer? FindByName(string name)
        {
            return _db.Buyers.FirstOrDefault(x => x.Nama_Buyer == name);
        }

        // Get all buyers
        public async Task<List<Buyer>> GetAllBuyers()
        {
            return await _db.Buyers.AsNoTracking().OrderBy(x => x.Nama_Buyer).ToListAsync();
        }

        // Add new buyer
        public async Task<Buyer> AddBuyer(Buyer buyer)
        {
            if (buyer.Created_At == default(DateTime))
            {
                buyer.Created_At = DateTime.Now;
            }
            _db.Buyers.Add(buyer);
            await _db.SaveChangesAsync();
            return buyer;
        }

        // Update existing buyer
        public async Task UpdateBuyer(Buyer buyer)
        {
            // Detach any existing tracked entity with same key
            var local = _db.Set<Buyer>()
                .Local
                .FirstOrDefault(entry => entry.Id_Buyer.Equals(buyer.Id_Buyer));

            if (local != null)
            {
                _db.Entry(local).State = EntityState.Detached;
            }

            _db.Entry(buyer).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        // Delete buyer
        public async Task<bool> DeleteBuyer(int buyerId)
        {
            var buyer = await _db.Buyers.FindAsync(buyerId);
            if (buyer != null)
            {
                _db.Buyers.Remove(buyer);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        // Check if buyer exists by email
        public async Task<bool> EmailExists(string email, int? excludeId = null)
        {
            if (excludeId.HasValue)
            {
                return await _db.Buyers.AnyAsync(x => x.Email == email && x.Id_Buyer != excludeId);
            }
            return await _db.Buyers.AnyAsync(x => x.Email == email);
        }

        // Search buyers by name or email
        public async Task<List<Buyer>> SearchBuyers(string searchTerm)
        {
            return await _db.Buyers
                .AsNoTracking()
                .Where(x => x.Nama_Buyer.Contains(searchTerm) || x.Email.Contains(searchTerm))
                .OrderBy(x => x.Nama_Buyer)
                .ToListAsync();
        }
    }
}