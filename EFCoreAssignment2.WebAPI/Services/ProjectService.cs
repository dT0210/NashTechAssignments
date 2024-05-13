using AutoMapper;
using EFCoreAssignment2.Infrastructure.Models;
using EFCoreAssignment2.Infrastructure.Repositories;
using EFCoreAssignment2.WebAPI.Models;

namespace EFCoreAssignment2.WebAPI.Services;

public class ProjectService : IProjectService {
    private readonly IGenericRepository<Project> _projectRepository;
    private readonly IProjectEmployeeRepository _projectEmployeeRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;
    public ProjectService(IGenericRepository<Project> projectRepository, IProjectEmployeeRepository projectEmployeeRepository, 
                            IEmployeeRepository employeeRepository, IMapper mapper) {
        _projectRepository = projectRepository;
        _projectEmployeeRepository = projectEmployeeRepository;
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProjectResponseModel>> GetAllProjectsAsync()
    {
        var projects = await _projectRepository.GetAllAsync();
        return projects.Select(_mapper.Map<ProjectResponseModel>);
    }

    public async Task<ProjectResponseModel?> GetProjectByIdAsync(Guid id)
    {
        var project = await _projectRepository.GetByIdAsync(id);
        return _mapper.Map<ProjectResponseModel>(project);
    }

    public async Task<Project> InsertProjectAsync(ProjectRequestModel project)
    {
        var newProject = _mapper.Map<Project>(project);
        await _projectRepository.InsertAsync(newProject);
        await _projectRepository.SaveAsync();
        return newProject;
    }

    public async Task UpdateProjectAsync(Guid id, ProjectRequestModel project)
    {
        var newProject = _mapper.Map<Project>(project);
        newProject.Id = id;
        _projectRepository.Update(newProject);
        await _projectRepository.SaveAsync();
    }

    public async Task DeleteProjectAsync(Guid id)
    {
        await _projectRepository.DeleteAsync(id);
        await _projectRepository.SaveAsync();
    }

    public async Task AddEmployeeToProject(Guid projectId, Guid employeeId) {
        var project = await _projectRepository.GetByIdAsync(projectId) ?? throw new ArgumentException("Project doesn't exist.");
        var employee = await _employeeRepository.GetByIdAsync(employeeId) ?? throw new ArgumentException("Employee doesn't exist.");
        var projectEmployee = await _projectEmployeeRepository.GetAsync(projectId, employeeId);
        if (projectEmployee != null) {
            if (projectEmployee.Enable) throw new ArgumentException("Employee is already in project.");
            projectEmployee.Enable = true;
            _projectEmployeeRepository.Update(projectEmployee);
            await _projectEmployeeRepository.SaveAsync();
            return;
        }
        await _projectEmployeeRepository.InsertAsync(projectId, employeeId);
        await _projectRepository.SaveAsync();
    }

    public async Task RemoveEmployeeFromProject(Guid projectId, Guid employeeId) {
        var projectEmployee = await _projectEmployeeRepository.GetAsync(projectId, employeeId) ?? throw new ArgumentException("Employee is not in project.");
        projectEmployee.Enable = false;
        _projectEmployeeRepository.Update(projectEmployee);
        await _projectEmployeeRepository.SaveAsync();
    }
}