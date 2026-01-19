using EC.Application.DTOs;
using EC.Application.Features.Brands.Commands;
using EC.Application.Interfaces.Common;
using EC.Domain.Entities;
using EC.Domain.Interfaces;

namespace EC.Application.Features.Brands.Handlers;

public class CreateBrandCommandHandler(IUnitOfWork _unitOfWork) 
    : ICommandHandler<CreateBrandCommand, BrandDto>
{
    public async Task<BrandDto> HandleAsync(CreateBrandCommand command, CancellationToken cancellationToken)
    {
        var brand = new Brand
        {
            Name = command.Name,
            Description = command.Description,
            LogoUrl = command.LogoUrl,
            IsActive = true,
            IsDeleted = false,
            CreatedAt = DateTime.UtcNow
        };

        await _unitOfWork.BrandRepository.AddAsync(brand);
        await _unitOfWork.SaveAsync(cancellationToken);

        var brandDto = new BrandDto
        {
            Id = brand.Id,
            Name = brand.Name,
            Description = brand.Description,
            LogoUrl = brand.LogoUrl,
            IsActive = brand.IsActive
        };
        
        return brandDto;
    }
}