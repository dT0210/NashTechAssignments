using EFCoreAssignment2.Infrastructure.Models;
using EFCoreAssignment2.WebAPI.Models;

namespace EFCoreAssignment2.WebAPI.Services;

public interface IEmployeeService {
    Task<IEnumerable<EmployeeResponseModel>> GetAllEmployeesAsync();
    Task<IEnumerable<EmployeeResponseModel2>> GetAllEmployeesWithDepartmentAsync();
    Task<IEnumerable<EmployeeResponseModel3>> GetAllEmployeesWithProjectsAsync();
    Task<IEnumerable<EmployeeResponseModel>> GetEmployeesWithQueryAsync();
    Task<EmployeeResponseModel?> GetEmployeeByIdAsync(Guid id);
    Task<Employee> InsertEmployeeAsync(EmployeeRequestModel employee);
    Task UpdateEmployeeAsync(Guid id, EmployeeRequestModel employee);
    Task DeleteEmployeeAsync(Guid id);
}