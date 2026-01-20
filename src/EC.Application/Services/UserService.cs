using EC.Application.DTOs;
using EC.Application.Interfaces;
using EC.Application.Interfaces.Common;
using EC.Domain.Entities;
using EC.Domain.Enums;
using EC.Domain.Exceptions;
using EC.Domain.Interfaces;

namespace EC.Application.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher _passwordHasher;

    public UserService(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher)
    {
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
    }

    public async Task<UserDto> RegisterAsync(UserRegisterDto userRegisterDto)
    {
        if (await _unitOfWork.UserRepository.GetUserAsync(userRegisterDto.EmailAddress) != null)
            throw new DuplicateEmailException(userRegisterDto.EmailAddress);
            
        var user = new User
        {
            FullName = userRegisterDto.FullName,
            EmailAddress = userRegisterDto.EmailAddress,
            PasswordHash = _passwordHasher.Hash(userRegisterDto.Password),  // One-way hashing (cannot be reversed)
            RoleId = UserRole.Customer,                                     // Customer - directly assigned
            MobileNumber = userRegisterDto.MobileNumber,
            DateOfBirth = userRegisterDto.DateOfBirth,
            ProfilePicture = userRegisterDto.ProfilePicture,
            IsActive = true,
            IsDeleted = false,
            CreatedBy = null,
            CreatedAt = DateTime.UtcNow
        };

        await _unitOfWork.UserRepository.AddAsync(user);
        await _unitOfWork.SaveAsync();

        return new UserDto
        {
            Id = user.Id,
            FullName = user.FullName,
            EmailAddress = user.EmailAddress,
            RoleId = user.RoleId,
            MobileNumber = user.MobileNumber,
            DateOfBirth = user.DateOfBirth,
            ProfilePicture = user.ProfilePicture,
            IsActive = user.IsActive
        };
    }
}