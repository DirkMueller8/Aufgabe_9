using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderedDictionaryTests;
using System.Text;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ReturnTrueIfSmallerNumberInFrontofBiggerNumber()
        {
            string numberRoman = "CM";
            StringBuilder sb = new StringBuilder();
            sb.Append(numberRoman);
            bool expectedResult = true;
            bool? returnedValue;

            GoForIt gfi1 = new GoForIt();
            returnedValue = gfi1.SubtractConsecutiveValues(sb[0], sb[1]);

            Assert.AreEqual(expectedResult, returnedValue);
        }
        [TestMethod]
        public void ReturnFalseIfSmallerNumberInFrontofBiggerNumber()
        {
            string numberRoman = "MC";
            StringBuilder sb = new StringBuilder();
            sb.Append(numberRoman);
            bool expectedResult = false;
            bool? returnedValue;

            GoForIt gfi1 = new GoForIt();
            returnedValue = gfi1.SubtractConsecutiveValues(sb[0], sb[1]);

            Assert.AreEqual(expectedResult, returnedValue);
        }
        [TestMethod]
        public void Return1997ForMCMXCVII()
        {
            string numberRoman = "MCMXCVII";
            StringBuilder sb = new StringBuilder();
            sb.Append(numberRoman);
            int? expectedResult = 1997;
            int? returnedValue;

            GoForIt gfi1 = new GoForIt();
            returnedValue = gfi1.CalculateArabicNumber(numberRoman);

            Assert.AreEqual(expectedResult, returnedValue);
        }
        [TestMethod]
        public void Return2009ForMMIX()
        {
            string numberRoman = "MMIX";
            StringBuilder sb = new StringBuilder();
            sb.Append(numberRoman);
            int? expectedResult = 2009;
            int? returnedValue;

            GoForIt gfi1 = new GoForIt();
            returnedValue = gfi1.CalculateArabicNumber(numberRoman);

            Assert.AreEqual(expectedResult, returnedValue);
        }
        [TestMethod]
        public void Return414ForCDXIV()
        {
            string numberRoman = "CDXIV";
            StringBuilder sb = new StringBuilder();
            sb.Append(numberRoman);
            int? expectedResult = 414;
            int? returnedValue;

            GoForIt gfi1 = new GoForIt();
            returnedValue = gfi1.CalculateArabicNumber(numberRoman);

            Assert.AreEqual(expectedResult, returnedValue);
        }
        [TestMethod]
        public void Return3999ForMMMCMXCIX()
        {
            string numberRoman = "MMMCMXCIX";
            StringBuilder sb = new StringBuilder();
            sb.Append(numberRoman);
            int? expectedResult = 3999;
            int? returnedValue;

            GoForIt gfi1 = new GoForIt();
            returnedValue = gfi1.CalculateArabicNumber(numberRoman);

            Assert.AreEqual(expectedResult, returnedValue);
        }
        [TestMethod]
        public void Return1ForI()
        {
            string numberRoman = "I";
            StringBuilder sb = new StringBuilder();
            sb.Append(numberRoman);
            int? expectedResult = 1;
            int? returnedValue;

            GoForIt gfi1 = new GoForIt();
            returnedValue = gfi1.CalculateArabicNumber(numberRoman);

            Assert.AreEqual(expectedResult, returnedValue);
        }
        [TestMethod]
        public void Return1000ForM()
        {
            string numberRoman = "M";
            StringBuilder sb = new StringBuilder();
            sb.Append(numberRoman);
            int? expectedResult = 1000;
            int? returnedValue;

            GoForIt gfi1 = new GoForIt();
            returnedValue = gfi1.CalculateArabicNumber(numberRoman);

            Assert.AreEqual(expectedResult, returnedValue);
        }
    }
}