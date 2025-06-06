using Avalonia.Controls;
using Avalonia.Interactivity;
using agency.Models;
using System;

namespace agency.Windows;

public partial class EditClientWindow : Window
{
    private ClientDto _client;

    public EditClientWindow(ClientDto client, Action onDelete)
    {
        InitializeComponent();
        _client = client;

        FullNameBox.Text = client.FullName;
        PhoneBox.Text = client.Phone;
    }

    private void SaveBtn_Click(object? sender, RoutedEventArgs e)
    {
        _client.FullName = FullNameBox.Text ?? "";
        _client.Phone = PhoneBox.Text ?? "";
        Close();
    }
}
