using E_TransferWebApi.Models;
using E_TransferWebApi.Repository;
using E_TransferWebApi.Services;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
namespace E_TransferWebApi.Controllers
{
    [Route("api/HR")]
    public class HRController : Controller
    {
        IHRService _service;
        IEmployeeDetailsService details;
        IAssetDetailsRepo _assetrepo;
        public HRController(IHRService service, IEmployeeDetailsService detailsab, IAssetDetailsRepo assetrepo)
        {
            _service = service;
            details = detailsab;
            _assetrepo = assetrepo;
            var builder = new ConfigurationBuilder()
                .AddJsonFile("config.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();
        }
        public IConfigurationRoot Configuration { get; }
        // GET: api/HRController
        [HttpGet]
        public IEnumerable<RequestDetails> Get()
        {
            return _service.GetAllRequest();
        }
        // PUT api/HR/5
        [HttpPut()]
        [Route("PutAcceptRequest/{id}")]
        public void PutAcceptRequest(int id, [FromBody]RequestDetails request)
        {
            _service.UpdateRequest(id, request);
            EmailForApprovalInHR(id, request);
        }
        private void EmailForApprovalInHR(int id, RequestDetails request)
        {
            List<AssetDetails> details = new List<AssetDetails>();
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

                    bodyBuilder.HtmlBody = @"<div> Dear Sir/Madam </div><br><br><div>Your Request is Approved By Hr</div><br><div> Hr Department</div>";
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
        // PUT api/HR/5
        [HttpPut()]
        [Route("PutRejectRequest/{id}")]
        public void PutRejectRequest(string id, [FromBody]RequestDetails request)
        {
            _service.UpdateRequestWithComment(id, request);
            EmailRejected(id, request);
        }
        private void EmailRejected(string id, RequestDetails req)
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

                bodyBuilder.HtmlBody = @"<div>  Dear Supervisor </div><br><br><div>Your Request has been rejected by Hr for the stated reason: "+ id+"</div><br><div> Hr Department</div>";
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