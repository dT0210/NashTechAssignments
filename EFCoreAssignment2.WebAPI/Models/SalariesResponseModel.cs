using EFCoreAssignment2.Infrastructure.Models;

namespace EFCoreAssignment2.WebAPI.Models;

public class SalariesResponseModel {
    public Guid EmployeeId {get; set;}
    public int Salary {get; set;}
}