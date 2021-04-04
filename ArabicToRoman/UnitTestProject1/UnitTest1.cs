using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ArabicToRoman;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Number986gives900_80_6()
        {
            //List<int> digits = new List<int>();
            SortedList<int, int> digits = new SortedList<int, int>();

            digits.Add(900, 0);
            digits.Add(80, 0);
            digits.Add(6, 0);

            List<int> returnedValue = new List<int>();

            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(digits.Keys[i], Program.GetDigits(986).Keys[i]);
            }
        }
        [TestMethod]
        public void Number3989gives3000_900_80_9()
        {
            //List<int> digits = new List<int>();
            SortedList<int, int> digits = new SortedList<int, int>();

            digits.Add(3000, 0);
            digits.Add(900, 0);
            digits.Add(80, 0);
            digits.Add(9, 0);

            List<int> returnedValue = new List<int>();

            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(digits.Keys[i], Program.GetDigits(3989).Keys[i]);
            }
        }
        [TestMethod]
        public void Number3989gives3000_900_80_9DifferentOrder()
        {
            //List<int> digits = new List<int>();
            SortedList<int, int> digits = new SortedList<int, int>();

            digits.Add(900, 0);
            digits.Add(3000, 0);
            digits.Add(9, 0);
            digits.Add(80, 0);

            List<int> returnedValue = new List<int>();

            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(digits.Keys[i], Program.GetDigits(3989).Keys[i]);
            }
        }
    }
}
