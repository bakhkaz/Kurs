using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using ToskanApp.Models;

namespace ToskanApp.Windows;


public partial class EditReceipts : Window
{
    private bool addPage = true;
    private List<Product> _ListProduct{ get; set; }
    private List<Employee> _ListEmployee{ get; set; }
    private AccountingForReceipts accountingForReceipts  { get; set; }
        
    public EditReceipts()
    {
        InitializeComponent();
        DBContent();
        accountingForReceipts = new AccountingForReceipts();
    }        
    public EditReceipts(AccountingForReceipts accountingForReceipts)
    {
        InitializeComponent();
        DBContent();
        
        addPage = false;
        this.accountingForReceipts = accountingForReceipts;
        
        DPdateStart.SelectedDate = accountingForReceipts.DateManufacture ;
        DPdateEnd.SelectedDate = accountingForReceipts.DateExpiration ;
        NUDcount.Value =  (decimal?)accountingForReceipts.Count ;
        CBoxEmployee.SelectedItem =  _ListEmployee.Where(d=>d.Id == accountingForReceipts.EmployeeId).FirstOrDefault() ;
        CBoxProduct.SelectedItem = _ListProduct.Where(d=>d.Id == accountingForReceipts.ProductId).FirstOrDefault() ;
    }
 
    public void DBContent()
    {
        _ListEmployee = DBCore.GetEmployee();
        _ListProduct = DBCore.GetProduct();

        CBoxEmployee.ItemsSource = _ListEmployee;
        CBoxProduct.ItemsSource = _ListProduct;
    }
    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
 
        accountingForReceipts.DateManufacture = DPdateStart.SelectedDate.Value.DateTime;
        accountingForReceipts.DateExpiration = DPdateEnd.SelectedDate.Value.DateTime;
        accountingForReceipts.Count = Convert.ToDouble(NUDcount.Value);
        accountingForReceipts.EmployeeId =  (CBoxEmployee.SelectedItem as Employee).Id;
        accountingForReceipts.ProductId = (CBoxProduct.SelectedItem as Product).Id;
        if (addPage)
        {
 
            DBCore.AddAccountingReceipts(accountingForReceipts);
            this.Close();
        }
        else 
        {
 
            DBCore.UpdateAccountingReceipts(accountingForReceipts);
            this.Close();
        }
    }
}