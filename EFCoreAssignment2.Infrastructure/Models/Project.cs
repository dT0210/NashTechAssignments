using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreAssignment2.Infrastructure.Models;

[Table("Projects")]
public class Project {
    [Key]
    public Guid Id {get; set;}
    [Required]
    public string Name {get; set;}
    public ICollection<Employee> Employees {get; set;}
}