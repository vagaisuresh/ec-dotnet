using EC.Application.DTOs;
using EC.Application.Interfaces.Auth;
using Microsoft.AspNetCore.Mvc;

namespace EC.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginRequest loginRequest)
    {
        var result = await _authService.LoginAsync(loginRequest);

        if (!result.Success)
            return Unauthorized(new { error = result.Error });
        
        return Ok(new { accessToken = result.Token, tokenType = "Bearer" });
    }
}