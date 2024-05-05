using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class RefreshPassword : Form
    {
        public RefreshPassword()
        {
            InitializeComponent();
        }

        string refreshCode = Mail.GenerateCode();
        User user;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                button1.Enabled = true;
            } else
            {
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            User _user = User.manager.get(
                new Dictionary<string, object>
                {
                    {"login", login},
                }
            );

            if (_user != null)
            {
                user = _user;
                MessageBox.Show($"На почту {user.Email} будет отправлено сообщение с кодом");
                new Mail().SendCode(user.Name, user.Email, refreshCode);
            } else
            {
                MessageBox.Show("Пользователь не найден");
                return;
            }

            groupBox2.Enabled = true;
            button2.Enabled = false;
            groupBox1.Enabled = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (refreshCode == textBox2.Text)
            {
                groupBox3.Enabled = true;
                button3.Enabled = false;
                groupBox2.Enabled = false;
            } else
            {
                MessageBox.Show("Неверный код");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                button3.Enabled = true;
            }
            else
            {
                button3.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Validator validator = new Validator();

            string password = textBox3.Text;
            bool validateResult = validator.validateRefreshPassword(password);

            if (validateResult)
            {
                user.Password = User.manager.hashedString(password);

                using (var context = new UserContext())
                {
                    context.Users.AddOrUpdate(user);
                    context.SaveChanges();
                    MessageBox.Show("Пароль успешно изменен.");
                    this.Close();
                }
            }
        }
    }
}
