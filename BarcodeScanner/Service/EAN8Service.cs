using BarcodeScanner.DataSeeder;
using BarcodeScanner.Interfaces;
using BarcodeScanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BarcodeScanner.Service
{

    public interface IEAN8Service : IBaseService{
        List<BarcodeModel> GetBarcodes();
    }

    public class EAN8Service: IEAN8Service {

        private readonly IControlNumberService controlNumberService;

        public EAN8Service(IControlNumberService controlNumberService) {
            this.controlNumberService = controlNumberService;
        }

        public List<BarcodeModel> GetBarcodes() {
            return DataLoader.LoadData(BarcodeType.EAN8);
        }

        public bool Scan(BarcodeModel input) {
            StringBuilder EANstring = new StringBuilder().Append(input.Barcode);

            if (input.BarcodeType == BarcodeType.EAN8) {

                if (EANstring.Length == 7) {
                    EANstring.Insert(0, "0");
                }

                Regex EAN8Check = new Regex("^[0-9]{8}$");

                if (EAN8Check.IsMatch(EANstring.ToString())) {
                    return controlNumberService.CheckControlNumber(EANstring.ToString().Substring(0, 8));
                }
                else {
                    return false;
                }

            }

            return false;
        }
    }
}
