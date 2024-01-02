using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Application.DTOs;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Application.Controllers;

[ApiController]
public class ServiceController : ControllerBase
{
    
    public readonly ServiceServices ServiceService;
    
    public ServiceController(ServiceServices serviceService)
    {
        ServiceService = serviceService;
    }
    
    [Authorize]
    [HttpGet("api/service")]
    public ActionResult<ServiceController> Get()
    {
        var services = ServiceService.GetServices();
        return Ok(services);
    }
    
    [Authorize]
    [HttpGet("api/service/{id}")]
    public ActionResult<ServiceController> GetById(int id)
    {
        var service = ServiceService.GetServiceById(id);
        if (service == null)
        {
            return NotFound();
        }
        return Ok(service);
    }
    
    [Authorize]
    [HttpPost("api/service")]
    public ActionResult<ServiceController> Create(ServiceRequestDTO service)
    {
        var createdService = ServiceService.CreateService(service);
        return CreatedAtAction(nameof(GetById), new { id = createdService.Id }, createdService);
    }
    
    [Authorize]
    [HttpPut("api/service/{id}")]
    public ActionResult<ServiceController> Update(int id, ServiceRequestDTO service)
    {
        var updatedService = ServiceService.UpdateService(service);
        return Ok(updatedService);
    }
    
    [Authorize]
    [HttpDelete("api/service/{id}")]
    public ActionResult Delete(int id)
    {
        ServiceService.DeleteService(id);
        return NoContent();
    }
    
}