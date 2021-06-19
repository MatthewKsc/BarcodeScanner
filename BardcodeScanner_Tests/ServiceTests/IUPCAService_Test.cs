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
    public class IUPCAService_Test{

        private readonly IControlNumberService controlNumberService;
        private readonly IUPCAService service;

        public IUPCAService_Test() {
            this.controlNumberService = new ControlNumberService();
            this.service = new UPCAService(controlNumberService);
        }

        [Test]
        [TestCase("795608291379")]
        [TestCase("16555801740")]
        [TestCase("451398834577")]
        [TestCase("243200923360")]
        public void Valid_UPCA_Barcode_Test(string barcode) {
            var ean = new BarcodeModel(barcode, BarcodeType.UPCA);

            var result = service.Scan(ean);

            Assert.AreEqual(true, result);
        }

        [Test]
        [TestCase("ds741832rt85")]
        [TestCase("")]
        [TestCase("2432009233")]
        [TestCase("442937901968")]
        public void Invalid_UPCA_Barcode_Test(string barcode) {
            var ean = new BarcodeModel(barcode, BarcodeType.UPCA);

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
