using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SBN_Application.Data;
using SBN_Application.Models;

namespace SBN_Application.Services
{
    public class SBNService
    {
        private readonly AppDbContext _db;

        public SBNService(AppDbContext db) => _db = db;

        // Get sbn by ID
        public async Task<SBN?> GetSBN(int sbnId)
        {
            var sbn = await _db.SBNs.AsNoTracking().FirstOrDefaultAsync(
                s => s.Id_Sbn == sbnId);
            return sbn;
        }
        // Set data for GridView with formatted display
        public object SetGridView()
        {
            var grid = _db.SBNs.OrderBy(s => s.Nama_Sbn)
                .Select(s => new
                {
                    s.Id_Sbn,
                    s.Nama_Sbn,
                    s.Kode_Sbn,
                    s.Deskripsi,
                    s.Tipe_Investor,
                    s.Min_Beli,
                    s.Fixed_Rate,
                    s.Created_At

                })
                .ToList();
            return grid;
        }

        // Find SBN by ID (synchronous)
        public SBN? FindById(int id)
        {
            return _db.SBNs.FirstOrDefault(s => s.Id_Sbn == id);
        }

        // Find SBN by name
        public SBN? FindByName(string name)
        {
            return _db.SBNs.FirstOrDefault(s => s.Nama_Sbn == name);
        }

        // Get all SBN
        public async Task<List<SBN>> GetAllSBN()
        {
            return await _db.SBNs.AsNoTracking().OrderBy(s => s.Nama_Sbn).ToListAsync();
        }

        // Add new SBN
        public async Task<SBN> AddSBN(SBN sbn)
        {
            if (sbn.Created_At == default(DateTime))
            {
                sbn.Created_At = DateTime.Now;
            }
            _db.SBNs.Add(sbn);
            await _db.SaveChangesAsync();
            return sbn;
        }

        // Update existing SBN
        public async Task UpdateSBN(SBN sbn)
        {
            // Detach any existing tracked entity with same key
            var local = _db.Set<SBN>()
                .Local
                .FirstOrDefault(entry => entry.Id_Sbn.Equals(sbn.Id_Sbn));

            if (local != null)
            {
                _db.Entry(local).State = EntityState.Detached;
            }

            _db.Entry(sbn).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        // Delete SBN
        public async Task<bool> DeleteSBN(int sbnId)
        {
            var sbn = await _db.SBNs.FindAsync(sbnId);
            if (sbn != null)
            {
                _db.SBNs.Remove(sbn);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
        // Check if SBN exists by kode
        public async Task<bool> KodeExists(string kode, int? excludeId = null)
        {
            if (excludeId.HasValue)
            {
                return await _db.SBNs.AnyAsync(s => s.Kode_Sbn == kode && s.Id_Sbn != excludeId);
            }
            return await _db.SBNs.AnyAsync(s => s.Kode_Sbn == kode);
        }
    }
}
