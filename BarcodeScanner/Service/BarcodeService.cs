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

        private readonly IEAN8Service ean8Service;
        private readonly IEAN13Service ean13Service;
        private readonly IITF14Service itf14Service;
        private readonly IUPCAService upcaService;

        public BarcodeService(IEAN8Service ean8Service, 
                              IEAN13Service ean13Service, 
                              IITF14Service itf14Service,
                              IUPCAService upcaService) {
            this.ean8Service = ean8Service;
            this.ean13Service = ean13Service;
            this.itf14Service = itf14Service;
            this.upcaService = upcaService;
        }

        public List<BarcodeModel> GetBarcodes(BarcodeType barcodeType) {
            switch (barcodeType) {
                case BarcodeType.EAN13: return ean13Service.GetBarcodes();
                case BarcodeType.EAN8: return ean8Service.GetBarcodes();
                case BarcodeType.ITF14: return itf14Service.GetBarcodes();
                case BarcodeType.UPCA: return upcaService.GetBarcodes();
                default: throw new ArgumentException("Wrong barcode type provided");
            }
        }

        public bool Scan(BarcodeModel input) {

            switch (input.BarcodeType) {
                case BarcodeType.EAN13: return ean13Service.Scan(input);
                case BarcodeType.EAN8: return ean8Service.Scan(input);
                case BarcodeType.ITF14: return itf14Service.Scan(input);
                case BarcodeType.UPCA: return upcaService.Scan(input);
                case BarcodeType.None: return false;
                default: return false;
            }
        }
    }
}
