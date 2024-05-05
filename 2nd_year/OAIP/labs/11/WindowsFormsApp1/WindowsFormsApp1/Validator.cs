using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class Validator
    {
        public bool ValidateName(string name)
        {
            // Разрешаем буквы, дефисы и пробелы
            return Regex.IsMatch(name, @"^[a-zA-Zа-яА-ЯёЁ\- ]+$");
        }

        public bool ValidateSurname(string surname)
        {
            // Аналогично имени
            return Regex.IsMatch(surname, @"^[a-zA-Zа-яА-ЯёЁ\- ]+$");
        }

        public bool ValidateDateOfBirth(string date)
        {
            // ДД.ММ.ГГГГ формат
            return Regex.IsMatch(date, @"^\d{2}\.\d{2}\.\d{4}$");
        }

        public bool ValidateEmail(string email)
        {
            // Простая проверка электронной почты
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public bool ValidatePhoneNumber(string phoneNumber)
        {
            // Телефон начинается с +7 и содержит 10 цифр после (не считая возможные пробелы и дефисы)
            return Regex.IsMatch(phoneNumber, @"^\+7[\s-]?(\d{3}[\s-]?){2}\d{4}$");
        }

        public bool ValidateRangeOfScience(string range)
        {
            // Проверка на отсутствие спецсимволов
            return Regex.IsMatch(range, @"^[a-zA-Zа-яА-ЯёЁ0-9\- ]+$");
        }

        public bool ValidateDateOfFirstPost(string date)
        {
            // Аналогично дате рождения
            return Regex.IsMatch(date, @"^\d{2}\.\d{2}\.\d{4}$");
        }

        public bool ValidateLogin(string login)
        {
            // Проверка на отсутствие спецсимволов
            return Regex.IsMatch(login, @"^[a-zA-Zа-яА-ЯёЁ0-9\- ]+$");
        }

        public bool validateRegisterData(
            string name,
            string surname,
            string dateOfBirth,
            string email,
            string phoneNumber,
            string rangeOfScience,
            string dateOfFirstPost,
            string login,
            string password
        )
        {
            // Валидация имени
            if (name == "")
            {
                MessageBox.Show("Имя не может быть пустым");
                return false;
            }
            else if (!this.ValidateName(name))
            {
                MessageBox.Show("Имя может содержать только буквы");
                return false;
            }

            // Валидация фамилии
            if (surname == "")
            {
                MessageBox.Show("Фамилия не может быть пустой");
                return false;
            }
            else if (!this.ValidateSurname(surname))
            {
                MessageBox.Show("Фамилия может содержать только буквы");
                return false;
            }

            // Валидация даты рождения
            if (dateOfBirth == "")
            {
                MessageBox.Show("Дата рождения не может быть пустой");
                return false;
            }
            else if (!this.ValidateDateOfBirth(dateOfBirth))
            {
                MessageBox.Show("Дата рождения должна соответствовать формату DD.MM.YYYY");
                return false;
            }

            // Валидация почты
            if (email == "")
            {
                MessageBox.Show("Почта не может быть пустой");
                return false;
            }
            else if (!this.ValidateEmail(email))
            {
                MessageBox.Show("Почта должна соответствовать формату 'email@mail.some'");
                return false;
            }

            // Валидация номера телефона
            if (phoneNumber == "")
            {
                MessageBox.Show("Номер телефона не может быть пустым");
                return false;
            }
            else if (!this.ValidatePhoneNumber(phoneNumber))
            {
                MessageBox.Show("Номер должен начинаться с +7 и содержать 10 цифр после");
                return false;
            }

            // Валидация области исследования
            if (rangeOfScience == "")
            {
                MessageBox.Show("Область исследования не может быть пустой");
                return false;
            }
            else if (!this.ValidateRangeOfScience(rangeOfScience))
            {
                MessageBox.Show("Область исследования может содержать только буквы и цифры");
                return false;
            }

            // Валидация даты первой публикации
            if (dateOfFirstPost == "")
            {
                MessageBox.Show("Дата первой публикации не может быть пустой");
                return false;
            }
            else if (!this.ValidateDateOfFirstPost(dateOfFirstPost))
            {
                MessageBox.Show("Дата первой публикации должна соответствовать формату DD.MM.YYYY");
                return false;
            }

            // Валидация логина
            if (login == "")
            {
                MessageBox.Show("Логин не может быть пустым");
                return false;
            }
            else if (!this.ValidateLogin(login))
            {
                MessageBox.Show("Логин может содержать только буквы и цифры");
                return false;
            } else
            {
                User user = User.manager.get(
                    new Dictionary<string, object>
                    {
                        {"login", login}
                    }
                );

                if (user != null)
                {
                    MessageBox.Show("Пользователь с таким логином уже существует");
                    return false;
                }
            }

            // Валидация пароля
            if (password == "")
            {
                MessageBox.Show("Пароль не может быть пустым");
                return false;
            }

            return true;
        }

        public bool validateSignIn(string login, string password)
        {
            // Валидация логина
            if (login == "")
            {
                MessageBox.Show("Логин не может быть пустым");
                return false;
            }
            // Валидация пароля
            if (password == "")
            {
                MessageBox.Show("Пароль не может быть пустым");
                return false;
            }

            return true;
        }

        public bool validateRefreshPassword(string password)
        {
            // Валидация пароля
            if (password == "")
            {
                MessageBox.Show("Пароль не может быть пустым");
                return false;
            }
            return true;
        }
    }

}
