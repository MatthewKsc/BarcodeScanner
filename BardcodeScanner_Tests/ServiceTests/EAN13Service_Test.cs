using BarcodeScanner.Interfaces;
using BarcodeScanner.Models;
using BarcodeScanner.Service;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BardcodeScanner_Tests.ServiceTests
{
    [TestFixture]
    public class EAN13Service_Test
    {
        private readonly IControlNumberService controlNumberService;
        private readonly IEAN13Service service;

        public EAN13Service_Test() {
            this.controlNumberService = new ControlNumberService();
            this.service = new EAN13Service(this.controlNumberService);
        }


        [Test]
        [TestCase("5485415953755")]
        [TestCase("1372177298566")]
        [TestCase("691536044738")]
        [TestCase("953053302624")]
        public void Valid_EAN13_Test(string barcode) {
            var ean = new BarcodeModel(barcode, BarcodeType.EAN13);

            var result = service.Scan(ean);

            Assert.AreEqual(true, result);
        }

        [Test]
        [TestCase("invalids")]
        [TestCase("")]
        [TestCase("dwdaw7192131489335dwa")]
        [TestCase("4427328265695")]
        public void Invalid_EAN13_Test(string barcode) {
            var ean = new BarcodeModel(barcode, BarcodeType.EAN13);

            var result = service.Scan(ean);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void GetBarcodes_Test() {
            var result = service.GetBarcodes();

            Assert.NotNull(result);
            Assert.NotZero(result.Count);
        }
    }
}
