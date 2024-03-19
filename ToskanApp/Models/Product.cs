namespace ToskanApp.Models;

public class Product
{
    public int    Id  { get; set; }
    public string Name{ get; set; }
    public int   UnitId{ get; set; }
    public double Count{ get; set; }
    public int   ExpirationDay{ get; set; }
public   string UnitName { get; set; }
    public Product(){}
   
    public Product(
        int Id,
         string Name,
         int   UnitId,
        double Count,
         int   ExpirationDay,
        string UnitName
    )
    {
        this.Id = Id;
        this.Name = Name;
        this.UnitId =UnitId;
        this.Count  =Count;
        this.ExpirationDay=  ExpirationDay;
        this.UnitName = UnitName;

    }
}