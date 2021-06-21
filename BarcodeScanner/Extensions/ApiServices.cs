using BarcodeScanner.Interfaces;
using BarcodeScanner.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeScanner.Extensions
{
    public static class ApiServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services) {

            services.AddScoped<IBarcodeService, BarcodeService>();
            services.AddScoped<IControlNumberService, ControlNumberService>();
            services.AddScoped<IEAN13Service, EAN13Service>();
            services.AddScoped<IEAN8Service, EAN8Service>();
            services.AddScoped<IITF14Service, ITF14Service>();
            services.AddScoped<IUPCAService, UPCAService>();

            return services;
        }
    }
}
