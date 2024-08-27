using RepositoryLayer.Data;
using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Data;
using RepositoryLayer.IRepository;
using ServiceLayer.ICustomServices;
namespace OnionArchitectureInAspNetCore6WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitsController : ControllerBase
    {
        private readonly ICustomService<Visit> _customService;
        private readonly ApplicationDbContext _applicationDbContext;
        public VisitsController(ICustomService<Visit>? customService, ApplicationDbContext applicationDbContext)
        {
            _customService = customService;
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet(nameof(GetVisitById))]
        public IActionResult GetVisitById(int Id)
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
        [HttpGet(nameof(GetAllVisit))]
        public IActionResult GetAllVisit()
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
        [HttpPost(nameof(CreateVisit))]
        public IActionResult CreateVisit(Visit visit)
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
        [HttpPost(nameof(UpdateVisit))]
        public IActionResult UpdateVisit(Visit visit)
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
        [HttpDelete(nameof(DeleteVisit))]
        public IActionResult DeleteVisit(Visit visit)
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