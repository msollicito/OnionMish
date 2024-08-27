using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Data;
using ServiceLayer.ICustomServices;
namespace OnionArchitectureInAspNetCore6WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicsController : ControllerBase
    {
        private readonly ICustomService<Clinic> _customService;
        private readonly ApplicationDbContext _applicationDbContext;
        public ClinicsController(ICustomService<Clinic> customService, ApplicationDbContext applicationDbContext)
        {
            _customService = customService;
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet(nameof(GetClinicById))]
        public IActionResult GetClinicById(int Id)
        {
            var obj = _customService.Get(Id);
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(obj);
            }
        }
        [HttpGet(nameof(GetAllClinic))]
        public IActionResult GetAllClinic()
        {
            var obj = _customService.GetAll();
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(obj);
            }
        }
        [HttpPost(nameof(CreateClinic))]
        public IActionResult CreateClinic(Clinic visit)
        {
            if (visit != null)
            {
                _customService.Insert(visit);
                return Ok("Created Successfully");
            }
            else
            {
                return BadRequest("Somethingwent wrong");
            }
        }
        [HttpPost(nameof(UpdateClinic))]
        public IActionResult UpdateClinic(Clinic visit)
        {
            if (visit != null)
            {
                _customService.Update(visit);
                return Ok("Updated SuccessFully");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete(nameof(DeleteClinic))]
        public IActionResult DeleteClinic(Clinic visit)
        {
            if (visit != null)
            {
                _customService.Delete(visit);
                return Ok("Deleted Successfully");
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }
    }
}