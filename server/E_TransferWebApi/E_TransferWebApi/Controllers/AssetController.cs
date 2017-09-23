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
        public IActionResult Get()
        {
            
            try
            {
                List<AssetDetails> list = _service.GetRequestStatus();
                if (list.Count !=0)
                {
                    return Ok(list);
                }
                else
                {
                    return this.NotFound("The Asset list for this Employee could not be found");

                }

            }
            catch
            {
                return StatusCode(500);
            }
        }

        //Method 
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            
            try
            {
                List<AssetDetails> assetList = _service.GetAssetDetailsByEmpcode(id);
                if (assetList.Count == 0)
                {
                    return this.NotFound("The Asset list for this Employee could not be found");
                }
                else
                {
                    return Ok(assetList);
                }
            }
           
            catch
            {
              //  Console.WriteLine(e.StackTrace);
                return StatusCode(500);
            }

           
            
     }

    }
}