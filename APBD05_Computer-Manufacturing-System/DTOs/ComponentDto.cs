namespace APBD05_Computer_Manufacturing_System.DTOs;

public class ComponentDto
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public int ComponentManufacturersId { get; set; }
    public int ComponentTypesId { get; set; }
}