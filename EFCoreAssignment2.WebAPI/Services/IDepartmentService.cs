using EFCoreAssignment2.Infrastructure.Models;
using EFCoreAssignment2.WebAPI.Models;

namespace EFCoreAssignment2.WebAPI.Services;

public interface IDepartmentService {
    Task<IEnumerable<DepartmentResponseModel>> GetAllDepartmentsAsync();
    Task<DepartmentResponseModel?> GetDepartmentByIdAsync(Guid id);
    Task<Department> InsertDepartmentAsync(DepartmentRequestModel department);
    Task UpdateDepartmentAsync(Guid id, DepartmentRequestModel department);
    Task DeleteDepartmentAsync(Guid id);
}