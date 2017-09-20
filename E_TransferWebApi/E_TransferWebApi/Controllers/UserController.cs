using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using E_TransferWebApi.Models;
using E_TransferWebApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        // GET api/values/5
        [HttpGet()]
        [Route("GetRequest/{id}")]
        public RequestDetails GetRequest(int id)
        {
            return _service.GetUserByEmpcode(id);
        }

        // GET api/values/5
        [HttpGet()]
        [Route("GetEmployee/{id}")]
        public EmployeeDetails GetEmployee(int id)
        {
            return _service.GetUserDetails(id);
        }

    }
}
