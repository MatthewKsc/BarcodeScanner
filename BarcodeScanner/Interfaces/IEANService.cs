using BarcodeScanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeScanner.Interfaces
{
    public interface IEANService :IBarcodeService<BarcodeModel>
    {
        List<BarcodeModel> GetEAN();
    }
}
