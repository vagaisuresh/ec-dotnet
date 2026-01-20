using EC.Domain.Entities;

namespace EC.Application.Interfaces.Auth;

public interface IJwtTokenService
{
    string GenerateJwtToken(User user);
}