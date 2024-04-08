using Microsoft.AspNetCore.Mvc;
using SpotifyPrototype.Application.Account;
using SpotifyPrototype.Application.Account.Dto;

namespace SpotifyPrototype.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Create(UserDto dto)
        {
            if (ModelState is { IsValid: false })
                return BadRequest();

            var result = this._userService.Create(dto);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var result = this._userService.Get(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Request.LoginRequest login)
        {
            if (ModelState.IsValid == false)
                return BadRequest();

            var result = this._userService.Authenticate(login.Email, login.Password);

            if (result == null)
            {
                return BadRequest(new
                {
                    Error = "Invalid email or password"
                });
            }

            return Ok(result);

        }
    }

}
