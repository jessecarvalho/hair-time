using AutoMapper;
using Application.DTOs;
using Infrastructure.Domain.Entities;

public class BarberShopProfile : Profile
{
    public BarberShopProfile()
    {
        CreateMap<BarberShop, BarberShopResponseDTO>();
        CreateMap<BarberShop, BarberShopRequestDTO>();
        CreateMap<BarberShopRequestDTO, BarberShop>();
        CreateMap<BarberShopResponseDTO, BarberShop>();
    }
}