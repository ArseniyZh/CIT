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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadMovies();
        }

        SolidColorBrush lightColor = new SolidColorBrush(Colors.White);
        SolidColorBrush blackColor = new SolidColorBrush(Colors.DarkGray);

        private void LoadMovies()
        {
            var movies = new List<Movie>
            {
                new Movie { Title = "Inception1", Description = "Movie1", RentalDates = "14.05 - 20.05", ImagePath = "C:\\Users\\Арсений\\Desktop\\КИТ\\репозиторий\\CIT\\2nd_year\\rpm\\labs\\train\\WpfApp1\\WpfApp1\\Images\\img1.png"},
                new Movie { Title = "Inception2", Description = "Movie2", RentalDates = "14.05 - 20.05", ImagePath = "C:\\Users\\Арсений\\Desktop\\КИТ\\репозиторий\\CIT\\2nd_year\\rpm\\labs\\train\\WpfApp1\\WpfApp1\\Images\\img2.png"},
                new Movie { Title = "Inception3", Description = "Movie3", RentalDates = "14.05 - 20.05", ImagePath = "C:\\Users\\Арсений\\Desktop\\КИТ\\репозиторий\\CIT\\2nd_year\\rpm\\labs\\train\\WpfApp1\\WpfApp1\\Images\\img3.png"},
                new Movie { Title = "Inception4", Description = "Movie4", RentalDates = "14.05 - 20.05", ImagePath = "C:\\Users\\Арсений\\Desktop\\КИТ\\репозиторий\\CIT\\2nd_year\\rpm\\labs\\train\\WpfApp1\\WpfApp1\\Images\\img4.png"},
                new Movie { Title = "Inception5", Description = "Movie5", RentalDates = "14.05 - 20.05", ImagePath = "C:\\Users\\Арсений\\Desktop\\КИТ\\репозиторий\\CIT\\2nd_year\\rpm\\labs\\train\\WpfApp1\\WpfApp1\\Images\\img5.png"},
            };

            MoviesList.ItemsSource = movies;
        }

        private void OnLightThemeClicked(object sender, RoutedEventArgs e)
        {
            this.Background = lightColor;
            MoviesList.Background = lightColor;
        }
        private void OnDarkThemeCLicked(object sender, RoutedEventArgs e)
        {
            this.Background = blackColor;
            MoviesList.Background = blackColor;
        }
    }
}
