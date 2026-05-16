namespace APBD05_Computer_Manufacturing_System.DTOs;

public class ComponentManufacturer
{
    public int Id { get; set; }
    public string Abbreviation { get; set; }
    public string FullName { get; set; }
    public DateOnly FoundationDate { get; set; }
}