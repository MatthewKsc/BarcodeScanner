using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarcodeScanner.Models;
using BarcodeScanner.Service;
using NUnit.Framework;

namespace BardcodeScanner_Tests.ServiceTests
{
    [TestFixture]
    public class EANService_Test
    {

        private readonly EANService service;

        public EANService_Test() {
            this.service = new EANService();
        }

        [Test]
        public void EAN_8_Success_Pass() {
            var ean = new EAN("12345670", EANTypes.EAN8);

            var result = service.Scan(ean);

            Assert.AreEqual(true, result);
            Assert.AreNotEqual(false, result);
        }

        [Test]
        public void EAN_8_Failure_Pass() {
            var noBarcode = new EAN("", EANTypes.EAN8);
            var wrongEANType = new EAN("", EANTypes.EAN13);
            var noEANType = new EAN("12345670", EANTypes.None);

            var noBarcodeResult = service.Scan(noBarcode);
            var wrongEANTypeResult = service.Scan(wrongEANType);
            var noEANTypeResult = service.Scan(noEANType);


            Assert.AreEqual(false, noBarcodeResult);
            Assert.AreEqual(false, wrongEANTypeResult);
            Assert.AreEqual(false, noEANTypeResult);
        }

        [Test]
        public void EAN_13_Success_Pass() {

        }

        [Test]
        public void EAN_13_Failure_Pass() {

        }

    }
}
