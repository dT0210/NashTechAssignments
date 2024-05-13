using EFCoreAssignment2.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAssignment2.Infrastructure.Repositories;

public class ProjectEmployeeRepository : GenericRepository<Project_Employee>, IProjectEmployeeRepository
{
    public ProjectEmployeeRepository(EFDay2Context dbContext) : base(dbContext)
    {
    }

    public async Task<Project_Employee?> GetAsync(Guid projectId, Guid employeeId)
    {
        var projectEmployee = await _dbContext.Project_Employees.FirstOrDefaultAsync(pe => pe.ProjectId == projectId && pe.EmployeeId == employeeId);
        return projectEmployee;
    }

    public async Task InsertAsync(Guid projectId, Guid employeeId)
    {
        var projectEmployee = new Project_Employee();
        projectEmployee.ProjectId = projectId;
        projectEmployee.EmployeeId = employeeId;
        projectEmployee.Enable = true;
        await _dbContext.AddAsync(projectEmployee);
    }
}