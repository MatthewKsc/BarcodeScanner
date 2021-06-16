using AutoMapper;
using BarcodeScanner.DTOs;
using BarcodeScanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeScanner.Extensions
{
    public class MappingProfiles : Profile{
        
        public MappingProfiles() {
            CreateMap<BarcodeModel, BarcodeModelDto>()
                .ForMember(e => e.Type, d => d.MapFrom(s => s.BarcodeType.ToString("g")));

            CreateMap<BarcodeModelDto, BarcodeModel>()
                .ForMember(e => e.BarcodeType, d => d.MapFrom(s => Enum.Parse(typeof(BarcodeType), s.Type, true)));
        }

    }
}
