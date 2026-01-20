using EC.Domain.Entities;

namespace EC.Domain.Interfaces;

public interface IUserRepository
{
    Task<User?> GetUserAsync(string emailAddress);
    Task AddAsync(User user);
}