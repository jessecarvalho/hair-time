using Application.DTOs;
using AutoMapper;
using Infrastructure.Domain.Entities;

namespace Application.Profiles;

public class ReviewProfile : Profile
{
    public ReviewProfile()
    {
        CreateMap<Review, ReviewRequestDTO>();
        CreateMap<Review, ReviewResponseDTO>();
    }
}