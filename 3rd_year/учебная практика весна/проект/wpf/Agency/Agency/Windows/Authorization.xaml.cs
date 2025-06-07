using Agency.Models;
using System.Linq;
using System.Windows;

namespace Agency.Windows
{
    public partial class Authorization : Window
    {
        private readonly AgencyRealEstate _context = new AgencyRealEstate();

        public Authorization()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
           
            string personIdText = Codetxtbox.Text.Trim();
            string password = Passwordtxtbox.Text.Trim();

           
            if (string.IsNullOrWhiteSpace(personIdText) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Пожалуйста, заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            
            if (!int.TryParse(personIdText, out int personId))
            {
                MessageBox.Show("Некорректный формат кода", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

           
            var user = _context.Persons.FirstOrDefault(p => p.Id == personId && p.Password == password);

            if (user != null)
            {
                if (user.Id_role == 1)
                {
                    MessageBox.Show($"Добро пожаловать, {user.MiddleName}!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    AgencyWindow agencyWindow = new AgencyWindow();
                    agencyWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("У вас нет доступа к системе.");
                }
              
            }
            else
            {
                MessageBox.Show("Неверный код или пароль", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Codetxtbox_TextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.All(char.IsDigit);
        }
    }
}