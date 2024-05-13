using AutoMapper;
using EFCoreAssignment2.Infrastructure.Models;
using EFCoreAssignment2.Infrastructure.Repositories;
using EFCoreAssignment2.WebAPI.Models;

namespace EFCoreAssignment2.WebAPI.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IGenericRepository<Department> _departmentRepository;
    private readonly IMapper _mapper;
    public DepartmentService(IGenericRepository<Department> departmentRepository, IMapper mapper) {
        _departmentRepository = departmentRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DepartmentResponseModel>> GetAllDepartmentsAsync()
    {
        var departments = await _departmentRepository.GetAllAsync();
        return departments.Select(_mapper.Map<Department, DepartmentResponseModel>);
    }

    public async Task<DepartmentResponseModel?> GetDepartmentByIdAsync(Guid id)
    {
        var department = await _departmentRepository.GetByIdAsync(id);
        return _mapper.Map<DepartmentResponseModel>(department);
    }

    public async Task<Department> InsertDepartmentAsync(DepartmentRequestModel department)
    {
        var newDepartment = _mapper.Map<Department>(department);
        await _departmentRepository.InsertAsync(newDepartment);
        await _departmentRepository.SaveAsync();
        return newDepartment;
    }

    public async Task UpdateDepartmentAsync(Guid id, DepartmentRequestModel department)
    {
        var updatedDepartment = _mapper.Map<Department>(department);
        updatedDepartment.Id = id;
        _departmentRepository.Update(updatedDepartment);
        await _departmentRepository.SaveAsync();
    }

    public async Task DeleteDepartmentAsync(Guid id)
    {
        await _departmentRepository.DeleteAsync(id);
        await _departmentRepository.SaveAsync();
    }
}