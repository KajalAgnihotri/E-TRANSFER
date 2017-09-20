using E_TransferWebApi.Models;
using E_TransferWebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_TransferWebApi.Services
{
    public interface ICsoService
    {
        List<RequestDetails> GetAllcsoRequest();
        List<RequestDetails> GetRequestPendingWithCso();
        RequestDetails GetRequestByEmpCode(int id);
        void UpdateRequest(int id, RequestDetails request);
        List<AssetDetails> GetAssetDetailsByEmpcode(int id);

    }
    public class CsoService : ICsoService
    {
        private IRequestDetailsRepo _repo;
        private IAssetDetailsRepo _assetrepo;
        public CsoService(IRequestDetailsRepo repo, IAssetDetailsRepo assetrepo)
        {
            _repo = repo;
            _assetrepo = assetrepo;

        }
        public List<RequestDetails> GetAllcsoRequest()
        {
            return _repo.GetAllRequest();
        }

        public List<RequestDetails> GetRequestPendingWithCso()
        {
            List<RequestDetails> requests = new List<RequestDetails>();
            List<RequestDetails> requestlist = _repo.GetAllRequest();
            foreach (RequestDetails req in requestlist)
            {
                if (req.pendingWith == Pendingwith.CSO && req.RequestStatus == Requeststatus.Pending)
                {
                    int id = req.EmployeeCode;
                    List<AssetDetails> assetlist = _assetrepo.GetAssetByEmpCode(id);
                    List<AssetDetails> assets = new List<AssetDetails>();
                    foreach (AssetDetails asset in assetlist)
                    {
                        if (asset.AssetStatus == status.Accepted)
                        {
                            assets.Add(asset);
                        }
                    }
                    if (assets.Count == assetlist.Count)
                    {
                        requests.Add(req);
                    }
                }
            }
            return requests;
        }


        public RequestDetails GetRequestByEmpCode(int id)
        {
            return _repo.GetRequestByEmpcode(id);
        }

        public void UpdateRequest(int id, RequestDetails request)
        {
            _repo.EditRequestByCso(id, request);
        }
        public List<AssetDetails> GetAssetDetailsByEmpcode(int id)
        {
            return _assetrepo.GetAssetByEmpCode(id);
        }
    }
}
