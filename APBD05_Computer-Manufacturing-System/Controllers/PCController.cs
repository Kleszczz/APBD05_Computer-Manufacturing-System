using APBD05_Computer_Manufacturing_System.DTOs;
using APBD05_Computer_Manufacturing_System.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD05_Computer_Manufacturing_System.Controllers;

/*
• GET api/pcs
• GET api/pcs/{id}/components
• POST api/pcs
• PUT api/pcs/{id}
• DELETE api/pcs/{id}
 */

[Route("api/[controller]")]
[ApiController]
public class PCController : ControllerBase
{
    private readonly IDbService _dbService;

    public PCController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPcsAsync()
    {
        var pcs = await _dbService.GetAllPCsAsync();
        return Ok(pcs);
    }

    [HttpGet("{id}/components")]
    public async Task<IActionResult> GetPCWithComponentsAsync(int id)
    {
        var pc = await _dbService.GetPCWithComponentsAsync(id);

        if (pc is null)
        {
            return NotFound();
        }

        return Ok(pc);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePcAsync([FromBody] PCDto dto)
    {
        var created = await _dbService.CreatePcAsync(dto);
        //return CreatedAtAction(nameof(GetPCWithComponentsAsync), new { id = created.Id }, created);
        return Created($"api/pcs/{created.Id}/components", created);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePcByIdAsync(int id, [FromBody] PCDto pcDto)
    {
        var updated = await _dbService.UpdatePcByIdAsync(id, pcDto);

        if (!updated)
        {
            return NotFound();
        }

        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePcByIdAsync(int id)
    {
        var deleted = await _dbService.DeletePcByIdAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
    
}