using Application.DTOs;
using AutoMapper;
using Infrastructure.Domain.Entities;

namespace Application.Profiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CustomerResponseDTO>();
        CreateMap<Customer, CustomerRequestDTO>();
    }
}