using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Data;
using ServiceLayer.ICustomServices;
namespace OnionArchitectureInAspNetCore6WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultsController : ControllerBase
    {
        private readonly ICustomService<Result> _customService;
        private readonly ApplicationDbContext _applicationDbContext;
        public ResultsController(ICustomService<Result> customService, ApplicationDbContext applicationDbContext)
        {
            _customService = customService;
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet(nameof(GetResultById))]
        public IActionResult GetResultById(int Id)
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
        [HttpGet(nameof(GetAllResult))]
        public IActionResult GetAllResult()
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
        [HttpPost(nameof(CreateResult))]
        public IActionResult CreateResult(Result result)
        {
            if (result != null)
            {
                _customService.Insert(result);
                return Ok("Created Successfully");
            }
            else
            {
                return BadRequest("Somethingwent wrong");
            }
        }
        [HttpPost(nameof(UpdateResult))]
        public IActionResult UpdateResult(Result result)
        {
            if (result != null)
            {
                _customService.Update(result);
                return Ok("Updated SuccessFully");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete(nameof(DeleteResult))]
        public IActionResult DeleteResult(Result result)
        {
            if (result != null)
            {
                _customService.Delete(result);
                return Ok("Deleted Successfully");
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }
    }
}