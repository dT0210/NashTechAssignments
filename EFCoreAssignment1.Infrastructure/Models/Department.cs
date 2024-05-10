using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreAssignment1.Infrastructure.Models;

[Table("Departments")]
public class Department {
    [Key]
    public Guid Id {get; set;}
    [Column("Name")]
    public string Name {get; set;}
    public ICollection<Employee> Employees {get; set;}
}