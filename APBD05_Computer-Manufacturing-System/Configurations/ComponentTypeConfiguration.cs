using APBD05_Computer_Manufacturing_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD05_Computer_Manufacturing_System.Configurations;

public class ComponentTypeConfiguration : IEntityTypeConfiguration<ComponentType>
{
    public void Configure(EntityTypeBuilder<ComponentType> builder)
    {
        builder.ToTable("ComponentTypes");
 
        builder.HasKey(ct => ct.Id);
 
        builder.Property(ct => ct.Abbreviation)
            .IsRequired()
            .HasMaxLength(30);
 
        builder.Property(ct => ct.Name)
            .IsRequired()
            .HasMaxLength(150);
        
        builder.HasData(new List<ComponentType>
        {
            new ComponentType { Id = 1, Abbreviation = "CPU", Name = "Processor" },
            new ComponentType { Id = 2, Abbreviation = "GPU", Name = "Graphics Card" },
            new ComponentType { Id = 3, Abbreviation = "RAM", Name = "Memory" },
            new ComponentType { Id = 4, Abbreviation = "SSD", Name = "Solid State Drive" },
            new ComponentType { Id = 5, Abbreviation = "PSU", Name = "Power Supply Unit" }
        });
    }
}