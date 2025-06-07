using Avalonia.Controls;
using Avalonia.Interactivity;
using agency.Models;
using agency.Data;

namespace agency.Windows;

public partial class EditClientWindow : Window
{
    private ClientDto _client;

    public EditClientWindow(ClientDto client)
    {
        InitializeComponent();
        _client = client;

        LastNameBox.Text = client.LastName;
        FirstNameBox.Text = client.FirstName;
        MiddleNameBox.Text = client.MiddleName;
        PasswordBox.Text = client.Password;
        PhoneBox.Text = client.Phone;
        EmailBox.Text = client.Email;
    }

    private void SaveBtn_Click(object? sender, RoutedEventArgs e)
    {
        _client.LastName = LastNameBox.Text ?? "";
        _client.FirstName = FirstNameBox.Text ?? "";
        _client.MiddleName = MiddleNameBox.Text ?? "";
        _client.Password = PasswordBox.Text ?? "";
        _client.Phone = PhoneBox.Text ?? "";
        _client.Email = EmailBox.Text ?? "";

        new ClientRepository().UpdateClient(_client);
        Close();
    }
}
