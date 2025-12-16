using AutoMapper;
using gym.Domain.Entities;

namespace gym.Application.DTOs;

public class MapProfile : Profile
{
    public MapProfile()
    {
        // User:
        CreateMap<UserCreateUpdateDto, User>();
        CreateMap<UserUpdateDto, User>();
        CreateMap<User, ResponseUserDto>();
        
        // Branch:
        CreateMap<BranchCreateDto, Branch>();
        CreateMap<BranchUpdateDto, Branch>();
        CreateMap<Branch, ResponseBranchDto>();
        
        // Payment:
        CreateMap<PaymentCreateDto, Payment>();
        CreateMap<PaymentUpdateDto, Payment>();
        CreateMap<Payment, ResponsePaymentDto>();
    }
}