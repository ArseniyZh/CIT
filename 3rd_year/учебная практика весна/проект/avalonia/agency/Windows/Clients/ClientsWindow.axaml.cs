using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using System.Collections.Generic;
using agency.Models;

namespace agency.Windows;

public partial class ClientsWindow : Window
{
    private List<ClientDto> _clients = new();
    private ClientDto? _selectedClient;
    private Dictionary<ClientDto, Border> _clientVisualMap = new();

    public ClientsWindow()
    {
        InitializeComponent();
        LoadClients();
    }

    private void LoadClients()
    {
        _clients = new List<ClientDto>
        {
            new ClientDto { Id = 1, FullName = "Иванов Иван", Phone = "+7 999 111 2233" },
            new ClientDto { Id = 2, FullName = "Петрова Анна", Phone = "+7 999 222 3344" },
            new ClientDto { Id = 3, FullName = "Сидоров Олег", Phone = "+7 999 333 4455" }
        };

        RenderClients();
    }

    private void RenderClients()
    {
        ClientsListPanel.Children.Clear();
        _clientVisualMap.Clear();

        foreach (var client in _clients)
        {
            var border = new Border
            {
                BorderThickness = new Thickness(1),
                BorderBrush = Brushes.Black,
                Margin = new Thickness(0, 0, 0, 5),
                Child = new TextBlock
                {
                    Text = $"ID: {client.Id}, ФИО: {client.FullName}, Телефон: {client.Phone}",
                    FontSize = 16,
                    Padding = new Thickness(5)
                }
            };

            border.PointerPressed += (_, _) =>
            {
                _selectedClient = client;
                HighlightSelected(client);
                EnableActionButtons();
            };

            _clientVisualMap[client] = border;
            ClientsListPanel.Children.Add(border);
        }

        DisableActionButtons();
    }

    private void HighlightSelected(ClientDto client)
    {
        foreach (var (cl, border) in _clientVisualMap)
        {
            border.Background = cl == client ? Brushes.LightBlue : Brushes.Transparent;
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

    private async void AddClientBtn_Click(object? sender, RoutedEventArgs e)
    {
        var addWindow = new AddClientWindow(client =>
        {
            _clients.Add(client);
            RenderClients();
        });

        await addWindow.ShowDialog(this);
    }

    private async void EditBtn_Click(object? sender, RoutedEventArgs e)
    {
        if (_selectedClient is null) return;

        var editWindow = new EditClientWindow(_selectedClient, () =>
        {
            // удалить при отмене (если нужно)
            _clients.Remove(_selectedClient);
        });

        await editWindow.ShowDialog(this);
        RenderClients();
    }

    private void DeleteBtn_Click(object? sender, RoutedEventArgs e)
    {
        if (_selectedClient is null) return;

        _clients.Remove(_selectedClient);
        ClientsListPanel.Children.Remove(_clientVisualMap[_selectedClient]);
        _clientVisualMap.Remove(_selectedClient);
        _selectedClient = null;
        DisableActionButtons();
    }

    private void BackBtn_Click(object? sender, RoutedEventArgs e)
    {
        var main = new AgencyWindow();
        main.Show();
        Close();
    }
}
