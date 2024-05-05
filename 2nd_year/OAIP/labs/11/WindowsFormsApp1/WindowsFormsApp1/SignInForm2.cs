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
    public partial class SignInForm2 : Form
    {
        public SignInForm2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Validator validator = new Validator();
            string login = textBox8.Text;
            string password = textBox9.Text;

            bool validateResult = validator.validateSignIn(login, password);

            if (validateResult)
            {
                User user = User.manager.get(
                    new Dictionary<string, object>
                    {
                        {"login", login},
                        {"password", User.manager.hashedString(password)}
                    }
                );

                if (user != null)
                {
                    MessageBox.Show(
                        "Вы успешно вошли!\n\n" +
                        $"Имя: {user.Name}\n" +
                        $"Фамилия: {user.Surname}\n" +
                        $"Дата рождения: {user.DateOfBirth}\n" +
                        $"E-mail: {user.Email}\n" +
                        $"Номер телефона: {user.PhoneNumber}\n" +
                        $"Область исследования: {user.RangeOfScience}\n" +
                        $"Дата первой публикации: {user.DateOfFirstPost}\n"
                    );
                } else
                {
                    MessageBox.Show("Пользователь с такими данными не найден :(");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form refreshPasswordForm = new RefreshPassword();
            refreshPasswordForm.ShowDialog();
        }
    }
}
