using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExamp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Tribonacci");

                Console.Write("Input signature (comma separated, Demo 1,1,1): ");
                string inputSignature = Console.ReadLine();

                int[] signature = ParseSignature(inputSignature);

                Console.Write("Please enter an integer : ");
                if (!int.TryParse(Console.ReadLine(), out int maxCount) || maxCount < 0)
                {
                    Console.WriteLine("Invalid Max Count!");
                }
                else
                {
                    var result = Tribonacci(signature, maxCount);
                    Console.WriteLine("Result: [" + string.Join(", ", result) + "]");
                }

                Console.WriteLine();
                Console.WriteLine("Press ESC to exit or any key to continue...");
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Escape)
                    break;
            }
        }

        static int[] ParseSignature(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return new int[] { };

            return input
                .Split(',')
                .Select(x => int.TryParse(x.Trim(), out int num) ? num : 0)
                .Take(3) 
                .ToArray();
        }

        
        static List<int> Tribonacci(int[] signature, int n)
        {
            List<int> result = new List<int>();

            if (n == 0)
                return result;

            result.AddRange(signature);

            if (result.Count > n)
                return result.Take(n).ToList();

            while (result.Count < 3)
                result.Add(0);

            while (result.Count < n)
            {
                int next =
                    result[result.Count - 1] +
                    result[result.Count - 2] +
                    result[result.Count - 3];

                result.Add(next);
            }

            return result;
        }
    }
}

