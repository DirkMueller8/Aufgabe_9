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

            int eingabe;
            SortedDictionary<int, int> digits;
            while (true)
            {
                Console.WriteLine("Gib Nummer: ");
                eingabe = Convert.ToInt32(Console.ReadLine());
                if (eingabe == 0)
                    break;
                digits = GetDigits(eingabe);

                SortedDictionary<int, int> work;
                work = GetClosest(digits, pairs);
                foreach (var item in work)
                {
                    Console.WriteLine($"{item.Key}, {item.Value}");
                }

                StringBuilder buildRoman = new StringBuilder();
                StringBuilder buildRomanH = new StringBuilder();
                StringBuilder buildRomanT = new StringBuilder();
                StringBuilder buildRomanO = new StringBuilder();
                if (digits.Count == 4)
                {
                    buildRoman = ProcessThousands(work);
                    work.Remove(work.ElementAt(3).Key);
                }
                Console.WriteLine("Thousands:");
                Console.WriteLine($"buildRoman: {buildRoman}");
                foreach (var item in work)
                {
                    Console.WriteLine($"{item.Key}, {item.Value}");
                }

                if (digits.Count == 3)
                {
                    buildRomanH = ProcessHundreds(work, buildRoman);
                    work.Remove(work.ElementAt(2).Key);
                }
                Console.WriteLine("Hundreds:");
                Console.WriteLine($"buildRoman: {buildRomanH}");

                if (digits.Count == 2)
                {
                    buildRomanT = ProcessTens(work, buildRoman);
                    work.Remove(work.ElementAt(1).Key);
                    Console.WriteLine("Letzter: {0}", work.ElementAt(0).Key);
                }
                Console.WriteLine("Tens:");
                Console.WriteLine($"buildRoman: {buildRomanT}");

                if (digits.Count == 1)
                {
                    buildRomanO = ProcessOnes(work, buildRoman);
                }
                Console.WriteLine("Ones:");
                Console.WriteLine($"buildRoman: {buildRomanO}");
            }
        }
        public static StringBuilder ProcessThousands(SortedDictionary<int, int> dict)
        {
            StringBuilder sb = new StringBuilder();
            int ratio;
            int i = 3;

            ratio = dict.ElementAt(i).Key / dict.ElementAt(i).Value;
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
            return sb;
        }
        public static StringBuilder ProcessHundreds(SortedDictionary<int, int> dict, StringBuilder sb)
        {
            int i = 2;
            int wert = dict.ElementAt(i).Key;
            if (wert >= 100 && wert <= 400)
                sb.Append("C");
            if (wert >= 200 && wert <= 300)
                sb.Append("C");
            if (wert == 300)
                sb.Append("C");
            if (wert == 400)
                sb.Append("D");
            if (wert >= 500 && wert <= 800)
                sb.Append("D");
            if (wert >= 600 && wert <= 800)
                sb.Append("C");
            if (wert >= 700 && wert <= 800)
                sb.Append("C");
            if (wert == 800)
                sb.Append("C");
            if (wert == 900)
                sb.Append("CM");

            return sb;
        }
        public static StringBuilder ProcessTens(SortedDictionary<int, int> dict, StringBuilder sb)
        {
            int i = 1;
            int wert = dict.ElementAt(i).Key;
            if (wert >= 10 && wert <= 40)
                sb.Append("X");
            if (wert >= 20 && wert <= 30)
                sb.Append("X");
            if (wert == 30)
                sb.Append("X");
            if (wert == 40)
                sb.Append("L");
            if (wert >= 50 && wert <= 80)
                sb.Append("L");
            if (wert >= 60 && wert <= 80)
                sb.Append("X");
            if (wert >= 70 && wert <= 80)
                sb.Append("X");
            if (wert == 80)
                sb.Append("X");
            if (wert == 90)
                sb.Append("XC");

            return sb;
        }
        public static StringBuilder ProcessOnes(SortedDictionary<int, int> dict, StringBuilder sb)
        {
            int i = 0;
            int wert = dict.ElementAt(i).Key;
            if (wert >= 1 && wert <= 4)
                sb.Append("I");
            if (wert >= 2 && wert <= 3)
                sb.Append("I");
            if (wert == 3)
                sb.Append("I");
            if (wert == 4)
                sb.Append("V");
            if (wert >= 5 && wert <= 8)
                sb.Append("V");
            if (wert >= 6 && wert <= 8)
                sb.Append("I");
            if (wert >= 7 && wert <= 8)
                sb.Append("I");
            if (wert == 8)
                sb.Append("I");
            if (wert == 9)
                sb.Append("VX");

            return sb;
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
                        //Console.WriteLine($"Verdacht: {verdacht}");
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
