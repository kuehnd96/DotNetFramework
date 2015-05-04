using DK.Framework.Store.Converters;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Windows.UI.Xaml;

namespace DK.Framework.Store.Win8.Tests
{
    [TestClass]
    public class BooleanToVisibilityConverterTest
    {
        [TestInitialize]
        public void Init()
        {
            Bootstrapper.Startup();
        }
        
        [TestMethod]
        public void NullValueConvertTest()
        {
            BooleanToVisibilityConverter converter = new BooleanToVisibilityConverter();

            var result = (Visibility)converter.Convert(null, typeof(Visibility), null, null);

            Assert.AreEqual<Visibility>(Visibility.Collapsed, result, "Conversion of null value didn't return Visibility.Collapsed.");
        }

        [TestMethod]
        public void NoParameterValueConvertTest()
        {
            BooleanToVisibilityConverter converter = new BooleanToVisibilityConverter();

            var visibleResult = (Visibility)converter.Convert(true, typeof(Visibility), null, null);
            var collapsedResult = (Visibility)converter.Convert(false, typeof(Visibility), null, null);

            Assert.AreEqual<Visibility>(Visibility.Visible, visibleResult, "Conversion of true value w/o parameter failed.");
            Assert.AreEqual<Visibility>(Visibility.Collapsed, collapsedResult, "Conversion of false value w/o parameter failed.");
        }

        [TestMethod]
        public void ParameterValueConvertTest()
        {
            BooleanToVisibilityConverter converter = new BooleanToVisibilityConverter();

            var visibleResult = (Visibility)converter.Convert(false, typeof(Visibility), "flip", null);
            var collapsedResult = (Visibility)converter.Convert(true, typeof(Visibility), "flip", null);

            Assert.AreEqual<Visibility>(Visibility.Visible, visibleResult, "Conversion of true value with parameter failed.");
            Assert.AreEqual<Visibility>(Visibility.Collapsed, collapsedResult, "Conversion of false value with parameter failed.");
        }

        [TestMethod]
        public void NoParameterConvertBackTest()
        {
            BooleanToVisibilityConverter converter = new BooleanToVisibilityConverter();

            var trueResult = (bool)converter.ConvertBack(Visibility.Visible, typeof(bool), null, null);
            var falseResult = (bool)converter.ConvertBack(Visibility.Collapsed, typeof(bool), null, null);

            Assert.IsTrue(trueResult, "Convert back of Visibility.Visible w/o parameter did not return true.");
            Assert.IsFalse(falseResult, "Convert back of Visibility.Collapsed w/o parameter did not return false.");
        }

        [TestMethod]
        public void ParameterConvertBackTest()
        {
            BooleanToVisibilityConverter converter = new BooleanToVisibilityConverter();

            var trueResult = (bool)converter.ConvertBack(Visibility.Collapsed, typeof(bool), "flip", null);
            var falseResult = (bool)converter.ConvertBack(Visibility.Visible, typeof(bool), 1, null);

            Assert.IsTrue(trueResult, "Convert back of Visibility.Visible with parameter did not return true.");
            Assert.IsFalse(falseResult, "Convert back of Visibility.Collapsed with parameter did not return false.");
        }
    }
}
