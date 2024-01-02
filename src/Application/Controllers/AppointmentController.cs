using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Application.DTOs;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Application.Controllers;

[ApiController]
public class AppointmentController : ControllerBase
{
    
    private readonly AppointmentServices AppointmentServices;

    public AppointmentController(AppointmentServices appointmentServices)
    {
        AppointmentServices = appointmentServices;
    }
    
    [Authorize]
    [HttpGet("api/appointment")]
    public ActionResult<AppointmentController> GetAppointment()
    {
        var appointments = AppointmentServices.GetAppointments();
        return Ok(appointments);
    }
    
    [Authorize]
    [HttpGet("api/appointment/{id}")]
    public ActionResult<AppointmentController> GetAppointmentById(int id)
    {
        var appointment = AppointmentServices.GetAppointmentById(id);
        if (appointment == null)
        {
            return NotFound();
        }
        return Ok(appointment);
    }
    
    [Authorize]
    [HttpPost("api/appointment")]
    public ActionResult<AppointmentController> CreateAppointment(AppointmentRequestDTO appointment)
    {
        var createdAppointment = AppointmentServices.CreateAppointment(appointment);
        return CreatedAtAction(nameof(GetAppointmentById), new { id = createdAppointment.Id }, createdAppointment);
    }
    
    [Authorize]
    [HttpPut("api/appointment/{id}")]
    public ActionResult<AppointmentController> UpdateAppointment(int id, AppointmentRequestDTO appointment)
    {
        var updatedAppointment = AppointmentServices.UpdateAppointment(appointment);
        return Ok(updatedAppointment);
    }
    
    [Authorize]
    [HttpDelete("api/appointment/{id}")]
    public ActionResult DeleteAppointment(int id)
    {
        AppointmentServices.DeleteAppointment(id);
        return NoContent();
    }

}