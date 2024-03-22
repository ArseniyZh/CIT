namespace _3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int x))
            {
                if (x >= 130)
                {
                    float result = 1;

                    for (int i = 2; i <= 128; i++)
                    {
                        result *= (x - i) / (x - i - 1);
                    }

                    label2.Text = $"Результат: {result}";
                }
                else
                {
                    MessageBox.Show("Значение x не может быть меньше 130.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Введите корректные значения для переменной x.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}