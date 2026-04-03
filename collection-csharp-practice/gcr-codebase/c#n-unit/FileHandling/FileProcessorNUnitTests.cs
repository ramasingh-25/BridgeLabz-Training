using NUnit.Framework;
using System.IO;
using Calculator;

namespace Calculator.Tests
{
    [TestFixture]
    public class FileProcessorNUnitTests
    {
        private FileProcessor processor;
        private string fileName;

        [SetUp]
        public void Setup()
        {
            processor = new FileProcessor();
            fileName = "test_nunit.txt";

            // Ensure clean state
            if (File.Exists(fileName))
                File.Delete(fileName);
        }

        [TearDown]
        public void Cleanup()
        {
            if (File.Exists(fileName))
                File.Delete(fileName);
        }

        [Test]
        public void Write_And_Read_File_Successfully()
        {
            processor.WriteToFile(fileName, "Hello NUnit");
            string content = processor.ReadFromFile(fileName);

            Assert.AreEqual("Hello NUnit", content);
        }

        [Test]
        public void File_Should_Exist_After_Writing()
        {
            processor.WriteToFile(fileName, "Check File");
            Assert.IsTrue(File.Exists(fileName));
        }

        [Test]
        public void Read_NonExisting_File_Should_Throw_Exception()
        {
            Assert.Throws<FileNotFoundException>(() =>
                processor.ReadFromFile("nofile_nunit.txt"));
        }
    }
}
