using System;
using System.Collections.Generic;

namespace ArabicToRoman
{
    class GoForIt
    {
        //public List<int> GetDigits(int number)
        //{
        //    int currentNumber = number;
        //    List<int> digits = new List<int>();
        //    while (currentNumber != 0)
        //    {
        //        digits.Add(currentNumber % 10);
        //        currentNumber = currentNumber / 10;
        //    }
        //    digits.Reverse();
        //    return digits;
        //}
    }
    public class Program
    {
        const int NUMBER = 986;
        List<int> decomposedNumbers = new List<int>();

        static void Main(string[] args)
        {
            GoForIt gfi = new GoForIt();
            //gfi.GetDigits(NUMBER);
            //List<int> digits = new List<int>();
            SortedList<int, int> digits = new SortedList<int, int>();


            foreach (var item in GetDigits(986))
            {
                Console.WriteLine(item);
            }
        }
        public static SortedList<int, int> GetDigits(int number)
        {
            int currentNumber = number;
            int a = number;
            int b = currentNumber;
            string currentNumberAsString = currentNumber.ToString();
            //List<int> digits = new List<int>();
            SortedList<int, int> digits = new SortedList<int, int>();

            int l = currentNumberAsString.Length;
            for (int i = 1; i < l; i++)
            {
                b = (int)(b/Math.Pow(10,l-i));
                b = (int)(b * Math.Pow(10, l - i));
                digits.Add((int)(b),0);
                b = a - b;
                a = b;
            }
            digits.Add((int)(b),0);
            return digits;
        }
    }
}
