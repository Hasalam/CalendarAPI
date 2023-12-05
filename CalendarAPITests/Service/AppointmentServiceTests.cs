using AutoMapper;
using CalendarAPI.Data;
using CalendarAPI.Services.AppointmentService;
using FakeItEasy;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarAPITests.Service
{
    public class AppointmentServiceTests
    {
        private readonly IMapper _mapper;

        public AppointmentServiceTests()
        {
            _mapper = A.Fake<IMapper>();
        }
        public async Task<CalendarAPIContext> CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<CalendarAPIContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new CalendarAPIContext(options);
            databaseContext.Database.EnsureCreated();
            if (await databaseContext.AppointmentModel.CountAsync() <= 0)
            {
                databaseContext.Patients.Add(new CalendarAPI.Models.Patient()
                {
                    Id = 10,
                    Name = "Test",
                    PhoneNumber = "1234567890",
                    Email = "test@gmail.com",
                    Address = "Test St. 11/22"
                });
                for (int i = 1; i < 11; i++)
                {
                    databaseContext.AppointmentModel.Add(
                       new CalendarAPI.Models.AppointmentModel()
                       {
                           Id = i,
                           Date = DateTime.Now,
                           Title = i.ToString(),
                           Description = i.ToString(),
                           Email = i.ToString(),
                           PhoneNumber = i.ToString(),
                           PatientId = 10
                       });
                    await databaseContext.SaveChangesAsync();

                }
            }
            return databaseContext;
        }

        [Fact]
        public async void AppointmentService_AppointmentExists_ReturnsTrue()
        {
            //Arrange
            var id = 1;
            var dbContext = await CreateDbContext();
            var service = new AppointmentService(_mapper, dbContext);

            //Act
            var result = service.AppointmentExists(id);

            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async void AppointmentService_AppointmentExists_ReturnsFalse()
        {
            //Arrange
            var id = -1;
            var dbContext = await CreateDbContext();
            var service = new AppointmentService(_mapper, dbContext);

            //Act
            var result = service.AppointmentExists(id);

            //Assert
            result.Should().BeFalse();
        }

        [Fact]
        public async void AppointmentService_DeleteAppointment_ReturnsTrue()
        {
            //Arrange
            var id = 1;
            var dbContext = await CreateDbContext();
            var service = new AppointmentService(_mapper, dbContext);

            //Act
            var result = service.DeleteAppointment(id);

            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async void AppointmentService_DeleteAppointment_ReturnsFalse()
        {
            //Arrange
            var id = -1;
            var dbContext = await CreateDbContext();
            var service = new AppointmentService(_mapper, dbContext);

            //Act
            var result = service.DeleteAppointment(id);

            //Assert
            result.Should().BeFalse();
        }

        [Fact]
        public async void AppointmentService_PutAppointment_ReturnsFalse()
        {
            //Arrange
            var id = -1;
            var dbContext = await CreateDbContext();
            var service = new AppointmentService(_mapper, dbContext);

            //Act
            var result = service.EditAppointment(id,null);

            //Assert
            result.Should().BeFalse();
        }
    }
}
