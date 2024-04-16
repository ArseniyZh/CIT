using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oaip_9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Init.pen = new Pen(Color.Aqua, 5);
            Init.bitmap = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            Init.pictureBox = pictureBox1;
        }

        private void textBoxInputString_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (RPN.CalculateRPN(textBoxInputString.Text))
                {
                    richTextBox1.Text += textBoxInputString.Text + " - выполнено\n";
                }
                else
                {
                    richTextBox1.Text += textBoxInputString.Text + " - не выполнено\n";
                }
                textBoxInputString.Text = "";
            }
        }
    }
}
