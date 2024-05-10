using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreAssignment1.Infrastructure.Models;

public class Project_Employee {
    public Guid ProjectId {get; set;}
    public Project Project {get; set;}
    public Guid EmployeeId {get; set;}
    public Employee Employee {get; set;}
    public bool Enable {get; set;}
}