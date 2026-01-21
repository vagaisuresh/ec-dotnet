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

    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        var users = await _unitOfWork.UserRepository.GetAllAsync();

        var userDtos = users.Select(x => new UserDto
        {
            Id = x.Id,
            FullName = x.FullName,
            EmailAddress = x.EmailAddress,
            RoleId = x.RoleId,
            MobileNumber = x.MobileNumber,
            DateOfBirth = x.DateOfBirth,
            ProfilePicture = x.ProfilePicture,
            IsActive = x.IsActive
        }).ToList();

        return userDtos;
    }

    public async Task<UserDto?> GetByIdAsync(int id)
    {
        var user = await _unitOfWork.UserRepository.GetByIdAsync(id);

        if (user == null)
            return null;

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

    public async Task<UserDto> CreateAsync(UserSaveDto userSaveDto)
    {
        if (await _unitOfWork.UserRepository.GetUserAsync(userSaveDto.EmailAddress) != null)
            throw new DuplicateEmailException(userSaveDto.EmailAddress);
            
        var user = new User
        {
            FullName = userSaveDto.FullName,
            EmailAddress = userSaveDto.EmailAddress,
            PasswordHash = _passwordHasher.Hash(userSaveDto.Password),  // One-way hashing (cannot be reversed)
            RoleId = (UserRole)userSaveDto.RoleId,
            MobileNumber = userSaveDto.MobileNumber,
            DateOfBirth = userSaveDto.DateOfBirth,
            ProfilePicture = userSaveDto.ProfilePicture,
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

    public async Task UpdateAsync(int id, UserUpdateDto userUpdateDto)
    {
        var existingUser = await _unitOfWork.UserRepository.GetByIdAsync(id, true);

        if (existingUser == null)
            throw new InvalidOperationException("User not found.");
        
        existingUser.FullName = userUpdateDto.FullName;
        existingUser.RoleId = (UserRole)userUpdateDto.RoleId;
        existingUser.MobileNumber = userUpdateDto.MobileNumber;
        existingUser.DateOfBirth = userUpdateDto.DateOfBirth;

        try
        {
            _unitOfWork.UserRepository.Update(existingUser);
            await _unitOfWork.SaveAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while updating the User.", ex);
        }
    }

    public async Task DeleteAsync(int id)
    {
        var existingUser = await _unitOfWork.UserRepository.GetByIdAsync(id, true);

        if (existingUser == null)
            throw new InvalidOperationException("User not found.");
        
        try
        {
            _unitOfWork.UserRepository.Remove(existingUser);
            await _unitOfWork.SaveAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while deleting the User.", ex);
        }
    }

    public async Task<UserDto> RegisterAsync(UserRegisterDto userRegisterDto)  // Move to customer service
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