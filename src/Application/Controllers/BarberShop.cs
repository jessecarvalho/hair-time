using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Application.Controllers;

[ApiController]
public class BarberShopController : ControllerBase
{

    [HttpGet("api/weather-forecast")]
    public ActionResult<bool> Get()
    {
        return true;
    }
}