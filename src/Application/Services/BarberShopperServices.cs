using Application.DTOs;
using AutoMapper;
using Infrastructure.Data;
using Infrastructure.Domain.Entities;

namespace Application.Services;

public class BarberShopServices
{
    
    private readonly IMapper _mapper;
    private readonly HairTimeDbContext _dbContext;
    
    public BarberShopServices(IMapper mapper, HairTimeDbContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;
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
    
    public BarberShopResponseDTO createBarberShop(BarberShopRequestDTO barberShop)
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
    
}