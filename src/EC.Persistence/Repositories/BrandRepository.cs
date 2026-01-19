using EC.Domain.Entities;
using EC.Domain.Interfaces;
using EC.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EC.Persistence.Repositories;

public class BrandRepository : RepositoryBase, IBrandRepository
{
    public BrandRepository(AppDbContext context) 
        : base(context)
    {
    }

    public async Task<IEnumerable<Brand>> GetAllAsync()
    {
        return await _context.Brands
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Brand?> GetByIdAsync(short id, bool tracked = false)
    {
        if (tracked)
            return await _context.Brands.FindAsync(id);
        
        return await _context.Brands
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task AddAsync(Brand brand)
    {
        await _context.Brands.AddAsync(brand);
    }

    public void Update(Brand brand)
    {
        _context.Brands.Update(brand);
    }

    public void Remove(Brand brand)
    {
        _context.Brands.Remove(brand);
    }
}