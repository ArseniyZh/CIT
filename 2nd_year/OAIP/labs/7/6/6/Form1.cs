using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out int hours) &&
                int.TryParse(textBox1.Text, out int minutes) && hours >= 0 && minutes >= 0)
            {
                Time time = new Time(hours, minutes);
                int totalMinutes = time.MinutesTotal();

                MessageBox.Show($"{hours} часов {minutes} минут составляет {totalMinutes} минут.");
            }
            else
            {
                MessageBox.Show("Введите корректные значения для часов и минут.");
            }
        }
    }

    class Time
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }

        public Time(int hours, int minutes)
        {
            Hours = hours;
            Minutes = minutes;
        }

        public int MinutesTotal()
        {
            return Hours * 60 + Minutes;
        }
    }
}
