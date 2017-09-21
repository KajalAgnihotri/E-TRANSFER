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
    [Route("api/Asset")]
    public class AssetController : Controller
    {
            IAssetControllerService _service;
            public AssetController(IAssetControllerService service)
            {
                _service = service;
            }

            [HttpGet]
            public IEnumerable<AssetDetails> Get()
            {
                return _service.GetRequestStatus();
            }

            [HttpGet("{id}")]   
            public IEnumerable<AssetDetails> Get(int id)
            {
                return _service.GetAssetDetailsByEmpcode(id);
            }    
        
    }
}
