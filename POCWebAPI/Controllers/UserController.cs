using Microsoft.AspNetCore.Mvc;
using POCWebAPI.Domain.Entities;
using POCWebAPI.Domain.Interfaces;

namespace POCWebAPI.Controllers
{
    public class HttpResponseModel
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService UserService)
        {
            userService = UserService;
        }

        [HttpGet("GetUser")]
        public IActionResult GetUser([FromQuery] int userId)
        {
            try
            {
                User user = userService.Get(userId);
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

        [HttpGet("RegisterUser")]
        public IActionResult RegisterUser([FromQuery] User newUser)
        {
            try
            {
                User user = userService.Create(newUser);
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

        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser([FromQuery] int userId)
        {
            try
            {
                userService.Delete(userId);
                return Ok(new User());
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
