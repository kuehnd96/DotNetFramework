using DK.Framework.UWP;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;

namespace DK.Framework.Store.WinPhone8.Tests
{
    [TestClass]
    public class ApplicationStateTest
    {
        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            Bootstrapper.Startup();
        }

        [TestMethod]
        //Ensures Set method does not accept null keys.
        public void TestNullKeySet()
        {
            ApplicationState applicationState = new ApplicationState();
            bool passed = false;
            
            try
            {
                applicationState.Set<int>(null, 4);
            }
            catch (ArgumentException)
            {
                // Test passes
                passed = true;
            }
            catch (Exception ex)
            {
                Assert.Fail(string.Format("Exception thrown of type {0}", ex.GetType().FullName));
            }

            if (!passed)
            {
                Assert.Fail("Expecting exception of type ArgumentException."); 
            }
        }

        [TestMethod]
        //Ensures Set method does not accept empty keys.
        public void TestEmptyKeySet()
        {
            ApplicationState applicationState = new ApplicationState();
            bool passed = false;
            
            try
            {
                applicationState.Set<int>(string.Empty, 4);
            }
            catch (ArgumentException)
            {
                // Test passes
                passed = true;
            }
            catch (Exception ex)
            {
                Assert.Fail(string.Format("Exception thrown of type {0}", ex.GetType().FullName));
            }

            if (!passed)
            {
                Assert.Fail("Expecting exception of type ArgumentException."); 
            }
        }

        [TestMethod]
        //Ensures Get method does not accept null keys
        public void TestNullKeyGet()
        {
            ApplicationState applicationState = new ApplicationState();
            bool passed = false;
            
            try
            {
                applicationState.Get<int>(null);
            }
            catch (ArgumentException)
            {
                // Test passes
                passed = true;
            }
            catch (Exception ex)
            {
                Assert.Fail(string.Format("Exception thrown of type {0}", ex.GetType().FullName));
            }

            if (!passed)
            {
                Assert.Fail("Expecting exception of type ArgumentException."); 
            }
        }

        [TestMethod]
        //Ensures Get method does not accept null keys
        public void TestEmptyKeyGet()
        {
            ApplicationState applicationState = new ApplicationState();
            bool passed = false;
            
            try
            {
                applicationState.Get<int>(string.Empty);
            }
            catch (ArgumentException)
            {
                // Test passes
                passed = true;
            }
            catch (Exception ex)
            {
                Assert.Fail(string.Format("Exception thrown of type {0}", ex.GetType().FullName));
            }

            if (!passed)
            {
                Assert.Fail("Expecting exception of type ArgumentException."); 
            }
        }

        [TestMethod]
        //Ensures Contains method does not accept null keys
        public void TestNullKeyContains()
        {
            ApplicationState applicationState = new ApplicationState();
            bool passed = false;
            
            try
            {
                applicationState.Contains(null);
            }
            catch (ArgumentException)
            {
                // Test passes
                passed = true;
            }
            catch (Exception ex)
            {
                Assert.Fail(string.Format("Exception thrown of type {0}", ex.GetType().FullName));
            }

            if (!passed)
            {
                Assert.Fail("Expecting exception of type ArgumentException."); 
            }
        }

        [TestMethod]
        //Ensures Contains method does not accept empty keys
        public void TestEmptyKeyContains()
        {
            ApplicationState applicationState = new ApplicationState();
            bool passed = false;
            
            try
            {
                applicationState.Contains(string.Empty);
            }
            catch (ArgumentException)
            {
                // Test passes
                passed = true;
            }
            catch (Exception ex)
            {
                Assert.Fail(string.Format("Exception thrown of type {0}", ex.GetType().FullName));
            }

            if (!passed)
            {
                Assert.Fail("Expecting exception of type ArgumentException."); 
            }
        }

        [TestMethod]
        //Ensures Remove method does not accept null keys
        public void TestNullKeyRemove()
        {
            ApplicationState applicationState = new ApplicationState();
            bool passed = false;
            
            try
            {
                applicationState.Remove(null);
            }
            catch (ArgumentException)
            {
                // Test passes
                passed = true;
            }
            catch (Exception ex)
            {
                Assert.Fail(string.Format("Exception thrown of type {0}", ex.GetType().FullName));
            }

            if (!passed)
            {
                Assert.Fail("Expecting exception of type ArgumentException."); 
            }
        }

        [TestMethod]
        //Ensures Remove method does not accept empty keys
        public void TestEmptyKeyRemove()
        {
            ApplicationState applicationState = new ApplicationState();
            bool passed = false;
            
            try
            {
                applicationState.Remove(string.Empty);
            }
            catch (ArgumentException)
            {
                // Test passes
                passed = true;
            }
            catch (Exception ex)
            {
                Assert.Fail(string.Format("Exception thrown of type {0}", ex.GetType().FullName));
            }

            if (!passed)
            {
                Assert.Fail("Expecting exception of type ArgumentException."); 
            }
        }

        [TestMethod]
        public void TestDataSet()
        {
            ApplicationState applicationState = new ApplicationState();
            string dataKey = "StringData";
            string data = "This is my data";
            string otherData = "This is my other data";

            // Test add
            Assert.IsTrue(!applicationState.Contains(dataKey), "Session state contains data.");
            applicationState.Set<string>(dataKey, data);
            Assert.IsTrue(applicationState.Contains(dataKey), "Session state doesn't contain newly-added data.");

            // Test update
            applicationState.Set<string>(dataKey, otherData);
            string storedData = applicationState.Get<string>(dataKey);
            Assert.AreEqual<string>(otherData, storedData, "Stored updated data does no match expected value.");
        }

        [TestMethod]
        public void TestDataGet()
        {
            ApplicationState applicationState = new ApplicationState();
            string dataKey = "NumberData";
            int data = 5674;

            applicationState.Set<int>(dataKey, data);
            int storedData = applicationState.Get<int>(dataKey);
            Assert.AreEqual<int>(data, storedData, "Stored data does not match expected data.");
        }

        [TestMethod]
        public void TestDataRemove()
        {
            ApplicationState applicationState = new ApplicationState();
            object data = "Go Packers!";
            string dataKey = "ObjectData";

            Assert.IsFalse(applicationState.Contains(dataKey), "Session state should not contain object data.");

            applicationState.Set<object>(dataKey, data);
            Assert.IsTrue(applicationState.Contains(dataKey), "Session state does not contain newly-added data.");

            applicationState.Remove(dataKey);
            Assert.IsFalse(applicationState.Contains(dataKey), "Session state remove failed.");
        }

        [TestMethod]
        //Ensures the removal of data not in session state runs without a problem
        public void TestMissingRemove()
        {
            ApplicationState applicationState = new ApplicationState();
            string missingDataKey = "MissingDataKey";

            applicationState.Remove(missingDataKey);
        }
    }
}
