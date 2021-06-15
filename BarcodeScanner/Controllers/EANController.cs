﻿using AutoMapper;
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
    public class EANController : ControllerBase
    {
        private readonly IEANService service;
        private readonly IMapper mapper;

        public EANController(IEANService service, IMapper mapper) {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult exampleEAN() {
            List<EAN> exampleEAN = service.GetEAN();

            List<EANDto> result = mapper.Map<List<EANDto>>(exampleEAN);

            return Ok(result);
        }

        [HttpPost]
        public ActionResult checkEAN([FromBody] EANDto dto) {

            if (string.IsNullOrEmpty(dto.Barcode) || string.IsNullOrWhiteSpace(dto.Barcode))
                return BadRequest("Please provide EAN code");

            var ean = mapper.Map<EAN>(dto);

            var result = service.Scan(ean);

            if (!result) {
                return BadRequest("Invalid EAN provided");
            }

            return Ok("EAN is correct");
        }
    }
}
