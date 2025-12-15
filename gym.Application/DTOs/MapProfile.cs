using AutoMapper;
using gym.Domain.Entities;

namespace gym.Application.DTOs;

public class MapProfile : Profile
{
    public MapProfile()
    {
        // User:
        CreateMap<UserCreateUpdateDto, User>();
        CreateMap<User, ResponseUserDto>();
        CreateMap<UserUpdateDto, User>();
        
        // Branch:
        CreateMap<BranchCreateDto, Branch>();
        CreateMap<Branch, ResponseBranchDto>();
        CreateMap<BranchUpdateDto, Branch>();
    }
}