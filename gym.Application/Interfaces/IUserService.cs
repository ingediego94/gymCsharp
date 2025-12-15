using gym.Application.DTOs;
using gym.Domain.Entities;

namespace gym.Application.Interfaces;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> GetByIdAsync(int id);
    Task<ResponseUserDto> CreateAsync(UserCreateUpdateDto dto);
    Task<ResponseUserDto?> UpdateAsync(int id, UserUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}