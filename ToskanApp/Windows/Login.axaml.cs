using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using ToskanApp.Models;

namespace ToskanApp.Windows;

public partial class Login : Window
{
    public Login()
    {
        InitializeComponent();
    }
    private Employee _EmployeeeAuth { get; set; }
    private void BtnAuth_OnClick(object? sender, RoutedEventArgs e)
    {
_EmployeeeAuth = null;
if (TBoxLogin.Text.Length <= 0 || TBoxPassword.Text.Length <= 0)
{
    MessageBoxManager.GetMessageBoxStandard("Ошибка", "Поля не заполнены", ButtonEnum.Ok).ShowAsync();
    return;
}

List<Employee> Employees = DBCore.GetEmployee();

for (int i = 0; i < Employees.Count; i++)
{
    if (Employees[i].Login.Contains(TBoxLogin.Text) &&
        Employees[i].Password.Contains(TBoxPassword.Text))
    {
        _EmployeeeAuth = Employees[i];
        break;
    }
}

if (_EmployeeeAuth == null)
{
    MessageBoxManager.GetMessageBoxStandard("Ошибка", "Данные не верны", ButtonEnum.Ok).ShowAsync();
    return;
}
else
{
    Menu wMeny = new Menu(_EmployeeeAuth);
    wMeny.Show();
    this.Hide();
}
    }
    
    private void BtnClose_OnClick(object? sender, RoutedEventArgs e)
    {
        Menu wMeny = new Menu();
        wMeny.Show();
        this.Hide();
    }
}