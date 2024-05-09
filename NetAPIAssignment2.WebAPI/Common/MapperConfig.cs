using AutoMapper;
using NetAPIAssignment2.Infrastructure.Models;
using NetAPIAssignment2.Shared;
using NetAPIAssignment2.WebAPI.Models;

namespace NetAPIAssignment2.WebAPI.Common;

public class MapperProfile : Profile {
    public MapperProfile() {
        CreateMap<PersonRequestModel, Person>()
        .ForMember(
            person => person.DateOfBirth,
            opt => opt.MapFrom(request => DateOnly.Parse(request.DateOfBirth)))
        .ForMember(
            person => person.Id,
            opt => opt.MapFrom(request => Guid.NewGuid()))
        .ReverseMap();
        CreateMap<Person, PersonResponseModel>()
        .ReverseMap();
        DisableConstructorMapping();
    }
}