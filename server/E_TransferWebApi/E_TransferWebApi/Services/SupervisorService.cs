using E_TransferWebApi.Models;
using E_TransferWebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_TransferWebApi.Services
{
    public interface ISupervisorService
    {
        //Request Methods
        List<RequestDetails> GetAllpendingRequest();
        bool AddRequest(RequestDetails request);
        bool EditRequest(int id, RequestDetails request);
        RequestDetails GetRequestById(int id);
       
        //Asset methods
        bool AddAsset(List<AssetDetails> assetlist);
        List<AssetDetails> GetRejectedAssetListByEmpCode(List<int> asset);
        bool EditAssetById(int id, AssetDetails assetlist);
        List<AssetDetails> Getasset();

    }
    public class SupervisorService : ISupervisorService
    {
        IRequestDetailsRepo _requestrepository;
        IAssetDetailsRepo _assetrepo;
        public SupervisorService(IRequestDetailsRepo request, IAssetDetailsRepo asset)
        {
            _requestrepository = request;
            _assetrepo = asset;
        }

        public bool AddAsset(List<AssetDetails> assetlist)
        {
               bool check = false;
                foreach (AssetDetails asset in assetlist)
                {
                    check=_assetrepo.AddAsset(asset);
                }
            return check;
        }

        public bool AddRequest(RequestDetails request)
        {
            
                request.DateOfRequest = DateTime.Now;
               bool check= _requestrepository.AddRequest(request);
            return check;

        }

        public void DeleteRequest(int id)
        {
            _requestrepository.DeleteRequest(id);
        }

        public bool EditAssetById(int id, AssetDetails assetlist)
        {           
              bool check=_assetrepo.EditAsset(id, assetlist);
            return check;
        }

        public bool EditRequest(int id, RequestDetails request)
        {
            bool check=_requestrepository.EditRequest(id, request);
            return check;
        }

        public List<AssetDetails> GetRejectedAssetListByEmpCode(List<int> asset)
        {
            List<AssetDetails> rejectedassetlist = new List<AssetDetails>();
            foreach (int empid in asset)
            {
                List<AssetDetails> matchassets = _assetrepo.GetAssetByEmpCode(empid);
                foreach (AssetDetails myasset in matchassets)
                {
                    if (myasset.AssetStatus == status.Rejected)
                    {
                        rejectedassetlist.Add(myasset);
                    }
                }
            }
            return rejectedassetlist;
        }

        public List<RequestDetails> GetAllpendingRequest()
        {
            List<RequestDetails> requestlist = new List<RequestDetails>();
            List<RequestDetails> request = _requestrepository.GetAllRequest();
            foreach (RequestDetails req in request)
            {
                if (req.pendingWith == Pendingwith.Supervisor)
                {
                    requestlist.Add(req);
                }
            }
            return requestlist;
        }

        public List<AssetDetails> Getasset()
        {
            return _assetrepo.GetAllAsset();
        }

        public RequestDetails GetRequestById(int id)
        {
            return _requestrepository.GetRequestById(id);
        }
    }
}
