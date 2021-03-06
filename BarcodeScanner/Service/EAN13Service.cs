using BarcodeScanner.DataSeeder;
using BarcodeScanner.Interfaces;
using BarcodeScanner.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BarcodeScanner.Service {

    public interface IEAN13Service : IBaseService{
        List<BarcodeModel> GetBarcodes();
    }

    public class EAN13Service : IEAN13Service {

        private readonly IControlNumberService controlNumberService;

        public EAN13Service(IControlNumberService controlNumberService) {
            this.controlNumberService = controlNumberService;
        }

        public List<BarcodeModel> GetBarcodes() {
            return DataLoader.LoadData(BarcodeType.EAN13);
        }

        public bool Scan(BarcodeModel input) {
            StringBuilder EANstring = new StringBuilder().Append(input.Barcode);

            if (input.BarcodeType == BarcodeType.EAN13) {

                if (EANstring.Length == 12) {
                    EANstring.Insert(0, "0");
                }

                Regex EAN13Check = new Regex("^[0-9]{13}$");

                if (EAN13Check.IsMatch(EANstring.ToString())) {
                    return controlNumberService.CheckControlNumber(EANstring.ToString().Substring(0, 13));
                }
                else {
                    return false;
                }

            }

            return false;
        }
    }
}