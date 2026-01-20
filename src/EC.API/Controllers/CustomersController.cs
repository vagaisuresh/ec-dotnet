using EC.Application.DTOs;
using EC.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EC.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly IUserService _service;

    public CustomersController(IUserService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterAsync([FromBody] UserRegisterDto userRegisterDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var userDto = await _service.RegisterAsync(userRegisterDto);
        
        return CreatedAtRoute("GetUserById", new { id = userDto.Id }, userDto);
    }
}