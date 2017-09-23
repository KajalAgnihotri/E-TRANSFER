using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using E_TransferWebApi.Models;
using E_TransferWebApi.Services;



namespace E_TransferWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }
        //Method to get request details using employee code
        // GET api/User/5
        [HttpGet()]
        [Route("GetRequest/{id}")]
        public IActionResult GetRequest(int id)
        {
             
            try
            {
                RequestDetails request = _service.GetUserByEmpcode(id);//service call
                if (request != null)
                {
                    return Ok(request);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return StatusCode(500);

            }

            
           
       }
        //Method to get Employee Details
        // GET api/User/5
    [HttpGet()]
        [Route("GetEmployee/{id}")]
        public IActionResult GetEmployee(int id)
        {
            

            try
            {
                EmployeeDetails employee = _service.GetUserDetails(id);
                if (employee == null)
                {
                    return BadRequest();
                }
                else

                {
                    return Ok(employee);
                }
                
            }
            catch
            {
                return StatusCode(500);
            }
        }

    }
    }

