using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using Avalonia.Controls;
using Avalonia.Interactivity;
using ToskanApp.Models;

namespace ToskanApp.Windows;


public partial class EditProduct : Window
{  
    private bool addPage = true;
    private List<Unit> _ListUnit { get; set; }
    private Product editProduct  { get; set; }
        
    public EditProduct()
    {
        InitializeComponent();
        DBContent();
        editProduct = new Product();
    }        
    public EditProduct(Product product)
    {
        InitializeComponent();
        DBContent();
        
        addPage = false;
        editProduct = product;
        
        TBoxName.Text = editProduct.Name ;
        NUDduration.Value = editProduct.ExpirationDay ;
        NUDCount.Value = (decimal?)editProduct.Count ;
        CBoxUnit.SelectedItem = _ListUnit.Where(d=>d.Id == editProduct.UnitId).FirstOrDefault() ;
    }
 
    public void DBContent()
    {
        _ListUnit = DBCore.GetUnit();
        CBoxUnit.ItemsSource = _ListUnit;
    }
    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        editProduct.Name = TBoxName.Text;
        editProduct.ExpirationDay = Convert.ToInt32(NUDduration.Value);
        editProduct.Count = Convert.ToDouble(NUDCount.Text);
        editProduct.UnitId = (CBoxUnit.SelectedItem as Unit).Id;
        if (addPage)
        {
 
            DBCore.AddProduct(editProduct);
            this.Close();
        }
        else 
        {
 
            DBCore.UpdateProduct(editProduct);
            this.Close();
        }
    }
}