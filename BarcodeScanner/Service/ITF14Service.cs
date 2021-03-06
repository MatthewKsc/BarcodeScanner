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
            return DataLoader.LoadData(BarcodeType.ITF14);
        }

        public bool Scan(BarcodeModel input) {
            StringBuilder ITFString = new StringBuilder().Append(input.Barcode);

            if (input.BarcodeType == BarcodeType.ITF14) {

                if (ITFString.Length == 13) {
                    ITFString.Insert(0, "0");
                }

                Regex ITF14Check = new Regex("^[0-9]{14}$");

                if (ITF14Check.IsMatch(ITFString.ToString())) {
                    return controlNumberService.CheckControlNumber(ITFString.ToString().Substring(0, 14));
                }
                else {
                    return false;
                }

            }

            return false;
        }
    }
}
