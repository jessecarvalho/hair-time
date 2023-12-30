using Application.DTOs;
using AutoMapper;
using ServiceCategory = Infrastructure.Domain.Entities.ServiceCategory;

namespace Application.Profiles;

public class ServiceCategoryProfile : Profile
{
    
    public ServiceCategoryProfile()
    {
        CreateMap<ServiceCategory, ServiceCategoryRequestDTO>();
        CreateMap<ServiceCategory, ServiceCategoryResponseDTO>();
    }
    
}