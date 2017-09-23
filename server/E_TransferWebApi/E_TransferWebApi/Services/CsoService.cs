using E_TransferWebApi.Models;
using E_TransferWebApi.Repository;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System.Collections.Generic;
namespace E_TransferWebApi.Services
{
    public interface ICsoService
    {
        List<RequestDetails> GetRequestPendingWithCso();
        bool UpdateRequest(int id, RequestDetails request);
        List<AssetDetails> GetAssetDetailsByEmpcode(int id);
        bool EmailbyCso(RequestDetails requestData);
    }
    public class CsoService : ICsoService
    {
        private IRequestDetailsRepo _repo;
        private IAssetDetailsRepo _assetrepo;
        private IEmployeeDetailsRepo _details;
        public CsoService(IRequestDetailsRepo repo, IAssetDetailsRepo assetrepo, IEmployeeDetailsRepo details)
        {
            _repo = repo;
            _assetrepo = assetrepo;
            _details = details;
            _details = details;
            var builder = new ConfigurationBuilder() //config file for the email method
            .AddJsonFile("config.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();
        }
        public IConfigurationRoot Configuration { get; }
      
        public List<RequestDetails> GetRequestPendingWithCso()
        {
            
            List<RequestDetails> requests = new List<RequestDetails>();
            List<RequestDetails> requestlist = _repo.GetAllRequest();
            foreach (RequestDetails req in requestlist)
            {
                //get only those requests that are pending with cso 
                if (req.pendingWith == Pendingwith.CSO && req.RequestStatus == Requeststatus.Pending)
                {
                    int id = req.EmployeeCode;
                    List<AssetDetails> assetlist = _assetrepo.GetAssetByEmpCode(id);
                    List<AssetDetails> assets = new List<AssetDetails>();
                    foreach (AssetDetails asset in assetlist)
                    {
                        if (asset.AssetStatus == status.Accepted)   //fetch request only when all asset clearance is done
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
        public bool UpdateRequest(int id, RequestDetails request)
        {
            _repo.EditRequestByCso(id, request);  //update the request to cleared
            return true;
        }
        public List<AssetDetails> GetAssetDetailsByEmpcode(int id)
        {
            return _assetrepo.GetAssetByEmpCode(id); //get the assets of employee by employerCode

        }
        public bool EmailbyCso(RequestDetails requestData)
        {
            EmployeeDetails details = _details.GetEmployeeById(requestData.EmployeeCode);
            //send email to the employers that cso clearance is done.
            if (details.EmployeeCode == requestData.EmployeeCode)
            {
                string email = details.EmployeeEmailId;
                string name = details.EmployeeName;
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(Configuration["Title"], Configuration["FromEmail"]));
                message.To.Add(new MailboxAddress(name, email));
                message.Subject = Configuration["SubjectForCSOApproval"];
                var bodyBuilder = new BodyBuilder();
                //body of the mail
                bodyBuilder.HtmlBody = @"<div>  Dear Sir/Madam</div><br><br><div>Your Request has been cleared by CSO Department for Asset Clearance</div><br><br><div> Cso Department</div>";
                message.Body = bodyBuilder.ToMessageBody();
                using (var client = new SmtpClient())
                {
                    client.Connect(Configuration["Domain"], 587, false);
                    client.Authenticate(Configuration["FromEmail"], Configuration["Password"]);
                    client.Send(message);
                    client.Disconnect(true);
                }
            }
            return true;
        }
    }
}