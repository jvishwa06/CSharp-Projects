using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly MongoUserService _mongoUserService;

    public AuthController(MongoUserService mongoUserService)
    {
        _mongoUserService = mongoUserService;
    }

    // POST: api/auth/register
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        if (await _mongoUserService.RegisterUser(request.Username, request.Password))
        {
            return Ok("User registered successfully");
        }
        else
        {
            return BadRequest("Username already exists");
        }
    }

    // POST: api/auth/login
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        if (await _mongoUserService.VerifyUser(request.Username, request.Password))
        {
            return Ok("Login successful");
        }
        else
        {
            return Unauthorized("Invalid credentials");
        }
    }
}

public class RegisterRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}
