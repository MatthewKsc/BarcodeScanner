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
        private readonly IEANService service;

        public EANController(IEANService service) {
            this.service = service;
        }

        [HttpGet]
        public ActionResult exampleEAN() {
            List<EAN> exampleEAN = service.GetEAN();

            return Ok(exampleEAN);
        }

        [HttpPost]
        public ActionResult checkEAN([FromBody] EAN ean) {
            if (string.IsNullOrEmpty(ean.Barcode) || string.IsNullOrWhiteSpace(ean.Barcode))
                return BadRequest("Please provide EAN code");

            var result = service.Scan(ean);

            if (!result) {
                return BadRequest("Invalid EAN provided");
            }

            return Ok("EAN is correct");
        }
    }
}
