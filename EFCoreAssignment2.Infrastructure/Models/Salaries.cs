using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreAssignment2.Infrastructure.Models;

[Table("Salaries")]
public class Salaries {
    [Key]
    public Guid Id {get; set;}
    public Guid EmployeeId {get; set;}
    public int Salary {get; set;}
    public Employee Employee {get; set;}
}