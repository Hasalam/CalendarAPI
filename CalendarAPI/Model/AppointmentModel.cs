using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace CalendarAPI.Models
{
    public class AppointmentModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        [DefaultValue(1)]
        public int Duration { get; set; }
        [Required]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
