using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using ToskanApp.Models;

namespace ToskanApp.Windows;


public partial class TableProduct : Window
{
 public List<Product> _data { get; set; }
    public List<Product> _view { get; set; }
    public TableProduct(){
        InitializeComponent();
        DataGridUpdate();
    }
    public void DataGridUpdate()
    {
        _data = DBCore.GetProduct();
        _view = _data;
        if (TBoxSearch.Text.Length > 1)
        {
            string src = TBoxSearch.Text;
            _data = _data.Where(d =>
                d.Id.ToString().ToLower().Contains(src.ToLower()) ||
                d.Count.ToString().ToLower().Contains(src.ToLower()) ||
                d.Name.ToLower().Contains(src.ToLower()) ||
                d.ExpirationDay.ToString().ToLower().Contains(src.ToLower()) ||
                d.UnitName.ToString().ToLower().Contains(src.ToLower()) ||
                d.Count.ToString().ToLower().Contains(src.ToLower())
            ).ToList();
        }
        DataGrid.ItemsSource = _data;

    }
    

 
    private void BtnEdit_OnClick(object? sender, RoutedEventArgs e)
    {
        if(DataGrid.SelectedItem == null)
            return;

        EditProduct wind = new EditProduct(DataGrid.SelectedItem as Product);
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
        EditProduct wind = new EditProduct();
        wind.ShowDialog(this);
    }
}