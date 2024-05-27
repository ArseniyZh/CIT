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
    public partial class EditSubjectWindow : Window
    {
        private Subjects _subject;
        private OlympiadsEntities1 _db;

        public EditSubjectWindow(Subjects subject)
        {
            InitializeComponent();
            _subject = subject;
            this.DataContext = _subject;  // Устанавливаем контекст данных
            _db = new OlympiadsEntities1();  // Создаем экземпляр контекста
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new OlympiadsEntities1())  // Создайте новый экземпляр для каждой операции
            {
                var existingSubject = db.Subjects.Find(_subject.SubjectID);
                if (existingSubject != null)
                {
                    // Копируем изменения в найденный объект
                    db.Entry(existingSubject).CurrentValues.SetValues(_subject);
                    db.SaveChanges();  // Сохраняем изменения
                }
            }

            this.Close();  // Закрываем окно после сохранения
        }


        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить этот предмет?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                using (var currentDbContext = new OlympiadsEntities1())
                {
                    if (currentDbContext.Entry(_subject).State == System.Data.Entity.EntityState.Detached)
                    {
                        var existingOlympiad = currentDbContext.Subjects.Find(_subject.SubjectID);
                        if (existingOlympiad != null)
                        {
                            currentDbContext.Subjects.Remove(existingOlympiad);
                            currentDbContext.SaveChanges();
                        }
                        else
                        {
                            MessageBox.Show("Предмет не найден.");
                        }
                    }
                    else
                    {
                        // Если объект уже отслеживается, его нужно сначала отсоединить
                        currentDbContext.Entry(_subject).State = System.Data.Entity.EntityState.Detached;
                    }
                }
                this.Close();  // Закрываем окно после удаления
            }
        }
    }

}
