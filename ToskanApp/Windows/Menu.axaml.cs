using System.Linq.Expressions;
using Avalonia.Controls;
using Avalonia.Interactivity;
using ToskanApp.Models;

namespace ToskanApp.Windows;

public partial class Menu : Window
{
    private Employee user;
    public Menu()
    {
        InitializeComponent();
    }    
    public Menu(Employee user)
    {
        InitializeComponent();
        this.user = user;
    }

    private void CreateProduct_OnClick(object? sender, RoutedEventArgs e)
    {
        EditProduct wind = new EditProduct();
        wind.ShowDialog(this);
    }

    private void TableExpense_OnClick(object? sender, RoutedEventArgs e)
    {
        TableExpense wind = new TableExpense();
        wind.ShowDialog(this);
    }

    private void TableReceipts_OnClick(object? sender, RoutedEventArgs e)
    {
        TableReceipts wind = new TableReceipts();
        wind.ShowDialog(this);
    }

    private void CreateExpense_OnClick(object? sender, RoutedEventArgs e)
    {
        EditExpense wind = new EditExpense();
        wind.ShowDialog(this);
    }

    private void CreateReceipts_OnClick(object? sender, RoutedEventArgs e)
    {
        EditReceipts wind = new EditReceipts();
        wind.ShowDialog(this);
    }

    private void TableProduct_OnClick(object? sender, RoutedEventArgs e)
    {
        TableProduct wind = new TableProduct();
        wind.ShowDialog(this);
    }
}