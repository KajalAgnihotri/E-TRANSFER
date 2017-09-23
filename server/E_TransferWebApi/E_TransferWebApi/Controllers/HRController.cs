using E_TransferWebApi.Models;
using E_TransferWebApi.Repository;
using E_TransferWebApi.Services;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace E_TransferWebApi.Controllers
{
    [Route("api/HR")]
    public class HRController : Controller
    {
        // Service instances
        IHRService _service;
        public HRController(IHRService service)
        {
            _service = service;
        }
        
        //Method to get all the rquests pending with HR 
        // GET: api/HRController
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<RequestDetails> requestList = _service.GetAllRequest();
                if (requestList.Count == 0)
                {
                    return this.NotFound("There are no requests pending with the supervisor");
                }
                return Ok(requestList);
            }
            
            catch(TimeoutException e)
            {
                Console.WriteLine(e.StackTrace);
                return StatusCode(102);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return StatusCode(500);
            }
        }

        //Method to update the request on the HR approval
        //Update request using requestId
        // PUT api/HR/5
        [HttpPut()]
        [Route("PutAcceptRequest/{id}")]
        public IActionResult PutAcceptRequest(int id, [FromBody]RequestDetails request)
        {
            try
            {
                if (request == null || request.RequestId != id)
                {
                    return BadRequest();  //Validation that object and id can't be null
                }
                if (_service.UpdateRequest(id, request)) //Update request on Hr rejection
                {
                    _service.EmailForApprovalInHr(id, request); //Asset Acceptence mail to employees
                    return new NoContentResult();
                }
                return BadRequest();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.StackTrace);
                return BadRequest();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return StatusCode(500);
            }

        }

        //Method to update the request on the HR rejection
        // PUT api/HR/5
        [HttpPut()]
        [Route("PutRejectRequest/{id}")]
        public IActionResult PutRejectRequest(string comment, [FromBody]RequestDetails request)
        {
            try
            {
                if (request == null || comment == null)
                {
                    //Validation that object and comment can't be null
                    return BadRequest();
                }
                if (_service.UpdateRequestWithComment(comment, request)) //Update request on Hr rejection
                {
                    _service.EmailRejected(comment, request); //Rejection mail to supervisor
                    return new NoContentResult();
                }
                return BadRequest();
            }
            catch(ArgumentNullException e)
            {
                return BadRequest();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return StatusCode(500);
               
            }
        }
        
    }
}