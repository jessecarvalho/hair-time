using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Application.DTOs;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Application.Controllers;

[ApiController]
public class CustomerController : ControllerBase
{
    
    private readonly CustomerServices CustomerServices;

    public CustomerController(CustomerServices customerServices)
    {
        CustomerServices = customerServices;
    }
    
    [Authorize]
    [HttpGet("api/customer")]
    public ActionResult<CustomerController> Get()
    {
        var customers = CustomerServices.GetCustomers();
        return Ok(customers);
    }
    
    [Authorize]
    [HttpGet("api/customer/{id}")]
    public ActionResult<CustomerController> GetById(int id)
    {
        var customer = CustomerServices.GetCustomerById(id);
        if (customer == null)
        {
            return NotFound();
        }
        return Ok(customer);
    }
    
    [Authorize]
    [HttpPost("api/customer")]
    public ActionResult<CustomerController> Create(CustomerRequestDTO customer)
    {
        var createdCustomer = CustomerServices.CreateCustomer(customer);
        return CreatedAtAction(nameof(GetById), new { id = createdCustomer.Id }, createdCustomer);
    }
    
    [Authorize]
    [HttpPut("api/customer/{id}")]
    public ActionResult<CustomerController> Update(int id, CustomerRequestDTO customer)
    {
        var updatedCustomer = CustomerServices.UpdateCustomer(customer);
        return Ok(updatedCustomer);
    }
    
    [Authorize]
    [HttpDelete("api/customer/{id}")]
    public ActionResult Delete(int id)
    {
        CustomerServices.DeleteCustomer(id);
        return NoContent();
    }
    
    [AllowAnonymous]
    [HttpPost("api/customer/authenticate")]
    public ActionResult<CustomerController> Authenticate(AuthenticateRequest customer)
    {
        var response = CustomerServices.Authenticate(customer);
        if (response == null)
        {
            return BadRequest(new { message = "Username or password is incorrect" });
        }
        return Ok(response);
    }
    
}