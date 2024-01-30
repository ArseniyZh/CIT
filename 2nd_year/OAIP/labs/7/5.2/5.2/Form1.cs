using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5._2
{
    public partial class Form1 : Form
    {
        private int[] array;

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Получаем введенные пользователем значения из TextBox и разбиваем их по пробелам
            string[] inputValues = textBox1.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Проверяем, что были введены значения
            if (inputValues.Length == 0)
            {
                MessageBox.Show("Введите элементы массива через пробел.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Создаем массив для хранения введенных элементов
            array = new int[inputValues.Length];

            // Заполняем массив и выводим его в консоль для отладки
            for (int i = 0; i < inputValues.Length; i++)
            {
                if (int.TryParse(inputValues[i], out array[i]))
                {
                    Console.WriteLine($"Элемент {i + 1}: {array[i]}");
                }
                else
                {
                    MessageBox.Show("Введите корректные целые числа.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Вызываем функцию для нахождения минимального элемента и увеличения его в два раза
            CalculateMinMaxElement(array);

            // Выводим обновленный массив в TextBox
            //outputTextBox.Text = string.Join(" ", array);
            _ = MessageBox.Show($"Итоговый список: {string.Join(" ", array)}");
        }

        private unsafe void CalculateMinMaxElement(int[] array)
        {
            if (array == null || array.Length == 0)
            {
                return;
            }

            fixed (int* ptr = array)
            {
                int* minPtr = ptr;
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i] < *minPtr)
                    {
                        minPtr = ptr + i;
                    }
                }

                *minPtr *= 2;
            }
        }
    }
}
