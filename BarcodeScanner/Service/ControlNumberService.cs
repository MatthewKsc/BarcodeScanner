using BarcodeScanner.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeScanner.Service
{
    public class ControlNumberService : IControlNumberService {
        public bool CheckControlNumber(string barcode) {
            char[] eanArray = barcode.ToCharArray();
            int sumOdds = 0;
            int sumEven = 0;
            int controlNumber;
            bool switcher = true;

            for (int i = eanArray.Length - 2; i >= 0; i--) {
                if (switcher) {
                    sumOdds += (int)Char.GetNumericValue(eanArray[i]);
                    switcher = false;
                }
                else {
                    sumEven += (int)Char.GetNumericValue(eanArray[i]);
                    switcher = true;
                }
            }

            sumOdds *= 3;

            if ((sumOdds + sumEven) % 10 == 0) {
                controlNumber = 0;
            }
            else {
                controlNumber = 10 - ((sumOdds + sumEven) % 10);
            }

            if (controlNumber == (int)Char.GetNumericValue(eanArray[eanArray.Length - 1])) {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
