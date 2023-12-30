using Application.DTOs;
using AutoMapper;
using Infrastructure.Domain.Entities;

namespace Application.Profiles;

public class ServiceProfile : Profile
{
    public ServiceProfile()
    {
        CreateMap<Service, ServiceResponseDTO>();
        CreateMap<Service, ServiceRequestDTO>();
    }
}