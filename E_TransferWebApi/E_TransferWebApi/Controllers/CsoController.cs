using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using E_TransferWebApi.Services;
using E_TransferWebApi.Models;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_TransferWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Cso")]
    public class CsoController : Controller
    {
        private ICsoService _service;
        private IEmployeeDetailsService _details;
        public CsoController(ICsoService service, IEmployeeDetailsService details)
        {
            _service = service;
            _details = details;
            var builder = new ConfigurationBuilder()
          .AddJsonFile("config.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }


        //[HttpGet]
        //[Route("GetRequestbycso")]
        //public List<RequestDetails> GetRequestbycso()
        //{
        //    return _service.GetAllcsoRequest();
        //}

        [HttpGet]
        [Route("GetPendingCsoRequest")]
        public List<RequestDetails> GetPendingCsoRequest()
      {
            return _service.GetRequestPendingWithCso();
        }
        //[HttpGet("{id}")]
        //public EmployeeDetails Get(int id)
        //{
        //    return _service.GetRequestByEmpCode(id);
        //}

        //[HttpGet("{id}")]
        //    public RequestDetails Get(int id)
        //    {
        //      return  _service.GetRequestByEmpCode(id);
        //    }

        [HttpGet()]
        [Route("GetAssetDetail/{id}")]
        public IEnumerable<AssetDetails> GetAssetDetails(int id)
        {
            return _service.GetAssetDetailsByEmpcode(id);
        }



        [HttpPut("{id}")]
        public void Put(int id, [FromBody] RequestDetails request)
        {
            _service.UpdateRequest(id, request);
            Email(id, request);
        }

        private void Email(int id, RequestDetails requestData)
        {
            EmployeeDetails details = _details.GetEmployeeById(requestData.EmployeeCode);


            if (details.EmployeeCode == requestData.EmployeeCode)
            {
                string email = details.EmployeeEmailId;
                string name = details.EmployeeName;
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(Configuration["Title"], Configuration["FromEmail"]));
                message.To.Add(new MailboxAddress(name, email));
                message.Subject = Configuration["SubjectForCSOApproval"];

                var bodyBuilder = new BodyBuilder();

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
        }
    }
}