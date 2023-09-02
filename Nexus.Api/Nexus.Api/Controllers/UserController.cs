using Microsoft.AspNetCore.Mvc;
using Nexus.Api.Domain.Entities;
using Nexus.Api.Domain.Interfaces;

namespace Nexus.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet(Name = "GetUsers")]
        public async Task<List<User>> GetAllUsers()
        {
            return await _userService.GetAllUsers();
        }


        [HttpPost(Name = "PostUser")]
        public async Task<User> CreateUser(User user)
        {
            return await _userService.CreateUser(user);
        }
    }
}