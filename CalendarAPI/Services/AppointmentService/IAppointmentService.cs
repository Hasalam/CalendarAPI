using CalendarAPI.Dtos;
using CalendarAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CalendarAPI.Services.AppointmentService
{
    public interface IAppointmentService
    {
        IEnumerable<AppointmentModel> GetAppointments();
        bool EditAppointment(int id, AppointmentDTO appointmentModel);
        IEnumerable<AppointmentDTO> CreateAppointment(AppointmentDTO appointmentModel);
        AppointmentDTO GetAppointment(int id);
        bool DeleteAppointment(int id);
        bool AppointmentExists(int id);
        IEnumerable<AppointmentModel> GetAppointmentsInDateRange(DateTime from,DateTime to);
    }
}
