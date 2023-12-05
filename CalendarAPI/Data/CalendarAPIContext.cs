using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CalendarAPI.Models;

namespace CalendarAPI.Data
{
    public class CalendarAPIContext : DbContext
    {
        public CalendarAPIContext (DbContextOptions<CalendarAPIContext> options)
            : base(options)
        {
        }

        public DbSet<CalendarAPI.Models.AppointmentModel> AppointmentModel { get; set; } = default!;
        public DbSet<Patient> Patients { get; set; } = default!;
    }
}
