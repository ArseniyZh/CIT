using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public List<Point> Points { get; private set; } = new List<Point>();

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int x) && int.TryParse(textBox2.Text, out int y))
            {
                Points.Add(new Point(x, y));
                textBox1.Clear();
                textBox2.Clear();
            }
            else
            {
                MessageBox.Show("Введите корректные числа");
            }
        }
    }
}
