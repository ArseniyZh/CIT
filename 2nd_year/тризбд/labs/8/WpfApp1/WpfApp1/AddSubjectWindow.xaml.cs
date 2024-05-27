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
    /// Логика взаимодействия для AddSubjectWindow.xaml
    /// </summary>
    public partial class AddSubjectWindow : Window
    {
        public AddSubjectWindow()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new OlympiadsEntities1())  // Создайте новый экземпляр для каждой операции
            {
                // Получаем максимальный ID из таблицы Olympiads и прибавляем 1
                int maxId = db.Subjects.Any() ? db.Subjects.Max(o => o.SubjectID) + 1 : 1;

                var subject = new Subjects
                {
                    SubjectID = maxId,  // Установка ID вручную
                    SubjectName = txtSubjectName.Text
                };

                db.Subjects.Add(subject);
                db.SaveChanges();  // Сохраните изменения
            }

            var SubjectsWindow = new SubjectsWindow();
            SubjectsWindow.Show();

            this.Close();  // Закрыть окно после добавления
        }
    }
}
