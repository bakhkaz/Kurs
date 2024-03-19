namespace ToskanApp.Models;

public class TypeExpense
{
    public int    Id  { get; set; }
    
    public string Name { get; set; }

   
    public TypeExpense(){}
   
    public TypeExpense(
        int    Id,
        string Name
    )
    {
        this.Id = Id;
        this.Name = Name;

    }
}