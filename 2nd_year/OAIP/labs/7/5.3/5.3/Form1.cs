using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5._3
{
    public partial class Form1 : Form
    {
        private int[,] matrix;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int rows) && int.TryParse(textBox2.Text, out int columns))
            {
                if (rows > 0 && columns > 0)
                {
                    // Создаем новую матрицу с заданными размерами
                    matrix = GenerateRandomMatrix(rows, columns);

                    // Выводим матрицу в TextBox
                    DisplayMatrix(matrix, dataGridView2);
                    DisplayMatrix(RotateMatrix(matrix), dataGridView1);
                }
                else
                {
                    MessageBox.Show("Введите корректные значения для размерности матрицы.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Введите корректные значения для размерности матрицы.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int[,] GenerateRandomMatrix(int rows, int columns)
        {
            int[,] result = new int[rows, columns];
            Random random = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result[i, j] = random.Next(-20, 21);
                }
            }

            return result;
        }

        private int[,] RotateMatrix(int[,] originalMatrix)
        {
            int rows = originalMatrix.GetLength(0);
            int columns = originalMatrix.GetLength(1);
            int[,] rotatedMatrix = new int[columns, rows];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    rotatedMatrix[j, rows - 1 - i] = originalMatrix[i, j];
                }
            }

            return rotatedMatrix;
        }

        private void DisplayMatrix(int[,] matrix, DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            // Добавляем столбцы в DataGridView
            for (int j = 0; j < columns; j++)
            {
                dataGridView.Columns.Add($"column{j}", $"Column {j + 1}");
            }

            // Заполняем DataGridView данными из матрицы
            for (int i = 0; i < rows; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView);

                for (int j = 0; j < columns; j++)
                {
                    row.Cells[j].Value = matrix[i, j];
                }

                dataGridView.Rows.Add(row);
            }
        }
    }
}
