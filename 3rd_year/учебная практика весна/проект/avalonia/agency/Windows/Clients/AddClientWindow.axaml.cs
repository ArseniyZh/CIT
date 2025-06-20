using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using agency.Models;
using agency.Data;

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
        var lastName = LastNameBox.Text?.Trim() ?? "";
        var firstName = FirstNameBox.Text?.Trim() ?? "";
        var middleName = MiddleNameBox.Text?.Trim() ?? "";
        var password = PasswordBox.Text?.Trim() ?? "";
        var phone = PhoneBox.Text?.Trim() ?? "";
        var email = EmailBox.Text?.Trim() ?? "";

        if (string.IsNullOrWhiteSpace(lastName) ||
            string.IsNullOrWhiteSpace(firstName) ||
            string.IsNullOrWhiteSpace(phone))
        {
            return; // можно также показать уведомление
        }

        var newClient = new ClientDto
        {
            LastName = lastName,
            FirstName = firstName,
            MiddleName = middleName,
            Password = password,
            Phone = phone,
            Email = email
        };

        new ClientRepository().AddClient(newClient);
        _onClientAdded.Invoke(newClient);
        Close();
    }
}
