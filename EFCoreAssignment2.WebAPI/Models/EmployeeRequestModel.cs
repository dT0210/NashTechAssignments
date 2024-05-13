using System.ComponentModel.DataAnnotations;

namespace EFCoreAssignment2.WebAPI.Models;

public class EmployeeRequestModel {
    [Required]
    public string Name {get; set;}
    public Guid DepartmentId {get; set;}
    [RegularExpression(@"^\d{4}-(0[1-9]|1[0-2])-(0[1-9]|[12][0-9]|3[01])$")]
    public string JoinedDate {get; set;}
}