using E_TransferWebApi.Models;
using E_TransferWebApi.Repository;
using E_TransferWebApi.Services;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System.Collections.Generic;


namespace E_TransferWebApi.Controllers
{
    [Produces("application/json")]
   // [Route("api/[controller]")]
    public class SupervisorController : Controller
    {
        ISupervisorService _service;
        IAssetDetailsRepo _assetrepo;
        public SupervisorController(ISupervisorService service, IAssetDetailsRepo assetrepo)
        {
            _service = service;
            _assetrepo = assetrepo;

            var builder = new ConfigurationBuilder()
                .AddJsonFile("config.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }
        // GET: api/Supervisor
        [Route("api/[controller]/GetRequest")]
        [HttpGet]
        public IEnumerable<RequestDetails> GetRequest()
        {
            return _service.GetAllpendingRequest();
        }
 
        [HttpGet()]
        [Route("api/[controller]/GetRequestById/{id}")]
        public RequestDetails GetRequestById(int id)
        {
            return _service.GetRequestById(id);
        }

        [HttpGet]
        [Route("api/[controller]/GetAsset")]
        public IEnumerable<AssetDetails> GetAsset()
        {
            return _service.Getasset();
        }


        // POST: api/Supervisor
        [HttpPost]
        [Route("api/[controller]/PostRequest")]
        public IActionResult PostRequest([FromBody]RequestDetails request)
        {
           string response=_service.AddRequest(request);
            return Ok(response);

        }

        // PUT: api/Supervisor/5
        [HttpPut]
        [Route("api/[controller]/PutRequest/{id}")]
        public void PutRequest(int id, [FromBody]RequestDetails request)
        {
            _service.EditRequest(id, request);
        }

        //byassetid
        [HttpPut]
        [Route("api/[controller]/PutAsset/{id}")]
        public void PutAsset(int id, [FromBody]AssetDetails assetlist)
        {
            _service.EditAssetById(id, assetlist);
            EmailToReassignedUser(id, assetlist);
        }
        private void EmailToReassignedUser(int id, AssetDetails assetList)
        {
            List<AssetDetails> details = new List<AssetDetails>();
            List<AssetDetails> detaillist = _assetrepo.GetAssetByEmpCode(assetList.EmployeeCode);
            foreach (AssetDetails del in detaillist)
            {
                if (del.EmployeeCode == assetList.EmployeeCode)
                {
                    string emailid = del.AssignToEmailId;
                    int code = del.AssignedTo;
                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress(Configuration["Title"], Configuration["FromEmail"]));
                    message.To.Add(new MailboxAddress(code.ToString(), emailid));
                    message.Subject = Configuration["SubjectForSupervisor"];
                    var bodyBuilder = new BodyBuilder();

                    bodyBuilder.HtmlBody = @"<div> Dear Employer </div><br><br><div>You are being reassigned new assets. Kindly check E-Transfer Portal.</div><br><div> Supervisor</div>";
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


        //byemployeecode
        // POSt: api/Supervisor/GetRejectedAssetList
        [HttpPost]
        [Route("api/[controller]/GetRejectedAssetList")]
        public IActionResult GetRejectedAssetList([FromBody]List<int> asset)
        {
            List<AssetDetails> assetlist = new List<AssetDetails>();
            assetlist = _service.GetRejectedAssetListByEmpCode(asset);
            return Ok(assetlist);
        }

        // POST: api/Supervisor/GetAssets
        [HttpPost]
        [Route("api/[controller]/PostAsset")]
        public void PostAsset([FromBody]List<AssetDetails> asset)
        {
            _service.AddAsset(asset);
        }


    }
}
