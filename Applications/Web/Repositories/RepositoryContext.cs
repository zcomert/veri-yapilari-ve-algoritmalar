using Libs.Entities;
using Microsoft.EntityFrameworkCore;

namespace Applications.Repositories;

public class RepositoryContext : DbContext
{
    public DbSet<Car> Cars { get; set; }
    public DbSet<Engine> Engine { get; set; }
    public RepositoryContext(DbContextOptions<RepositoryContext> options)
        : base(options)
    {

    }
}