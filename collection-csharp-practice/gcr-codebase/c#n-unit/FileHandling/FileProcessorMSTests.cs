using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Calculator;

namespace CalculatorTests
{
    [TestClass]
    public class FileProcessorMSTests
    {
        private FileProcessor processor;

        [TestInitialize]
        public void Setup()
        {
            processor = new FileProcessor();
        }

        [TestMethod]
        public void Write_And_Read_File_Successfully()
        {
            string fileName = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "test_mstest_ok.txt"
            );

            if (File.Exists(fileName))
                File.Delete(fileName);

            processor.WriteToFile(fileName, "Hello MSTest");
            string content = processor.ReadFromFile(fileName);

            Assert.AreEqual("Hello MSTest", content);

            File.Delete(fileName);
        }

        [TestMethod]
        public void File_Should_Exist_After_Writing()
        {
            string fileName = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "test_mstest_exists.txt"
            );

            if (File.Exists(fileName))
                File.Delete(fileName);

            processor.WriteToFile(fileName, "Check File");

            Assert.IsTrue(File.Exists(fileName));

            File.Delete(fileName);
        }

        [TestMethod]
        public void Read_NonExisting_File_Should_Throw_Exception()
        {
            // 🔥 GUARANTEED NON-EXISTING FILE
            string missingFile = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                Guid.NewGuid().ToString() + ".txt"
            );

            // Double safety check
            if (File.Exists(missingFile))
                File.Delete(missingFile);

            try
            {
                processor.ReadFromFile(missingFile);
                Assert.Fail("Expected FileNotFoundException was not thrown");
            }
            catch (FileNotFoundException)
            {
                Assert.IsTrue(true);
            }
        }
    }
}
