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
        [TestMethod]
        public void Number3962gives3000_1000_900__900_1000__60_50__2_1()
        {
            SortedDictionary<int, char> pairs = new SortedDictionary<int, char>();
            pairs.Add(1, 'I');
            pairs.Add(5, 'V');
            pairs.Add(10, 'X');
            pairs.Add(50, 'L');
            pairs.Add(100, 'C');
            pairs.Add(500, 'D');
            pairs.Add(1000, 'M');
            
            SortedDictionary<int, int> digits = new SortedDictionary<int, int>();
            digits.Add(3000, 0);
            digits.Add(900, 0);
            digits.Add(60, 0);
            digits.Add(2, 0);

            SortedDictionary<int, int> expectedResult = new SortedDictionary<int, int>();
            expectedResult.Add(3000, 1000);
            expectedResult.Add(900, 1000);
            expectedResult.Add(60, 50);
            expectedResult.Add(2, 1);

            for (int i = 0; i < digits.Count; i++)
            {
                Assert.AreEqual(expectedResult.ElementAt(i), Program.GetClosest(digits, pairs).ElementAt(i));
            }
        }
        [TestMethod]
        public void Number3752gives3000_1000_700__500_50_50__2_1()
        {
            SortedDictionary<int, char> pairs = new SortedDictionary<int, char>();
            pairs.Add(1, 'I');
            pairs.Add(5, 'V');
            pairs.Add(10, 'X');
            pairs.Add(50, 'L');
            pairs.Add(100, 'C');
            pairs.Add(500, 'D');
            pairs.Add(1000, 'M');

            SortedDictionary<int, int> digits = new SortedDictionary<int, int>();
            digits.Add(3000, 0);
            digits.Add(700, 0);
            digits.Add(50, 0);
            digits.Add(2, 0);

            SortedDictionary<int, int> expectedResult = new SortedDictionary<int, int>();
            expectedResult.Add(3000, 1000);
            expectedResult.Add(700, 500);
            expectedResult.Add(50, 50);
            expectedResult.Add(2, 1);

            for (int i = 0; i < digits.Count; i++)
            {
                Assert.AreEqual(expectedResult.ElementAt(i), Program.GetClosest(digits, pairs).ElementAt(i));
            }
        }
        [TestMethod]
        public void Number12gives10__10__2_1()
        {
            SortedDictionary<int, char> pairs = new SortedDictionary<int, char>();
            pairs.Add(1, 'I');
            pairs.Add(5, 'V');
            pairs.Add(10, 'X');
            pairs.Add(50, 'L');
            pairs.Add(100, 'C');
            pairs.Add(500, 'D');
            pairs.Add(1000, 'M');

            SortedDictionary<int, int> digits = new SortedDictionary<int, int>();
            digits.Add(10, 0);
            digits.Add(2, 0);

            SortedDictionary<int, int> expectedResult = new SortedDictionary<int, int>();
            expectedResult.Add(10, 10);
            expectedResult.Add(2, 1);

            for (int i = 0; i < digits.Count; i++)
            {
                Assert.AreEqual(expectedResult.ElementAt(i), Program.GetClosest(digits, pairs).ElementAt(i));
            }
        }
    }
}
