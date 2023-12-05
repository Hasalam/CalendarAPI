
using FakeItEasy;
using CalendarAPI.Services.AppointmentService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalendarAPI.Dtos;
using CalendarAPI.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using CalendarAPI.Models;

namespace CalendarAPITests.Controller
{
    public class AppointmentControllerTests
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentControllerTests() {
            _appointmentService = A.Fake<IAppointmentService>();
        }

        [Fact]
        public void AppointmentController_GetAppointments_ReturnOK()
        {
            //Arrange
            var appointments = A.Fake<ICollection<AppointmentDTO>>();
            var controller = new AppointmentModelsController(_appointmentService);
            //Act
            var result = controller.GetAppointmentModel();
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void AppointmentController_PostAppointments_ReturnActionOK()
        {
            //Arrange
            var appointmentModel = A.Fake<AppointmentDTO>();
            var appointments = A.Fake<ICollection<AppointmentDTO>>();
            var controller = new AppointmentModelsController(_appointmentService);

            //Act
            var result = controller.PostAppointmentModel(appointmentModel);
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void AppointmentController_PostAppointments_ReturnAvtionBadRequest()
        {
            //Arrange
            AppointmentDTO appointmentModel = null;
            var appointments = A.Fake<ICollection<AppointmentDTO>>();
            var controller = new AppointmentModelsController(_appointmentService);
            A.CallTo(() => _appointmentService.CreateAppointment(appointmentModel)).Returns(null);
            //Act
            var result = controller.PostAppointmentModel(appointmentModel);
            //Assert
            result.Should().BeOfType(typeof(BadRequestResult));
        }

        [Fact]
        public void AppointmentController_GetAppointment_ReturnOK()
        {
            //Arrange
            int id = 1;
            var controller = new AppointmentModelsController(_appointmentService);
            //Act
            var result = controller.GetAppointmentModel(id);
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public void AppointmentController_GetAppointment_ReturnNotFound()
        {
            //Arrange
            int id = -1;
            var controller = new AppointmentModelsController(_appointmentService);
            A.CallTo(() => _appointmentService.GetAppointment(id)).Returns(null);
            //Act
            var result = controller.GetAppointmentModel(id);
            //Assert
            result.Should().BeOfType(typeof(NotFoundResult));
        }
    }
}
