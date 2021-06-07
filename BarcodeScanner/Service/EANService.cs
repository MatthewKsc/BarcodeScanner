using BarcodeScanner.Interfaces;
using BarcodeScanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeScanner.Service
{
    public class EANService : IBarcodeService<EAN> {
        public bool Scan(EAN input) {
            if(input.EANType == EANTypes.EAN13) {
                return true;
            }

            if(input.EANType == EANTypes.EAN8) {
                return true;
            }

            return false;
        }
    }
}
