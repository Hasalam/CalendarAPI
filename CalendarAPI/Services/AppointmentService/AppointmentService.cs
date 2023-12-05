using AutoMapper;
using CalendarAPI.Data;
using CalendarAPI.Dtos;
using CalendarAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalendarAPI.Services.AppointmentService
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IMapper _mapper;
        private readonly CalendarAPIContext _context;
        public AppointmentService(IMapper mapper, CalendarAPIContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public bool AppointmentExists(int id)
        {
            return (_context.AppointmentModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public bool DeleteAppointment(int id)
        {
            if (_context.AppointmentModel == null)
            {
                return false;
            }
            var appointmentModel = _context.AppointmentModel.Find(id);
            if (appointmentModel == null)
            {
                return false;
            }

            _context.AppointmentModel.Remove(appointmentModel);
            _context.SaveChanges();

            return true;
        }

        public IEnumerable<AppointmentModel> GetAppointments()
        {
            if (_context.AppointmentModel == null)
            {
                return null;
            }
            return _context.AppointmentModel.ToList();
        }

        public AppointmentDTO GetAppointment(int id)
        {
            if (_context.AppointmentModel == null)
            {
                return null;
            }
            var appointmentModel = _context.AppointmentModel.Find(id);

            if (appointmentModel == null)
            {
                return null;
            }

            return _mapper.Map<AppointmentDTO>(appointmentModel);
        }

        public IEnumerable<AppointmentDTO> CreateAppointment(AppointmentDTO appointmentModel)
        {
            _context.AppointmentModel.Add(_mapper.Map<AppointmentModel>(appointmentModel));
            _context.SaveChanges();

            return _context.AppointmentModel.ToList().Select(a => _mapper.Map<AppointmentDTO>(a)).ToList();
        }

        public bool EditAppointment(int id, AppointmentDTO appointmentModel)
        {
            if (!AppointmentExists(id))
            {
                return false;
            }
            var appointment = _context.AppointmentModel.Find(id);
            appointment.PatientId = appointmentModel.PatientId;
            appointment.Date = appointmentModel.Date;
            appointment.Email = appointmentModel.Email;
            appointment.Title = appointmentModel.Title;
            appointment.Description = appointmentModel.Description;
            appointment.PhoneNumber = appointmentModel.PhoneNumber;
            appointment.Duration = appointmentModel.Duration;
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public IEnumerable<AppointmentModel> GetAppointmentsInDateRange(DateTime from, DateTime to)
        {
            if (_context.AppointmentModel == null)
            {
                return null;
            }
            return _context.AppointmentModel.Where(a=> a.Date >= from && a.Date <= to).ToList();
        }
    }
}
