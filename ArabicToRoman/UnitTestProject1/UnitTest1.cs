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

            digits.Add(0, 1);

            for (int i = 0; i < digits.Count; i++)
            {
                Assert.AreEqual(digits.ElementAt(i), Program.GetDigits(1).ElementAt(i));
            }
        }
        [TestMethod]
        public void Number986gives900_80_6()
        {
            SortedDictionary<int, int> digits = new SortedDictionary<int, int>();

            digits.Add(2, 900);
            digits.Add(1,80);
            digits.Add(0,6);

            for (int i = 0; i < digits.Count; i++)
            {
                Assert.AreEqual(digits.ElementAt(i), Program.GetDigits(986).ElementAt(i));
            }
        }
        [TestMethod]
        public void Number906gives900_6()
        {
            SortedDictionary<int, int> digits = new SortedDictionary<int, int>();

            digits.Add(2, 900);
            digits.Add(1, 0);
            digits.Add(0, 6);

            for (int i = 0; i < digits.Count; i++)
            {
                Assert.AreEqual(digits.ElementAt(i), Program.GetDigits(906).ElementAt(i));
            }
        }
        [TestMethod]
        public void Number3962gives3000_900_60_2()
        {
            SortedDictionary<int, int> digits = new SortedDictionary<int, int>();

            digits.Add(3, 3000);
            digits.Add(2,900);
            digits.Add(1,60);
            digits.Add(0, 2);

            for (int i = 0; i < digits.Count; i++)
            {
                Assert.AreEqual(digits.ElementAt(i), Program.GetDigits(3962).ElementAt(i));
            }
        }
        [TestMethod]
        public void Number3069gives3000_0_60_9()
        {
            SortedDictionary<int, int> digits = new SortedDictionary<int, int>();

            digits.Add(3, 3000);
            digits.Add(2, 0);
            digits.Add(1, 60);
            digits.Add(0, 9);

            for (int i = 0; i < digits.Count; i++)
            {
                Assert.AreEqual(digits.ElementAt(i), Program.GetDigits(3069).ElementAt(i));
            }
        }
        [TestMethod]
        public void Number3000gives3000_0_0_0()
        {
            SortedDictionary<int, int> digits = new SortedDictionary<int, int>();

            digits.Add(3, 3000);
            digits.Add(2, 0);
            digits.Add(1, 0);
            digits.Add(0, 0);

            for (int i = 0; i < digits.Count; i++)
            {
                Assert.AreEqual(digits.ElementAt(i), Program.GetDigits(3000).ElementAt(i));
            }
        }
    }
}