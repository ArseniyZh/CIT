using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace YourNamespace
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Change_Color(string color)
        {
            switch (color)
            {
                case "Blue":
                    this.Background = Brushes.Blue;
                    break;
                case "Green":
                    this.Background = Brushes.Green;
                    break;
                case "Yellow":
                    this.Background = Brushes.Yellow;
                    break;
                case "Red":
                    this.Background = Brushes.Red;
                    break;
                case "White":
                    this.Background = Brushes.White;
                    break;
                default:
                    this.Background = Brushes.White;
                    break;
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ChangeBackgroundColor_Click(object sender, RoutedEventArgs e)
        {
            var item = sender as MenuItem;
            var color = item.Header.ToString();
            Change_Color(color);
        }

        private void ChangeBackgroundColor_ComboBoxChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            var selectedItem = comboBox.SelectedItem as ComboBoxItem;
            var color = selectedItem.Content.ToString();

            Change_Color(color);
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Developed by Arseniy.", "About Developer");
        }
    }
}
