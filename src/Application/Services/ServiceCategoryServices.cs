using Application.DTOs;
using AutoMapper;
using Infrastructure.Data;
using Domain.Entities;

namespace Application.Services;

public class ServiceCategoryServices
{
    
    private readonly IMapper _mapper;
    private readonly HairTimeDbContext _dbContext;
    
    public ServiceCategoryServices(IMapper mapper, HairTimeDbContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }
    
    public List<ServiceCategoryResponseDTO> GetServiceCategories()
    {
        var serviceCategories = _dbContext.ServiceCategories.ToList();
        return _mapper.Map<List<ServiceCategoryResponseDTO>>(serviceCategories);
    }
    
    public ServiceCategoryResponseDTO GetServiceCategoryById(int id)
    {
        var serviceCategory = _dbContext.ServiceCategories.FirstOrDefault(x => x.Id == id);
        
        return _mapper.Map<ServiceCategoryResponseDTO>(serviceCategory);
    }
    
    public ServiceCategoryResponseDTO CreateServiceCategory(ServiceCategoryRequestDTO serviceCategory)
    {
        
        var newServiceCategory = _mapper.Map<ServiceCategory>(serviceCategory);
        _dbContext.ServiceCategories.Add(newServiceCategory);
        _dbContext.SaveChanges();

        return _mapper.Map<ServiceCategoryResponseDTO>(newServiceCategory);
    }
    
    public ServiceCategoryResponseDTO UpdateServiceCategory(ServiceCategoryRequestDTO serviceCategory)
    {
        var updateServiceCategory = _mapper.Map<ServiceCategory>(serviceCategory);
        _dbContext.ServiceCategories.Update(updateServiceCategory);
        _dbContext.SaveChanges();
        return _mapper.Map<ServiceCategoryResponseDTO>(updateServiceCategory);
    }
    
    public void DeleteServiceCategory(int id)
    {
        var serviceCategory = _dbContext.ServiceCategories.FirstOrDefault(x => x.Id == id);
        _dbContext.ServiceCategories.Remove(serviceCategory);
        _dbContext.SaveChanges();
    }
    
}