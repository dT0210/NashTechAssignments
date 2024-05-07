using NetMVCDay2.Models.Models;
using NetMVCDay2.Models.Repositories;
using NetMVCDay2.Shared;

namespace NetMVCDay2.BusinessLogic;

public class PersonBusinessLogic : IPersonBusinessLogic {
    private readonly IPersonRepositories _personRepositories;
    public PersonBusinessLogic(IPersonRepositories personRepositories) {
        _personRepositories = personRepositories;
    }
    public IEnumerable<Person> GetAllPeople() {
        return _personRepositories.GetAllPeople();
    }
    public IEnumerable<Person> GetPeopleByGender(GenderType gender) {
        var malePeople = from person in _personRepositories.GetAllPeople()
                        where person.Gender == gender
                        select person;
        return malePeople;
    }
    public Person? GetOldestPerson() {
        Person? oldest = _personRepositories.GetAllPeople().MinBy(person => person.DateOfBirth);
        return oldest;
    }
    public List<string> GetFullNameList() {
        List<string> fullNameList = new List<string>();
        foreach (Person person in _personRepositories.GetAllPeople()) {
            fullNameList.Add($"{person.FirstName} {person.LastName}");
        }
        return fullNameList;
    }

    public IEnumerable<Person> GetPeopleByYearEqualsTo(int birthYear) {
        var equalPeople = from person in _personRepositories.GetAllPeople()
                          where person.DateOfBirth.Year == birthYear
                          select person;
        return equalPeople;
    }
    public IEnumerable<Person> GetPeopleByYearGreaterThan(int birthYear) {
        var greaterPeople = from person in _personRepositories.GetAllPeople()
                          where person.DateOfBirth.Year > birthYear
                          select person;
        return greaterPeople;
    }
    public IEnumerable<Person> GetPeopleByYearLessThan(int birthYear) {
        var lessPeople = from person in _personRepositories.GetAllPeople()
                          where person.DateOfBirth.Year < birthYear
                          select person;
        return lessPeople;
    }
    public void AddPerson(Person person) {
        _personRepositories.AddPerson(person);
    }
    public void UpdatePerson(Person person) {
        _personRepositories.UpdatePerson(person);
    }
    public Person? GetPersonById(Guid id) {
        return _personRepositories.GetPersonById(id);
    }
    public void DeletePerson(Person person) {
        _personRepositories.DeletePerson(person);
    }
}