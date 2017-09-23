using E_TransferWebApi.Models;
using E_TransferWebApi.Repository;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_TransferWebApi.Services
{
    public interface IHRService
    {
        //Request Methods
        List<RequestDetails> GetAllRequest();   
        bool UpdateRequest(int id, RequestDetails request);
        bool UpdateRequestWithComment(string id, RequestDetails request);

        //Asset Methods
        List<AssetDetails> GetAssetDetailsByEmpCode(int id);

        //E-mail methods
        void EmailForApprovalInHr(int id, RequestDetails request);
        void EmailRejected(string id, RequestDetails req);
    }
    public class HRService : IHRService
    {
        //Repository instances
        readonly IRequestDetailsRepo _requestrepository;
        readonly IAssetDetailsRepo _assetrepo;
        readonly IEmployeeDetailsRepo details;
      
        public HRService(IRequestDetailsRepo repo, IEmployeeDetailsRepo detailsab, IAssetDetailsRepo assetrepo)
        {
            _requestrepository = repo;
            _assetrepo = assetrepo;
            details = detailsab;
            var builder = new ConfigurationBuilder().AddJsonFile("config.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();
        }
        public IConfigurationRoot Configuration { get; }
        //Method to return the requests pending with the HR
        public List<RequestDetails> GetAllRequest()
        {
            List<RequestDetails> requests = new List<RequestDetails>();
            List<RequestDetails> requestlist = _requestrepository.GetAllRequest(); //repo call
            foreach (RequestDetails req in requestlist)
            {
                if (req.pendingWith == Pendingwith.HR && req.RequestStatus == Requeststatus.Pending)
                {
                    requests.Add(req);
                }
            }
            return requests;
        }

        //Method to update the request by the HR on the approval
        public bool UpdateRequest(int id, RequestDetails request)
        {
            _requestrepository.EditRequestByHr(id, request);
            return true;
        }

        //Method to get the asset list based on the employee code
        public List<AssetDetails> GetAssetDetailsByEmpCode(int id)
        {
            return _assetrepo.GetAssetByEmpCode(id);
        }

        //Method to update the request by the HR on the rejection
        public bool UpdateRequestWithComment(string id, RequestDetails request)
        {
            int reqid = request.RequestId;
            _requestrepository.EditRequestByHr(reqid, request);
            return true;
        }

        //Method to the Asset reassigned employees post the HR approve the request initiated by the supervisor
        public void EmailForApprovalInHr(int id, RequestDetails request)
        {    
            List<AssetDetails> detaillist = _assetrepo.GetAssetByEmpCode(request.EmployeeCode);
            foreach (AssetDetails del in detaillist)
            {
                if (del.EmployeeCode == request.EmployeeCode)
                {
                    string emailid = del.AssignToEmailId;
                    int code = del.AssignedTo;
                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress(Configuration["Title"], Configuration["FromEmail"]));
                    message.To.Add(new MailboxAddress(code.ToString(), emailid));
                    message.Subject = Configuration["SubjectForApproval"];
                    var bodyBuilder = new BodyBuilder();

                    bodyBuilder.HtmlBody = @"<div> Dear Sir/Madam </div><br><br><div>An Asset Acceptance request has been send to you. Please take the necessary actions.</div><br><div> Hr Department</div>";
                    message.Body = bodyBuilder.ToMessageBody();

                    using (var client = new SmtpClient())
                    {
                        client.Connect(Configuration["Domain"], 587, false);
                        client.Authenticate(Configuration["FromEmail"], Configuration["Password"]);
                        client.Send(message);
                        client.Disconnect(true);
                    }
                }
            }
        }

        //Method to send the email to the supervisor post the rejection of the request by the HR
        public void EmailRejected(string id, RequestDetails req)
        {
            EmployeeDetails temp = details.GetEmployeeById(req.EmployeeCode);

            Console.WriteLine(temp);
            if (temp.Supervisor == req.SupervisorCode)
            {
                string emailid = temp.SupervisorEmailId;
                string name = temp.SupervisorName;

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(Configuration["Title"], Configuration["FromEmail"]));
                message.To.Add(new MailboxAddress(name, emailid));
                message.Subject = Configuration["SubjectForRejection"];
                var bodyBuilder = new BodyBuilder();

                bodyBuilder.HtmlBody = @"<div>  Dear Supervisor </div><br><br><div>Your Request has been rejected by Hr for the stated reason: " + id + "</div><br><div> Hr Department</div>";
                message.Body = bodyBuilder.ToMessageBody();
                //message.Body = new TextPart("plain")
                //{
                //    Text = id
                //};
                using (var client = new SmtpClient())
                {
                    client.Connect(Configuration["Domain"], 587, false);
                    client.Authenticate(Configuration["FromEmail"], Configuration["Password"]);
                    client.Send(message);
                    client.Disconnect(true);
                }
            }
        }
    }
}

