using AutoMapper;
using gym.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gym.Api.Controllers;


// [Authorize]
[ApiController]
[Route("api/[controller]")]
public class BranchCrontroller : ControllerBase
{
    private readonly IBranchService _branchService;
    private readonly IMapper _mapper;

    public BranchCrontroller( IBranchService branchService,
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
}