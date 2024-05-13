using AutoMapper;
using EFCoreAssignment2.Infrastructure.Models;
using EFCoreAssignment2.Infrastructure.Repositories;
using EFCoreAssignment2.WebAPI.Common;
using EFCoreAssignment2.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAssignment2.WebAPI.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IGenericRepository<Department> _departmentRepository;
    private readonly IProjectEmployeeRepository _projectEmployeeRepository;
    private readonly IGenericRepository<Project> _projectRepository;
    private readonly IGenericRepository<Salaries> _salariesRepository;
    private readonly IMapper _mapper;
    public EmployeeService(IEmployeeRepository employeeRepository, 
                            IGenericRepository<Department> departmentRepository,
                            IProjectEmployeeRepository projectEmployeeRepository,
                            IGenericRepository<Project> projectRepository,
                            IGenericRepository<Salaries> salariesRepository,
                            IMapper mapper) {
        _employeeRepository = employeeRepository;
        _departmentRepository = departmentRepository;
        _projectEmployeeRepository = projectEmployeeRepository;
        _projectRepository = projectRepository;
        _salariesRepository = salariesRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EmployeeResponseModel>> GetAllEmployeesAsync()
    {
        var employees = await _employeeRepository.GetAllAsync();
        return employees.Select(_mapper.Map<EmployeeResponseModel>);
    }

    public async Task<EmployeeResponseModel?> GetEmployeeByIdAsync(Guid id)
    {
        var employee = await _employeeRepository.GetByIdAsync(id);
        return _mapper.Map<EmployeeResponseModel>(employee);
    }

    public async Task<Employee> InsertEmployeeAsync(EmployeeRequestModel employee)
    {
        var newEmployee = _mapper.Map<Employee>(employee);
        await _employeeRepository.InsertAsync(newEmployee);
        await _employeeRepository.SaveAsync();
        return newEmployee;
    }

    public async Task UpdateEmployeeAsync(Guid id, EmployeeRequestModel employee)
    {
        var updatedEmployee = _mapper.Map<Employee>(employee);
        updatedEmployee.Id = id;
        _employeeRepository.Update(updatedEmployee);
        await _employeeRepository.SaveAsync();
    }

    public async Task DeleteEmployeeAsync(Guid id)
    {
        await _employeeRepository.DeleteAsync(id);
        await _employeeRepository.SaveAsync();
    }

    public async Task<IEnumerable<EmployeeResponseModel2>> GetAllEmployeesWithDepartmentAsync()
    {
        var employees = from employee in _employeeRepository.GetAllQueryable()
                        join department in _departmentRepository.GetAllQueryable()
                        on employee.DepartmentId equals department.Id
                        select new EmployeeResponseModel2 {
                            Name = employee.Name,
                            JoinedDate = employee.JoinedDate,
                            DepartmentName = department.Name
                        };
        return await employees.ToListAsync();
    }

    public async Task<IEnumerable<EmployeeResponseModel3>> GetAllEmployeesWithProjectsAsync()
    {
        var employees = from employee in _employeeRepository.GetAllQueryable()
                        join pe in _projectEmployeeRepository.GetAllQueryable()
                        on employee.Id equals pe.EmployeeId
                        into employeeProjectsGroup
                        select new EmployeeResponseModel3
                        {
                            Name = employee.Name,
                            JoinedDate = employee.JoinedDate,
                            Projects = from pe in employeeProjectsGroup
                                        join project in _projectRepository.GetAllQueryable()
                                        on pe.ProjectId equals project.Id
                                        select _mapper.Map<ProjectResponseModel>(project)
                        };
        return await employees.ToListAsync();
    }

    public async Task<IEnumerable<EmployeeResponseModel>> GetEmployeesWithQueryAsync() {
        var employees = from employee in _employeeRepository.GetAllQueryable()
                        join salary in _salariesRepository.GetAllQueryable()
                        on employee.Id equals salary.EmployeeId
                        where salary.Salary > 100 && employee.JoinedDate > new DateOnly(2024, 1, 1)
                        select _mapper.Map<EmployeeResponseModel>(employee);
        return await employees.ToListAsync();
    }
}