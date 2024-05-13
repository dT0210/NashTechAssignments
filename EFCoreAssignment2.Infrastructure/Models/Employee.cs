using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreAssignment2.Infrastructure.Models;

[Table("Employees")]
public class Employee {
    [Key]
    public Guid Id {get; set;}
    public string Name {get; set;}
    public Guid DepartmentId {get; set;}
    public Department Department {get; set;}
    public DateOnly JoinedDate {get; set;}
    public Salaries Salary {get; set;}
    public ICollection<Project> Projects {get; set;}
}