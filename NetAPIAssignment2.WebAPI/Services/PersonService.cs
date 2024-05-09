using AutoMapper;
using NetAPIAssignment2.Infrastructure.Models;
using NetAPIAssignment2.Infrastructure.Repositories;
using NetAPIAssignment2.Shared;
using NetAPIAssignment2.WebAPI.Common;
using NetAPIAssignment2.WebAPI.Models;

namespace NetAPIAssignment2.WebAPI.Services;

public class PersonService : IPersonService {
    private readonly IPersonRepository _personRepository;
    private readonly IMapper _mapper;
    public PersonService(IPersonRepository personRepository, IMapper mapper) {
        _personRepository = personRepository;
        _mapper = mapper;
    }
    public IEnumerable<PersonResponseModel> GetAllPeople(string? firstName, string? lastName, GenderType? gender, string? birthPlace) {
        var people = _personRepository.GetAll();
        if (!string.IsNullOrWhiteSpace(firstName)) {
            people = from person in people
                     where person.FirstName.ToLower().Equals(firstName.ToLower())
                     select person;
        }
        if (!string.IsNullOrWhiteSpace(lastName)) {
            people = from person in people
                     where person.LastName.ToLower().Equals(lastName.ToLower())
                     select person;
        }
        if (!string.IsNullOrWhiteSpace(birthPlace)) {
            people = from person in people
                     where person.BirthPlace.ToLower().Equals(Uri.UnescapeDataString(birthPlace).Trim().ToLower())
                     select person;
        }
        if (gender != null) {
            people = from person in people
                     where person.Gender == gender
                     select person;
        }
        var response = people.Select(_mapper.Map<PersonResponseModel>);
        
        return response;
    }
    public PersonResponseModel? GetPerson(Guid id) {
        var person = _personRepository.Get(id);
        var response = _mapper.Map<PersonResponseModel>(person);
        return response;
    }
    public void AddPerson(Person person) {
        _personRepository.Insert(person);
    }

    public Person AddPerson(PersonRequestModel person) {
        var newPerson = _mapper.Map<Person>(person);
        _personRepository.Insert(newPerson);
        return newPerson;
    }
    
    public bool UpdatePerson(Person person) {
        return _personRepository.Update(person);
    }
    public bool UpdatePerson(Guid id, PersonRequestModel updatedPerson) {
        var newPerson = _mapper.Map<Person>(updatedPerson);
        newPerson.Id = id;
        return _personRepository.Update(newPerson);
    }
    public void DeletePerson(Guid id) {
        _personRepository.Delete(id);
    }
}