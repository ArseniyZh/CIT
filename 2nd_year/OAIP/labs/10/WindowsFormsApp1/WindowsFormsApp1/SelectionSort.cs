using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class SelectionSort : Sorter
    {
        public override SortResult Sort(List<int> list, bool saveProcess = true)
        {
            ResetStats();
            Stopwatch stopwatch = new Stopwatch();
            StartTimer(stopwatch);

            int n = list.Count;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    IncrementComparison();
                    if (list[j] < list[minIndex])
                        minIndex = j;
                }

                if (minIndex != i)
                {
                    int temp = list[minIndex];
                    list[minIndex] = list[i];
                    list[i] = temp;
                    IncrementSwap();
                }

                if (saveProcess == true)
                {
                    AddToProcessed(list);
                }
            }

            StopTimer(stopwatch);

            return new SortResult
            {
                MethodName = "Selection Sort",
                Comparisons = this.Comparisons,
                Swaps = this.Swaps,
                Time = stopwatch.Elapsed.TotalMilliseconds,
                ElementsCount = list.Count
            };
        }
    }

}
