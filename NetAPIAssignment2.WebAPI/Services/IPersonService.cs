using NetAPIAssignment2.Infrastructure.Models;
using NetAPIAssignment2.Shared;
using NetAPIAssignment2.WebAPI.Models;

namespace NetAPIAssignment2.WebAPI.Services;

public interface IPersonService {
    public IEnumerable<PersonResponseModel> GetAllPeople(string? firstName, string? lastName, GenderType? gender, string? birthPlace);
    public PersonResponseModel? GetPerson(Guid id);
    public void AddPerson(Person person);
    public Person AddPerson(PersonRequestModel person);
    public bool UpdatePerson(Person person);
    public bool UpdatePerson(Guid id, PersonRequestModel person);
    public void DeletePerson(Guid id);
}