using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Application.DTOs;
using Application.Services;
using Infrastructure.Domain.Entities;

namespace Application.Controllers;

[ApiController]
public class BarberShopController : ControllerBase
{

    private readonly BarberShopServices BarberShopServices;

    public BarberShopController(BarberShopServices barberShopServices)
    {
        BarberShopServices = barberShopServices;
    }
    
    [HttpGet("api/barber-shopper")]
    public ActionResult<BarberShop> Get()
    {
        var barberShops = BarberShopServices.GetBarberShops();
        return Ok(barberShops);
    }
    
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
    
    [HttpPost("api/barber-shopper")]
    public ActionResult<BarberShop> Create(BarberShopRequestDTO barberShop)
    {
        var createdBarberShop = BarberShopServices.createBarberShop(barberShop);
        return CreatedAtAction(nameof(GetById), new { id = createdBarberShop.Id }, createdBarberShop);
    }
    
    [HttpPut("api/barber-shopper/{id}")]
    public ActionResult<BarberShop> Update(int id, BarberShopRequestDTO barberShop)
    {
        if (id != barberShop.Id)
        {
            return BadRequest();
        }
        var updatedBarberShop = BarberShopServices.updateBarberShop(barberShop);
        return Ok(updatedBarberShop);
    }
    
    [HttpDelete("api/barber-shopper/{id}")]
    public ActionResult Delete(int id)
    {
        BarberShopServices.deleteBarberShop(id);
        return NoContent();
    }
    
}