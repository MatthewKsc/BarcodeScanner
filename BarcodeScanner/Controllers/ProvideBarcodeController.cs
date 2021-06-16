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
    [Route("api/example")]
    public class ProvideBarcodeController :ControllerBase
    {
        private readonly IBarcodeService barcodeService;

        public ProvideBarcodeController(IBarcodeService barcodeService) {
            this.barcodeService = barcodeService;
        }


        [HttpGet]
        public ActionResult GetExampleBarcode([FromBody] string barcodeType) {

            if (string.IsNullOrEmpty(barcodeType) || string.IsNullOrWhiteSpace(barcodeType))
                return BadRequest("Please provide EAN type");

            BarcodeType type = (BarcodeType) Enum.Parse(typeof(BarcodeType), barcodeType, true);

            var result = barcodeService.GetBarcodes(type);

            return Ok(result);
        }
    }
}
