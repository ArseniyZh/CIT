using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using agency.Models;

namespace agency.Windows;

public partial class AddClientWindow : Window
{
    private readonly Action<ClientDto> _onClientAdded;

    public AddClientWindow(Action<ClientDto> onClientAdded)
    {
        InitializeComponent();
        _onClientAdded = onClientAdded;
    }

    private void SaveBtn_Click(object? sender, RoutedEventArgs e)
    {
        var fullName = FullNameBox.Text;
        var phone = PhoneBox.Text;

        if (!string.IsNullOrWhiteSpace(fullName) && !string.IsNullOrWhiteSpace(phone))
        {
            var newClient = new ClientDto
            {
                Id = Guid.NewGuid().GetHashCode(),
                FullName = fullName,
                Phone = phone
            };

            _onClientAdded.Invoke(newClient); // или просто _onClientAdded(newClient);
            Close();
        }
    }
}
