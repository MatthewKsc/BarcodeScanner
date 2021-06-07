using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeScanner.Models
{
    public class BaseModel
    {
        public string Barcode { get; set; }

        public BaseModel() {

        }

        public BaseModel(string barcode) {
            Barcode = barcode;
        }
    }
}
