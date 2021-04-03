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
            StringBuilder sb = new StringBuilder();
            romanNumber = romanNumber.TrimEnd(' ');
            string tempString = romanNumber.ToUpper();
            sb.Append(tempString.ToUpper());
            if (MaximumRepititionOfCharactersExceeded(tempString))
            {
                return null;
            }
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
                        cumm = cumm + GetValueForKey1(sb[i + 1]);
                }
            }
            return cumm;
        }
        public Boolean MaximumRepititionOfCharactersExceeded(string str)
        {
            // Define array with characters M, C, X, I from sorted dictionary:
            char[] charMCXI = new char[4] { dyRoman[1000], dyRoman[100], dyRoman[10], dyRoman[1] };

            // Define array with characters V, L, D from sorted dictionary:
            char[] charVLD = new char[3] { dyRoman[5], dyRoman[50], dyRoman[500] };

            int i = 0;
            int countRepititions = 0;

            while (i < str.Length - 1)
            {
                // Check if the running character is of ('M', 'C', 'X', 'I') AND if it repeats with the next character:
                if ((str[i] == charMCXI[0] || str[i] == charMCXI[1] || str[i] == charMCXI[2] || str[i] == charMCXI[3]) && str[i] == str[i + 1])
                    countRepititions++;
                i++;
            }
            // If there are more than three same consecutive characters of ('M', 'C', 'X', 'I') return true:
            if (countRepititions > 2)
            {
                return true;
            }
            countRepititions = 0;
            i = 0;
            while (i < str.Length - 1)
            {
                // Check if the running character is of ('V', 'L', 'D')  AND if it repeats with the next character:
                if ((str[i] == charVLD[0] || str[i] == charVLD[1] || str[i] == charVLD[2]) && str[i] == str[i + 1])
                    countRepititions++;
                i++;
            }
            // If there are more than two same consecutive characters of ('V', 'L', 'D') return true:
            if (countRepititions > 0)
            {
                return true;
            }
            countRepititions = 0;
            i = 1;
            while (i < str.Length - 1)
            {
                // Check if the running character is of ('M', 'C', 'X', 'I') AND if it repeats with the next character:
                if (SubtractConsecutiveValues(str[i], str[i + 1]) && str[i - 1] == str[i])
                    return true;
                i++;
            }
            for (int j = 0; j < str.Length - 1; j++)
            {
                // Check if for V any bigger number comes after it:
                if (str[j] == 'V' && str[j + 1] == 'X' && str[j + 1] == 'L' && str[j + 1] == 'C' && str[j + 1] == 'D' && str[j + 1] == 'M')
                {
                    return true;
                }
            }
            for (int j = 0; j < str.Length - 1; j++)
            {
                // Check if for L any bigger number comes after it:
                if (str[j] == 'L' && str[j + 1] == 'C' && str[j + 1] == 'D' && str[j + 1] == 'M')
                {
                    return true;
                }
            }
            for (int j = 0; j < str.Length - 1; j++)
            {
                // Check if for M any bigger number comes after it:
                if (str[j] == 'D' && str[j + 1] == 'M')
                {
                    return true;
                }
            }
            // In all other cases it is a valid input:
            return false;
        }
        public Boolean AllCharactersPresentedAreUsedInRomaNumbers(string str)
        {
            foreach (var item in str)
            {
                if (!dyRoman1.ContainsKey(item))
                    return false;
            }
            return true;
        }
    }
    class Program
    {
        //const string NUMBERROMAN = "MCMXCVII";
        const string NUMBERROMAN = "mcmxcvii";

        static void Main(string[] args)
        {
            int? wert;
            GoForIt gfi = new GoForIt();
            string strInput;
            while (true)
            {
                Console.WriteLine("Give roman number (0 for exit)");
                strInput = Console.ReadLine();
                if (strInput == "0")
                    break;
                if (gfi.AllCharactersPresentedAreUsedInRomaNumbers(strInput))
                {
                    wert = gfi.CalculateArabicNumber(strInput);
                    if (wert != null)
                        Console.WriteLine($"Resultat: {wert}");
                    else
                        Console.WriteLine("There was some problem in your input!");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("At least one character does not represent a roman number.");
                }
            }
        }
    }
}
