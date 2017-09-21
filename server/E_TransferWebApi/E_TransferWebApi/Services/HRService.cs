using E_TransferWebApi.Models;
using E_TransferWebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_TransferWebApi.Services
{
    public interface IHRService
    {
        List<RequestDetails> GetAllRequest();
        RequestDetails GetRequesttByEmpCode(int id);
        void UpdateRequest(int id, RequestDetails request);
        void UpdateRequestWithComment(string id, RequestDetails request);
        List<AssetDetails> GetAssetDetailsByEmpCode(int id);
    }
    public class HRService : IHRService
    {
        IRequestDetailsRepo _requestrepository;
        IAssetDetailsRepo _assetrepo;
        public HRService(IRequestDetailsRepo repo, IAssetDetailsRepo assetrepo)
        {
            _requestrepository = repo;
            _assetrepo = assetrepo;
        }
        public List<RequestDetails> GetAllRequest()
        {
            List<RequestDetails> requests = new List<RequestDetails>();
            List<RequestDetails> requestlist = _requestrepository.GetAllRequest();
            foreach (RequestDetails req in requestlist)
            {
                if (req.pendingWith == Pendingwith.HR && req.RequestStatus == Requeststatus.Pending)
                {
                    requests.Add(req);
                }
            }
            return requests;
        }

        public RequestDetails GetRequesttByEmpCode(int id)
        {
            return _requestrepository.GetRequestById(id);
        }

        public void UpdateRequest(int id, RequestDetails request)
        {
            _requestrepository.EditRequestByHr(id, request);
        }

        public List<AssetDetails> GetAssetDetailsByEmpCode(int id)
        {
            return _assetrepo.GetAssetByEmpCode(id);
        }

        public void UpdateRequestWithComment(string id, RequestDetails request)
        {
            string comment = id; //send this comment in an email to the supervisor
            int reqid = request.RequestId;
            _requestrepository.EditRequestByHr(reqid, request);
        }
    }
}

