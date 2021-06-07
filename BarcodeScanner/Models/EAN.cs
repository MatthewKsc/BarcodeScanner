using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeScanner.Models
{
    public class EAN : BaseModel
    {
        public EANTypes EANType { get; set; }

        public EAN() {
        }

        public EAN(string barcode, EANTypes eANType) : base(barcode){
            EANType = eANType;
        }
    }
}
