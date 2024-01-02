using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles;

public class ServiceCategoryProfile : Profile
{
    
    public ServiceCategoryProfile()
    {
        CreateMap<ServiceCategory, ServiceCategoryRequestDTO>();
        CreateMap<ServiceCategory, ServiceCategoryResponseDTO>();
    }
    
}