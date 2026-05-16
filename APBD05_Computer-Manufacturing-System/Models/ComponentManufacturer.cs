namespace APBD05_Computer_Manufacturing_System.Models;

public class ComponentManufacturer
{
    public int Id { get; set; }
    public string Abbreviation { get; set; }
    public string FullName { get; set; }
    public DateOnly FoundationDate { get; set; }
    
    public ICollection<Component> Components { get; set; } = new List<Component>();
}