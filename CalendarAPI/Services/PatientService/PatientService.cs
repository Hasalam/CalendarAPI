using AutoMapper;
using CalendarAPI.Data;
using CalendarAPI.Models;

namespace CalendarAPI.Services.PatientService
{
    public class PatientService : IPatientService
    {
        private readonly CalendarAPIContext _context;
        public PatientService(CalendarAPIContext context)
        {
            _context = context;
        }

        public Patient GetPatient(int id)
        {
            return _context.Patients.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Patient> GetPatients()
        {
            return _context.Patients.ToList();
        }
    }
}
