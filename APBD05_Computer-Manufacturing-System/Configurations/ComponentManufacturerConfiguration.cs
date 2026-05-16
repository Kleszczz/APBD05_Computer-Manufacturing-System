using APBD05_Computer_Manufacturing_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD05_Computer_Manufacturing_System.Configurations;

public class ComponentManufacturerConfiguration : IEntityTypeConfiguration<ComponentManufacturer>
{
    public void Configure(EntityTypeBuilder<ComponentManufacturer> builder)
    {
        builder.ToTable("ComponentManufacturers");

        builder.HasKey(cm => cm.Id);

        builder.Property(cm => cm.Abbreviation)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(cm => cm.FullName)
            .IsRequired()
            .HasMaxLength(300);

        builder.Property(cm => cm.FoundationDate)
            .IsRequired()
            .HasColumnType("date");
        
        
        builder.HasData(new List<ComponentManufacturer>
        {
            new ComponentManufacturer
            {
                Id = 1,
                Abbreviation = "AMD",
                FullName = "Advanced Micro Devices",
                FoundationDate = new DateOnly(1969, 5, 1)
            },
            new ComponentManufacturer
            {
                Id = 2,
                Abbreviation = "NV",
                FullName = "NVIDIA Corporation",
                FoundationDate = new DateOnly(1993, 4, 5)
            },
            new ComponentManufacturer
            {
                Id = 3,
                Abbreviation = "COR",
                FullName = "Corsair Gaming Inc.",
                FoundationDate = new DateOnly(1994, 1, 1)
            },
            new ComponentManufacturer
            {
                Id = 4,
                Abbreviation = "SAM",
                FullName = "Samsung Electronics",
                FoundationDate = new DateOnly(1969, 1, 13)
            },
            new ComponentManufacturer
            {
                Id = 5,
                Abbreviation = "SEA",
                FullName = "SeaSonic Electronics",
                FoundationDate = new DateOnly(1975, 1, 1)
            }
        });
    }
}