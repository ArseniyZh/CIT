using Agency.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    
    public partial class EditAgentsWindow : Window
    {
        private readonly AgencyRealEstate _context = new AgencyRealEstate();
        private Agents _agent;

        public EditAgentsWindow(int agentId)
        {
            InitializeComponent();
            _agent = _context.Agents
         .Include("Persons")
         .FirstOrDefault(a => a.Id == agentId);

            if (_agent == null)
            {
                MessageBox.Show("Агент не найден.");
                Close();
                return;
            }

            FillFields();
        }

        private void FillFields()
        {
            Codetxt.Text = _agent.Id.ToString();
            Surnametxt.Text = _agent.Persons.LastName;
            Nametxt.Text = _agent.Persons.FirstName;
            Patronymictxt.Text = _agent.Persons.MiddleName;
            Passwordtxt.Text = _agent.Persons.Password;
            Percentxt.Text = _agent.DealShare.ToString();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            AgentsWindow agentsWindow = new AgentsWindow();
            agentsWindow.Show();
            this.Close();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                _agent.Persons.LastName = Surnametxt.Text;
                _agent.Persons.FirstName = Nametxt.Text;
                _agent.Persons.MiddleName = Patronymictxt.Text;
                _agent.Persons.Password = Passwordtxt.Text;
                _agent.DealShare = float.Parse(Percentxt.Text);
                
                _context.Persons.AddOrUpdate(_agent.Persons);
                _context.Agents.AddOrUpdate(_agent);
                _context.SaveChanges();
                MessageBox.Show("Агент успешно обновлен!");
                BackBtn_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обновлении: " + ex.Message);
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить этого агента?", "Подтверждение удаления",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                   
                    var agentToRemove = _context.Agents.FirstOrDefault(a => a.Id == _agent.Id);
                    if (agentToRemove != null)
                    {
                       
                        var personToRemove = _context.Persons.FirstOrDefault(p => p.Id == agentToRemove.Person_Id);

                        
                        _context.Agents.Remove(agentToRemove);

                      
                        bool personUsedElsewhere = _context.Clients.Any(c => c.Person_Id == personToRemove.Id);

                        if (personToRemove != null && !personUsedElsewhere)
                        {
                            _context.Persons.Remove(personToRemove);
                        }

                        _context.SaveChanges();
                        MessageBox.Show("Агент успешно удалён.");

                        AgentsWindow agentsWindow = new AgentsWindow();
                        agentsWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Агент не найден.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении агента: " + ex.Message);
                }
            }
        }
    }
}