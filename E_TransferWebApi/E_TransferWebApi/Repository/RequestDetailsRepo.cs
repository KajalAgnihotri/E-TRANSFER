using E_TransferWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_TransferWebApi.Repository
{
    public interface IRequestDetailsRepo
    {
        void AddRequest(RequestDetails request);
        void EditRequest(int id, RequestDetails request);
        void EditRequestByHr(int id, RequestDetails request);
        void DeleteRequest(int id);
        List<RequestDetails> GetAllRequest();
        RequestDetails GetRequestById(int id);
        RequestDetails GetRequestByEmpcode(int code);
        void EditRequestByCso(int id, RequestDetails request);
    }
    public class RequestDetailsRepo : IRequestDetailsRepo
    {
        ETransferDbContext _context;
        public RequestDetailsRepo(ETransferDbContext context)
        {
            _context = context;
        }
        public void AddRequest(RequestDetails request)
        {
            _context.RequestsInformation.Add(request);
            _context.SaveChanges();
        }
        public void DeleteRequest(int id)
        {
            RequestDetails request = _context.RequestsInformation.FirstOrDefault(m => m.RequestId == id);
            _context.RequestsInformation.Remove(request);
            _context.SaveChanges();
        }
        public void EditRequest(int id, RequestDetails request)
        {
            RequestDetails currentrequest = _context.RequestsInformation.FirstOrDefault(m => m.RequestId == id);
            currentrequest.NewCcCode = request.NewCcCode;
            currentrequest.NewOucode = request.NewOucode;
            currentrequest.Newpacode = request.Newpacode;
            currentrequest.Newpsacode = request.Newpsacode;
            currentrequest.pendingWith = request.pendingWith;
            currentrequest.TypeOfRequest = request.TypeOfRequest;
            _context.SaveChanges();
        }

        public void EditRequestByHr(int id, RequestDetails request)
        {
            RequestDetails currentrequest = _context.RequestsInformation.FirstOrDefault(m => m.RequestId == id);
            currentrequest.pendingWith = request.pendingWith;
            _context.SaveChanges();
        }

        public List<RequestDetails> GetAllRequest()
        {
            return _context.RequestsInformation.ToList();
        }

        public RequestDetails GetRequestByEmpcode(int code)
        {
            RequestDetails request = _context.RequestsInformation.FirstOrDefault(m => m.EmployeeCode == code);
            return request;
        }

        public RequestDetails GetRequestById(int id)
        {
            RequestDetails request = _context.RequestsInformation.FirstOrDefault(m => m.RequestId == id);
            return request;
        }
        public void EditRequestByCso(int id, RequestDetails request)
        {
            RequestDetails currentrequest = _context.RequestsInformation.FirstOrDefault(m => m.RequestId == id);
            currentrequest.pendingWith = request.pendingWith;
            currentrequest.RequestStatus = request.RequestStatus;
            _context.SaveChanges();
        }
    }
}
