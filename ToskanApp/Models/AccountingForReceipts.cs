using System;

namespace ToskanApp.Models;

public class AccountingForReceipts
{
    public int    Id  { get; set; }
    
    public int ProductId{ get; set; }

    public   DateTime   DateExpiration{ get; set; }

    public DateTime DateManufacture{ get; set; }

    public double     Count{ get; set; }

    public int EmployeeId{ get; set; } 
    public string GetEmployeeName{ get; set; }  
    public string GetProductName{ get; set; }

   
    public AccountingForReceipts(){}
   
    public AccountingForReceipts(
        int    Id,
     int ProductId,
       DateTime   DateExpiration,
     DateTime DateManufacture,
        double     Count,     
        string     GetEmployeeName,  
        string     GetProductName,
     int EmployeeId  
         )
    {
        this.Id = Id;
        this.  ProductId= ProductId;
        this.    DateExpiration= DateExpiration;
        this.  DateManufacture= DateManufacture;
        this.      Count= Count;
        this.  EmployeeId =EmployeeId ;   
        this.  GetEmployeeName = GetEmployeeName ;  
        this.  GetProductName = GetProductName ;

    }
}