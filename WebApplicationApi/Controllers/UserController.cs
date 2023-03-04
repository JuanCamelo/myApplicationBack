using ApplicationServices.DTOs.Models;
using ApplicationServices.Services.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace WebApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserApplicationServices _userApplicationServices;

        public UserController(IUserApplicationServices userApplicationServices)
        {
            _userApplicationServices = userApplicationServices;
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetUserAsync([FromQuery] UserFilters filters)
        {
            try
            {
                var result = await _userApplicationServices.GetUserAsync(filters);
                return new ObjectResult(result) { StatusCode = StatusCodes.Status200OK };
            }
            catch (Exception ex)
            {
                return new ConflictObjectResult(ex) { StatusCode = StatusCodes.Status409Conflict };
            }
        }

        [HttpPost("user")]
        public async Task<IActionResult> PostUserAsync([FromBody] UserModel filters)
        {
            try
            {
                var result = await _userApplicationServices.PostUserAsync(filters);
                return new ObjectResult(result) { StatusCode = StatusCodes.Status201Created };
            }
            catch (Exception ex)
            {
                return new ConflictObjectResult(ex) { StatusCode = StatusCodes.Status409Conflict };
            }
        }

        [HttpPut("user/{id}")]
        public async Task<IActionResult> GetByIdUserAsync(string id)
        {
            try
            {
                var result = await _userApplicationServices.GetByIdUserAsync(id);
                return new ObjectResult(result) { StatusCode = StatusCodes.Status200OK };
            }
            catch (Exception ex)
            {
                return new ConflictObjectResult(ex) { StatusCode = StatusCodes.Status409Conflict };
            }
        }
    }
}
