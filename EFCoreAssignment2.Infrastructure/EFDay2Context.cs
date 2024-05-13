using EFCoreAssignment2.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAssignment2.Infrastructure;

public class EFDay2Context : DbContext {
    public DbSet<Department> Departments {get; set;}
    public DbSet<Employee> Employees {get; set;}
    public DbSet<Project> Projects {get; set;}
    public DbSet<Salaries> Salaries {get; set;}
    public DbSet<Project_Employee> Project_Employees {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Salary)
            .WithOne(s => s.Employee)
            .HasForeignKey<Salaries>(s => s.EmployeeId);
        
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Department)
            .WithMany(d => d.Employees)
            .HasForeignKey(e => e.DepartmentId);

        modelBuilder.Entity<Employee>()
            .HasMany(e => e.Projects)
            .WithMany(p => p.Employees);
        modelBuilder.Entity<Project_Employee>().HasKey(pe => new { pe.EmployeeId, pe.ProjectId});

        modelBuilder.Entity<Department>().HasData(
            new { Id = Guid.NewGuid(), Name = "Software Development"},
            new { Id = Guid.NewGuid(), Name = "Finance"},
            new { Id = Guid.NewGuid(), Name = "Accountant"},
            new { Id = Guid.NewGuid(), Name = "HR"}
        );
    }

    public EFDay2Context(DbContextOptions<EFDay2Context> options) : base(options)
    {
    }
}
