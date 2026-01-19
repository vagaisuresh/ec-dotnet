using EC.Application.DTOs;
using EC.Application.Interfaces.Common;

namespace EC.Application.Features.Brands.Commands;

public class CreateBrandCommand : ICommand<BrandDto>
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? LogoUrl { get; set; }
}