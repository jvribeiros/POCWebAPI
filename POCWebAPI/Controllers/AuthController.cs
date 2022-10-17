using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POCWebAPI.Domain.Models;
using POCWebAPI.Domain.Interfaces;

namespace POCWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }   
    }
}
