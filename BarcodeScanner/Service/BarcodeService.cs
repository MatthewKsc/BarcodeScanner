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
    public class BarcodeService : IBarcodeService {

        private readonly EAN8Service ean8Service;
        private readonly IEAN13Service ean13Service;

        public BarcodeService(EAN8Service ean8Service, IEAN13Service ean13Service) {
            this.ean8Service = ean8Service;
            this.ean13Service = ean13Service;
        }

        public List<BarcodeModel> GetBarcodes(BarcodeType barcodeType) {
            switch (barcodeType) {
                case BarcodeType.EAN13: return ean13Service.GetBarcodes();
                case BarcodeType.EAN8: return ean8Service.GetBarcodes();
                default: throw new ArgumentException("Wrong barcode type provided");
            }
        }

        public bool Scan(BarcodeModel input) {

            switch (input.BarcodeType) {
                case BarcodeType.EAN13: return ean13Service.Scan(input);
                case BarcodeType.EAN8: return ean8Service.Scan(input);
                case BarcodeType.None: return false;
                default: return false;
            }
        }
    }
}
