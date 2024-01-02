using Application.DTOs;
using AutoMapper;
using Infrastructure.Data;
using Domain.Entities;

namespace Application.Services;

public class ServiceServices
{
    
    private readonly IMapper _mapper;
    private readonly HairTimeDbContext _dbContext;
    
    public ServiceServices(IMapper mapper, HairTimeDbContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }
    
    public List<ServiceResponseDTO> GetServices()
    {
        var services = _dbContext.Services.ToList();
        return _mapper.Map<List<ServiceResponseDTO>>(services);
    }
    
    public ServiceResponseDTO GetServiceById(int id)
    {
        var service = _dbContext.Services.FirstOrDefault(x => x.Id == id);
        
        return _mapper.Map<ServiceResponseDTO>(service);
    }
    
    public ServiceResponseDTO CreateService(ServiceRequestDTO service)
    {
        
        var newService = _mapper.Map<Service>(service);
        _dbContext.Services.Add(newService);
        _dbContext.SaveChanges();

        return _mapper.Map<ServiceResponseDTO>(newService);
    }
    
    public ServiceResponseDTO UpdateService(ServiceRequestDTO service)
    {
        var updateService = _mapper.Map<Service>(service);
        _dbContext.Services.Update(updateService);
        _dbContext.SaveChanges();
        return _mapper.Map<ServiceResponseDTO>(updateService);
    }
    
    public void DeleteService(int id)
    {
        var service = _dbContext.Services.FirstOrDefault(x => x.Id == id);
        _dbContext.Services.Remove(service);
        _dbContext.SaveChanges();
    }
    
}