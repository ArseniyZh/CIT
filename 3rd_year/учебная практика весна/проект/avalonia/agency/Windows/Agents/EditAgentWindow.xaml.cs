using Avalonia.Controls;
using Avalonia.Interactivity;
using agency.Models;

namespace agency.Windows;

public partial class EditAgentWindow : Window
{
    private AgentDto _agent;

    public EditAgentWindow(AgentDto agent)
    {
        InitializeComponent();
        _agent = agent;

        NameBox.Text = agent.Name;
        PhoneBox.Text = agent.Phone;
    }

    private void SaveBtn_Click(object? sender, RoutedEventArgs e)
    {
        _agent.Name = NameBox.Text ?? "";
        _agent.Phone = PhoneBox.Text ?? "";
        Close();
    }
}
