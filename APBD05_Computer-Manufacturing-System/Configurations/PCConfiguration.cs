using APBD05_Computer_Manufacturing_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD05_Computer_Manufacturing_System.Configurations;

public class PCConfiguration : IEntityTypeConfiguration<PC>
{
    public void Configure(EntityTypeBuilder<PC> builder)
    {
        builder.ToTable("PCs");
 
        builder.HasKey(p => p.Id);
 
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(50);
 
        builder.Property(p => p.Weight)
            .IsRequired()
            .HasColumnType("float(5)");
 
        builder.Property(p => p.Warranty)
            .IsRequired();
 
        builder.Property(p => p.CreatedAt)
            .IsRequired()
            .HasColumnType("datetime");
 
        builder.Property(p => p.Stock)
            .IsRequired();
        
        builder.HasData(new List<PC>
        {
            new PC
            {
                Id = 1,
                Name = "Gaming Beast X",
                Weight = (float)12.5,
                Warranty = 36,
                CreatedAt = new DateTime(2026, 5, 8, 9, 0, 0),
                Stock = 5
            },
            new PC
            {
                Id = 2,
                Name = "Office Mini Pro",
                Weight = (float)4.2,
                Warranty = 24,
                CreatedAt = new DateTime(2026, 4, 15, 13, 30, 0),
                Stock = 12
            },
            new PC
            {
                Id = 3,
                Name = "Workstation Ultra",
                Weight = (float)15.8,
                Warranty = 48,
                CreatedAt = new DateTime(2026, 3, 1, 10, 0, 0),
                Stock = 3
            }
        });
    }
}