using EC.Application.DTOs;

namespace EC.Application.Interfaces;

public interface IUserService
{
    Task<UserDto> RegisterAsync(UserRegisterDto userRegisterDto);
}