using EFCoreAssignment2.Infrastructure.Models;

namespace EFCoreAssignment2.WebAPI.Models;

public class EmployeeResponseModel3 {
    public string Name {get; set;}
    public DateOnly JoinedDate {get; set;}
    public IEnumerable<ProjectResponseModel>? Projects {get; set;}
}