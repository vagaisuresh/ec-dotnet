using EC.Application.DTOs;

namespace EC.Application.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllAsync();
    Task<UserDto?> GetByIdAsync(int id);
    Task<UserDto> CreateAsync(UserSaveDto userSaveDto);
    Task UpdateAsync(int id, UserUpdateDto userUpdateDto);
    Task DeleteAsync(int id);

    Task<UserDto> RegisterAsync(UserRegisterDto userRegisterDto); // Move to customer service
}