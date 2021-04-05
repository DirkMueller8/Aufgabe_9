using System;
using System.Collections.Generic;

namespace ArabicToRoman
{
    public class Program
    {
        const int NUMBER = 986;
        List<int> decomposedNumbers = new List<int>();

        static void Main(string[] args)
        {
            Dictionary<int, char> pairs = new Dictionary<int, char>();
            pairs.Add(1, 'I');
            pairs.Add(5, 'V');
            pairs.Add(10, 'X');
            pairs.Add(50, 'L');
            pairs.Add(100, 'C');
            pairs.Add(500, 'D');
            pairs.Add(1000, 'M');

            Dictionary<int, int> digits;
            digits = GetDigits(986);

            foreach (var item in digits)
            {
                Console.WriteLine(item);
            }
            GetClosest(digits, pairs);

        }
        public static Dictionary<int, int> GetClosest(Dictionary<int, int> digits, Dictionary<int, char> toCompareWith)
        {
            int diff = 10000;
            int temp;
            int verdacht = 0;
            foreach (var item in toCompareWith)
            {
                foreach (var item1 in digits)
                {
                    temp = Math.Abs(item.Key - item1.Key);
                    Console.WriteLine("temp: {0}", temp);
                    if (temp < diff)
                    {
                        verdacht = item.Key;
                    }
                    diff = temp;
                }
                Console.WriteLine($"item.Key: {item.Key}, item.value: {item.Value}, verdacht: {verdacht}, {toCompareWith[verdacht]}");
                Console.ReadLine();
                digits[item.Key] = verdacht;
            }
            foreach (var item in digits)
            {
                Console.WriteLine(item.Key + ", " + item.Value);
            }
            return digits;
        }
        public static Dictionary<int, int> GetDigits(int number)
        {
            int a = number;
            string currentNumberAsString = number.ToString();
            Dictionary<int, int> digits = new Dictionary<int, int>();

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
