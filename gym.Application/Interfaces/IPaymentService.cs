using gym.Application.DTOs;

namespace gym.Application.Interfaces;

public interface IPaymentService
{
    Task<IEnumerable<ResponsePaymentDto>> GetAllAsync();
    Task<ResponsePaymentDto?> GetByIdAsync(int id);
    // Task<ResponsePaymentDto> CreateAsync(PaymentCreateDto dto);
    // Task<ResponsePaymentDto?> UpdateAsync(PaymentUpdateDto dto);
    // Task<bool> DeleteAsync(int id);
}