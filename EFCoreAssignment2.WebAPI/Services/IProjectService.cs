using EFCoreAssignment2.Infrastructure.Models;
using EFCoreAssignment2.WebAPI.Models;

namespace EFCoreAssignment2.WebAPI.Services;

public interface IProjectService {
    Task<IEnumerable<ProjectResponseModel>> GetAllProjectsAsync();
    Task<ProjectResponseModel?> GetProjectByIdAsync(Guid id);
    Task<Project> InsertProjectAsync(ProjectRequestModel project);
    Task UpdateProjectAsync(Guid id, ProjectRequestModel project);
    Task DeleteProjectAsync(Guid id);
    Task AddEmployeeToProject(Guid projectId, Guid employeeId);
    Task RemoveEmployeeFromProject(Guid projectId, Guid employeeId);
}