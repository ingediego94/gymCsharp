using AutoMapper;
using gym.Application.DTOs;
using gym.Application.Interfaces;
using gym.Domain.Entities;
using gym.Domain.Interfaces;

namespace gym.Application.Services;

public class PaymentService : IPaymentService
{
    private readonly IRepository<Payment> _paymentRepository;
    private readonly IMapper _mapper;

    public PaymentService(IRepository<Payment> paymentRepository,
        IMapper mapper)
    {
        _paymentRepository = paymentRepository;
        _mapper = mapper;
    }

    // ----------------------------------------------------------

    // GET ALL:
    public async Task<IEnumerable<ResponsePaymentDto>> GetAllAsync()
    {
        var payments = await _paymentRepository.GetAllAsync();

        return _mapper.Map<IEnumerable<ResponsePaymentDto>>(payments);
    }
    

    // GET BY ID:
    public async Task<ResponsePaymentDto?> GetByIdAsync(int id)
    {
        var payment = await _paymentRepository.GetByIdAsync(id);

        return _mapper.Map<ResponsePaymentDto>(payment);
    }

    
    // CREATE:
    public async Task<ResponsePaymentDto> CreateAsync(PaymentCreateDto dto)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(PaymentCreateDto),
                "El cuerpo de la petición no puede estar vacío.");

        var payment = _mapper.Map<Payment>(dto);

        var response = await _paymentRepository.CreateAsync(payment);

        return _mapper.Map<ResponsePaymentDto>(response);
    }

    
    // UPDATE:
    public async Task<ResponsePaymentDto?> UpdateAsync(int id, PaymentUpdateDto dto)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(PaymentUpdateDto),
                $"El cuerpo de la petición no puede estar vacío.");

        var payment = await _paymentRepository.GetByIdAsync(id);

        if (payment == null)
            return null;
        
        _mapper.Map(dto, payment);

        var paymentUploated = await _paymentRepository.UpdateAsync(payment);

        return _mapper.Map<ResponsePaymentDto>(paymentUploated);

    }
    
    
    // DELETE:
    public async Task<bool> DeleteAsync(int id)
    {
        var toDelete = await _paymentRepository.GetByIdAsync(id);

        if (toDelete == null)
            return false;

        await _paymentRepository.DeleteAsync(toDelete);
        return true;
    }
}