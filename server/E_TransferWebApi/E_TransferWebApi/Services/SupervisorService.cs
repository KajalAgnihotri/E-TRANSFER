using E_TransferWebApi.Models;
using E_TransferWebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace E_TransferWebApi.Services
{
    public interface ISupervisorService
    {
        //Request Methods
        List<RequestDetails> GetAllpendingRequest();
        string AddRequest(RequestDetails request);
        void EditRequest(int id, RequestDetails request);
        RequestDetails GetRequestById(int id);
       
        //Asset methods
        void AddAsset(List<AssetDetails> assetlist);
        List<AssetDetails> GetRejectedAssetListByEmpCode(List<int> asset);
        void EditAssetById(int id, AssetDetails assetlist);
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

        public void AddAsset(List<AssetDetails> assetlist)
        {   
                foreach (AssetDetails asset in assetlist)
                {
                    _assetrepo.AddAsset(asset);
                }
        }

        public string AddRequest(RequestDetails request)
        {
            request.DateOfRequest = DateTime.Now;
            List<RequestDetails> checkrequestlist = new List<RequestDetails>();
            checkrequestlist = _requestrepository.GetAllRequest();
            foreach(RequestDetails req in checkrequestlist)
            {
                if(req.EmployeeCode == request.EmployeeCode)
                {
                    return "already exist";
                }
            }
            _requestrepository.AddRequest(request);
            return "successful";
        }

        public void DeleteRequest(int id)
        {
            _requestrepository.DeleteRequest(id);
        }

        public void EditAssetById(int id, AssetDetails assetlist)
        {
            //foreach (AssetDetails asset in assetlist)
            //{
            
            _assetrepo.EditAsset(id, assetlist);
            //}
        }

        public void EditRequest(int id, RequestDetails request)
        {
            _requestrepository.EditRequest(id, request);
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
            //this function return all pending request
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
