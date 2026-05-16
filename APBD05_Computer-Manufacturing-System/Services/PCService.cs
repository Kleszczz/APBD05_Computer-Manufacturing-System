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

    //TODO: SKONCZ TO, POCZEKAC NA ODP. PROWADZACEGO.
    public async Task<IEnumerable<ComponentDto>> GetPCWithComponentsAsync(int pcId)
    {
        throw new NotImplementedException();
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