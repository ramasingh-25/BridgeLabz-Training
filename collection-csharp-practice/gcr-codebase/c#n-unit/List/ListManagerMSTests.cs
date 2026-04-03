using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Calculator;

namespace CalculatorTests
{
    [TestClass]
    public class ListManagerMSTests
    {
        private ListManager manager;
        private List<int> list;

        [TestInitialize]
        public void Setup()
        {
            manager = new ListManager();
            list = new List<int>();
        }

        [TestMethod]
        public void AddElement_Test()
        {
            manager.AddElement(list, 10);
            Assert.IsTrue(list.Contains(10));
        }

        [TestMethod]
        public void RemoveElement_Test()
        {
            list.Add(5);
            manager.RemoveElement(list, 5);
            Assert.IsFalse(list.Contains(5));
        }

        [TestMethod]
        public void GetSize_Test()
        {
            manager.AddElement(list, 1);
            manager.AddElement(list, 2);
            Assert.AreEqual(2, manager.GetSize(list));
        }
    }
}
