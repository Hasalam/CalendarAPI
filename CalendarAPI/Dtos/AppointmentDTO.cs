using System.ComponentModel.DataAnnotations;

namespace CalendarAPI.Dtos
{
    public class AppointmentDTO
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int PatientId { get; set; }
        public int Duration { get; set; }
    }
}
