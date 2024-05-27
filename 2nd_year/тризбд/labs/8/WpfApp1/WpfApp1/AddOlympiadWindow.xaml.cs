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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для AddOlympiadWindow.xaml
    /// </summary>
    public partial class AddOlympiadWindow : Window
    {
        public AddOlympiadWindow()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new OlympiadsEntities1())  // Создайте новый экземпляр для каждой операции
            {
                // Получаем максимальный ID из таблицы Olympiads и прибавляем 1
                int maxId = db.Olympiads.Any() ? db.Olympiads.Max(o => o.OlympiadID) + 1 : 1;

                var olympiad = new Olympiads
                {
                    OlympiadID = maxId,  // Установка ID вручную
                    OlympiadName = txtOlympiadName.Text,
                    OlympiadDate = dpOlympiadDate.SelectedDate,
                    Location = txtLocation.Text
                };

                db.Olympiads.Add(olympiad);
                db.SaveChanges();  // Сохраните изменения
            }

            var olympiadsWindow = new OlympiadsWidnow();
            olympiadsWindow.Show();

            this.Close();  // Закрыть окно после добавления
        }

    }
}
