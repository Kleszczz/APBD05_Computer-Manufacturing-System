using APBD05_Computer_Manufacturing_System.DTOs;

namespace APBD05_Computer_Manufacturing_System.Services;

public interface IDbService
{
    Task<IEnumerable<PCDto>> GetAllPCsAsync();
    Task<PCWithComponentsDto?> GetPCWithComponentsAsync(int pcId);
    Task<PCDto> CreatePcAsync(PCDto pcDto);
    Task<bool> UpdatePcByIdAsync(int pcId, PCDto pcDto);
    Task<bool> DeletePcByIdAsync(int pcId);
}