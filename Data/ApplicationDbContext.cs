using IMS.Models;
using Microsoft.EntityFrameworkCore;

namespace IMS.Data;
//dotnet add package Microsoft.EntityFrameworkCore --version 9.0.0 install
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Product { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Supplier> Supplier { get; set; }
}
