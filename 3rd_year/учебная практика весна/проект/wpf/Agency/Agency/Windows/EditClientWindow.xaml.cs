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
    
    public partial class EditClientWindow : Window
    {
        private readonly AgencyRealEstate _context = new AgencyRealEstate();
        private int _personId;
        private Clients _client;
        private Persons _person;
        public EditClientWindow(int personId)
        {
            InitializeComponent();
            _personId = personId;
            try
            {
                _client = _context.Clients.FirstOrDefault(c => c.Person_Id == _personId);
                _person = _context.Persons.FirstOrDefault(p => p.Id == _personId);

                if (_client != null && _person != null)
                {
                    Codetxt.Text = _client.Id.ToString();
                    Surnametxt.Text = _person.LastName;
                    Nametxt.Text = _person.FirstName;
                    Patronymictxt.Text = _person.MiddleName;
                    Passwordtxt.Text = _person.Password;
                    Emailtxt.Text = _client.Email;
                    Phonetxt.Text = _client.Phone;
                }
                else
                {
                    MessageBox.Show("Клиент не найден.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки клиента: {ex.Message}");
                this.Close();
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_client == null || _person == null)
                {
                    MessageBox.Show("Ошибка: данные клиента не загружены.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(Surnametxt.Text) ||
                    string.IsNullOrWhiteSpace(Nametxt.Text) ||
                    string.IsNullOrWhiteSpace(Passwordtxt.Text) ||
                    string.IsNullOrWhiteSpace(Phonetxt.Text) ||
                    string.IsNullOrWhiteSpace(Emailtxt.Text))
                {
                    MessageBox.Show("Заполните все обязательные поля.");
                    return;
                }

               
                _person.LastName = Surnametxt.Text.Trim();
                _person.FirstName = Nametxt.Text.Trim();
                _person.MiddleName = Patronymictxt.Text.Trim();
                _person.Password = Passwordtxt.Text.Trim();
                _client.Phone = Phonetxt.Text.Trim();
                _client.Email = Emailtxt.Text.Trim();

                _context.SaveChanges();

                MessageBox.Show("Данные клиента успешно обновлены.");
                ClientsWindow clientsWindow = new ClientsWindow();
                clientsWindow.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}");
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            ClientsWindow clientsWindow = new ClientsWindow();
            clientsWindow.Show();
            this.Close();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить этого клиента?", "Подтверждение удаления",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                  
                    var clientToRemove = _context.Clients.FirstOrDefault(c => c.Id == _person.Id);
                    if (clientToRemove != null)
                    {
                       
                        var personToRemove = _context.Persons.FirstOrDefault(p => p.Id == clientToRemove.Person_Id);

                     
                        _context.Clients.Remove(clientToRemove);

                     
                        bool personUsedElsewhere = _context.Clients.Any(c => c.Person_Id == personToRemove.Id && c.Id != clientToRemove.Id);
                        if (personToRemove != null && !personUsedElsewhere)
                        {
                            _context.Persons.Remove(personToRemove);
                        }

                        _context.SaveChanges();
                        MessageBox.Show("Клиент успешно удалён.");

                        
                        ClientsWindow clientsWindow = new ClientsWindow();
                        clientsWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Клиент не найден.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении клиента: " + ex.Message);
                }
            }
        }
    }
}
