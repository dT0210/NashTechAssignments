using EFCoreAssignment2.Infrastructure.Models;

namespace EFCoreAssignment2.Infrastructure.Repositories;

public interface IProjectEmployeeRepository :IGenericRepository<Project_Employee> {
    Task<Project_Employee?> GetAsync(Guid projectId, Guid employeeId);
    Task InsertAsync(Guid projectId, Guid employeeId);
}