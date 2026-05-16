using APBD05_Computer_Manufacturing_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD05_Computer_Manufacturing_System.Configurations;

public class ComponentConfiguration : IEntityTypeConfiguration<Component>
{
    public void Configure(EntityTypeBuilder<Component> builder)
    {
        builder.ToTable("Components");
 
        builder.HasKey(c => c.Code);
 
        builder.Property(c => c.Code)
            .IsRequired()
            .HasColumnType("char(10)");
 
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(300);
 
        builder.Property(c => c.Description)
            .IsRequired()
            .HasColumnType("nvarchar(max)");
        
        
        builder.HasOne(c => c.Manufacturer)
            .WithMany(m => m.Components)
            .HasForeignKey(c => c.ComponentManufacturersId)
            .OnDelete(DeleteBehavior.Restrict);
 
        builder.HasOne(c => c.Type)
            .WithMany(t => t.Components)
            .HasForeignKey(c => c.ComponentTypesId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(new List<Component>
        {
            new Component
            {
                Code = "CPU0000001",
                Name = "Ryzen 7 7800X3D",
                Description = "8-core gaming processor with 3D V-Cache technology",
                ComponentManufacturersId = 1,
                ComponentTypesId = 1
            },
            new Component
            {
                Code = "CPU0000002",
                Name = "Ryzen 5 7600X",
                Description = "6-core high performance processor for everyday use",
                ComponentManufacturersId = 1,
                ComponentTypesId = 1
            },
            new Component
            {
                Code = "GPU0000001",
                Name = "RTX 4080 Super",
                Description = "High-end gaming graphics card with 16GB GDDR6X",
                ComponentManufacturersId = 2,
                ComponentTypesId = 2
            },
            new Component
            {
                Code = "GPU0000002",
                Name = "RTX 4060 Ti",
                Description = "Mid-range gaming graphics card with 8GB GDDR6",
                ComponentManufacturersId = 2,
                ComponentTypesId = 2
            },
            new Component
            {
                Code = "RAM0000001",
                Name = "Corsair Vengeance DDR5 16GB",
                Description = "DDR5 RAM module 16GB 5600MHz",
                ComponentManufacturersId = 3,
                ComponentTypesId = 3
            },
            new Component
            {
                Code = "RAM0000002",
                Name = "Corsair Vengeance DDR5 32GB",
                Description = "DDR5 RAM module 32GB 5600MHz",
                ComponentManufacturersId = 3,
                ComponentTypesId = 3
            },
            new Component
            {
                Code = "SSD0000001",
                Name = "Samsung 990 Pro 1TB",
                Description = "NVMe M.2 SSD with read speeds up to 7450 MB/s",
                ComponentManufacturersId = 4,
                ComponentTypesId = 4
            },
            new Component
            {
                Code = "PSU0000001",
                Name = "SeaSonic Focus GX-850",
                Description = "850W 80+ Gold fully modular power supply",
                ComponentManufacturersId = 5,
                ComponentTypesId = 5
            }
        });
    }
}