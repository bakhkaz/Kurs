namespace ToskanApp.Models;

public class Position
{
    public int    Id  { get; set; }
    
    public string Name { get; set; }

   
    public Position(){}
   
    public Position(
        int    Id,
        string Name
    )
    {
        this.Id = Id;
        this.Name = Name;

    }
}