using NetMVCDay1.Models.Models;
using NetMVCDay1.Models.Repositories;

namespace NetMVCDay1.BusinessLogic;

public class PersonBusinessLogic : IPersonBusinessLogic {
    private readonly IPersonRepositories _personRepositories;
    public PersonBusinessLogic(IPersonRepositories personRepositories) {
        _personRepositories = personRepositories;
    }
    public IEnumerable<Person> GetAllPeople() {
        return _personRepositories.GetAllPeople();
    }
    public IEnumerable<Person> GetMalePeople() {
        var malePeople = from person in _personRepositories.GetAllPeople()
                        where person.Gender == GenderType.Male
                        select person;
        return malePeople;
    }
    public Person GetOldestPerson() {
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
}