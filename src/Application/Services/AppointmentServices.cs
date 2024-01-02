using Application.DTOs;
using AutoMapper;
using Infrastructure.Data;
using Domain.Entities;

namespace Application.Services;

public class AppointmentServices
{
        
        private readonly IMapper _mapper;
        private readonly HairTimeDbContext _dbContext;
    
        public AppointmentServices(IMapper mapper, HairTimeDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        
        public List<AppointmentResponseDTO> GetAppointments()
        {
            var appointments = _dbContext.Appointments.ToList();
            return _mapper.Map<List<AppointmentResponseDTO>>(appointments);
        }
        public AppointmentResponseDTO GetAppointmentById(int id)
        {
            var appointment = _dbContext.Appointments.FirstOrDefault(x => x.Id == id);
            
            return _mapper.Map<AppointmentResponseDTO>(appointment);
        }
        
        public AppointmentResponseDTO CreateAppointment(AppointmentRequestDTO appointment)
        {
            
            var newAppointment = _mapper.Map<Appointment>(appointment);
            _dbContext.Appointments.Add(newAppointment);
            _dbContext.SaveChanges();
    
            return _mapper.Map<AppointmentResponseDTO>(newAppointment);
        }
        
        public AppointmentResponseDTO UpdateAppointment(AppointmentRequestDTO appointment)
        {
            var updateAppointment = _mapper.Map<Appointment>(appointment);
            _dbContext.Appointments.Update(updateAppointment);
            _dbContext.SaveChanges();
            return _mapper.Map<AppointmentResponseDTO>(updateAppointment);
        }
        
        public void DeleteAppointment(int id)
        {
            var appointment = _dbContext.Appointments.FirstOrDefault(x => x.Id == id);
            _dbContext.Appointments.Remove(appointment);
            _dbContext.SaveChanges();
        }
}