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

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users
            .Where(a => a.IsDeleted == false)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<User?> GetByIdAsync(int id, bool tracked = false)
    {
        if (tracked)
            return await _context.Users.FindAsync(id);
        
        return await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);
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

    public void Update(User user)
    {
        _context.Users.Update(user);
    }

    public void Remove(User user)
    {
        _context.Users.Remove(user);
    }
}