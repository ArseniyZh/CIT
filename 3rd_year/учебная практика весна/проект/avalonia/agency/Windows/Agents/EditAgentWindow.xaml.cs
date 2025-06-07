using Avalonia.Controls;
using Avalonia.Interactivity;
using agency.Models;
using agency.Data;
using System;

namespace agency.Windows;

public partial class EditAgentWindow : Window
{
    private readonly AgentDto _agent;

    public EditAgentWindow(AgentDto agent)
    {
        InitializeComponent();
        _agent = agent;

        LastNameBox.Text = agent.LastName;
        FirstNameBox.Text = agent.FirstName;
        MiddleNameBox.Text = agent.MiddleName;
        PasswordBox.Text = agent.Password;
        CommissionRateBox.Text = agent.CommissionRate.ToString();
    }

    private void SaveBtn_Click(object? sender, RoutedEventArgs e)
    {
        var lastName = LastNameBox.Text?.Trim() ?? "";
        var firstName = FirstNameBox.Text?.Trim() ?? "";
        var middleName = MiddleNameBox.Text?.Trim() ?? "";
        var password = PasswordBox.Text?.Trim() ?? "";
        var rateText = CommissionRateBox.Text?.Trim();

        if (string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(firstName)) return;
        if (!double.TryParse(rateText, out var commissionRate)) return;

        _agent.LastName = lastName;
        _agent.FirstName = firstName;
        _agent.MiddleName = middleName;
        _agent.Password = password;
        _agent.CommissionRate = commissionRate;

        new AgentRepository().UpdateAgent(_agent);
        Close();
    }
}
