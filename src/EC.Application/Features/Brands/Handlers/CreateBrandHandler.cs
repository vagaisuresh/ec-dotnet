using EC.Application.DTOs;
using EC.Application.Features.Brands.Commands;
using EC.Application.Interfaces;

namespace EC.Application.Features.Brands.Handlers;

public class CreateBrandHandler : ICommandHandler<CreateBrandCommand, BrandDto>
{
    public Task<BrandDto> HandleAsync(CreateBrandCommand command)
    {
        throw new NotImplementedException();
    }
}