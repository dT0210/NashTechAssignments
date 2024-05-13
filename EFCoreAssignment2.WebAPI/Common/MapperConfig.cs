using AutoMapper;
using EFCoreAssignment2.Infrastructure.Models;
using EFCoreAssignment2.WebAPI.Models;

namespace EFCoreAssignment2.WebAPI.Common;

public class MapperProfile : Profile {
    public MapperProfile() {
        CreateMap<Employee, EmployeeResponseModel>();
        
        CreateMap<EmployeeRequestModel, Employee>()
        .ForMember(
            employee => employee.Id,
            opt => opt.MapFrom(request => Guid.NewGuid())
        )
        .ForMember(
            employee => employee.JoinedDate,
            opt => opt.MapFrom(request => DateOnly.Parse(request.JoinedDate))
        );

        CreateMap<DepartmentRequestModel, Department>()
        .ForMember(
            department => department.Id,
            opt => opt.MapFrom(request => Guid.NewGuid())
        );

        CreateMap<Department, DepartmentResponseModel>();

        CreateMap<Salaries, SalariesResponseModel>();

        CreateMap<SalariesRequestModel, Salaries>();
        
        CreateMap<Project, ProjectResponseModel>();

        CreateMap<ProjectRequestModel, Project>();
    }
}