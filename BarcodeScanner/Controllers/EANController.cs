using BarcodeScanner.Interfaces;
using BarcodeScanner.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeScanner.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EANController : ControllerBase
    {
        private readonly IBarcodeService<EAN> service;

        public EANController(IBarcodeService<EAN> service) {
            this.service = service;
        }


        [HttpGet]
        public ActionResult checkEAN([FromBody] EAN ean) {
            var result = service.Scan(ean);

            if (!result) {
                return BadRequest("Wrong EAN code provided");
            }

            return Ok("EAN is correct");
        }
    }
}
