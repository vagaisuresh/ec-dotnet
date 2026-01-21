using EC.Application.DTOs;
using EC.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EC.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _service;

    public UsersController(IUserService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var userDtos = await _service.GetAllAsync();
            return Ok(userDtos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error. {ex.Message}");
        }
    }

    [HttpGet("{id}", Name = "GetUser")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        if (id <= 0)
            return BadRequest("Invalid user id provided.");
        
        try
        {
            var userDto = await _service.GetByIdAsync(id);

            if (userDto is null)
                return NotFound();
            
            return Ok(userDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error. {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] UserSaveDto userSaveDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        try
        {
            var userDto = await _service.CreateAsync(userSaveDto);

            if (userDto == null)
                return NotFound();
            
            return CreatedAtRoute("GetUser", new { id = userDto.Id }, userDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error. {ex.Message}");
        }
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] UserUpdateDto userUpdateDto)
    {
        if (id <= 0)
            return BadRequest("Invalid user id provided.");
        
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        try
        {
            await _service.UpdateAsync(id, userUpdateDto);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error. {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        if (id <= 0)
            return BadRequest("Invalid user id provided.");
        
        try
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error. {ex.Message}");
        }
    }
}