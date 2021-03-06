using E_TransferWebApi.Models;
using E_TransferWebApi.Repository;
using E_TransferWebApi.Services;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Server.Kestrel;


namespace E_TransferWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SupervisorController : Controller
    {
        ISupervisorService _service;
       // IAssetDetailsRepo _assetrepo;
        public SupervisorController(ISupervisorService service)
        {
            _service = service;
        }

        //Method to get the requests pending with supervisor 
        // GET: api/Supervisor
        [Route("api/[controller]/GetRequest")]
        [HttpGet]
        public IActionResult GetRequest()
        {
            try
            {
                List<RequestDetails> item = _service.GetAllpendingRequest();
                if (item.Count == 0)
                {
                    return NotFound(404);                  
                }
                else
                    return Ok(item);
            }
            catch(Exception)
            {
                return StatusCode(500);
            }
        }

        //Method to get the request by id
        [HttpGet]
        [Route("api/[controller]/GetRequestById/{id}")]
        public IActionResult GetRequestById(int id)
        {
            try
            {
                RequestDetails request = _service.GetRequestById(id);
                if (request == null)
                {
                    return NotFound(404);
                }
                return Ok(request);              
            }       
            catch(Exception)
            {
                return StatusCode(500);
            }
        }

        //Method to add the new request into the database.
         //POST: api/Supervisor
        [HttpPost]
        [Route("api/[controller]/PostRequest")]
        public IActionResult PostRequest([FromBody]RequestDetails request)
        {
            try
            {
                if (request == null)
                {
                    return  BadRequest(400); //new BadRequestObjectResult(400);
                }
                bool response = _service.AddRequest(request); //service call
                if (response==false)
                {
                    return NotFound(404);
                }
                return Ok(200);             
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        //Method to add the asset of a particular employee at the time of request generation
        // POST: api/Supervisor/GetAssets
        [HttpPost]
        [Route("api/[controller]/PostAsset")]
        public IActionResult PostAsset([FromBody]List<AssetDetails> asset)
        {
            try
            {
                if (asset== null)
                {
                    return BadRequest(400);
                }
                bool response=_service.AddAsset(asset); //service call
                if (response == false)
                {
                    return NotFound(404);
                }
                 return Ok(200);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        //Method to update the request by the supervisor 
        // PUT: api/Supervisor/5
        [HttpPut]
        [Route("api/[controller]/PutRequest/{id}")]
        public IActionResult PutRequest(int id, [FromBody]RequestDetails request)
        {
            try
            {
                if (request == null || request.RequestId != id)
                {
                    //Validation that object and id can't be null
                    return BadRequest(400);
                }
                bool response = _service.EditRequest(id, request); //service call
                if (response == false)
                {
                    return NotFound(404);
                }
                else
                {
                    return Ok(200);
                }
            }
            catch(Exception)
            {
                return StatusCode(500);
            }
        }

        //Method to add the Updated Asset Reassignment of the Employee who is seeking clearance
        //byassetid
        [HttpPut]
        [Route("api/[controller]/PutAsset/{id}")]
        public IActionResult PutAsset(int id, [FromBody]AssetDetails assetlist)
        {
            try
            {
                if (assetlist == null || assetlist.AssetId != id)
                {
                    //Validation that object and id can't be null
                    return BadRequest(400);
                }
                bool response = _service.EditAssetById(id, assetlist); //service call
                if (response == false)
                {
                    return NotFound(404);
                }
                else
                {
                    // _service.EmailToReassignedUser(id, assetlist); //Email to the reassigned employee of the asset
                    return Ok(200);
                }
            }
            catch(Exception)
            {
                return StatusCode(500);
            }
        }

       
        //Method to get the list of assets rejected by the reassigned user 
        //byemployeecode
        [HttpPost]
        [Route("api/[controller]/GetRejectedAssetList")]
        public IActionResult GetRejectedAssetList([FromBody]List<int> asset)
        {
            try
            {
                if (asset == null)
                {
                    return BadRequest(400);
                }
                List<AssetDetails> assetlist = new List<AssetDetails>();
                assetlist = _service.GetRejectedAssetListByEmpCode(asset); //service call
                if (assetlist.Count==0)
                {
                    return NotFound(404);
                }
                return Ok(assetlist);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}