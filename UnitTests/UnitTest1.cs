using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using Aufgabe_9;


namespace UnitTests

{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string numberRoman = "MCMXCVII";
            StringBuilder sb = new StringBuilder();
            sb.Append(numberRoman);
            Transform tf1 = new Transform();
            int? i = tf1.DeterminePositionOFLetter(sb, 'X');
            int expectedIntnumber = 3;
            Assert.AreEqual(i, expectedIntnumber);
        }

        [TestMethod]
        public void TestMethod2()
        {
            string numberRoman = "MCMXCVII";
            StringBuilder sb = new StringBuilder();
            sb.Append(numberRoman);
            Transform tf1 = new Transform();
            int? i = tf1.DeterminePositionOFLetter(sb, 'P');
            int? expectedIntnumber = null;
            Assert.AreEqual(i, expectedIntnumber);
        }
        [TestMethod]
        public void TestMethod3()
        {
            string numberRoman = "MCMXCVII";
            StringBuilder sb = new StringBuilder();
            sb.Append(numberRoman);
            Transform tf1 = new Transform();
            int? i = tf1.DeterminePositionOFLetter(sb, 'M');
            int? expectedIntnumber = 0;
            Assert.AreEqual(i, expectedIntnumber);
        }
        [TestMethod]
        public void TestMethod4()
        {
            string numberRoman = "MCMXCVII";
            StringBuilder sb = new StringBuilder();
            sb.Append(numberRoman);
            Transform tf1 = new Transform();
            int? i = tf1.DeterminePositionOFLetter(sb, 'V');
            int? expectedIntnumber = 5;
            Assert.AreEqual(i, expectedIntnumber);
        }
        [TestMethod]
        public void TestMethod5()
        {
            string numberRoman = "MCMXCVII";
            StringBuilder sb = new StringBuilder();
            sb.Append(numberRoman);
            Transform tf1 = new Transform();
            StringBuilder strB = tf1.RemoveLetter(sb, 0);
            string expectedString = "CMXCVII";
            StringBuilder sb1 = new StringBuilder();
            sb1.Append(expectedString);
            Assert.AreEqual(sb1.ToString(), strB.ToString());
        }
        [TestMethod]
        public void TestMethod6()
        {
            string numberRoman = "MCMXCVII";
            StringBuilder sb = new StringBuilder();
            sb.Append(numberRoman);
            Transform tf1 = new Transform();
            StringBuilder strB = tf1.RemoveLetter(sb, 5);
            string expectedString = "II";
            StringBuilder sb1 = new StringBuilder();
            sb1.Append(expectedString);
            Assert.AreEqual(sb1.ToString(), strB.ToString());
        }
    }
}
