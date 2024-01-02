using Application.DTOs;
using AutoMapper;
using Infrastructure.Data;
using Domain.Entities;

namespace Application.Services;

public class CustomerServices
{
    
    private readonly IMapper _mapper;
    private readonly HairTimeDbContext _dbContext;
    private readonly TokenService _tokenService;

    public CustomerServices(IMapper mapper, HairTimeDbContext dbContext, TokenService tokenService)
    {
        _mapper = mapper;
        _dbContext = dbContext;
        _tokenService = tokenService;
    }
    
    public List<CustomerResponseDTO> GetCustomers()
    {
        var customers = _dbContext.Customers.ToList();
        return _mapper.Map<List<CustomerResponseDTO>>(customers);
    }
    public CustomerResponseDTO GetCustomerById(int id)
    {
        var customer = _dbContext.Customers.FirstOrDefault(x => x.Id == id);
        
        return _mapper.Map<CustomerResponseDTO>(customer);
    }
    
    public CustomerResponseDTO CreateCustomer(CustomerRequestDTO customer)
    {
        
        var newCustomer = _mapper.Map<Customer>(customer);
        _dbContext.Customers.Add(newCustomer);
        _dbContext.SaveChanges();

        return _mapper.Map<CustomerResponseDTO>(newCustomer);
    }
    
    public CustomerResponseDTO UpdateCustomer(CustomerRequestDTO customer)
    {
        var updateCustomer = _mapper.Map<Customer>(customer);
        _dbContext.Customers.Update(updateCustomer);
        _dbContext.SaveChanges();
        return _mapper.Map<CustomerResponseDTO>(updateCustomer);
    }
    
    public void DeleteCustomer(int id)
    {
        var customer = _dbContext.Customers.FirstOrDefault(x => x.Id == id);
        _dbContext.Customers.Remove(customer);
        _dbContext.SaveChanges();
    }
    
    public string Authenticate(AuthenticateRequest barberShop)
    {
        if (string.IsNullOrEmpty(barberShop.Username) || string.IsNullOrEmpty(barberShop.Password))
        {
            return null;
        }

        var barberShopEntity = _dbContext.BarberShops.FirstOrDefault(x => x.Email == barberShop.Username && x.Password == barberShop.Password);

        return _tokenService.GenerateBarberShopToken(barberShopEntity);
    }
    
}