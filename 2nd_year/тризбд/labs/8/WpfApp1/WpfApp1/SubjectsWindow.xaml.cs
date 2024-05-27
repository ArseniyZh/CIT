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
    /// Логика взаимодействия для SubjectsWindow.xaml
    /// </summary>
    public partial class SubjectsWindow : Window
    {
        public SubjectsWindow()
        {
            InitializeComponent();
            LoadSubjects();
        }

        private void LoadSubjects()
        {
            using (var db = new OlympiadsEntities1())
            {
                var subjects = db.Subjects.Select(o => new
                {
                    o.SubjectID,
                    o.SubjectName
                }).ToList();

                dataGridOlympiads.ItemsSource = subjects;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var subjectWindow = new AddSubjectWindow();
            subjectWindow.Show();
            this.Close();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            // Получение ID олимпиады
            Button editButton = sender as Button;
            int subjectId = Convert.ToInt32(editButton.DataContext);

            // Загрузка олимпиады из базы данных
            using (var db = new OlympiadsEntities1())
            {
                Subjects subject = db.Subjects.FirstOrDefault(o => o.SubjectID == subjectId);
                if (subject == null)
                {
                    MessageBox.Show("Предмет не найден.");
                    return;
                }

                // Открытие окна редактирования
                EditSubjectWindow editWindow = new EditSubjectWindow(subject);
                editWindow.ShowDialog();
                LoadSubjects();
            }
        }
    }
}
