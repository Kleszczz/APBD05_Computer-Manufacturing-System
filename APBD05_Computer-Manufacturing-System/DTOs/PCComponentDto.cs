namespace APBD05_Computer_Manufacturing_System.DTOs;

public class PCComponentDto
{
    public int Amount { get; set; }
    public ComponentDto Component { get; set; } = null!;
}