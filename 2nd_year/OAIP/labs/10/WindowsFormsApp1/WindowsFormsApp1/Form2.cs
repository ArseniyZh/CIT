using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        public static void AddAnalyzRow(DataGridView dataGridView, int n, ref List<SortResult> results)
        {
            Sorter selectionSort = new SelectionSort();
            Sorter radixSort = new RadixSort();

            List<int> analyzList1 = Utils.GenerateRandomList(n);
            List<int> analyzList2 = new List<int>(analyzList1); // Копируем

            SortResult result1 = selectionSort.Sort(analyzList1, false);
            SortResult result2 = radixSort.Sort(analyzList2, false);

            results.Add(result1);
            results.Add(result2);

            string analyzString1 = $"С: {result1.Comparisons} П: {result1.Swaps} В: {result1.Time}ms";
            string analyzString2 = $"С: {result2.Comparisons} П: {result2.Swaps} В: {result2.Time}ms";

            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dataGridView);
            row.SetValues(analyzString1, analyzString2);
            row.HeaderCell.Value = $"{n}";
            dataGridView.Rows.Add(row);
        }

        public void AnalyzeAndDisplayResults(List<SortResult> results)
        {
            if (results.Count == 0) return;

            // Нахождение наилучших и наихудших результатов по количеству сравнений
            var bestByComparisons = results.OrderBy(r => r.Comparisons).First();
            var worstByComparisons = results.OrderByDescending(r => r.Comparisons).First();

            // Вывод результатов
            string message = $"Лучший метод сортировки по минимальному количеству сравнений ({bestByComparisons.Comparisons} сравнений) для массива из {bestByComparisons.ElementsCount} элементов - {bestByComparisons.MethodName}.\n" +
                             $"Худший метод сортировки по максимальному количеству сравнений ({worstByComparisons.Comparisons} сравнений) для массива из {worstByComparisons.ElementsCount} элементов - {worstByComparisons.MethodName}.";

            label1.Text = message;

            // MessageBox.Show(message, "Анализ эффективности сортировок", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void InitializeDataGridView()
        {
            DataGridView dataGridView = new DataGridView
            {
                Location = new System.Drawing.Point(0, 0),
                Size = new System.Drawing.Size(600, 150),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            Controls.Add(dataGridView);

            // Добавляем столбцы
            dataGridView.Columns.Add("Column1", "Метод выбора");
            dataGridView.Columns.Add("Column2", "Метод поразрядной сортировки");

            List<SortResult> allSortResults = new List<SortResult>();
            // Создаем строки с данными и заголовками
            AddAnalyzRow(dataGridView, 10, ref allSortResults);
            AddAnalyzRow(dataGridView, 20, ref allSortResults);
            AddAnalyzRow(dataGridView, 30, ref allSortResults);
            AddAnalyzRow(dataGridView, 40, ref allSortResults);
            AddAnalyzRow(dataGridView, 50, ref allSortResults);

            AnalyzeAndDisplayResults(allSortResults);

            // Обновляем внешний вид заголовков строк
            dataGridView.RowHeadersVisible = true; // Убедитесь, что заголовки строк видимы
            dataGridView.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders); // Опционально: Автоматически изменить ширину заголовков строк
        }
    }
}
