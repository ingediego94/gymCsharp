using AutoMapper;
using gym.Application.DTOs;
using gym.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace gym.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _paymentService;
    private readonly IMapper _mapper;
    private readonly ILogger<PaymentController> _logger;

    public PaymentController(IPaymentService paymentService,
        IMapper mapper, ILogger<PaymentController> logger)
    {
        _paymentService = paymentService;
        _mapper = mapper;
        _logger = logger;
    }
    
    // --------------------------------------------------
    
    // GET ALL:
    [HttpGet("get")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var payments = await _paymentService.GetAllAsync();

            return Ok(payments);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al traer todos los payments.");
            return StatusCode(500, "Internal server error"); 
        }
        
    }
    
    
    // GET BY ID:
    [HttpGet("get/{id:int:min(1)}")]
    public async Task<IActionResult> GetById(int id)
    {
        if (id <= 0)
        {
            return BadRequest("El ID debe ser mayor a 0.");
        }

        try
        {
            var payment = await _paymentService.GetByIdAsync(id);

            if (payment == null)
            {
                return NotFound(new
                {
                    message = $"Payment con ID {id} no encontrado.",
                    id = id
                });
            }
            
            return Ok(payment);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error consiguiendo el payment con el ID {PaymentId}", id);
            return StatusCode(500, "Internal server error");
        }
    } 
    
    
    // UPDATE:
    [HttpPut("upload/{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] PaymentUpdateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updatedPayment = await _paymentService.UpdateAsync(id, dto);

        if (updatedPayment == null)
            return NotFound(
                new { message = $"El registro con ID {id} no fue encontrado." });

        return Ok(new { message = $"Registro actualizado con éxito.", updatedPayment });
    }
    
    
    //CREATE:
    [HttpPost("create")]
    public async Task<IActionResult> Create( [FromBody] PaymentCreateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var paymentCreated = await _paymentService.CreateAsync(dto);

        return Ok(new { message = "Registro creado exitosamente.", paymentCreated });
    }
    
    
    // DELETE:
    [HttpDelete("delete/{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var toDelete = await _paymentService.DeleteAsync(id);

        if (!toDelete)
            return NotFound(
                new { message = $"El registro con dl ID {id} no" }
                );

        await _paymentService.DeleteAsync(id);
        return Ok(new { message = $"El registro con ID {id} ha sido eliminado exitosamente." });
    }
}