using EC.Domain.Entities;
using EC.Domain.Interfaces;
using EC.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EC.Persistence.Repositories;

public class UserRepository : RepositoryBase, IUserRepository
{
    public UserRepository(AppDbContext context)
        : base(context)
    {
    }

    public async Task<User?> GetUserAsync(string emailAddress)
    {
        return await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.EmailAddress == emailAddress);
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }
}