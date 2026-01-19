using EC.Domain.Entities;

namespace EC.Domain.Interfaces;

public interface IBrandRepository
{
    Task<IEnumerable<Brand>> GetAllAsync();
    Task<Brand?> GetByIdAsync(short id, bool tracked = false);
    Task AddAsync(Brand brand);
    void Update(Brand brand);
    void Remove(Brand brand);
}