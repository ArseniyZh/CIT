using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using agency.Models;
using agency.Data;

namespace agency.Windows;

public partial class AddAgentWindow : Window
{
    private readonly Action<AgentDto> _onAgentAdded;

    public AddAgentWindow(Action<AgentDto> onAgentAdded)
    {
        InitializeComponent();
        _onAgentAdded = onAgentAdded;
    }

    private void SaveBtn_Click(object? sender, RoutedEventArgs e)
    {
        var lastName = LastNameBox.Text?.Trim() ?? "";
        var firstName = FirstNameBox.Text?.Trim() ?? "";
        var middleName = MiddleNameBox.Text?.Trim() ?? "";
        var password = PasswordBox.Text?.Trim() ?? "";
        var commissionText = CommissionRateBox.Text?.Trim();

        if (string.IsNullOrWhiteSpace(lastName) ||
            string.IsNullOrWhiteSpace(firstName) ||
            !double.TryParse(commissionText, out var commissionRate))
        {
            return; // Можно добавить окно-уведомление об ошибке
        }

        var newAgent = new AgentDto
        {
            LastName = lastName,
            FirstName = firstName,
            MiddleName = middleName,
            Password = password,
            CommissionRate = commissionRate
        };

        new AgentRepository().AddAgent(newAgent);
        _onAgentAdded.Invoke(newAgent);
        Close();
    }
}
