using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using ToskanApp.Models;

namespace ToskanApp.Windows;


public partial class TableExpense : Window
{
 public List<AccountingForExpense> _data { get; set; }
    public List<AccountingForExpense> _view { get; set; }
    public TableExpense(){
        InitializeComponent();
        DataGridUpdate();
    }
    public void DataGridUpdate()
    {
        _data = DBCore.GetAccountExpense();
        _view = _data;
        if (TBoxSearch.Text.Length > 1)
        {
            string src = TBoxSearch.Text;
            _data = _data.Where(d =>
                d.Id.ToString().ToLower().Contains(src.ToLower()) ||
                d.Count.ToString().ToLower().Contains(src.ToLower()) ||
                d.EmployeeId.ToString().ToLower().Contains(src.ToLower()) ||
                d.Date.ToString().ToLower().Contains(src.ToLower()) ||
                d.Count.ToString().ToLower().Contains(src.ToLower())
            ).ToList();
        }
        DataGrid.ItemsSource = _data;

    }
 
    private void BtnDelete_OnClick(object? sender, RoutedEventArgs e)
    {
        if(DataGrid.SelectedItem == null)
            return;
        
        DBCore.RemoveAccuntingExpense(DataGrid.SelectedItem as AccountingForExpense);
        DataGridUpdate();
        
    }
 
    private void BtnEdit_OnClick(object? sender, RoutedEventArgs e)
    {
        if(DataGrid.SelectedItem == null)
            return;

        EditExpense wind = new EditExpense(DataGrid.SelectedItem as AccountingForExpense);
        wind.ShowDialog(this);
        DataGridUpdate();
    }
 

    private void SearchTBox_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        DataGridUpdate();
    }

    private void ResetBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        TBoxSearch.Text = "";
        DataGridUpdate();
    }

    private void BtnAdd_OnClick(object? sender, RoutedEventArgs e)
    {
        EditExpense wind = new EditExpense();
        wind.ShowDialog(this);
        DataGridUpdate();
    }
}