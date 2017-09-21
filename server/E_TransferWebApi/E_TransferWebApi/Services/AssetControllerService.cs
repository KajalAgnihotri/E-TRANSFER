using E_TransferWebApi.Models;
using E_TransferWebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_TransferWebApi.Services
{
    public interface IAssetControllerService
    {
        List<AssetDetails> GetAssetDetailsByEmpcode(int code);
        List<AssetDetails> GetRequestStatus();
    }
    public class AssetControllerService : IAssetControllerService
    {
        private IAssetDetailsRepo _assetrepo;
        private IRequestDetailsRepo _requestrepo;
        public AssetControllerService(IAssetDetailsRepo assetrepo, IRequestDetailsRepo requestrepo)
        {
            _assetrepo = assetrepo;
            _requestrepo = requestrepo;
        }
        public List<AssetDetails> GetAssetDetailsByEmpcode(int code)
        {
            return _assetrepo.GetAssetByEmpCode(code);
        }

        public List<AssetDetails> GetRequestStatus()
        {
            List<AssetDetails> assetcontrollist = new List<AssetDetails>();
            List<RequestDetails> requestclear = new List<RequestDetails>();
            List<RequestDetails> requests = _requestrepo.GetAllRequest();
            foreach (RequestDetails request in requests)
            {
                if (request.RequestStatus == Requeststatus.Cleared && request.pendingWith == Pendingwith.Approved)
                {
                    requestclear.Add(request);
                }
            }
            // return requestclear;
            foreach (RequestDetails req in requestclear)
            {
                List<AssetDetails> request = new List<AssetDetails>();
                request = GetAssetDetailsByEmpcode(req.EmployeeCode);
                foreach (AssetDetails req1 in request)
                {
                    assetcontrollist.Add(req1);
                }
            }

            return assetcontrollist;
        }
    }
}
