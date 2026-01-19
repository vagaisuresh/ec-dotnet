using EC.Application.Features.Brands.Commands;
using EC.Application.Features.Brands.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace EC.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BrandsController : ControllerBase
{
    private readonly CreateBrandCommandHandler _handler;

    public BrandsController(CreateBrandCommandHandler handler)
    {
        _handler = handler;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] CreateBrandCommand command)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var createdBrand = await _handler.HandleAsync(command, CancellationToken.None);

        if (createdBrand is null)
            return BadRequest("Brand creation failed.");
        
        return CreatedAtRoute("GetBrandById", new { id = createdBrand.Id }, createdBrand);
    }
}