using Agency.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Agency.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddAgentWindow.xaml
    /// </summary>
    public partial class AddAgentWindow : Window
    {
        private readonly AgencyRealEstate _context = new AgencyRealEstate();
        public AddAgentWindow()
        {
            InitializeComponent();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            AgentsWindow agentsWindow = new AgentsWindow();
            agentsWindow.Show();
            this.Close();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Codetxt.Text) ||
                string.IsNullOrWhiteSpace(Surnametxt.Text) ||
                string.IsNullOrWhiteSpace(Nametxt.Text) ||
                string.IsNullOrWhiteSpace(Passwordtxt.Text) ||
                string.IsNullOrWhiteSpace(Percentxt.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля.");
                return;
            }

            if (!int.TryParse(Codetxt.Text, out int agentId))
            {
                MessageBox.Show("Код агента должен быть числом.");
                return;
            }

            if (!float.TryParse(Percentxt.Text, out float dealShare))
            {
                MessageBox.Show("Процент должен быть числом.");
                return;
            }

            if (_context.Agents.Any(a => a.Id == agentId))
            {
                MessageBox.Show("Агент с таким кодом уже существует.");
                return;
            }

            try
            {
                // Проверяем, есть ли уже Person с этим Id
                var existingPerson = _context.Persons.FirstOrDefault(p => p.Id == agentId);

                if (existingPerson != null)
                {
                    // Проверяем, не связан ли уже с Agent
                    if (_context.Agents.Any(a => a.Person_Id == existingPerson.Id))
                    {
                        MessageBox.Show("Этот пользователь уже зарегистрирован как агент.");
                        return;
                    }

                    // Обновляем данные
                    existingPerson.LastName = Surnametxt.Text.Trim();
                    existingPerson.FirstName = Nametxt.Text.Trim();
                    existingPerson.MiddleName = Patronymictxt.Text.Trim();
                    existingPerson.Password = Passwordtxt.Text.Trim();
                    existingPerson.Id_role = 1;

                    _context.Persons.AddOrUpdate(existingPerson);
                }
                else
                {
                    // Создаем нового Person
                    existingPerson = new Persons
                    {
                        Id = agentId, // Явно указываем ID
                        LastName = Surnametxt.Text.Trim(),
                        FirstName = Nametxt.Text.Trim(),
                        MiddleName = Patronymictxt.Text.Trim(),
                        Password = Passwordtxt.Text.Trim(),
                        Id_role = 1
                    };

                    _context.Persons.Add(existingPerson);
                }

                _context.SaveChanges();

                // Создаем нового агента
                var newAgent = new Agents
                {
                    Id = agentId,
                    DealShare = dealShare,
                    Person_Id = existingPerson.Id
                };

                _context.Agents.Add(newAgent);
                _context.SaveChanges();

                MessageBox.Show("Агент успешно добавлен.");
                BackBtn_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении агента: " + ex.Message +
                    (ex.InnerException != null ? "\n" + ex.InnerException.Message : ""));
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            // Очищает поля
            Codetxt.Clear();
            Surnametxt.Clear();
            Nametxt.Clear();
            Patronymictxt.Clear();
            Passwordtxt.Clear();
            Percentxt.Clear();
        }
    }
}
  