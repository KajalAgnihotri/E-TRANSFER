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
    [Route("api/AssetAssignedUser")]
    public class AssetAssignedUserController : Controller
    {
        IAssetAssignedUserService _service;
        public AssetAssignedUserController(IAssetAssignedUserService service)
        {
            _service = service;
        }
        // GET: api/values
        [HttpGet("{id}")]
        public IEnumerable<AssetDetails> Get(int id)
        {
            return _service.GetAssetListByEmpcode(id);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]AssetDetails asset)
        {
            _service.UpdateAssetStatus(id, asset);
        }
        
    }
}
