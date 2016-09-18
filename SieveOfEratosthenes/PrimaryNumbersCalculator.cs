using System;
using System.Linq;

namespace SieveOfEratosthenes
{
    public class PrimaryNumbersCalculator : IPrimaryNumbersCalculator
    {
        const int Zero = 0;
        const int FirstNumber = 2;
        const int MaxOneDigitNumber = 9;
        static readonly int[] Dividers = { '0', '2', '4', '6', '8', '5' };

        public int[] CalculateAllPrimaryNumbers(int size, bool returnOnlyPrimaryNumbers = true) //поиск простых чисел в диапазоне
        {
            var p = FirstNumber;
            var source = Enumerable.Range(p, size - p + 1).ToArray();

            CrossAllNonePrimeNumbers(source, p);
            p++;

            while (p <= size)
            {
                CrossAllNonePrimeNumbers(source, p);
                p += 2;
            }

            return returnOnlyPrimaryNumbers ? source.Where(x => x != Zero).ToArray() : source;
        }

        public int[] CalculateAllCircularPrimaryNumbers(int size)// поиск circular prime в диапазоне
        {
            if (size <= 0)
            {
                throw new ArgumentException(nameof(size));
            }

            var source = CalculateAllPrimaryNumbers(size, false);
            
            var firstIndex = GetFirstNoneOneDigitNumberIndex(source);
            for (var i = firstIndex; i < source.Length; i++)
            {
                var number = source[i];
                if (number == Zero)
                {
                    continue;
                }

                var numberStr = number.ToString();
                if (numberStr.Any(x => Dividers.Any(y => y == x)))
                {
                    source[i] = Zero;
                }
                else
                {
                    var attempt = 1;
                    while (attempt < numberStr.Length)
                    {
                        numberStr = numberStr.Shift(1);

                        var shiftedNumber = int.Parse(numberStr);
                        var shiftedNumberIndex = shiftedNumber - 2;
                        if (shiftedNumberIndex < source.Length && source[shiftedNumberIndex] == Zero)
                        {
                            source[i] = Zero;
                            break;
                        }

                        attempt++;
                    }
                }
            }

            return source.Where(x => x != Zero).ToArray();
        }

        private int GetFirstNoneOneDigitNumberIndex(int[] source) //определение индекса, после которого начинаются двузначные числа
        {
            var firstIndex = Zero;

            for (var i = 0; i < source.Length; i++)
            {
                if (source[i] > MaxOneDigitNumber)
                {
                    firstIndex = i;
                    break;
                }
            }

            return firstIndex;
        }

        private void CrossAllNonePrimeNumbers(int[] source, int startPosition)
        {
            long step = startPosition;
            var position = startPosition * step - 2;

            while (position < source.Length)
            {
                source[position] = Zero;
                step++;
                position = startPosition * step - 2;
            }
        }
    }
}