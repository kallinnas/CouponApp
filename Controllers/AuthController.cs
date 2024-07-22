using CouponApp.Service;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserService _userService;

    public AuthController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateUser([FromBody] UserCreateRequest request)
    {
        try
        {
            await _userService.CreateUserAsync(request.Email, request.Password, request.Role);
            return Ok("New user inserted successfully!");
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    public class UserCreateRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty ;
        public int Role { get; set; }
    }
}