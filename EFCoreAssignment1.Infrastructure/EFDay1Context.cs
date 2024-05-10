using EFCoreAssignment1.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAssignment1.Infrastructure;

public class EFDay1Context : DbContext {
    public DbSet<Department> Departments {get; set;}
    public DbSet<Employee> Employees {get; set;}
    public DbSet<Project> Projects {get; set;}
    public DbSet<Salaries> Salaries {get; set;}
    public DbSet<Project_Employee> Project_Employees {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=.\SQLEXPRESS;
              Database=EFCoreAssignment1;
              User Id=dthanh;
              password=123456;
              Trusted_Connection=False;
              Integrated Security=True;
              TrustServerCertificate=True"
        );
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
}
