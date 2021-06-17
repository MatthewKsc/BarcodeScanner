using BarcodeScanner.Interfaces;
using BarcodeScanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeScanner.Service
{

    public interface IITF14Service : IBaseService{
        List<BarcodeModel> GetBarcodes();
    }
    public class ITF14Service : IITF14Service
    {
        private readonly IControlNumberService controlNumberService;

        public ITF14Service(IControlNumberService controlNumberService) {
            this.controlNumberService = controlNumberService;
        }

        public List<BarcodeModel> GetBarcodes() {
            return new List<BarcodeModel>() {

            };
        }

        public bool Scan(BarcodeModel input) {
            return false;
        }
    }
}
