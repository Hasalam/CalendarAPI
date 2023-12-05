using CalendarAPI.Services.AppointmentService;
using CalendarAPI.Services.PatientService;
using Microsoft.AspNetCore.Mvc;

namespace CalendarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;
        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        [HttpGet]
        public ActionResult GetPatients()
        {
            var patients = _patientService.GetPatients();
            if (patients == null)
            {
                return NotFound();
            }
            return Ok(patients.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult GetPatient(int id)
        {
            var patient = _patientService.GetPatient(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }
    }
}
