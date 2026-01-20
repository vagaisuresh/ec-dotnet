using EC.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EC.Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
    
    public DbSet<Brand> Brands { get; set; }
}