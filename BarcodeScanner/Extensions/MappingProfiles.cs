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
            CreateMap<EAN, EANDto>()
                .ForMember(e => e.Type, d => d.MapFrom(s => s.EANType.ToString("g")));

            CreateMap<EANDto, EAN>()
                .ForMember(e => e.EANType, d => d.MapFrom(s => Enum.Parse(typeof(EANTypes), s.Type, true)));
        }

    }
}
