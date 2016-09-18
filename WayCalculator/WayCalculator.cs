using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxOfTheWay
{
    class WayCalculator
    {
        int height;
        int width;
        public WayCalculator(int heightTriangle, int widthTriangle)
        {
            this.height = heightTriangle;
            this.width = widthTriangle;
        }
        public void CalculateSum(string input)
        {
            int[,] list = new int[height, width];
            var charArray = input.Split('\n');

            for (int i = 0; i < charArray.Length; i++) // Заполняем наш массив данными
            {
                var numArr = charArray[i].Trim().Split(' ');
                for (int j = 0; j < numArr.Length; j++)
                {
                    int number = Convert.ToInt32(numArr[j]);
                    list[i, j] = number;
                }
            }

            for (int i = height - 2; i >= 0; i--) //Движемся по треугольнику снизу вверх и нахоим максимальную сумму пути, максимум будет в массиве по индексу [0,0]
            {
                for (int j = 0; j < width - 1; j++)
                {
                    list[i, j] = Math.Max(list[i, j] + list[i + 1, j], list[i, j] + list[i + 1, j + 1]);
                }
            }
            Console.WriteLine(string.Format("Максимальная сумма до основания составляет: {0}", list[0, 0]));
        }

    }
}
