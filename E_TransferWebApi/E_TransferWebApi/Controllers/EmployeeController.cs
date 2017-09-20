using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using E_TransferWebApi.Models;
using E_TransferWebApi.Services;

namespace E_TransferWebApi.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        IEmployeeDetailsService _service;
        public EmployeeController(IEmployeeDetailsService service)
        {
            _service = service;
        }
        // GET api/Employee
        [HttpGet]
        public IEnumerable<EmployeeDetails> Get()
        {
            return _service.GetAllEmployee();
        }

        // GET api/Employee/5
        [HttpGet("{id}")]
        public EmployeeDetails Get(int id)
        {
            return _service.GetEmployeeById(id);
        }

        // POST api/Employee
        [HttpPost]
        public IActionResult Post([FromBody]EmployeeDetails employee)
        {   
           string response= _service.AddEmployee(employee);
            return Ok(response);
        }

        // PUT api/Employee/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]EmployeeDetails employee)
        {
            _service.EditEmployee(id, employee);
        }

        // DELETE api/Employee/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.DeleteEmployee(id);
        }
    }
}
