using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using ToskanApp.Models;

namespace ToskanApp.Windows;


public partial class EditExpense : Window
{
    private bool addPage = true;
    private List<AccountingForReceipts> _ListAccoutingForReceipts{ get; set; }
    private List<TypeExpense> _ListType{ get; set; }
    private List<Employee> _ListEmployee{ get; set; }
    private AccountingForExpense accountingForExpense  { get; set; }
        
    public EditExpense()
    {
        InitializeComponent();
        DBContent();
        accountingForExpense = new AccountingForExpense();
    }        
    public EditExpense(AccountingForExpense accountingForExpense)
    {
        InitializeComponent();
        DBContent();
        
        addPage = false;
        this.accountingForExpense = accountingForExpense;
        
        DPdateExpense.SelectedDate = accountingForExpense.Date ;
        NUDCount.Value = (decimal?)accountingForExpense.Count ;
        CBoxEmployee.SelectedItem =  _ListEmployee.Where(d=>d.Id == accountingForExpense.EmployeeId).FirstOrDefault() ;
        CBoxType.SelectedItem =  _ListType.Where(d=>d.Id == accountingForExpense.TypeId).FirstOrDefault() ;
        CBoxAccRec.SelectedItem = _ListAccoutingForReceipts.Where(d=>d.Id == accountingForExpense.AccoutingForReceiptsId).FirstOrDefault() ;
    }
 
    public void DBContent()
    {
        _ListEmployee = DBCore.GetEmployee();
        _ListType = DBCore.GetTypeExpense();
        _ListAccoutingForReceipts = DBCore.GetAccountReceipts();
        CBoxEmployee.ItemsSource = _ListEmployee;
        CBoxType.ItemsSource = _ListType;
        CBoxAccRec.ItemsSource = _ListAccoutingForReceipts;
    }
    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
 
        accountingForExpense.Date = DPdateExpense.SelectedDate.Value.Date;
        accountingForExpense.Count = Convert.ToDouble(NUDCount.Value);
        accountingForExpense.EmployeeId =   (CBoxEmployee.SelectedItem as Employee).Id;
        accountingForExpense.TypeId =  (CBoxType.SelectedItem as TypeExpense).Id;
        accountingForExpense.AccoutingForReceiptsId = (CBoxAccRec.SelectedItem as AccountingForReceipts).Id;
        if (addPage)
        {
 
            DBCore.AddAccountingExpense(accountingForExpense);
            this.Close();
        }
        else 
        {
 
            DBCore.UpdateAccountingExpense(accountingForExpense);
            this.Close();
        }
    }
}