using System;

namespace ToskanApp.Models;

public class AccountingForExpense
{
    public int    Id  { get; set; }
    public  int  AccoutingForReceiptsId{ get; set; }
    public DateTime Date { get; set; }
    public int   TypeId{ get; set; }
    public double Count{ get; set; }
    public  int  EmployeeId{ get; set; }
    public  string  TypeeName{ get; set; }
    public  string  EmployeeName{ get; set; }
   
    public AccountingForExpense(){}
   
    public AccountingForExpense(
         int    Id  ,
          int  AccoutingForReceiptsId,
         DateTime Date ,
         int   TypeId,
         double Count,
          int  EmployeeId,
          string  TypeeName,
          string  EmployeeName
    )
    {
        this.Id = Id;
        this.AccoutingForReceiptsId = AccoutingForReceiptsId;
        this.   Date  = Date;
        this.TypeId = TypeId;
        this. Count = Count;
        this.  EmployeeId  = EmployeeId;
        this.  TypeeName  = TypeeName;
        this.  EmployeeName  = EmployeeName;
  
    }
}