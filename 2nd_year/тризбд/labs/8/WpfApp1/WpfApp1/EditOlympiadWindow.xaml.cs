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
    /// Логика взаимодействия для EditOlympiadWindow.xaml
    /// </summary>
    public partial class EditOlympiadWindow : Window
    {
        private Olympiads _olympiad;
        private OlympiadsEntities1 _db;

        public EditOlympiadWindow(Olympiads olympiad)
        {
            InitializeComponent();
            _olympiad = olympiad;
            this.DataContext = _olympiad;  // Устанавливаем контекст данных
            _db = new OlympiadsEntities1();  // Создаем экземпляр контекста
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new OlympiadsEntities1())  // Создайте новый экземпляр для каждой операции
            {
                var existingOlympiad = db.Olympiads.Find(_olympiad.OlympiadID);
                if (existingOlympiad != null)
                {
                    // Копируем изменения в найденный объект
                    db.Entry(existingOlympiad).CurrentValues.SetValues(_olympiad);
                    db.SaveChanges();  // Сохраняем изменения
                }
            }

            this.Close();  // Закрываем окно после сохранения
        }


        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить эту олимпиаду?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                using (var currentDbContext = new OlympiadsEntities1())
                {
                    if (currentDbContext.Entry(_olympiad).State == System.Data.Entity.EntityState.Detached)
                    {
                        var existingOlympiad = currentDbContext.Olympiads.Find(_olympiad.OlympiadID);
                        if (existingOlympiad != null)
                        {
                            currentDbContext.Olympiads.Remove(existingOlympiad);
                            currentDbContext.SaveChanges();
                        }
                        else
                        {
                            MessageBox.Show("Олимпиада не найдена.");
                        }
                    }
                    else
                    {
                        // Если объект уже отслеживается, его нужно сначала отсоединить
                        currentDbContext.Entry(_olympiad).State = System.Data.Entity.EntityState.Detached;
                    }
                }
                this.Close();  // Закрываем окно после удаления
            }
        }
    }

}
