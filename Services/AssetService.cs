using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SBN_Application.Data;
using SBN_Application.Models;

namespace SBN_Application.Services
{
    public class AssetService
    {
        private readonly AppDbContext _db;

        public AssetService(AppDbContext db) => _db = db;

        // Get asset by ID with related data
        public async Task<Asset?> GetAsset(int assetId)
        {
            var asset = await _db.Assets
                .Include(a => a.Buyer)
                .Include(a => a.Sbn)
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id_Asset == assetId);
            return asset;
        }

        // Set data for GridView with formatted display
        public object SetGridView()
        {
            var grid = _db.Assets
                .Include(a => a.Buyer)
                .Include(a => a.Sbn)
                .OrderByDescending(a => a.Created_At)
                .Select(a => new
                {
                    a.Id_Asset,
                    Nama_Buyer = a.Buyer.Nama_Buyer,
                    Nama_Sbn = a.Sbn.Nama_Sbn,
                    a.Modal,
                    a.Tenor,
                    a.Total_Diterima,
                    a.Created_At
                }).ToList();
            return grid;
        }

        // Find asset by ID (synchronous)
        public Asset? FindById(int id)
        {
            return _db.Assets
                .Include(a => a.Buyer)
                .Include(a => a.Sbn)
                .FirstOrDefault(a => a.Id_Asset == id);
        }

        // Get all assets with related data
        public async Task<List<Asset>> GetAllAssets()
        {
            return await _db.Assets
                .Include(a => a.Buyer)
                .Include(a => a.Sbn)
                .AsNoTracking()
                .OrderByDescending(a => a.Created_At)
                .ToListAsync();
        }

        // Add new asset
        public async Task<Asset> AddAsset(Asset asset)
        {
            if (asset.Created_At == default(DateTime))
            {
                asset.Created_At = DateTime.Now;
            }

            // Load SBN data untuk perhitungan
            var sbn = await _db.SBNs.FindAsync(asset.Id_Sbn);
            if (sbn != null)
            {
                asset.Sbn = sbn;
                asset.HitungTotalDiterima();
            }

            _db.Assets.Add(asset);
            await _db.SaveChangesAsync();
            return asset;
        }

        // Update existing asset
        public async Task UpdateAsset(int assetId, int buyerId, int sbnId, int modal, int tenorBulan)
        {
            var asset = await _db.Assets
                .Include(a => a.Sbn)
                .FirstOrDefaultAsync(a => a.Id_Asset == assetId);

            if (asset == null)
                throw new Exception("Asset tidak ditemukan.");

            asset.Id_Buyer = buyerId;
            asset.Id_Sbn = sbnId;
            asset.Modal = modal;
            asset.Tenor = tenorBulan;

            // hitung ulang total
            var sbn = await _db.SBNs.FindAsync(sbnId);
            asset.Sbn = sbn;
            asset.HitungTotalDiterima();

            await _db.SaveChangesAsync();
        }


        // Delete asset
        public async Task<bool> DeleteAsset(int assetId)
        {
            var asset = await _db.Assets.FindAsync(assetId);
            if (asset != null)
            {
                _db.Assets.Remove(asset);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        // Get assets by buyer
        public async Task<List<Asset>> GetAssetsByBuyer(int buyerId)
        {
            return await _db.Assets
                .Include(a => a.Buyer)
                .Include(a => a.Sbn)
                .Where(a => a.Id_Buyer == buyerId)
                .AsNoTracking()
                .OrderByDescending(a => a.Created_At)
                .ToListAsync();
        }

        // Get assets by SBN
        public async Task<List<Asset>> GetAssetsBySBN(int sbnId)
        {
            return await _db.Assets
                .Include(a => a.Buyer)
                .Include(a => a.Sbn)
                .Where(a => a.Id_Sbn == sbnId)
                .AsNoTracking()
                .OrderByDescending(a => a.Created_At)
                .ToListAsync();
        }
    }
}