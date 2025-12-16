using AutoMapper;
using gym.Application.DTOs;
using gym.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gym.Api.Controllers;


// [Authorize]
[ApiController]
[Route("api/[controller]")]
public class BranchController : ControllerBase
{
    private readonly IBranchService _branchService;
    private readonly IMapper _mapper;
    

    public BranchController(IBranchService branchService,
        IMapper mapper)
    {
        _branchService = branchService;
        _mapper = mapper;
    }
    // -------------------------------------------------------

    // GET ALL:
    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        var branches = await _branchService.GetAllAsync();
        
        return Ok(branches);

    }


    // GET BY ID:
    [HttpGet("getById/{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var branch = await _branchService.GetByIdAsync(id);

        return Ok(branch);
    }


    // CREATE:
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] BranchCreateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var branchCreated = await _branchService.CreateAsync(dto);

        return Ok(new { message = $"Registro creado exitosamente.", branchCreated });
    }


    // UPDATE:
    [HttpPut("update/{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] BranchUpdateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updatedBranch = await _branchService.UpdateAsync(id, dto);

        if (updatedBranch == null)
            return NotFound(new { message = $"Branch con ID {id} no encontrado.," });

        return Ok(new { message = "Registro actualizado con éxito.", updatedBranch });

    }

    
    // DELETE:
    [HttpDelete("delete/{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var toDelete = await _branchService.DeleteAsync(id);
        
        if(!toDelete)
            return NotFound(
                new {message=$"Registro con ID {id} no encontrado."}
                );
        return Ok(new { message = $"Registro con ID {id} eliminado exitosamente." });
    }

}