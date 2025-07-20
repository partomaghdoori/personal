using System;
using Microsoft.EntityFrameworkCore;

namespace ProductManagement;


public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }

    // Add your DbSets here
    // public DbSet<YourModel> YourModels { get; set; }
}