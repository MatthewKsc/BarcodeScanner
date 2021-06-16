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
    public class EANService_Test
    {

        private readonly IEANService service;
        private readonly IControlNumberService controlNumberService;

        public EANService_Test() {
            this.controlNumberService = new ControlNumberService();
            this.service = new EANService(this.controlNumberService);
        }

        //TODO get TestCases from file with EAN8 and EAN13 sets of data

        [Test]
        [TestCase("3498125")]
        [TestCase("12345670")]
        [TestCase("36455065")]
        [TestCase("8723093")]
        public void Valid_EAN8_Barcode_Test(string barcode) {
            var ean = new BarcodeModel(barcode, BarcodeType.EAN8);

            var result = service.Scan(ean);

            Assert.AreEqual(true, result);
            Assert.AreNotEqual(false, result);
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
            Assert.AreNotEqual(true, result);
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
            Assert.AreNotEqual(false, result);
        }

        [Test]
        [TestCase("invalids")]
        [TestCase("")]
        [TestCase("dwdaw7192131489335dwa")]
        [TestCase("4427328265695")]
        public void Invalid_EAN8_Test(string barcode) {
            var ean = new BarcodeModel(barcode, BarcodeType.EAN13);

            var result = service.Scan(ean);

            Assert.AreEqual(false, result);
            Assert.AreNotEqual(true, result);
        }

        [Test]
        public void None_Type_EAN_Test() {
            var eanNoType = new BarcodeModel("", BarcodeType.None);

            var result = service.Scan(eanNoType);

            Assert.AreEqual(false, result);
            Assert.AreNotEqual(true, result);
        }
    }
}
