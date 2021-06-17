using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarcodeScanner.Interfaces;
using BarcodeScanner.Models;
using BarcodeScanner.Service;
using NUnit.Framework;

namespace BardcodeScanner_Tests.ServiceTests
{
    [TestFixture]
    public class BarcodeService_Test
    {

        private readonly IBarcodeService service;
        private readonly IControlNumberService controlNumberService;

        public BarcodeService_Test() {
            this.controlNumberService = new ControlNumberService();
            this.service = new BarcodeService(new EAN8Service(controlNumberService), new EAN13Service(controlNumberService));
        }

        //TODO get TestCases from file with EAN8 and EAN13 sets of data

        [Test]
        public void Valid_Barcodes_Test() {
            var barcodes = GetBarcodes_Valid();

            var result = barcodes.TrueForAll(b => service.Scan(b) == true);

            Assert.IsTrue(result);
        }

        [Test]
        public void Invalid_Barcodes_Test() {
            var barcodes = GetBarcodes_Invalid();

            var result = barcodes.TrueForAll(b => service.Scan(b) == true);

            Assert.IsFalse(result);
        }

        [Test]
        public void None_Type_EAN_Test() {
            var eanNoType = new BarcodeModel("", BarcodeType.None);

            var result = service.Scan(eanNoType);

            Assert.AreEqual(false, result);
            Assert.AreNotEqual(true, result);
        }



        //---Data generation---\\
        private List<BarcodeModel> GetBarcodes_Valid() {
            return new List<BarcodeModel>() {
               new BarcodeModel("12345670", BarcodeType.EAN8),
               new BarcodeModel("3498125", BarcodeType.EAN8),
               new BarcodeModel("5485415953755", BarcodeType.EAN13),
               new BarcodeModel("691536044738", BarcodeType.EAN13)
            };
        }

        private List<BarcodeModel> GetBarcodes_Invalid() {
            return new List<BarcodeModel>() {
               new BarcodeModel("invalids", BarcodeType.EAN8),
               new BarcodeModel("", BarcodeType.EAN8),
               new BarcodeModel("dwdaw12345670dwa", BarcodeType.EAN8),
               new BarcodeModel("36455064", BarcodeType.EAN8),
               new BarcodeModel("", BarcodeType.EAN13),
               new BarcodeModel("invalids", BarcodeType.EAN13),
               new BarcodeModel("4427328265695", BarcodeType.EAN13)
            };
        }
    }
}
