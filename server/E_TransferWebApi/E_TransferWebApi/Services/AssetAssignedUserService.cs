using E_TransferWebApi.Models;
using E_TransferWebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_TransferWebApi.Services
{
  
    public interface IAssetAssignedUserService
    {
        List<AssetDetails> GetAssetListByEmpcode(int code);
        void UpdateAssetStatus(int id , AssetDetails asset);
        
    }
    public class AssetAssignedUserService : IAssetAssignedUserService
    {
        IAssetDetailsRepo _repo;
        public AssetAssignedUserService(IAssetDetailsRepo repo)
        {
            _repo = repo;
        }
        public List<AssetDetails> GetAssetListByEmpcode(int code)
        {
            List<AssetDetails> assetlist = new List<AssetDetails>();
            List<AssetDetails> assets = _repo.GetAllAsset();
            foreach(AssetDetails asset in assets)
            {
                if(asset.AssignedTo == code && asset.AssetStatus == status.Pending )
                {
                    assetlist.Add(asset);
                }
            }
            return assetlist;
        }

        public void UpdateAssetStatus(int id, AssetDetails asset)
        {
            _repo.EditAssetonAssignedUserResponse(id, asset);
        }
    }
}
