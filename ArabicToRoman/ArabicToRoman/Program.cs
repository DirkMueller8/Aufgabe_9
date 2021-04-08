using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArabicToRoman
{
    public class Program
    {
        static void Main(string[] args)
        {
            StringBuilder buildRoman = new StringBuilder();
            int eingabe;
            SortedDictionary<int, int> digits;

            while (true)
            {
                Console.WriteLine("Gib Nummer: ");
                eingabe = Convert.ToInt32(Console.ReadLine());
                if (eingabe == 0)
                    break;
                digits = GetDigits(eingabe);
                foreach (var item in digits)
                {
                    Console.WriteLine($"{item.Key}, {item.Value}");
                }

                if (digits.Count == 4)
                {
                    buildRoman = ProcessThousands(digits);
                    digits.Remove(digits.ElementAt(3).Key);
                }

                foreach (var item in digits)
                {
                    Console.WriteLine($"{item.Key}, {item.Value}");
                }

                if (digits.Count == 3)
                {
                    buildRoman = ProcessHundreds(digits, buildRoman);
                    digits.Remove(digits.ElementAt(2).Key);
                }

                if (digits.Count == 2)
                {
                    buildRoman = ProcessTens(digits, buildRoman);
                    digits.Remove(digits.ElementAt(1).Key);
                }

                if (digits.Count == 1)
                {
                    buildRoman = ProcessOnes(digits, buildRoman);
                }
                Console.WriteLine("Final result: {0}", buildRoman);
            }
        }
        public static StringBuilder ProcessThousands(SortedDictionary<int, int> dict)
        {
            StringBuilder sb = new StringBuilder();
            int ratio;
            int i = 3;

            ratio = dict.ElementAt(i).Value / 1000;
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
            int wert = dict.ElementAt(i).Value;
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
            int wert = dict.ElementAt(i).Value;
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
            int wert = dict.ElementAt(i).Value;
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
                sb.Append("IX");

            return sb;
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
                digits.Add(l - i, (int)(number));

                number = a - number;
                a = number;
            }
            digits.Add(0, (int)(number));
            return digits;
        }
    }
}
