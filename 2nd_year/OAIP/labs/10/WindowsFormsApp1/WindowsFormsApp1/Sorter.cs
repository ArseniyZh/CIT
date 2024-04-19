using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public abstract class Sorter
    {
        protected int Comparisons { get; private set; }
        protected int Swaps { get; private set; }
        protected double SortingTime { get; private set; }
        protected List<List<int>> ProcessedList { get; private set; } = new List<List<int>>();

        public abstract SortResult Sort(List<int> list, bool saveProcess = true);

        protected void ResetStats()
        {
            Comparisons = 0;
            Swaps = 0;
            SortingTime = 0.0;
            ProcessedList.Clear();
        }

        protected void IncrementComparison()
        {
            Comparisons++;
        }

        protected void IncrementSwap()
        {
            Swaps++;
        }

        protected void StartTimer(Stopwatch stopwatch)
        {
            stopwatch.Restart();
        }

        protected void StopTimer(Stopwatch stopwatch)
        {
            stopwatch.Stop();
            SortingTime = stopwatch.Elapsed.TotalMilliseconds;
        }

        protected void AddToProcessed(List<int> list)
        {
            ProcessedList.Add(new List<int>(list));
        }

        public int GetComparisons()
        {
            return Comparisons;
        }

        public int GetSwaps()
        {
            return Swaps;
        }

        public double GetSortingTime()
        {
            return SortingTime;
        }

        public List<List<int>> GetProcessedList()
        {
            return ProcessedList;
        }
    }

    public class SortResult
    {
        public string MethodName { get; set; }
        public int Comparisons { get; set; }
        public int Swaps { get; set; }
        public double Time { get; set; }
        public int ElementsCount { get; set; }
    }

}
