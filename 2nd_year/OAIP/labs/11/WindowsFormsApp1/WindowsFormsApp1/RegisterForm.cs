using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Validator validator = new Validator();
            string name = this.textBox1.Text;
            string surname = this.textBox2.Text;
            string dateOfBirth = this.textBox3.Text;
            string email = this.textBox4.Text;
            string phoneNumber = this.textBox5.Text;
            string rangeOfScience = this.textBox6.Text;
            string dateOfFirstPost = this.textBox7.Text;
            string login = this.textBox8.Text;
            string password = this.textBox9.Text;

            bool validateResult = validator.validateRegisterData(
                name,
                surname,
                dateOfBirth,
                email,
                phoneNumber,
                rangeOfScience,
                dateOfFirstPost,
                login,
                password
            );

            if (validateResult)
            {
                User.manager.create(
                    name,
                    surname,
                    dateOfBirth,
                    email,
                    phoneNumber,
                    rangeOfScience,
                    dateOfFirstPost,
                    login,
                    password
                );

                MessageBox.Show("Вы успешно зарегистрировались");
                this.Close();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
