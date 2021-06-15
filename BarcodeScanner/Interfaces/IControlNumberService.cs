using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeScanner.Interfaces
{
    public interface IControlNumberService
    {
        bool CheckControlNumber(string barcode);
    }
}
