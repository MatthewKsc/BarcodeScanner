using BarcodeScanner.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeScanner.DataSeeder
{
    public static class DataLoader
    {

        private static readonly Dictionary<BarcodeType, string> pathsMap = new Dictionary<BarcodeType, string>
        {
            { BarcodeType.EAN8, @"DataSeeder\JsonFiles\EAN8.json" },
            { BarcodeType.EAN13, @"DataSeeder\JsonFiles\EAN13.json" },
            { BarcodeType.ITF14, @"DataSeeder\JsonFiles\ITF14.json" },
            { BarcodeType.UPCA, @"DataSeeder\JsonFiles\UPCA.json" },
        };

        public static List<BarcodeModel> LoadData(BarcodeType type) {
            List<BarcodeModel> results;

            using (StreamReader reader = new StreamReader(pathsMap[type])) {
                string json = reader.ReadToEnd();
                results = JsonConvert.DeserializeObject<List<BarcodeModel>>(json);
            }

            return results;
        }
    }
}
