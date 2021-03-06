using AutoMapper;
using BarcodeScanner.DTOs;
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
    public class BarcodeCheckController : ControllerBase
    {
        private readonly IBarcodeService service;
        private readonly IMapper mapper;

        public BarcodeCheckController(IBarcodeService service, IMapper mapper) {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpPost]
        public ActionResult checkEAN([FromBody] BarcodeModelDto dto) {

            if (string.IsNullOrEmpty(dto.Barcode) || string.IsNullOrWhiteSpace(dto.Barcode))
                return BadRequest("Please provide EAN code");

            var ean = mapper.Map<BarcodeModel>(dto);

            var result = service.Scan(ean);

            if (!result) {
                return BadRequest("Invalid EAN provided");
            }

            return Ok("EAN is correct");
        }
    }
}
