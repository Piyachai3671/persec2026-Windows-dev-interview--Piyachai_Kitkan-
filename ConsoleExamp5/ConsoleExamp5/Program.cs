using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExamp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input;
          
            while (true)
            {
                Console.Write("Please Input Positive Integer Value: ");
                if (int.TryParse(Console.ReadLine(), out input) && input > 0)
                {
                    break;
                }
            
                Console.WriteLine("Invalid input. Try again.\n");
            }
          int result= SetDataInt(input);
            Console.WriteLine("Result is : " + result);
            Console.ReadLine();
        }
        static int SetDataInt(int input)
        {
            var arr = input.ToString().ToArray();
            var orderDes = arr.OrderByDescending(e => e).ToArray();
            return Convert.ToInt32(string.Join("", orderDes));
             
        }
    }
}
