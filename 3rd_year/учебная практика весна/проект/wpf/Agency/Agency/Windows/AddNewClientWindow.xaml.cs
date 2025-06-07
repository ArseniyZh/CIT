using Agency.Models;
using System;
using System.Collections.Generic;
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
   
    public partial class AddNewClientWindow : Window
    {
        private readonly AgencyRealEstate _context = new AgencyRealEstate();
        public AddNewClientWindow()
        {
            InitializeComponent();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            ClientsWindow clientsWindow = new ClientsWindow();
            clientsWindow.Show();
            this.Close();
        }
        private bool HasDigits(string input)
        {
            return input.Any(char.IsDigit);
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
        
            string codeText = Codetxt.Text.Trim();
            string lastName = Surnametxt.Text.Trim();
            string firstName = Nametxt.Text.Trim();
            string middleName = Patronymictxt.Text.Trim();
            string password = Passwordtxt.Text.Trim();
            string phone = Phonetxt.Text.Trim();
            string email = Emailtxt.Text.Trim();

       
            if (string.IsNullOrWhiteSpace(codeText) ||
                string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(phone) ||
                string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Все обязательные поля должны быть заполнены.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

          
            if (HasDigits(firstName) || HasDigits(lastName) || HasDigits(middleName))
            {
                MessageBox.Show("Фамилия, имя и отчество не должны содержать цифры.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

           
            if (!int.TryParse(codeText, out int code))
            {
                MessageBox.Show("Код клиента должен быть числом.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (_context.Persons.Any(p => p.Id == code) || _context.Clients.Any(c => c.Id == code))
            {
                MessageBox.Show("Клиент с таким кодом уже существует.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
               
                var newPerson = new Persons
                {
                    Id = code,
                    FirstName = firstName,
                    MiddleName = middleName,
                    LastName = lastName,
                    Password = password,
                    Id_role = 2 // клиент
                };

                _context.Persons.Add(newPerson);
                _context.SaveChanges();

              
                var newClient = new Clients
                {
                    Id = code,
                    Phone = phone,
                    Email = email,
                    Person_Id = code
                };

                _context.Clients.Add(newClient);
                _context.SaveChanges();

                MessageBox.Show("Клиент успешно добавлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

               
                new ClientsWindow().Show();
                this.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении клиента: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
