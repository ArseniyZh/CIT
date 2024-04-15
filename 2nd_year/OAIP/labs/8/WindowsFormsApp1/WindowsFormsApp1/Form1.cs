using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;

        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            Init.pen = new Pen(Color.Purple, 5);
            Init.bitmap = bitmap;
            Init.pictureBox = pictureBox1;
            ShapeContainer.figureList = new List<Figure>(1);

            label15.Text = $"w: {pictureBox1.ClientSize.Width} h: {pictureBox1.ClientSize.Height}";
        }

        int startX, startY;

        private bool checkStartCoordinates()
        {
            bool _error = false;
            string _errorText = "";

            if (! int.TryParse(textBox3.Text, out int x) && (x < 0 || x > pictureBox1.ClientSize.Width))
            {
                _error = true;
                _errorText = $"Введите корректное значение начальной координаты X: {textBox3.Text}";
            }
            if (! int.TryParse(textBox4.Text, out int y) && !_error && (y < 0 || y > pictureBox1.ClientSize.Height))
            {
                _error = true;
                _errorText = $"Введите корректное значение начальной координаты Y: {textBox4.Text}";
            }

            startX = x;
            startY = y;

            if (_error)
            {
                MessageBox.Show(_errorText);
                return false;
            }

            return true;
        }

        private void raiseIncorrectStartX()
        {
            MessageBox.Show("Введите корректное значение X");
            textBox3.Focus();
            return;
        }

        private void raiseIncorrectStartY()
        {
            MessageBox.Show("Введите корректное значение Y");
            textBox4.Focus();
            return;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Прямоугольник

            bool checkError = checkStartCoordinates();
            if (!checkError) { return; }

            int.TryParse(textBox1.Text, out int a);
            int.TryParse(textBox2.Text, out int b);

            if (a <= 0 || b <= 0)
            {
                MessageBox.Show("Введите значения больше 0");
            }

            if (startX + a >= pictureBox1.ClientSize.Width)
            {
                raiseIncorrectStartX();
                return;
            }
            if (startY + b >= pictureBox1.ClientSize.Width)
            {
                raiseIncorrectStartY();
                return;
            }

            Rectangle rectangle = new Rectangle(startX, startY, a, b);
            ShapeContainer.figureList.Add(rectangle);
            comboBox1.Items.Add($"Прямоугольник ({a}; {b})"); ; ;
            rectangle.Draw();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Квадрта
            bool checkError = checkStartCoordinates();
            if (!checkError) { return; }

            int.TryParse(textBox6.Text, out int a);

            if (a <= 0)
            {
                MessageBox.Show("Введите значение больше 0");
            }


            if (a <= 0)
            {
                MessageBox.Show($"Введите корректные значение длины");
                return;
            } if (startX + a >= pictureBox1.ClientSize.Width)
            {
                raiseIncorrectStartX();
                return;
            }
            if (startY + a >= pictureBox1.ClientSize.Height)
            {
                raiseIncorrectStartY();
                return;
            }

            Square square = new Square(startX, startY, a);
            ShapeContainer.figureList.Add(square);
            comboBox1.Items.Add($"Квадрат ({a})");
            square.Draw();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Многоугольник

            bool checkError = checkStartCoordinates();
            if (!checkError) { return; }

            int.TryParse(textBox7.Text, out int a);
            int.TryParse(textBox5.Text, out int b);

            if (a < 0 || b < 0)
            {
                MessageBox.Show("Введите значения больше 0");
                return;
            }


            if (a > pictureBox1.ClientSize.Width || a > pictureBox1.ClientSize.Height)
            {
                MessageBox.Show($"Введите корректное значение высоты");
                textBox7.Text = "";
                textBox7.Focus();
                return;
            }
            if (startX + a >= pictureBox1.ClientSize.Width)
            {
                raiseIncorrectStartX();
                return;
            }
            if (startY + a >= pictureBox1.ClientSize.Height)
            {
                raiseIncorrectStartY();
                return;
            }

            Polygon polygon = new Polygon(startX, startY, a, b);
            ShapeContainer.figureList.Add(polygon);
            comboBox1.Items.Add($"Многоугольник ({a}; {b})");
            polygon.Draw();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Треугольник

            bool checkError = checkStartCoordinates();
            if (!checkError) { return; }

            int.TryParse(textBox8.Text, out int a);

            if (a <= 0)
            {
                MessageBox.Show("Введите значение больше 0");
                return;
            }

            if (a > pictureBox1.ClientSize.Width || a > pictureBox1.ClientSize.Height)
            {
                MessageBox.Show("Введите значение больше 0");
                textBox4.Text = "";
                textBox4.Focus();
                return;
            }
            if (startX + a >= pictureBox1.ClientSize.Width)
            {
                raiseIncorrectStartX();
                return;
            }
            if (startY + a >= pictureBox1.ClientSize.Height)
            {
                raiseIncorrectStartY();
                return;
            }

            Triangle triangle = new Triangle(startX, startY, a);
            ShapeContainer.figureList.Add(triangle);
            comboBox1.Items.Add($"Треугольник ({a})");
            triangle.Draw();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Элипс

            bool checkError = checkStartCoordinates();
            if (!checkError) { return; }

            int.TryParse(textBox10.Text, out int a);
            int.TryParse(textBox9.Text, out int b);

            if (a <= 0 || b <= 0)
            {
                MessageBox.Show("Введите значения больше 0");
                return;
            }

            if (startX + a >= pictureBox1.ClientSize.Width)
            {
                raiseIncorrectStartX();
                return;
            }
            if (startY + b >= pictureBox1.ClientSize.Height)
            {
                raiseIncorrectStartY();
                return;
            }

            Ellipse ellipse = new Ellipse(startX, startY, a, b);
            ShapeContainer.figureList.Add(ellipse);
            comboBox1.Items.Add($"Элипс ({a}; {b})");
            ellipse.Draw();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Круг

            bool checkError = checkStartCoordinates();
            if (!checkError) { return; }

            int.TryParse(textBox11.Text, out int a);

            if (a <= 0)
            {
                MessageBox.Show("Введите значение больше 0");
                return;
            }

            if (startX + a >= pictureBox1.ClientSize.Width)
            {
                raiseIncorrectStartX();
                return;
            }
            if (startY + a >= pictureBox1.ClientSize.Height)
            {
                raiseIncorrectStartY();
                return;
            }

            Circle circle = new Circle(startX, startY, a);
            ShapeContainer.figureList.Add(circle);
            comboBox1.Items.Add($"Круг ({a})");
            circle.Draw();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Дом

            bool checkError = checkStartCoordinates();
            if (!checkError) { return; }

            int.TryParse(textBox15.Text, out int a);
            int.TryParse(textBox14.Text, out int b);

            if (a <= 0 || b <= 0)
            {
                MessageBox.Show("Введите значения больше 0");
                return;
            }

            if (startX + a * 2 > pictureBox1.ClientSize.Width || startY + a * 2 > pictureBox1.ClientSize.Height)
            {
                raiseIncorrectStartX();
                return;
            }
            if (startX + b * 2 > pictureBox1.ClientSize.Width || startY + b * 2 > pictureBox1.ClientSize.Height)
            {
                raiseIncorrectStartX();
                return;
            }

            House house = new House(startX, startY, a, b);
            ShapeContainer.figureList.Add(house);
            comboBox1.Items.Add($"Дом ({a}; {b})");
            house.Draw();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
                Figure.DeleteF(ShapeContainer.figureList[comboBox1.SelectedIndex]);
                comboBox1.Items.RemoveAt(comboBox1.SelectedIndex);
                comboBox1.SelectedIndex = -1;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
                int.TryParse(textBox12.Text, out int newX);
                int.TryParse(textBox13.Text, out int newY);

                if (newX <= 0 || newY <= 0)
                {
                    MessageBox.Show("Введите корректные значения новых координат");
                    return;
                }
                
                ShapeContainer.figureList[comboBox1.SelectedIndex].MoveTo(newX, newY, comboBox1.SelectedIndex);
                return;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
