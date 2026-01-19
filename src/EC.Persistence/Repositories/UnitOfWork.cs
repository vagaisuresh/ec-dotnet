using EC.Domain.Interfaces;
using EC.Persistence.Context;

namespace EC.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    private IBrandRepository _brandRepository;

    public UnitOfWork(AppDbContext context,
        IBrandRepository brandRepository)
    {
        _context = context;
        _brandRepository = brandRepository;
    }

    public IBrandRepository BrandRepository => _brandRepository;

    public async Task SaveAsync()
    {
        await SaveAsync(CancellationToken.None);
    }
    
    public async Task SaveAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Dispose of the resources
    /// </summary>
    public void Dispose()
    {
        _context.Dispose();
    }
}