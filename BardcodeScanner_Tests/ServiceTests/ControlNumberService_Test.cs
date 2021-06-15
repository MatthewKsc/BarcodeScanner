using BarcodeScanner.Interfaces;
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
    public class ControlNumberService_Test{

        private readonly IControlNumberService service;

        public ControlNumberService_Test() {
            this.service = new ControlNumberService();
        }

        [Test]
        [TestCase("12345670")]
        [TestCase("36455065")]
        [TestCase("1372177298566")]
        [TestCase("0691536044738")]
        public void checkControlNumber_Test_ReturnTrue(string barcode) {
            var result = service.CheckControlNumber(barcode);

            Assert.AreEqual(true, result);
            Assert.AreNotEqual(false, result);
        }

        [Test]
        [TestCase("02995241")]
        [TestCase("92733383")]
        [TestCase("8016633322829")]
        [TestCase("7172131489335")]
        public void checkControlNumber_Test_ReturnFalse(string barcode) {
            var result = service.CheckControlNumber(barcode);

            Assert.AreEqual(false, result);
            Assert.AreNotEqual(true, result);
        }

    }
}
