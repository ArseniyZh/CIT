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

namespace Agency.Windows
{
   
    public partial class AgencyWindow : Window
    {
        public AgencyWindow()
        {
            InitializeComponent();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Authorization authorization = new Authorization();
            authorization.Show();
            this.Close();
        }

        private void ClientsBtn_Click(object sender, RoutedEventArgs e)
        {
            ClientsWindow clientsWindow = new ClientsWindow();
            clientsWindow.Show();
            this.Close();
        }

        private void RealEstatesBtn_Click(object sender, RoutedEventArgs e)
        {
            RealEstatesWindow realEstatesWindow = new RealEstatesWindow();
            realEstatesWindow.Show();
            this.Close();
        }

        private void AgensBtn_Click(object sender, RoutedEventArgs e)
        {
            AgentsWindow agentsWindow = new AgentsWindow();
            agentsWindow.Show();
            this.Close();
        }

        private void DealsBtn_Click(object sender, RoutedEventArgs e)
        {
            DealsWindow dealsWindow = new DealsWindow();
            dealsWindow.Show();
            this.Close();
        }
    }
}
