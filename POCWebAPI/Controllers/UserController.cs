using Microsoft.AspNetCore.Mvc;
using POCWebAPI.Domain.Entities;
using POCWebAPI.Domain.Interfaces.Services;
using POCWebAPI.Domain.Models;

namespace POCWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService UserService)
        {
            userService = UserService;
        }

        [HttpGet("Authenticate")]
        public async Task<IActionResult> Authenticate(string username, string password)
        {
            try
            {
                User user = await userService.Authenticate(username, password);
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(new HttpResponseModel()
                {
                    Message = e.Message
                });
            }
        }

        [HttpGet("GetUser/{userId}")]
        public async Task<IActionResult> GetUser(int userId)
        {
            try
            {
                User user = await userService.Get(userId);
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(new HttpResponseModel()
                {
                    Message = e.Message
                });
            }
        }

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser(User newUser)
        {
            try
            {
                User user = await userService.Create(newUser);
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(new HttpResponseModel()
                {
                    Code = 0,
                    Message = e.Message
                });
            }
        }
    }
}
