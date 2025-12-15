using gym.Application.DTOs;

namespace gym.Application.Interfaces;

public interface IBranchService
{
    Task<IEnumerable<ResponseBranchDto>> GetAllAsync();
    Task<ResponseBranchDto?> GetByIdAsync(int id);
    // Task<ResponseBranchDto> CreateAsync(BranchCreateDto dto);
    // Task<ResponseBranchDto?> UpdateAsync(int id, BranchUpdateDto dto);
    // Task<bool> DeleteAsync(int id);
}