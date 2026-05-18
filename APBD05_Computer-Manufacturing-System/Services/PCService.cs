using APBD05_Computer_Manufacturing_System.Data;
using APBD05_Computer_Manufacturing_System.DTOs;
using APBD05_Computer_Manufacturing_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APBD05_Computer_Manufacturing_System.Services;

/*
• GET api/pcs
• GET api/pcs/{id}/components
• POST api/pcs
• PUT api/pcs/{id}
• DELETE api/pcs/{id}
*/

public class PCService : IDbService
{
    private readonly AppDbContext _context;

    public PCService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PCDto>> GetAllPCsAsync()
    {
        var pcs = await _context.PCs.Select(pc => new PCDto()
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock
        }).ToListAsync();

        return pcs;
    }


    public async Task<PCWithComponentsDto?> GetPCWithComponentsAsync(int pcId)
    {
        var pc = await _context.PCs
            .Include(p => p.PCComponents)
            .ThenInclude(pcc => pcc.Component)
            .ThenInclude(c => c.Manufacturer)
            .Include(p => p.PCComponents)
            .ThenInclude(pcc => pcc.Component)
            .ThenInclude(c => c.Type)
            .FirstOrDefaultAsync(p => p.Id == pcId);

        if (pc is null)
            return null;

        return new PCWithComponentsDto
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock,
            Components = pc.PCComponents.Select(pcc => new PCComponentDto
            {
                Amount = pcc.Amount,
                Component = new ComponentDto
                {
                    Code = pcc.Component.Code,
                    Name = pcc.Component.Name,
                    Description = pcc.Component.Description,
                    Manufacturer = new ComponentManufacturerDto
                    {
                        Id = pcc.Component.Manufacturer.Id,
                        Abbreviation = pcc.Component.Manufacturer.Abbreviation,
                        FullName = pcc.Component.Manufacturer.FullName,
                        FoundationDate = pcc.Component.Manufacturer.FoundationDate
                    },
                    Type = new ComponentTypeDto
                    {
                        Id = pcc.Component.Type.Id,
                        Abbreviation = pcc.Component.Type.Abbreviation,
                        Name = pcc.Component.Type.Name
                    }
                }
            }).ToList()
        };
    }

    // POST api/pcs
    public async Task<PCDto> CreatePcAsync(PCDto pcDto)
    {
        var pc = new PC
        {
            Name = pcDto.Name,
            Weight = pcDto.Weight,
            Warranty = pcDto.Warranty,
            CreatedAt = pcDto.CreatedAt,
            Stock = pcDto.Stock
        };

        await _context.PCs.AddAsync(pc);
        await _context.SaveChangesAsync();

        return new PCDto
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock
        };
    }

    public async Task<bool> UpdatePcByIdAsync(int pcId, PCDto pcDto)
    {
        var pc = await _context.PCs.FindAsync(pcId);

        if (pc is null)
            return false;

        pc.Name = pcDto.Name;
        pc.Weight = pcDto.Weight;
        pc.Warranty = pcDto.Warranty;
        pc.CreatedAt = pcDto.CreatedAt;
        pc.Stock = pcDto.Stock;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeletePcByIdAsync(int pcId)
    {
        var pc = await _context.PCs.FindAsync(pcId);

        if (pc is null)
            return false;

        _context.PCs.Remove(pc);
        await _context.SaveChangesAsync();
        return true;
    }
}