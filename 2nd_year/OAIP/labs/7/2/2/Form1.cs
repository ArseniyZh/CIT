using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int a) && int.TryParse(textBox2.Text, out int b) && int.TryParse(textBox3.Text, out int c))
            {
                if (a >= b && b >= c)
                {
                    a *= 2;
                    b *= 2;
                    c *= 2;
                }
                else
                {
                    a = Math.Abs(a);
                    b = Math.Abs(b);
                    c = Math.Abs(c);
                }

                label1.Text = $"Результат: a = {a}, b = {b}, c = {c}";
            }
            else
            {
                MessageBox.Show("Введите корректные значения для переменных a, b и c.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
