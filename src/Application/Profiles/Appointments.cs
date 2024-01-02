using Application.DTOs;
using AutoMapper;
using Infrastructure.Domain.Entities;

namespace Application.Profiles;

public class AppointmentProfile : Profile
{
    public AppointmentProfile()
    {
        CreateMap<Appointment, AppointmentRequestDTO>();
        CreateMap<Appointment, AppointmentResponseDTO>();
    }
}