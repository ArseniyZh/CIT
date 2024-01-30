using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double totalVoltage) &&
                double.TryParse(textBox2.Text, out double current) &&
                double.TryParse(textBox3.Text, out double resistance1) &&
                double.TryParse(textBox4.Text, out double resistance2))
            {
                double totalResistance, voltageDrop1, voltageDrop2;

                CalculateCircuit(totalVoltage, current, resistance1, resistance2, out totalResistance, out voltageDrop1, out voltageDrop2);
                label5.Text = $"Общее сопротивление в цепи: {totalResistance} Ом\n" +
                                   $"Падение напряжения на первом резисторе: {voltageDrop1} Вольт\n" +
                                   $"Падение напряжения на втором резисторе: {voltageDrop2} Вольт";
            }
            else
            {
                label5.Text = "Пожалуйста, введите корректные значения.";
            }
        }

        private void CalculateCircuit(double totalVoltage, double current, double resistance1, double resistance2, out double totalResistance, out double voltageDrop1, out double voltageDrop2)
        {
            // Вычисляем общее сопротивление в цепи (резисторы в последовательном соединении)
            totalResistance = resistance1 + resistance2;

            // Вычисляем падение напряжения на первом резисторе
            voltageDrop1 = current * resistance1;

            // Вычисляем падение напряжения на втором резисторе
            voltageDrop2 = current * resistance2;
        }
    }
}
