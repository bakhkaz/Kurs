namespace ToskanApp.Models;

public class Unit
{
    public int    Id  { get; set; }
    
    public string Name { get; set; }

   
    public Unit(){}
   
    public Unit(
        int    Id,
        string Name
    )
    {
        this.Id = Id;
        this.Name = Name;

    }
}