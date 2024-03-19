namespace ToskanApp.Models;

public class Employee
{
    public int    Id  { get; set; }


    public string Firstname { get; set; }
    public string  Lastname { get; set; }
    public string Patronymic { get; set; }   
    public string  Login { get; set; }
    public string Password { get; set; }
    public  int  RoleId { get; set; }
    public int PositionId { get; set; }
    public string RoleName { get; set; }
    public string PositionName { get; set; }

    public Employee(){}
   
    public Employee(
        int Id,
     string Firstname,
     string  Lastname,
     string Patronymic,
      string  Login ,
      string Password ,
      int  RoleId,
     int PositionId,
        string RoleName  ,    
            string PositionName
    )
    {
        this.Id = Id;
        this.Firstname = Firstname;
        this.Lastname = Lastname;
        this.Patronymic = Patronymic;
        this.Login = Login;
        this.Password = Password;
        this.RoleId = RoleId;
        this.PositionId = PositionId;
        this.RoleName =   RoleName;
        this.PositionName = PositionName;


    }
}