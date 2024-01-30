using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Получаем порядок матрицы из текстового поля
            if (int.TryParse(textBox1.Text, out int order) && order > 0)
            {
                // Генерируем случайную квадратную матрицу
                int[,] originalMatrix = GenerateRandomMatrix(order);

                // Создаем новую матрицу согласно условию
                int[,] resultMatrix = CalculateNewMatrix(originalMatrix);

                // Отображаем исходную матрицу в первой вкладке
                DisplayMatrix(originalMatrix, "Исходная матрица", dataGridView1);

                // Отображаем результирующую матрицу во второй вкладке
                DisplayMatrix(resultMatrix, "Результирующая матрица", dataGridView2);
            }
            else
            {
                MessageBox.Show("Введите корректный порядок матрицы (целое положительное число).", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int[,] GenerateRandomMatrix(int order)
        {
            Random random = new Random();
            int[,] matrix = new int[order, order];

            for (int i = 0; i < order; i++)
            {
                for (int j = 0; j < order; j++)
                {
                    matrix[i, j] = random.Next(101); // Генерируем случайные числа от 0 до 100
                }
            }

            return matrix;
        }

        private int[,] CalculateNewMatrix(int[,] originalMatrix)
        {
            int order = originalMatrix.GetLength(0);
            int[,] resultMatrix = new int[order, order];

            for (int i = 0; i < order; i++)
            {
                for (int j = 0; j < order; j++)
                {
                    if (originalMatrix[i, j] > originalMatrix[i, i])
                    {
                        resultMatrix[i, j] = 1;
                    }
                    else
                    {
                        resultMatrix[i, j] = 0;
                    }
                }
            }

            return resultMatrix;
        }

        private void DisplayMatrix(int[,] matrix, string header, DataGridView dataGridView)
        {
            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();
            dataGridView.ColumnCount = matrix.GetLength(1);

            dataGridView.Rows.Add(matrix.GetLength(0));
            dataGridView.Rows[0].HeaderCell.Value = header;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    dataGridView[j, i].Value = matrix[i, j];
                }
            }

            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.Width = 25;
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
