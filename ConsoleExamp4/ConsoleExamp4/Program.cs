using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleExamp4
{
    internal class Program
    {
        private class RomanFormat
        {
            public int Value;
            public string Sign;
        }

        static List<RomanFormat> listRoman { get; set; }

        static void Main(string[] args)
        {
            GetRomanData();

            while (true)
            {
                Console.Clear();
                Console.Write("Please input (Int or Roman): ");
                string input = Console.ReadLine().ToUpper();

                if (int.TryParse(input, out int number))
                {
                    Console.WriteLine("Result Roman : " + IntToRoman(number));
                }
                else if (IsValidRoman(input))
                {
                    Console.WriteLine("Result Int : " + RomanToInt(input));
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                Console.WriteLine();
                Console.WriteLine("Press ESC to exit or any other key to continue...");
                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Escape)
                    break;
            }
        }

        static void GetRomanData()
        {
            listRoman = new List<RomanFormat>()
            {
                new RomanFormat { Value = 1000, Sign = "M" },
                new RomanFormat { Value = 900,  Sign = "CM" },
                new RomanFormat { Value = 500,  Sign = "D" },
                new RomanFormat { Value = 400,  Sign = "CD" },
                new RomanFormat { Value = 100,  Sign = "C" },
                new RomanFormat { Value = 90,   Sign = "XC" },
                new RomanFormat { Value = 50,   Sign = "L" },
                new RomanFormat { Value = 40,   Sign = "XL" },
                new RomanFormat { Value = 10,   Sign = "X" },
                new RomanFormat { Value = 9,    Sign = "IX" },
                new RomanFormat { Value = 5,    Sign = "V" },
                new RomanFormat { Value = 4,    Sign = "IV" },
                new RomanFormat { Value = 1,    Sign = "I" }
            };
        }

        static string IntToRoman(int number)
        {
            if (number <= 0 || number > 3999)
                return "Range 1-3999 only";

            string result = "";

            foreach (var item in listRoman)
            {
                while (number >= item.Value)
                {
                    result = result + item.Sign;

                    number = number - item.Value;
                }
            }

            return result;
        }

        static int RomanToInt(string roman)
        {
            int totalInt = 0;
            int i = 0;

            while (i < roman.Length)
            {
                foreach (var item in listRoman)
                {
                    if (roman.Substring(i).StartsWith(item.Sign))
                    {
                        totalInt += item.Value;
                        i += item.Sign.Length;
                        break;
                    }
                }
            }

            return totalInt;
        }

        // Check Roman ตามรูปแบบเลขโรมัน
        static bool IsValidRoman(string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;

            input = input.ToUpper();

            foreach (char c in input)
            {
                if ("IVXLCDM".IndexOf(c) == -1)
                    return false;
            }

            int value = RomanToInt(input);

            if (value <= 0 || value > 3999)
                return false;

            return IntToRoman(value) == input;
        }
    }
}
