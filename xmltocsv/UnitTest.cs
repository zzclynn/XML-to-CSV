using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FormatConversion.Convertor;
using FormatConversion.Problems;
using System.IO;

namespace xmltocsv
{
    [TestFixture]
    public class UnitTest
    {
        private string mainPath = AppDomain.CurrentDomain.BaseDirectory;

        [Test]
        public void csvExists()
        {
            File.Delete(mainPath + @"\sample_data.csv");
            
            XmlToCsvConversion convertor = new XmlToCsvConversion(mainPath, "sample_data");
            // Initialize the problem
            StudentEnrollment bomboraAssignment = new StudentEnrollment();

            // Sign the problem to the convertor
            convertor.Problem = bomboraAssignment;

            // Execute the conversion
            convertor.Execute();

            Assert.True(File.Exists(mainPath + @"\sample_data.csv"));
        }
    }
}
