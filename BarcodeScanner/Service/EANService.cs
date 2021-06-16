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
    public class EANService : IEANService {
        private readonly IControlNumberService controlNumberService;

        public EANService(IControlNumberService controlNumberService) {
            this.controlNumberService = controlNumberService;
        }

        public List<BarcodeModel> GetEAN() {
            List<BarcodeModel> EANs = new List<BarcodeModel>() {
                new BarcodeModel{Barcode= "265792032008" ,BarcodeType= BarcodeType.EAN13},
                new BarcodeModel{Barcode= "3702235451288" ,BarcodeType= BarcodeType.EAN13},
                new BarcodeModel{Barcode= "90733383" ,BarcodeType= BarcodeType.EAN8},
                new BarcodeModel{Barcode= "55056533" ,BarcodeType= BarcodeType.EAN8}
            };

            return EANs;
        }

        public bool Scan(BarcodeModel input) {
            StringBuilder EANstring = new StringBuilder().Append(input.Barcode);

            if(input.BarcodeType == BarcodeType.EAN8) {
                
                if(EANstring.Length == 7) {
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

            if(input.BarcodeType == BarcodeType.EAN13) {

                if(EANstring.Length == 12) {
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
