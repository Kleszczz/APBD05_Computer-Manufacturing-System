using APBD05_Computer_Manufacturing_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD05_Computer_Manufacturing_System.Configurations;

public class PCComponentConfiguration : IEntityTypeConfiguration<PCComponent>
{
    public void Configure(EntityTypeBuilder<PCComponent> builder)
    {
        builder.ToTable("PCComponents");
        
        builder.HasKey(pcComponent => new { pcComponent.PCId, pcComponent.ComponentCode });
 
        builder.Property(pcComponent => pcComponent.ComponentCode)
            .IsRequired()
            .HasColumnType("char(10)");
 
        builder.Property(pcComponent => pcComponent.Amount)
            .IsRequired();
        
        
        builder.HasOne(pcComponent => pcComponent.PC)
            .WithMany(p => p.PCComponents)
            .HasForeignKey(pcComponent => pcComponent.PCId)
            .OnDelete(DeleteBehavior.Cascade);
 
        builder.HasOne(pcComponent => pcComponent.Component)
            .WithMany(c => c.PCComponents)
            .HasForeignKey(pcComponent => pcComponent.ComponentCode)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasData(new List<PCComponent>
        {
            new PCComponent { PCId = 1, ComponentCode = "CPU0000001", Amount = 1 },
            new PCComponent { PCId = 1, ComponentCode = "GPU0000001", Amount = 1 },
            new PCComponent { PCId = 1, ComponentCode = "RAM0000001", Amount = 2 },
            new PCComponent { PCId = 1, ComponentCode = "SSD0000001", Amount = 1 },
            new PCComponent { PCId = 1, ComponentCode = "PSU0000001", Amount = 1 },
            
            new PCComponent { PCId = 2, ComponentCode = "CPU0000002", Amount = 1 },
            new PCComponent { PCId = 2, ComponentCode = "GPU0000002", Amount = 1 },
            new PCComponent { PCId = 2, ComponentCode = "RAM0000001", Amount = 1 },
            new PCComponent { PCId = 2, ComponentCode = "SSD0000001", Amount = 1 },
            
            new PCComponent { PCId = 3, ComponentCode = "CPU0000001", Amount = 1 },
            new PCComponent { PCId = 3, ComponentCode = "RAM0000002", Amount = 4 },
            new PCComponent { PCId = 3, ComponentCode = "SSD0000001", Amount = 2 },
            new PCComponent { PCId = 3, ComponentCode = "PSU0000001", Amount = 1 }
        });
    }
}