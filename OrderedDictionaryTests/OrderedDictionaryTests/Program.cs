using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderedDictionaryTests
{
    public class GoForIt
    {
        string numberRoman = "MCMXCVII";

        SortedDictionary<int, char> dyRoman = new SortedDictionary<int, char>
        {
            {1000, 'M'}, {500, 'D'}, {100, 'C'}, {50, 'L'}, {10, 'X' }, {5, 'V'}, {1, 'I'}
        };

        SortedDictionary<char, int> dyRoman1 = new SortedDictionary<char, int>
        {
            {'M', 1000}, {'D', 500}, {'C', 100}, {'L', 50}, {'X', 10 }, {'V', 5}, {'I', 1}
        };
        SortedList<char, int> dyRoman2 = new SortedList<char, int>
        {
            {'M', 1000}, {'D', 500}, {'C', 100}, {'L', 50}, {'X', 10 }, {'V', 5}, {'I', 1}
        };

        public char? GetValueForKey(int keyNumber)
        {
            char result;
            if (dyRoman.TryGetValue(keyNumber, out result))
            {
                return result;
            }
            return null;
        }
        public int? GetValueForKey1(char letter)
        {
            int result;
            if (dyRoman1.TryGetValue(letter, out result))
            {
                return result;
            }
            return null;
        }
        public bool SubtractConsecutiveValues(char left, char right)
        {
            Console.WriteLine(left.ToString() + ", " + right.ToString());
            if (dyRoman1[right] > dyRoman1[left])
            {
                return true;
            }
            else
                return false;
        }
        public int? CalculateArabicNumber(string romanNumber)
        {
            int? cumm = 0;
            if (MaximumRepititionOfCharactersExceeded(romanNumber))
            {
                Console.WriteLine("Too many repititions in your input");
                Console.ReadKey();
            }
            StringBuilder sb = new StringBuilder();
            romanNumber = romanNumber.TrimEnd(' ');
            sb.Append(romanNumber.ToUpper());
            if (sb.Length == 1)
                cumm = GetValueForKey1(sb[0]);
            for (int i = 0; i < sb.Length - 1; i++)
            {
                if (SubtractConsecutiveValues(sb[i], sb[i + 1]))
                {
                    cumm = cumm + GetValueForKey1(sb[i + 1]) - GetValueForKey1(sb[i]);
                    i++;
                }
                else
                {
                    cumm += GetValueForKey1(sb[i]);
                    if (i == sb.Length - 2)
                        cumm = cumm + GetValueForKey1(sb[i+1]);
                }
            }
            return cumm;
        }
        public Boolean MaximumRepititionOfCharactersExceeded(string str)
        {
            // Define array with characters M, C, X, I from sorted list:
            char[] charMCXI = new char[4] {dyRoman2.Keys[0], dyRoman2.Keys[2], dyRoman2.Keys[4], dyRoman2.Keys[6]};

            // Define array with characters M, C, X, I from sorted list:
            char[] charVLD = new char[3] { dyRoman2.Keys[1], dyRoman2.Keys[3], dyRoman2.Keys[5]};

            foreach (var item in charMCXI)
            {
                int occurences = str.Count(f => (f == item));
                if (occurences > 3)
                {
                    return true;
                }
            }
            foreach (var item in charVLD)
            {
                int occurences = str.Count(f => (f == item));
                if (occurences > 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
    class Program
    {
        const string NUMBERROMAN = "MCMXCVII";
        static void Main(string[] args)
        {
            int? wert;
            GoForIt gfi = new GoForIt();
            Console.WriteLine(gfi.GetValueForKey(1000));
            Console.WriteLine(gfi.GetValueForKey(50));
            Console.WriteLine(gfi.GetValueForKey(23));
            wert = gfi.CalculateArabicNumber(NUMBERROMAN);
            Console.WriteLine(wert);
        }
    }
}
