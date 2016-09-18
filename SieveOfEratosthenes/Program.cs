using System;
using System.Collections.Generic;
using System.Linq;

namespace SieveOfEratosthenes
{
    class Program
    {
        static void Main(string[] args)
        {
            const int N = 1000000;
            
            IPrimaryNumbersCalculator calculator = new PrimaryNumbersCalculator();

            var startTime = DateTime.Now;

            var source = calculator.CalculateAllCircularPrimaryNumbers(N);

            var finishTime = DateTime.Now;
            var executingTime = finishTime - startTime;

            Print(source, N, executingTime);

            /*
            for (var i = 1; i <= 100; i++)
            {
                var startTime = DateTime.Now;

                var source = calculator.CalculateAllCircularPrimaryNumbers(i);

                var finishTime = DateTime.Now;
                var executingTime = finishTime - startTime;

                Print(source, N, executingTime, false);
            } 
            */

            Console.ReadKey();
        }

        private static void Print(IEnumerable<int> source, int size, TimeSpan executingTime, bool needPrintPrimaryNumbers = true)
        {
            Console.Write("Диапазон: " + size + " ");
            Console.Write("Найдено circular prime: " + source.Count() + " ");
            Console.WriteLine("Время поиска: " + executingTime.TotalSeconds);

            if (needPrintPrimaryNumbers)
            {
                foreach (var i in source)
                {
                    Console.Write(i + ", ");
                }

                Console.WriteLine();
            }
        }
    }
}