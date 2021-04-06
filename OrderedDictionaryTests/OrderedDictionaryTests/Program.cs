using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderedDictionaryTests
{
    public class GoForIt
    {
        SortedDictionary<int, char> dyRoman = new SortedDictionary<int, char>
        {
            {1000, 'M'}, {500, 'D'}, {100, 'C'}, {50, 'L'}, {10, 'X' }, {5, 'V'}, {1, 'I'}
        };

        SortedDictionary<char, int> letterNumber = new SortedDictionary<char, int>
        {
            {'M', 1000}, {'D', 500}, {'C', 100}, {'L', 50}, {'X', 10 }, {'V', 5}, {'I', 1}
        };

        public int? GetValueForKey(char letter)
        {
            int result;
            if (letterNumber.TryGetValue(letter, out result))
            {
                return result;
            }
            return null;
        }

        // When a smaller roman number precedes a larger number return true:
        public bool CanSubtractConsecutiveValues(char left, char right)
        {
            if (letterNumber[right] > letterNumber[left])
            {
                return true;
            }
            else
                return false;
        }
        public int? CalculateArabicNumber(string romanNumber)
        {
            int? cummulativeValue = 0;
            StringBuilder sb = new StringBuilder();
            romanNumber = romanNumber.TrimEnd(' ');
            string tempString = romanNumber.ToUpper();
            sb.Append(tempString.ToUpper());

            // Check if the input does not represent an existing roman number:
            if (ForbiddenCombinationOrMaximumNumberOfSameLetterExceeded(tempString))
            {
                return null;
            }
            // Special case of only one roman letter:
            if (sb.Length == 1)
            {
                cummulativeValue = GetValueForKey(sb[0]);
            }

            // Traverse the roman number from left to right. Distinguish between
            // the case where a subtraction is necessary, and where not:
            int i = 0;
            while (i < sb.Length - 1)
            {
                if (CanSubtractConsecutiveValues(sb[i], sb[i + 1]))
                {
                    cummulativeValue += GetValueForKey(sb[i + 1]) - GetValueForKey(sb[i]);
                    i++;
                }
                else
                {
                    cummulativeValue += GetValueForKey(sb[i]);
                    if (i == sb.Length - 2)
                        cummulativeValue += GetValueForKey(sb[i + 1]);
                }
                i++;
            }
            return cummulativeValue;
        }
        public Boolean ForbiddenCombinationOrMaximumNumberOfSameLetterExceeded(string str)
        {
            // Define array with characters M, C, X, I from sorted dictionary:
            char[] chMCXI = new char[4] { dyRoman[1000], dyRoman[100], dyRoman[10], dyRoman[1] };

            // Define array with characters V, L, D from sorted dictionary:
            char[] chVLD = new char[3] { dyRoman[5], dyRoman[50], dyRoman[500] };

            int i = 0;
            int countRepititions = 0;

            foreach (var item in chMCXI)
            {
                for (int m = 0; m < str.Length - 1; m++)
                {
                    // Check if the running character is any of ('M', 'C', 'X', 'I') AND if it repeats 
                    // with the next character:
                    if ((str[m] == item) && str[m] == str[m + 1])
                        countRepititions++;
                }
                if (countRepititions > 2)
                {
                    return true;
                }
                countRepititions = 0;
            }

            countRepititions = 0;
            foreach (var item in chVLD)
            {
                for (int m = 0; m < str.Length - 1; m++)
                {
                    // Check if the running character is any of ('M', 'C', 'X', 'I') AND if it repeats 
                    // with the next character:
                    if ((str[m] == item) && str[m] == str[m + 1])
                        countRepititions++;
                }
                if (countRepititions > 0)
                {
                    return true;
                }
                countRepititions = 0;
            }

            for (int h = 1; h < str.Length - 1; h++)
            {
                // Check if the running character is of ('M', 'C', 'X', 'I') AND if it repeats with the next character:
                if (CanSubtractConsecutiveValues(str[h], str[h + 1]) && str[h - 1] == str[h])
                {
                    return true;
                }
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
            // In all other cases it is a valid input and return false:
            return false;
        }
        public Boolean AllCharactersPresentedAreUsedInRomaNumbers(string str)
        {
            string str1 = str.ToUpper();
            foreach (var item in str1)
            {
                if (!letterNumber.ContainsKey(item))
                    return false;
            }
            return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {  
            //string probe = "CCCLXXXVIII";
            int? value;
            GoForIt gfi = new GoForIt();
            string strInput;
            //string strInput = probe;
            while (true)
            {
                Console.WriteLine("Give a roman number (0 for exit)");
                strInput = Console.ReadLine();
                if (strInput == "0")
                {
                    break;
                }
                if (gfi.AllCharactersPresentedAreUsedInRomaNumbers(strInput))
                {
                    value = gfi.CalculateArabicNumber(strInput);
                    if (value != null)
                    {
                        Console.WriteLine($"Corresponding arabic number: {value}");
                    }
                    else
                    {
                        Console.WriteLine("There was a problem in your input!");
                        Console.WriteLine("Check the following rules:");
                        Console.WriteLine("1.) The symbols V, L and D are never repeated.");
                        Console.WriteLine("2.) Any symbol may not occur more than three times.");
                        Console.WriteLine("3.) The symbols V, L and D are never written to the left of a symbol of greater value");
                        Console.WriteLine("Please try again");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("At least one character does not represent a roman number.");
                    Console.WriteLine("Please try again");
                }
            }
        }
    }
}
