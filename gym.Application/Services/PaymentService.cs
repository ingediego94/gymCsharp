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

    // public async Task<ResponsePaymentDto> CreateAsync(PaymentCreateDto dto)
    // {
    //
    // }
    //
    // public async Task<ResponsePaymentDto?> UpdateAsync(PaymentUpdateDto dto)
    // {
    //
    // }
    //
    // public async Task<bool> DeleteAsync(int id)
    // {
    //
    // }
}