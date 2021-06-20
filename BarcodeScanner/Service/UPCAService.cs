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
    public interface IUPCAService: IBaseService {
        List<BarcodeModel> GetBarcodes();
    }

    public class UPCAService : IUPCAService {

        private readonly IControlNumberService controlNumberService;

        public UPCAService(IControlNumberService controlNumberService) {
            this.controlNumberService = controlNumberService;
        }

        public List<BarcodeModel> GetBarcodes() {
            return new List<BarcodeModel>() {
                new BarcodeModel("795608291379", BarcodeType.UPCA),
                new BarcodeModel("16555801740", BarcodeType.UPCA),
                new BarcodeModel("451398834577", BarcodeType.UPCA),
                new BarcodeModel("442937901966", BarcodeType.UPCA)
            };
        }

        public bool Scan(BarcodeModel input) {
            StringBuilder UPCAstring = new StringBuilder().Append(input.Barcode);

            if (input.BarcodeType == BarcodeType.UPCA) {

                if (UPCAstring.Length ==11) {
                    UPCAstring.Insert(0, "0");
                }

                Regex UPCACheck = new Regex("^[0-9]{12}$");

                if (UPCACheck.IsMatch(UPCAstring.ToString())) {
                    return controlNumberService.CheckControlNumber(UPCAstring.ToString().Substring(0, 12));
                }
                else {
                    return false;
                }

            }

            return false;
        }
    }
}
