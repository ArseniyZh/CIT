using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class RadixSort : Sorter
    {
        public override SortResult Sort(List<int> list, bool saveProcess = true)
        {
            ResetStats();  // Сброс статистики перед началом сортировки
            Stopwatch stopwatch = new Stopwatch();
            StartTimer(stopwatch);  // Запуск таймера

            int i, m = list[0], exp = 1, n = list.Count;
            List<int> b = new List<int>(new int[n]);

            // Найти максимальное число в массиве для определения количества цифр
            for (i = 1; i < n; i++)
            {
                IncrementComparison();
                if (list[i] > m)
                    m = list[i];
            }

            // Сортировать числа по каждому разряду
            while (m / exp > 0)
            {
                int[] bucket = new int[10];

                // Счетчик чисел в каждом бакете
                for (i = 0; i < n; i++)
                {
                    IncrementComparison();
                    bucket[(list[i] / exp) % 10]++;
                }

                // Накапливать сумму для определения индексов
                for (i = 1; i < 10; i++)
                    bucket[i] += bucket[i - 1];

                // Создание временного массива для сортировки по разряду
                for (i = n - 1; i >= 0; i--)
                {
                    b[--bucket[(list[i] / exp) % 10]] = list[i];
                    IncrementSwap();  // Считаем операции перемещения
                }

                // Копировать временный массив в основной
                for (i = 0; i < n; i++)
                    list[i] = b[i];

                exp *= 10;

                if (saveProcess == true)
                {
                    AddToProcessed(list);  // Добавление состояния списка после каждой итерации
                }
            }

            StopTimer(stopwatch);  // Остановка таймера

            return new SortResult
            {
                MethodName = "Radix Sort",
                Comparisons = this.Comparisons,
                Swaps = this.Swaps,
                Time = stopwatch.Elapsed.TotalMilliseconds,
                ElementsCount = list.Count
            };
        }
    }
}
