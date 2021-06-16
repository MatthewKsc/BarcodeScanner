using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeScanner.Models
{
    public class BarcodeModel
    {
        public string Barcode { get; set; }
        public BarcodeType BarcodeType { get; set; }

        public BarcodeModel() {
        }

        public BarcodeModel(string barcode, BarcodeType barcodeType){
            Barcode = barcode;
            BarcodeType = barcodeType;
        }
    }
}
