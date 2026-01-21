using EC.Domain.Entities;

namespace EC.Domain.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> GetByIdAsync(int id, bool tracked = false);
    Task<User?> GetUserAsync(string emailAddress);
    Task AddAsync(User user);
    void Update(User user);
    void Remove(User user);
}