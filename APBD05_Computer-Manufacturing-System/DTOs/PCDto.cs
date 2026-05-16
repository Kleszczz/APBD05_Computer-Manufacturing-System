namespace APBD05_Computer_Manufacturing_System.DTOs;

public class PCDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public float Weight { get; set; } = float.NaN;
    public int Warranty { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Stock { get; set; }
}