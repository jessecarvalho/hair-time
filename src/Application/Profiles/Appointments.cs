using Application.DTOs;
using AutoMapper;
using Infrastructure.Domain.Entities;

namespace Application.Profiles;

public class Appointments : Profile
{
    public Appointments()
    {
        CreateMap<Appointment, AppointmentRequestDTO>();
        CreateMap<Appointment, AppointmentResponseDTO>();
    }
}