using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<int> mainList = new List<int>();

        private void clearAll()
        {
            richTextBox1.Clear();
            button1.Enabled = true;
            button3.Enabled = false;
            button5.Enabled = true;
            mainList.Clear();

            label1.Text = "Количество\nсравнений:";
            label2.Text = "Количество\nперестановок:";
            label3.Text = "Время\nсортировки:";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Сгенерировать

            int.TryParse(textBox1.Text, out int n);

            if (n <= 0)
            {
                MessageBox.Show("Количество элементов должно быть больше 0");
                return;
            }

            mainList = Utils.GenerateRandomList(n);
            string strList = string.Join(" ", mainList);

            richTextBox1.Text = $"---> Текущий список\n{strList}";
            button1.Enabled = false;
            button3.Enabled = true;
            button5.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Очистить все

            clearAll();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Отсортировать

            Sorter sorter;
            int selectedSort = comboBox1.SelectedIndex;

            if (selectedSort == 0)
            {
                sorter = new SelectionSort();
            } else
            {
                sorter = new RadixSort();
            }

            sorter.Sort(mainList);
            string strList = string.Join(" ", mainList);
            richTextBox1.Text += $"\n\n---> Отсортированный список\n{strList}\nИтерации";

            button3.Enabled = false;
            label1.Text += $" {sorter.GetComparisons()}";
            label2.Text += $" {sorter.GetSwaps()}";
            label3.Text += $" {sorter.GetSortingTime()}ms";
            List<List<int>> ProcessedList = sorter.GetProcessedList();
            for (int i = 0;  i < ProcessedList.Count; i++)
            {
                List<int> currentList = ProcessedList[i];
                richTextBox1.Text += "\n" + string.Join(" ", currentList);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            clearAll();

            // Настройка OpenFileDialog
            openFileDialog1.Title = "Выберите текстовый файл";
            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"; // Фильтр для текстовых файлов

            // Показываем диалог и проверяем, был ли файл выбран
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName; // Получаем полный путь к файлу

                try
                {
                    // Чтение файла и вывод его содержимого
                    string fileContent = System.IO.File.ReadAllText(filePath);
                    string[] numbersStr = fileContent.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string num in numbersStr)
                    {
                        if (int.TryParse(num, out int parsedNumber))
                        {
                            mainList.Add(parsedNumber);
                        }
                        else
                        {
                            MessageBox.Show($"Не удалось преобразовать '{num}' в число.");
                        }
                    }
                    string strList = string.Join(" ", mainList);

                    richTextBox1.Text = $"---> Текущий список\n{strList}";
                    button1.Enabled = false;
                    button3.Enabled = true;
                    button5.Enabled = false;
                }
                catch (Exception ex)
                {
                    // Обработка возможных ошибок при чтении файла
                    MessageBox.Show("Ошибка чтения файла: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
