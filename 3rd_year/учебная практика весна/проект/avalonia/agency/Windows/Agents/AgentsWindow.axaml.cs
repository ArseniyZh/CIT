using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using agency.Data;
using agency.Models;
using System.Collections.Generic;

namespace agency.Windows;

public partial class AgentsWindow : Window
{
    private List<AgentDto> _agents = new();
    private AgentDto? _selectedAgent;
    private Dictionary<AgentDto, Border> _agentVisualMap = new();
    private readonly AgentRepository _agentRepository = new();

    public AgentsWindow()
    {
        InitializeComponent();
        LoadAgentsFromDb();
        RenderAgents();
    }

    private void LoadAgentsFromDb()
    {
        _agents = _agentRepository.GetAllAgents();
    }

    private void RenderAgents()
    {
        AgentsListPanel.Children.Clear();
        _agentVisualMap.Clear();

        foreach (var agent in _agents)
        {
            var border = new Border
            {
                BorderThickness = new Thickness(1),
                BorderBrush = Brushes.Black,
                Margin = new Thickness(0, 0, 0, 5),
                Child = new TextBlock
                {
                    Text = $"ID: {agent.Id}, ФИО: {agent.LastName} {agent.FirstName} {agent.MiddleName}, Процент: {agent.CommissionRate}%",
                    FontSize = 16,
                    Padding = new Thickness(5)
                }
            };

            border.PointerPressed += (_, _) =>
            {
                _selectedAgent = agent;
                HighlightSelected(agent);
                EnableActionButtons();
            };

            _agentVisualMap[agent] = border;
            AgentsListPanel.Children.Add(border);
        }

        DisableActionButtons();
    }

    private void HighlightSelected(AgentDto agent)
    {
        foreach (var (ag, border) in _agentVisualMap)
            border.Background = ag == agent ? Brushes.LightBlue : Brushes.Transparent;
    }

    private void EnableActionButtons()
    {
        EditButton.IsEnabled = true;
        DeleteButton.IsEnabled = true;
    }

    private void DisableActionButtons()
    {
        EditButton.IsEnabled = false;
        DeleteButton.IsEnabled = false;
    }

    private async void AddAgentBtn_Click(object? sender, RoutedEventArgs e)
    {
        var addWindow = new AddAgentWindow(agent =>
        {
            _agents.Add(agent);
            RenderAgents();
        });

        await addWindow.ShowDialog(this);
    }

    private void BackBtn_Click(object? sender, RoutedEventArgs e)
    {
        var main = new AgencyWindow();
        main.Show();
        Close();
    }

    private void DeleteBtn_Click(object? sender, RoutedEventArgs e)
    {
        if (_selectedAgent is null) return;

        _agents.Remove(_selectedAgent);
        AgentsListPanel.Children.Remove(_agentVisualMap[_selectedAgent]);
        _agentVisualMap.Remove(_selectedAgent);
        _selectedAgent = null;
        DisableActionButtons();
    }

    private async void EditBtn_Click(object? sender, RoutedEventArgs e)
    {
        if (_selectedAgent is null) return;

        var editWindow = new EditAgentWindow(_selectedAgent);
        await editWindow.ShowDialog(this);
        LoadAgentsFromDb();
        RenderAgents();
    }
}
