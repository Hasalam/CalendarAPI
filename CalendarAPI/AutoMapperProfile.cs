using AutoMapper;
using CalendarAPI.Dtos;
using CalendarAPI.Models;

namespace CalendarAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AppointmentModel, AppointmentDTO>();
            CreateMap<AppointmentDTO, AppointmentModel>();
        }
    }
}
