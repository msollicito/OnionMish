using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OnionMish.Controllers;
using RepositoryLayer.Data;
using ServiceLayer.ICustomServices;
using System;
using System.Threading.Tasks;
using Xunit;

namespace XunitTestProject1.Controllers
{
    public class PatientControllerTests
    {
        
        private readonly Mock<ICustomService<Patient>> _mockService;
        private readonly PatientController _controller;
        private readonly Mock<ApplicationDbContext> _mockApplicationDbContext;

        public PatientControllerTests()
        {
            //setup controller!!
            //setup the mocks of the objects that will be needed for the tests and send them into the controller object
            _mockService = new Mock<ICustomService<Patient>>();
            _mockApplicationDbContext = new Mock<ApplicationDbContext>();
            _controller = new PatientController(_mockService.Object, _mockApplicationDbContext.Object);
        }

        private PatientController CreatePatientController()
        {
            return new PatientController( this._mockService.Object,
                this._mockApplicationDbContext.Object);
        }

        

        [Fact]
        public async Task Details_GetForNullId_ExpectedBehavior()
        {
            // Arrange
            var patientController = this.CreatePatientController();
            int? id = null;

            // Act
            var result = await patientController.Details(
                id);

            // Assert
            Assert.IsType<NotFoundResult>(result);

        }

        //[Fact]
        //public async Task Details_StateUnderTest_FailWrongType()
        //{
        //    // Arrange
        //    var patientController = this.CreatePatientController();
        //    int? id = null;

        //    // Act
        //    var result = await patientController.Details(
        //        id);

        //    // Assert
        //    Assert.IsType<NotFoundObjectResult>(result);

        //}

        [Fact]
        public void Create_CreateController_ExpectedBehavior()
        {
            //This test just checks that when you create a patientController there are no exceptions etc.
            // Arrange
            var patientController = this.CreatePatientController();

            // Act
            var result = patientController.Create();

            // Assert
            Assert.True(true);
            
        }

        [Fact]
        public async Task Create_NullPatient_ExpectedBehavior1()
        {
            // This test checks that when you create a controller and send in a null patient
            // the response type is redirect to an actionresult 
            // and it redirects to Index (actionname)
            // Arrange
            var patientController = this.CreatePatientController();
            Patient? patient = null;

            // Act
            var result = await patientController.Create(
                patient);

            // Assert
            Assert.IsType<RedirectToActionResult>(result);
            RedirectToActionResult res = (RedirectToActionResult)result;
            Assert.True(res?.ActionName?.ToString().Equals("Index"));
            
        }

        [Fact]
        public async Task Edit_NullPatient_ExpectedBehavior()
        {
            // Arrange
            var patientController = this.CreatePatientController();
            int? id = null;

            // Act
            var result = await patientController.Edit(
                id);


            // Assert
            Assert.IsType<NotFoundResult>(result);
        
        }

        [Fact]
        public async Task Edit_ValidPatient_ExpectedBehavior()
        {
            // Arrange
            Patient patient = new Patient();
            patient.Id = 1;
            patient.Name = "Fred";
            _mockApplicationDbContext.Setup(appdb=>appdb.FindAsync<Patient>(1)).Returns(Task.FromResult(patient));
            
            var patientController = this.CreatePatientController();
            int? id = 1;
            
            // Act
            var result = await patientController.Edit(
                id);


            // Assert
            Assert.IsType<OkObjectResult>(result);
            OkObjectResult res = (OkObjectResult)result;

            Assert.Equal(patient, res.Value);

        }
        [Fact]
        public async Task Edit_ThrowsExceptionIfId0AndPatientNull_ExpectedBehavior1()
        {
            // Arrange
            var patientController = this.CreatePatientController();
            int id = 0;
            Patient? patient = null;

            // Act
            Exception value = await Assert.ThrowsAsync<System.NullReferenceException>( async () => 
            {
                var result = await patientController.Edit(
                id,
                patient);
            });

            

            // Assert
            Assert.Equal("Object reference not set to an instance of an object.", value?.Message);
        
        }


    }
}
