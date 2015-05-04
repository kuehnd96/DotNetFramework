using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;

namespace DK.Framework.Store.Win8.Tests
{
    [TestClass]
    public class ApplicationStateTest
    {
        ApplicationState _applicationState = new ApplicationState();

        [TestInitialize]
        public void Init()
        {
            Bootstrapper.Startup();
        }

        //[Description("Ensures Set method does not accept null keys.")]
        [TestMethod]
        public void TestNullKeySet()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                {
                    _applicationState.Set<int>(null, 4);
                });
        }

        [TestMethod]
        //[Description("Ensures Set method does not accept empty keys.")]
        public void TestEmptyKeySet()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                {
                    _applicationState.Set<int>(string.Empty, 4);
                });
        }

        [TestMethod]
        //[Description("Ensures Get method does not accept null keys.")]
        public void TestNullKeyGet()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                {
                    _applicationState.Get<int>(null);
                });
        }

        [TestMethod]
        //[Description("Ensures Get method does not accept null keys.")]
        public void TestEmptyKeyGet()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                {
                    _applicationState.Get<int>(string.Empty);
                });
        }

        [TestMethod]
        
        //[Description("Ensures Contains method does not accept null keys.")]
        public void TestNullKeyContains()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                {
                    _applicationState.Contains(null);
                });
        }

        [TestMethod]
        //[Description("Ensures Contains method does not accept empty keys.")]
        public void TestEmptyKeyContains()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                _applicationState.Contains(string.Empty);
            });
        }

        [TestMethod]
        //[Description("Ensures Remove method does not accept null keys.")]
        public void TestNullKeyRemove()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                {
                    _applicationState.Remove(null);
                });
        }

        [TestMethod]
        //[Description("Ensures Remove method does not accept empty keys.")]
        public void TestEmptyKeyRemove()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                {
                    _applicationState.Remove(string.Empty);
                });
        }

        [TestMethod]
        public void TestDataSet()
        {
            string dataKey = "StringData";
            string data = "This is my data";
            string otherData = "This is my other data";

            // Test add
            Assert.IsTrue(!_applicationState.Contains(dataKey), "Session state contains data.");
            _applicationState.Set<string>(dataKey, data);
            Assert.IsTrue(_applicationState.Contains(dataKey), "Session state doesn't contain newly-added data.");

            // Test update
            _applicationState.Set<string>(dataKey, otherData);
            string storedData = _applicationState.Get<string>(dataKey);
            Assert.AreEqual<string>(otherData, storedData, "Stored updated data does no match expected value.");
        }

        [TestMethod]
        public void TestDataGet()
        {
            string dataKey = "NumberData";
            int data = 5674;

            _applicationState.Set<int>(dataKey, data);
            int storedData = _applicationState.Get<int>(dataKey);
            Assert.AreEqual<int>(data, storedData, "Stored data does not match expected data.");
        }

        [TestMethod]
        public void TestDataRemove()
        {
            var data = "Test data";
            string dataKey = "ObjectData";

            Assert.IsFalse(_applicationState.Contains(dataKey), "Session state should not contain object data.");

            _applicationState.Set<object>(dataKey, data);
            Assert.IsTrue(_applicationState.Contains(dataKey), "Session state does not contain newly-added data.");

            _applicationState.Remove(dataKey);
            Assert.IsFalse(_applicationState.Contains(dataKey), "Session state remove failed.");
        }

        [TestMethod]
        //[Description("Ensures the removal of data not in session state runs without a problem.")]
        public void TestMissingRemove()
        {
            string missingDataKey = "MissingDataKey";

            _applicationState.Remove(missingDataKey);
        }
    }
}
