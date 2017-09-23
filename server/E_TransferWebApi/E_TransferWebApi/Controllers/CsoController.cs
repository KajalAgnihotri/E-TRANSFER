using System;
using E_TransferWebApi.Models;
using E_TransferWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace E_TransferWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Cso")]
    public class CsoController : Controller
    {
        private ICsoService _service;

        public CsoController(ICsoService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetPendingCsoRequest")]
        public List<RequestDetails> GetPendingCsoRequest()
        {

            return _service.GetRequestPendingWithCso();

            //to get all the pending request with cso
        }

        [HttpGet()]
        [Route("GetAssetDetail/{id}")]
        public IActionResult GetAssetDetails(int id)
        {
            try
            {
                var assetDetails = _service.GetAssetDetailsByEmpcode(id);
                if (assetDetails.Count == 0)
                    return NotFound("The Asset List for this Employer Code could not be found"); //not found

                return Ok(assetDetails); //return status code ok along with data
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }


        [HttpPut("{id}")]

        public IActionResult Put(int id, [FromBody] RequestDetails request)
        {
            if (request == null)
            {

                return StatusCode(404);  //BadRequest
            }

            if (_service.UpdateRequest(id, request))//update request status to cleared and appoved by cso
            {
                _service.EmailbyCso(request); //mail for approval of request

                return new NoContentResult();
            }
            return BadRequest();

        }
    }
}