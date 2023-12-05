using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CalendarAPI.Data;
using CalendarAPI.Models;
using CalendarAPI.Dtos;
using CalendarAPI.Services.AppointmentService;

namespace CalendarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentModelsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentModelsController( IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        // GET: api/AppointmentModels
        [HttpGet]
        public ActionResult GetAppointmentModel()
        {
          var appointments = _appointmentService.GetAppointments();
            if (appointments == null)
            { 
                return NotFound();
            }
            return Ok(appointments.ToList());
        }
        [HttpGet("InRange")]
        public IActionResult GetAppointentsInDateRange(DateTime from, DateTime to) {
            var appointments = _appointmentService.GetAppointmentsInDateRange(from,to);
            if (appointments == null)
            {
                return NotFound();
            }
            return Ok(appointments.ToList());
        }

        // GET: api/AppointmentModels/5
        [HttpGet("{id}")]
        public IActionResult GetAppointmentModel(int id)
        {
         var appointment = _appointmentService.GetAppointment(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return Ok(appointment);
        }

        // PUT: api/AppointmentModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutAppointmentModel(int id, AppointmentDTO appointmentModel)
        {

            var success = _appointmentService.EditAppointment(id, appointmentModel);
            return success ? Ok() : BadRequest();
        }

        // POST: api/AppointmentModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostAppointmentModel(AppointmentDTO appointmentModel)
        {
            var appointments = _appointmentService.CreateAppointment(appointmentModel);
            return appointments != null ? Ok(appointments) : BadRequest(); 
        }

        // DELETE: api/AppointmentModels/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAppointmentModel(int id)
        {
            var success = _appointmentService.DeleteAppointment(id);
            return success ? Ok() : BadRequest();
        }
    }
}
