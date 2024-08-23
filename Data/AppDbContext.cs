using Microsoft.EntityFrameworkCore;
using WebAppMvc.Models;

namespace WebAppMvc.Data;

public class AppDbContext : DbContext
{
    public AppDbContext (DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Department> Department { get; set; } 
    public DbSet<Seller> Seller { get; set; }
    public DbSet<SalesRecord> Sales {  get; set; }


}
