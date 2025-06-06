using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.Generic;
using Avalonia.Media;
using agency.Models;

namespace agency.Windows;

public partial class AgentsWindow : Window
{
    private List<AgentDto> _agents = new();
    private AgentDto? _selectedAgent;
    private Dictionary<AgentDto, Border> _agentVisualMap = new();

    public AgentsWindow()
    {
        InitializeComponent();
        InitializeAgents(); // отдельный метод для создания начальных данных
        RenderAgents();     // отрисовка
    }

    private void InitializeAgents()
    {
        _agents = new List<AgentDto>
        {
            new AgentDto { Id = 1, Name = "Иванов Иван", Phone = "+7 999 123-45-67" },
            new AgentDto { Id = 2, Name = "Петрова Анна", Phone = "+7 999 987-65-43" }
        };
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
                    Text = $"ID: {agent.Id}, Имя: {agent.Name}, Телефон: {agent.Phone}",
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
        {
            border.Background = ag == agent ? Brushes.LightBlue : Brushes.Transparent;
        }
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

    private void AddAgentBtn_Click(object? sender, RoutedEventArgs e)
    {
        var message = new Window
        {
            Title = "Заглушка",
            Width = 300,
            Height = 100,
            Content = new TextBlock
            {
                Text = "Форма добавления не реализована",
                VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center,
                HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center
            }
        };
        message.ShowDialog(this);
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

        RenderAgents(); // теперь просто перерисовываем список
    }
}
