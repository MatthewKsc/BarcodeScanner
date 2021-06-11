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
    public class EANService : IBarcodeService<EAN> {
        public bool Scan(EAN input) {
            StringBuilder EANstring = new StringBuilder().Append(input.Barcode);

            if(input.EANType == EANTypes.EAN8) {
                
                if(EANstring.Length == 7) {
                    EANstring.Insert(0, "0");
                }

                Regex EAN8Check = new Regex("^[0-9]{8}$");

                if (EAN8Check.IsMatch(EANstring.ToString())) {
                    return checkControlNumber(EANstring.ToString().Substring(0, 8));
                }
                else {
                    return false;
                }

            }

            if(input.EANType == EANTypes.EAN13) {

                if(EANstring.Length == 12) {
                    EANstring.Insert(0, "0");
                }

                Regex EAN13Check = new Regex("^[0-9]{13}$");

                if (EAN13Check.IsMatch(EANstring.ToString())) {
                    return checkControlNumber(EANstring.ToString().Substring(0, 13));
                }
                else {
                    return false;
                }
            }

            return false;
        }

        private bool checkControlNumber(string ean) {
            char[] eanArray = ean.ToCharArray();
            int sumOdds = 0;
            int sumEven = 0;
            int controlNumber;
            bool switcher = true;
            for(int i=eanArray.Length-2; i>=0; i--) {
                if (switcher) {
                    sumOdds += (int) Char.GetNumericValue(eanArray[i]);
                    switcher = false;
                }
                else {
                    sumEven += (int)Char.GetNumericValue(eanArray[i]);
                    switcher = true;
                }
            }

            sumOdds *= 3;

            if ((sumOdds + sumEven) % 10==0) {
                controlNumber = 0;
            }
            else {
                controlNumber = 10 - ((sumOdds + sumEven) % 10);
            }

            if (controlNumber == (int) Char.GetNumericValue(eanArray[eanArray.Length - 1])) {
                return true;
            }
            else {
                return false;
            }

        }
    }
}
