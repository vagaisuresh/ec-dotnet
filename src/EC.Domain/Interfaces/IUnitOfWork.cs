namespace EC.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IBrandRepository BrandRepository { get; }
    
    /// <summary>
    /// SaveAsync is used to commit changes to the database. It wraps the call to SaveChangesAsync on the database context.
    /// </summary>
    /// <returns></returns>
    Task SaveAsync();

    Task SaveAsync(CancellationToken cancellationToken);
}