using FinalExam.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinalExam.DAL.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Doctors> Doctors { get; set; }
    public DbSet<Departments> Departments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}