using System.Text;
using Application.DTOs;
using AutoMapper;
using Infrastructure.Data;
using Infrastructure.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Application.Services;

public class BarberShopServices
{
    
    private readonly IMapper _mapper;
    private readonly HairTimeDbContext _dbContext;
    private readonly TokenService _tokenService;

    public BarberShopServices(IMapper mapper, HairTimeDbContext dbContext, TokenService tokenService)
    {
        _mapper = mapper;
        _dbContext = dbContext;
        _tokenService = tokenService;
    }
    
    public List<BarberShopResponseDTO> GetBarberShops()
    {
        var barberShops = _dbContext.BarberShops.ToList();
        return _mapper.Map<List<BarberShopResponseDTO>>(barberShops);
    }
    public BarberShopResponseDTO getBarberShopById(int id)
    {
        var barberShop = _dbContext.BarberShops.FirstOrDefault(x => x.Id == id);
        
        return _mapper.Map<BarberShopResponseDTO>(barberShop);
    }
    
    public BarberShopResponseDTO CreateBarberShop(BarberShopRequestDTO barberShop)
    {
        
        var newBarberShop = _mapper.Map<BarberShop>(barberShop);
        _dbContext.BarberShops.Add(newBarberShop);
        _dbContext.SaveChanges();

        return _mapper.Map<BarberShopResponseDTO>(newBarberShop);
    }
    
    public BarberShopResponseDTO updateBarberShop(BarberShopRequestDTO barberShop)
    {
        var updateBarberShop = _mapper.Map<BarberShop>(barberShop);
        _dbContext.BarberShops.Update(updateBarberShop);
        _dbContext.SaveChanges();
        return _mapper.Map<BarberShopResponseDTO>(updateBarberShop);
    }
    
    public void deleteBarberShop(int id)
    {
        var barberShop = _dbContext.BarberShops.FirstOrDefault(x => x.Id == id);
        _dbContext.BarberShops.Remove(barberShop);
        _dbContext.SaveChanges();
    }

    public string Authenticate(AuthenticateRequest barberShop)
    {
        if (string.IsNullOrEmpty(barberShop.Username) || string.IsNullOrEmpty(barberShop.Password))
        {
            return null;
        }

        var barberShopEntity = _dbContext.BarberShops.FirstOrDefault(x => x.Email == barberShop.Username && x.Password == barberShop.Password);
        if (barberShopEntity == null)
        {
            return null;
        }

        return _tokenService.GenerateBarberShopToken(barberShopEntity);
    }

}