using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Application.DTOs;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Application.Controllers;

[ApiController]
public class ServiceCategoryController : ControllerBase
{
    
    private readonly ServiceCategoryServices ServiceCategoryServices;

    public ServiceCategoryController(ServiceCategoryServices serviceCategoryServices)
    {
        ServiceCategoryServices = serviceCategoryServices;
    }
    
    [Authorize]
    [HttpGet("api/service-category")]
    public ActionResult<ServiceCategoryController> Get()
    {
        var serviceCategories = ServiceCategoryServices.GetServiceCategories();
        return Ok(serviceCategories);
    }
    
    [Authorize]
    [HttpGet("api/service-category/{id}")]
    public ActionResult<ServiceCategoryController> GetById(int id)
    {
        var serviceCategory = ServiceCategoryServices.GetServiceCategoryById(id);
        if (serviceCategory == null)
        {
            return NotFound();
        }
        return Ok(serviceCategory);
    }
    
    [Authorize]
    [HttpPost("api/service-category")]
    public ActionResult<ServiceCategoryController> Create(ServiceCategoryRequestDTO serviceCategory)
    {
        var createdServiceCategory = ServiceCategoryServices.CreateServiceCategory(serviceCategory);
        return CreatedAtAction(nameof(GetById), new { id = createdServiceCategory.Id }, createdServiceCategory);
    }
    
    [Authorize]
    [HttpPut("api/service-category/{id}")]
    public ActionResult<ServiceCategoryController> Update(int id, ServiceCategoryRequestDTO serviceCategory)
    {
        var updatedServiceCategory = ServiceCategoryServices.UpdateServiceCategory(serviceCategory);
        return Ok(updatedServiceCategory);
    }
    
    [Authorize]
    [HttpDelete("api/service-category/{id}")]
    public ActionResult Delete(int id)
    {
        ServiceCategoryServices.DeleteServiceCategory(id);
        return NoContent();
    }
    
}