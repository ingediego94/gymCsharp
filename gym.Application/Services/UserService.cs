using AutoMapper;
using gym.Application.DTOs;
using gym.Application.Interfaces;
using gym.Domain.Entities;
using gym.Domain.Interfaces;

namespace gym.Application.Services;

public class UserService : IUserService
{
    private readonly IRepository<User> _userRepository;
    private readonly IMapper _mapper;

    public UserService(IRepository<User> userRepository, 
        IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    // ----------------------------------------
    
    // GET ALL:
    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _userRepository.GetAllAsync();
    }

    
    // GET BY ID:
    public async Task<User?> GetByIdAsync(int id)
    {
        return await _userRepository.GetByIdAsync(id);
    }

    
    // CREATE:
    public async Task<ResponseUserDto> CreateAsync(UserCreateUpdateDto dto)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(UserCreateUpdateDto), 
                "El cuerpo de la petición no puede estar vacío.");

        var user = _mapper.Map<User>(dto);
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);
        user.CreatedAt = DateTime.UtcNow;
        user.UpdatedAt = DateTime.UtcNow;

        var response = await _userRepository.CreateAsync(user);

        return _mapper.Map<ResponseUserDto>(response);
    }
    
    
    // UPDATE:
    public async Task<ResponseUserDto?> UpdateAsync(int id, UserUpdateDto dto)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(dto));
        
        var user = await _userRepository.GetByIdAsync(id);

        if (user == null)
            return null;
        
        _mapper.Map(dto, user);
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);
        user.UpdatedAt = DateTime.UtcNow;

        var updatedUser = await _userRepository.UpdateAsync(user);

        return _mapper.Map<ResponseUserDto>(updatedUser);
    }


    // DELETE:
    public async Task<bool> DeleteAsync(int id)
    {
        var toDelete = await _userRepository.GetByIdAsync(id);

        if (toDelete == null)
            return false;

        return await _userRepository.DeleteAsync(toDelete);
    }
}