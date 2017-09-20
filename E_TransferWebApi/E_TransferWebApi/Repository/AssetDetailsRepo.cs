using E_TransferWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_TransferWebApi.Repository
{
        public interface IAssetDetailsRepo
        {
            void AddAsset(AssetDetails asset);
            void EditAsset(int id, AssetDetails asset);
            void DeleteAsset(int id);
            List<AssetDetails> GetAllAsset();
            List<AssetDetails> GetAssetByEmpCode(int id);
           void EditAssetonAssignedUserResponse(int id, AssetDetails asset);
        }
        public class AssetDetailsRepo : IAssetDetailsRepo
        {
            ETransferDbContext _context;
            public AssetDetailsRepo(ETransferDbContext _context)
            {
                this._context = _context;
            }
            public void AddAsset(AssetDetails asset)
            {
                _context.AssetsInformation.Add(asset);
                _context.SaveChanges();
            }
            public void DeleteAsset(int id)
            {
                AssetDetails asset = _context.AssetsInformation.FirstOrDefault(m => m.AssetCode == id);
                _context.AssetsInformation.Remove(asset);
                _context.SaveChanges();
            }
            public void EditAsset(int id, AssetDetails asset)
            {
                AssetDetails currentasset = _context.AssetsInformation.FirstOrDefault(m => m.AssetId == id);
                currentasset.AssignedTo = asset.AssignedTo;
                currentasset.AssignToEmailId = asset.AssignToEmailId;
                currentasset.AssetStatus = asset.AssetStatus;
                _context.SaveChanges();
            }
            public List<AssetDetails> GetAllAsset()
            {
                return _context.AssetsInformation.ToList();
            }
        public void EditAssetonAssignedUserResponse(int id, AssetDetails asset)
        {
            AssetDetails currentasset = _context.AssetsInformation.FirstOrDefault(m => m.AssetId == id);
            currentasset.AssetStatus = asset.AssetStatus;
            _context.SaveChanges();
        }
        public List<AssetDetails> GetAssetByEmpCode(int id)
            {
                List<AssetDetails> assetList = new List<AssetDetails>();
                List<AssetDetails> assets = _context.AssetsInformation.ToList();
                foreach (AssetDetails asset in assets)
                {
                    if (asset.EmployeeCode == id)
                    {
                        assetList.Add(asset);
                    }
                }
                return assetList;
            }
        }
    
}
