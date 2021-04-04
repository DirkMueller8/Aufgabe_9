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
            SortedList<int, char> sl = new SortedList<int, char>();
            sl.Add(1, 'I');
            sl.Add(5, 'V');
            sl.Add(10, 'X');
            sl.Add(50, 'L');
            sl.Add(100, 'C');
            sl.Add(500, 'D');
            sl.Add(1000, 'M');

            SortedList<int, int> digits;
            digits = GetDigits(986);

            foreach (var item in digits)
            {
                Console.WriteLine(item);
            }
            GetClosest(digits, sl);

        }
        public static SortedList<int, int> GetClosest(SortedList<int, int> digits, SortedList<int, char> toCompareWith)
        {
            int diff = 10000;
            int temp;
            int verdacht = 0;
            foreach (var item in digits)
            {
                for (int i = 0; i < toCompareWith.Count; i++)
                {
                    temp = Math.Abs(item.Key - toCompareWith.Keys[i]);
                    Console.WriteLine("temp: {0}", temp);
                    if (temp < diff)
                    {
                        verdacht = toCompareWith.Keys[i];
                    }
                    diff = temp;
                }
                Console.WriteLine($"item.Key: {item.Key}, item.value: {item.Value}, verdacht: {verdacht}, {toCompareWith[verdacht]}");
                Console.ReadLine();
                item.Value = verdacht;
            }
            return digits;
        }
        public static SortedList<int, int> GetDigits(int number)
        {
            int a = number;
            string currentNumberAsString = number.ToString();
            SortedList<int, int> digits = new SortedList<int, int>();

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
