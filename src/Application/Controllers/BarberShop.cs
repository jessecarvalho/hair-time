using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Application.DTOs;
using Application.Services;
using Infrastructure.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Application.Controllers;

[ApiController]
public class BarberShopController : ControllerBase
{

    private readonly BarberShopServices BarberShopServices;

    public BarberShopController(BarberShopServices barberShopServices)
    {
        BarberShopServices = barberShopServices;
    }
    
    [Authorize]
    [HttpGet("api/barber-shopper")]
    public ActionResult<BarberShop> Get()
    {
        var barberShops = BarberShopServices.GetBarberShops();
        return Ok(barberShops);
    }
    
    [Authorize]
    [HttpGet("api/barber-shopper/{id}")]
    public ActionResult<BarberShop> GetById(int id)
    {
        var barberShop = BarberShopServices.getBarberShopById(id);
        if (barberShop == null)
        {
            return NotFound();
        }
        return Ok(barberShop);
    }
    
    [Authorize]
    [HttpPost("api/barber-shopper")]
    public ActionResult<BarberShop> Create(BarberShopRequestDTO barberShop)
    {
        var createdBarberShop = BarberShopServices.CreateBarberShop(barberShop);
        return CreatedAtAction(nameof(GetById), new { id = createdBarberShop.Id }, createdBarberShop);
    }
    
    [Authorize]
    [HttpPut("api/barber-shopper/{id}")]
    public ActionResult<BarberShop> Update(int id, BarberShopRequestDTO barberShop)
    {
        var updatedBarberShop = BarberShopServices.updateBarberShop(barberShop);
        return Ok(updatedBarberShop);
    }
    
    [Authorize]
    [HttpDelete("api/barber-shopper/{id}")]
    public ActionResult Delete(int id)
    {
        BarberShopServices.deleteBarberShop(id);
        return NoContent();
    }
    
    [HttpPost("api/barber-shopper/authenticate")]
    public ActionResult<BarberShop> Authenticate(AuthenticateRequest model)
    {
        var barberShop = BarberShopServices.Authenticate(model);
        
        if (barberShop == null)
            return BadRequest(new { message = "Username or password is incorrect" });
        
        return Ok(barberShop);
    }
    
}