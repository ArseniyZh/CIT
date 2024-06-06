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



namespace WpfApp3

{

    /// <summary> 

    /// Логика взаимодействия для MainWindow.xaml 

    /// </summary> 

    public partial class MainWindow : Window

    {

        public MainWindow()

        {

            InitializeComponent();

        }



        private void close_Click(object sender, RoutedEventArgs e)

        {

            Window window = Window.GetWindow((MenuItem)sender);

            if (window != null)

            {

                window.Close();



            }

        }



        private void Progmenu_Click(object sender, RoutedEventArgs e)

        {

            MessageBox.Show("Калимуллин Гадель 4235");

        }



        private void task_Click(object sender, RoutedEventArgs e)

        {

            new Window1().Show();



        }



        private void Prog_Click(object sender, RoutedEventArgs e)

        {

            MessageBox.Show("Желваков Арсений 4235");

        }



        private void closemenu_Click(object sender, RoutedEventArgs e)

        {

            Window window = Window.GetWindow((MenuItem)sender);

            if (window != null)

            {

                window.Close();



            }

        }

    }

}