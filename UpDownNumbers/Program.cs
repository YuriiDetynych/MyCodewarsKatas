using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpDownNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ulong result = CalculateUpDown(5);
            Console.WriteLine(result);
            Console.WriteLine("OK");
            Console.ReadLine();
        }

        private static ulong CalculateUpDown(int x)
        {
            if (x == 0)
            {
                return 1;
            }

            ulong result = CalculateUp(x);
            result += CalculateDown(x);
            return result - (ulong)(9 * x) + 1;
        }


        private static ulong CalculateUp(int nDigits)
        {
            ulong[] arr = { 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            ulong sum = 0;
            for (int i = 1; i < nDigits; i++)
            {
                //ulong arrSum = arr.Sum();
                sum += (ulong)arr.Sum(x => (long)x);
                for (int j = 7; j >= 0; j--)
                {
                    arr[j] += arr[j + 1];
                }
            }

            return sum + (ulong)arr.Sum(x => (long)x);
        }

        private static ulong CalculateDown(int nDigits)
        {
            ulong[] arr = { 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            ulong sum = 0;
            for (int i = 1; i < nDigits; i++)
            {
                sum += (ulong)arr.Sum(x => (long)x);
                arr[0]++;
                for (int j = 1; j <= 8; j++)
                {
                    arr[j] += arr[j - 1];
                }
            }

            return sum + (ulong)arr.Sum(x => (long)x);
        }
    }
}
