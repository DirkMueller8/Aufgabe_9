using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArabicToRoman
{
    public class Program
    {
        const int NUMBER = 986;
        List<int> decomposedNumbers = new List<int>();

        static void Main(string[] args)
        {
            SortedDictionary<int, char> pairs = new SortedDictionary<int, char>();
            pairs.Add(1, 'I');
            pairs.Add(5, 'V');
            pairs.Add(10, 'X');
            pairs.Add(50, 'L');
            pairs.Add(100, 'C');
            pairs.Add(500, 'D');
            pairs.Add(1000, 'M');

            SortedDictionary<int, int> digits;
            digits = GetDigits(986);

            SortedDictionary<int, int> work;
            work = GetClosest(digits, pairs);

            string buildRoman = "";
            buildRoman = FinalConversion(work);
        }
        public static string FinalConversion(SortedDictionary<int, int> dict)
        {
            string temp = "";
            StringBuilder sb = new StringBuilder();
            int ratio;
            int rest;
            int i = 0;
            if (dict.ElementAt(i).Key > dict.ElementAt(i).Value)
            {
                ratio = dict.ElementAt(i).Key / dict.ElementAt(i).Value;
                rest = dict.ElementAt(i).Key % dict.ElementAt(i).Value;
                switch (ratio)
                {
                    case 1:
                        sb.Append("M");
                        break;
                    case 2:
                        sb.Append("MM");
                        break;
                    case 3:
                        sb.Append("MMM");
                        break;
                }
            }
            i = 1;

            return temp;
        }
    public static SortedDictionary<int, int> GetClosest(SortedDictionary<int, int> digits, SortedDictionary<int, char> toCompareWith)
    {
        int diff = 10000;
        int temp;
        int verdacht;

        for (int i = 0; i < digits.Count; i++)
        {
            foreach (var item in toCompareWith)
            {
                temp = Math.Abs(item.Key - digits.ElementAt(i).Key);
                if (temp < diff)
                {
                    verdacht = item.Key;
                    Console.WriteLine($"Verdacht: {verdacht}");
                    digits[digits.ElementAt(i).Key] = verdacht;
                }
                diff = temp;
            }
            diff = 10000;
        }
        return digits;
    }
    public static SortedDictionary<int, int> GetDigits(int number)
    {
        int a = number;
        string currentNumberAsString = number.ToString();
        SortedDictionary<int, int> digits = new SortedDictionary<int, int>();

        int l = currentNumberAsString.Length;
        for (int i = 1; i < l; i++)
        {
            number = (int)(number / Math.Pow(10, l - i));
            number = (int)(number * Math.Pow(10, l - i));
            digits.Add((int)(number), 0);
            number = a - number;
            a = number;
        }
        digits.Add((int)(number), 0);
        return digits;
    }
}
}
