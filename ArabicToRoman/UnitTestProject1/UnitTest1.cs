using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ArabicToRoman;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Number1gives1()
        {
            SortedDictionary<int, int> digits = new SortedDictionary<int, int>();

            digits.Add(1, 0);

            for (int i = 0; i < digits.Count; i++)
            {
                Assert.AreEqual(digits.ElementAt(i), Program.GetDigits(1).ElementAt(i));
            }
        }
        [TestMethod]
        public void Number986gives900_80_6()
        {
            SortedDictionary<int, int> digits = new SortedDictionary<int, int>();

            digits.Add(900, 0);
            digits.Add(80, 0);
            digits.Add(6, 0);

            for (int i = 0; i < digits.Count; i++)
            {
                Assert.AreEqual(digits.ElementAt(i), Program.GetDigits(986).ElementAt(i));
            }
        }
        [TestMethod]
        public void Number3962gives3000_900_60_2()
        {
            SortedDictionary<int, int> digits = new SortedDictionary<int, int>();

            digits.Add(3000, 0);
            digits.Add(900, 0);
            digits.Add(60, 0);
            digits.Add(2, 0);

            for (int i = 0; i < digits.Count; i++)
            {
                Assert.AreEqual(digits.ElementAt(i), Program.GetDigits(3962).ElementAt(i));
            }
        }
    }
}
