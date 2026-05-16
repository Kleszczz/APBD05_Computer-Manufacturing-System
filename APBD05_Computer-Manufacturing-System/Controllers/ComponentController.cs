using APBD05_Computer_Manufacturing_System.Data;
using APBD05_Computer_Manufacturing_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APBD05_Computer_Manufacturing_System.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ComponentController : ControllerBase
{
    private readonly AppDbContext _context;
    public ComponentController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
       List<Component> components = await _context.Components.ToListAsync();
       return Ok(components);
    }
}