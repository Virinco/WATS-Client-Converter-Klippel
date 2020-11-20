using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;
using Virinco.WATS.Interface;
using System.IO;

namespace KlippelConverters
{
    [TestClass]
    public class ConverterTests : TDM
    {
        [TestMethod]
        public void SetupClient()
        {
            SetupAPI(null, "", "Test", true);
            RegisterClient("your wats", "username", "password/token");
            InitializeAPI(true);
        }

        [TestMethod]
        public void TestLogConverter()
        {
            const string fileName = @"Data\Log\DUT xyz116 2020-05-14 10-02-51-3 UTC+0200.txt";

            InitializeAPI(true);
            KlippelLogConverter converter = new KlippelLogConverter();
            using (FileStream file = new FileStream(fileName, FileMode.Open))
            {
                SetConversionSource(new FileInfo(fileName), null, converter.ConverterParameters);
                Report uut = converter.ImportReport(this, file);
                Submit(uut);
            }
        }
    }
}
