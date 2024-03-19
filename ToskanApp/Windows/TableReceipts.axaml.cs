using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using ToskanApp.Models;

namespace ToskanApp.Windows;


public partial class TableReceipts : Window
{
    public List<AccountingForReceipts> _data { get; set; }
    public List<AccountingForReceipts> _view { get; set; }
    public TableReceipts(){
        InitializeComponent();
        DataGridUpdate();
    }
    public void DataGridUpdate()
    {
        _data = DBCore.GetAccountReceipts();
        _view = _data;
        if (TBoxSearch.Text.Length > 1)
        {
            string src = TBoxSearch.Text;
            _data = _data.Where(d =>
                d.Id.ToString().ToLower().Contains(src.ToLower()) ||
                d.Count.ToString().ToLower().Contains(src.ToLower()) ||
                d.EmployeeId.ToString().ToLower().Contains(src.ToLower()) ||
                d.DateExpiration.ToString().ToLower().Contains(src.ToLower()) ||
                d.DateManufacture.ToString().ToLower().Contains(src.ToLower()) ||
                d.GetEmployeeName.ToLower().Contains(src.ToLower()) ||
                d.GetProductName.ToLower().Contains(src.ToLower()) ||
                d.Count.ToString().ToLower().Contains(src.ToLower())
            ).ToList();
                
        }
        DataGrid.ItemsSource = _data;

    }
 
    private void BtnDelete_OnClick(object? sender, RoutedEventArgs e)
    {
        if(DataGrid.SelectedItem == null)
            return;
        
        DBCore.RemoveAccintingReceipts(DataGrid.SelectedItem as AccountingForReceipts);
        DataGridUpdate();
        
    }
 
    private void BtnEdit_OnClick(object? sender, RoutedEventArgs e)
    {
        if(DataGrid.SelectedItem == null)
            return;

        EditReceipts wind = new EditReceipts(DataGrid.SelectedItem as AccountingForReceipts);
        wind.ShowDialog(this);
        
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
        EditReceipts wind = new EditReceipts();
        wind.ShowDialog(this);
    }
}