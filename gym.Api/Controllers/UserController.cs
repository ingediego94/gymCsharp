using AutoMapper;
using gym.Application.DTOs;
using gym.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gym.Api.Controllers;

// [Authorize]
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    // -------------------------------------------
    
    // GET ALL:
    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAllAsync();
        return Ok(users);
    }
    
    
    // GET BY ID:
    [HttpGet("getById{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userService.GetByIdAsync(id);

        if (user == null)
            return NotFound(new { message = $"El usuario con ID {id} no se encuentra registrado." });

        return Ok(user);

    }
    
    
    // CREATE:
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] UserCreateUpdateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var userCreated = await _userService.CreateAsync(dto);
        
        // return CreatedAtAction(
        //     nameof(GetById),
        //     new { id = userCreated.Id },
        //     userCreated
        // );

        return Ok(new { message = $"Registro creado exitosamente.", userCreated });
    }
    
    
    // UPDATED:
    [HttpPut("update/{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UserUpdateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updatedUser = await _userService.UpdateAsync(id, dto);

        if(updatedUser == null)
            return NotFound(new { message = $"Usuario con ID {id} no encontrado." });

        return Ok(new {message=$"Registro actualizado con éxito.", updatedUser});

    }
    
    
    // DELETE:
    [HttpDelete("delete/{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var toDelete = await _userService.DeleteAsync(id);

        if (!toDelete)
            return NotFound(
                new { message = $"Registro con ID {id} no encontrado." }
            );
        
        return Ok(new { message = $"Registro con ID {id} eliminado con éxito." });
    }
}