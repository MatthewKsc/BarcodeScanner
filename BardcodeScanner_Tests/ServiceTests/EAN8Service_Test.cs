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
    public class EAN8Service_Test
    {
        private readonly IControlNumberService controlNumberService;
        private readonly IEAN8Service service;

        public EAN8Service_Test() {
            this.controlNumberService = new ControlNumberService();
            this.service = new EAN8Service(this.controlNumberService);
        }


        [Test]
        [TestCase("3498125")]
        [TestCase("12345670")]
        [TestCase("36455065")]
        [TestCase("8723093")]
        public void Valid_EAN8_Barcode_Test(string barcode) {
            var ean = new BarcodeModel(barcode, BarcodeType.EAN8);

            var result = service.Scan(ean);

            Assert.AreEqual(true, result);
        }

        [Test]
        [TestCase("invalids")]
        [TestCase("")]
        [TestCase("dwdaw12345670dwa")]
        [TestCase("36455064")]
        public void Invalid_EAN8_Barcode_Test(string barcode) {
            var ean = new BarcodeModel(barcode, BarcodeType.EAN8);

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
