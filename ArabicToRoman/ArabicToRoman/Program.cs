using System;
using System.Collections.Generic;
using System.Linq;

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

            //foreach (var item in digits)
            //{
            //    Console.WriteLine(item);
            //}
            GetClosest(digits, pairs);

        }
        public static SortedDictionary<int, int> GetClosest(SortedDictionary<int, int> digits, SortedDictionary<int, char> toCompareWith)
        {
            int diff = 10000;
            int temp;
            int verdacht = 0;

            for (int i = 0; i < digits.Count; i++)
            {
                Console.WriteLine($"Äussere Schleife:, digits (key, value): {digits.ElementAt(i).Key}, {digits.ElementAt(i).Value}");
                //foreach (var item1 in digits)
                foreach (var item in toCompareWith)
                {
                    Console.WriteLine();
                    Console.WriteLine($"i: {i}");
                    temp = Math.Abs(item.Key - digits.ElementAt(i).Key);
                    Console.WriteLine($"temp, diff: {temp}, {diff}");
                    if (temp < diff)
                    {
                        verdacht = item.Key;
                        Console.WriteLine($"Verdacht: {verdacht}");
                        digits[digits.ElementAt(i).Key] = verdacht;
                    }
                    Console.WriteLine($"digits (key, value): {digits.ElementAt(i).Key}, {digits.ElementAt(i).Value}");
                    diff = temp;
                }
                verdacht = 0;
                diff = 10000;
            }
            foreach (var item2 in digits)
            {
                Console.WriteLine($"Final result: {item2.Key},  {item2.Value}");
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
