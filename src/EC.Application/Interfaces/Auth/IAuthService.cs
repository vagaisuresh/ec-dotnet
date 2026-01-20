using EC.Application.DTOs;
using EC.Application.DTOs.Result;

namespace EC.Application.Interfaces.Auth;

public interface IAuthService
{
    Task<LoginResult> LoginAsync(LoginRequest loginRequest);
}