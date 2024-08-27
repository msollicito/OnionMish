using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RepositoryLayer.Data;
using ServiceLayer.ICustomServices;
using System.Collections.Generic;
using Xunit;
using OnionArchitectureInAspNetCore6WebAPI.Controllers;

namespace OnionArchitecture.Tests
{
    public class ClinicsControllerTests
    {
        private readonly Mock<ICustomService<Clinic>> _mockService;
        private readonly ClinicsController _controller;

        public ClinicsControllerTests()
        {
            _mockService = new Mock<ICustomService<Clinic>>();
            var mockDbContext = new Mock<ApplicationDbContext>(); // If needed
            _controller = new ClinicsController(_mockService.Object, mockDbContext.Object);
        }

        [Fact]
        public void GetClinicById_ReturnsOkResult_WhenClinicExists()
        {
            // Arrange
            var clinicId = 1;
            var clinic = new Clinic { Id = clinicId };
            _mockService.Setup(service => service.Get(clinicId)).Returns(clinic);

            // Act
            var result = _controller.GetClinicById(clinicId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(clinic, okResult.Value);
        }

        [Fact]
        public void GetClinicById_ReturnsNotFoundResult_WhenClinicDoesNotExist()
        {
            // Arrange
            var clinicId = 1;
            _mockService.Setup(service => service.Get(clinicId)).Returns((Clinic)null);

            // Act
            var result = _controller.GetClinicById(clinicId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void GetAllClinic_ReturnsOkResult_WithListOfClinics()
        {
            // Arrange
            // create two clinics that we want the test to find
            var clinics = new List<Clinic> { new Clinic { Id = 1, ClinicName= "Clinic1" }, new Clinic { Id = 2, ClinicName="Clinic2" } };
            // setup the mock to return the list of clinics
            _mockService.Setup(service => service.GetAll()).Returns(clinics);

            // Act
            var result = _controller.GetAllClinic();

            // Assert
            // check the return type is of the correct type (OKObjectResult)
            var okResult = Assert.IsType<OkObjectResult>(result);
            // check the Value in the result object contains clinics
            Assert.Equal(clinics, okResult.Value);
        }

        [Fact]
        public void GetAllClinic_ReturnsNotFoundResult_WhenNoClinicsExist()
        {
            // Arrange
            // Set up the mock to return null for the clinics
            _mockService.Setup(service => service.GetAll()).Returns((List<Clinic>)null);

            // Act
            var result = _controller.GetAllClinic();

            // Assert
            // Check that the response type is of type NotFoundResult
            Assert.IsType<NotFoundResult>(result);

        }

        [Fact]
        public void CreateClinic_ReturnsOkResult_WhenClinicIsValid()
        {
            // Arrange
            var clinic = new Clinic { Id = 1, ClinicName = "MyClinic" };

            // Act
            var result = _controller.CreateClinic(clinic);

            // Assert
            // check the result type is valid
            var okResult = Assert.IsType<OkObjectResult>(result);
            //Check the value inside okResult is a valid value
            Assert.Equal("Created Successfully", okResult.Value);
            //check that the mock service received a call to Insert with the clinic object - once 
            _mockService.Verify(service => service.Insert(clinic), Times.Once);
        }

        [Fact]
        public void CreateClinic_ReturnsBadRequest_WhenClinicIsNull()
        {
            // Act
            var result = _controller.CreateClinic(null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void UpdateClinic_ReturnsOkResult_WhenClinicIsValid()
        {
            // Arrange
            var clinic = new Clinic { Id = 1 };

            // Act
            var result = _controller.UpdateClinic(clinic);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Updated SuccessFully", okResult.Value);
            _mockService.Verify(service => service.Update(clinic), Times.Once);
        }

        [Fact]
        public void UpdateClinic_ReturnsBadRequest_WhenClinicIsNull()
        {
            // Act
            var result = _controller.UpdateClinic(null);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void DeleteClinic_ReturnsOkResult_WhenClinicIsValid()
        {
            // Arrange
            var clinic = new Clinic { Id = 1 };

            // Act
            var result = _controller.DeleteClinic(clinic);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Deleted Successfully", okResult.Value);
            _mockService.Verify(service => service.Delete(clinic), Times.Once);
        }

        [Fact]
        public void DeleteClinic_ReturnsBadRequest_WhenClinicIsNull()
        {
            // Act
            var result = _controller.DeleteClinic(null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
