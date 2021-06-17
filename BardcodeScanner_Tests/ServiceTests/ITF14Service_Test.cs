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
    public class ITF14Service_Test
    {
        private readonly IControlNumberService controlNumberService;
        private readonly IITF14Service service;

        public ITF14Service_Test() {
            this.controlNumberService = new ControlNumberService();
            this.service = new ITF14Service(this.controlNumberService);
        }

        [Test]
        [TestCase("33013851979966")]
        [TestCase("5814441493650")]
        [TestCase("23133631169073")]
        [TestCase("46443094168836")]
        public void Valid_ITF14_Barcode_Test(string barcode) {
            var ean = new BarcodeModel(barcode, BarcodeType.ITF14);

            var result = service.Scan(ean);

            Assert.AreEqual(true, result);
        }

        [Test]
        [TestCase("invalids")]
        [TestCase("")]
        [TestCase("23193631169077")]
        [TestCase("dwdaw309411dwa")]
        public void Invalid_ITF14_Barcode_Test(string barcode) {
            var ean = new BarcodeModel(barcode, BarcodeType.ITF14);

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
