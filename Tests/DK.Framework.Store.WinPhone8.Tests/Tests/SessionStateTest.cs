using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;

namespace DK.Framework.Store.WinPhone8.Tests
{
    [TestClass]
    public class SessionStateTest
    {
        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            //Bootstrapper.Startup();
        }

        [TestMethod]
        //Ensures Set method does not accept null keys
        public void TestNullKeySet()
        {
            SessionState sessionState = new SessionState();
            bool passed = false;
            
            try
            {
                sessionState.Set<int>(null, 4);
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
        //Ensures Set method does not accept empty keys
        public void TestEmptyKeySet()
        {
            SessionState sessionState = new SessionState();
            bool passed = false;
            
            try
            {
                sessionState.Set<int>(string.Empty, 4);
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
            SessionState sessionState = new SessionState();
            bool passed = false;
            
            try
            {
                sessionState.Get<int>(null);
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
            SessionState sessionState = new SessionState();
            bool passed = false;
            
            try
            {
                sessionState.Get<int>(string.Empty);
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
            SessionState sessionState = new SessionState();
            bool passed = false;
            
            try
            {
                sessionState.Contains(null);
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
            SessionState sessionState = new SessionState();
            bool passed = false;
            
            try
            {
                sessionState.Contains(string.Empty);
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
            SessionState sessionState = new SessionState();
            bool passed = false;
            
            try
            {
                sessionState.Remove(null);
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
            SessionState sessionState = new SessionState();
            bool passed = false;
            
            try
            {
                sessionState.Remove(string.Empty);
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
            SessionState sessionState = new SessionState();
            string dataKey = "StringData";
            string data = "This is my data";
            string otherData = "This is my other data";
            
            // Test add
            Assert.IsTrue(!sessionState.Contains(dataKey), "Session state contains data.");
            sessionState.Set<string>(dataKey, data);
            Assert.IsTrue(sessionState.Contains(dataKey), "Session state doesn't contain newly-added data.");

            // Test update
            sessionState.Set<string>(dataKey, otherData);
            string storedData = sessionState.Get<string>(dataKey);
            Assert.AreEqual<string>(otherData, storedData, "Stored updated data does no match expected value.");
        }

        [TestMethod]
        public void TestDataGet()
        {
            SessionState sessionState = new SessionState();
            string dataKey = "NumberData";
            int data = 5674;

            sessionState.Set<int>(dataKey, data);
            int storedData = sessionState.Get<int>(dataKey);
            Assert.AreEqual<int>(data, storedData, "Stored data does not match expected data.");
        }

        [TestMethod]
        public void TestDataRemove()
        {
            SessionState sessionState = new SessionState();
            object data = new object();
            string dataKey = "ObjectData";

            Assert.IsFalse(sessionState.Contains(dataKey), "Session state should not contain object data.");
            
            sessionState.Set<object>(dataKey, data);
            Assert.IsTrue(sessionState.Contains(dataKey), "Session state does not contain newly-added data.");
            
            sessionState.Remove(dataKey);
            Assert.IsFalse(sessionState.Contains(dataKey), "Session state remove failed.");
        }

        [TestMethod]
        //Ensures the removal of data not in session state runs without a problem
        public void TestMissingRemove()
        {
            SessionState sessionState = new SessionState();
            string missingDataKey = "MissingDataKey";
            
            sessionState.Remove(missingDataKey);
        }
    }
}
