using AutoMapper;
using CalendarAPI.Data;
using CalendarAPI.Models;

namespace CalendarAPI.Services.PatientService
{
    public interface IPatientService
    {
        IEnumerable<Patient> GetPatients();
        Patient GetPatient(int id);
    }
}
