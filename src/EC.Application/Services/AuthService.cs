using EC.Application.DTOs;
using EC.Application.DTOs.Result;
using EC.Application.Interfaces.Auth;
using EC.Application.Interfaces.Common;
using EC.Domain.Interfaces;

namespace EC.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJwtTokenService _jwtTokenService;
    private readonly IPasswordHasher _passwordHasher;

    public AuthService(IUnitOfWork unitOfWork, IJwtTokenService jwtTokenService, IPasswordHasher passwordHasher)
    {
        _unitOfWork = unitOfWork;
        _jwtTokenService = jwtTokenService;
        _passwordHasher = passwordHasher;
    }

    public async Task<LoginResult> LoginAsync(LoginRequest loginRequest)
    {
        var user = await _unitOfWork.UserRepository
            .GetUserAsync(loginRequest.EmailAddress);
        
        const string invalidMessage = "Invalid email or password.";

        if (user is null)
            return LoginResult.Failure(invalidMessage);
        
        if (!user.IsActive || user.IsDeleted)
            return LoginResult.Failure(invalidMessage);

        if (_passwordHasher.Verify(loginRequest.Password, user.PasswordHash) == false)
            return LoginResult.Failure(invalidMessage);

        return LoginResult.Ok(_jwtTokenService.GenerateJwtToken(user));
    }
}