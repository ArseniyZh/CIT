using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Collections.Generic;
using System.Data.SqlClient;


namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для OlympiadsWidnow.xaml
    /// </summary>
    public partial class OlympiadsWidnow : Window
    {
        public OlympiadsWidnow()
        {
            InitializeComponent();
            LoadOlympiads();
        }

        private void LoadOlympiads()
        {
            using (var db = new OlympiadsEntities1())
            {
                var olympiads = db.Olympiads.Select(o => new
                {
                    o.OlympiadID,
                    o.OlympiadName,
                    o.Location
                }).ToList();

                dataGridOlympiads.ItemsSource = olympiads;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var olympiadsWindow = new AddOlympiadWindow();
            olympiadsWindow.Show();
            this.Close();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            // Получение ID олимпиады
            Button editButton = sender as Button;
            int olympiadId = Convert.ToInt32(editButton.DataContext);

            // Загрузка олимпиады из базы данных
            using (var db = new OlympiadsEntities1())
            {
                Olympiads olympiad = db.Olympiads.FirstOrDefault(o => o.OlympiadID == olympiadId);
                if (olympiad == null)
                {
                    MessageBox.Show("Олимпиада не найдена.");
                    return;
                }

                // Открытие окна редактирования
                EditOlympiadWindow editWindow = new EditOlympiadWindow(olympiad);
                editWindow.ShowDialog();
                LoadOlympiads();
            }
        }
    }
}
