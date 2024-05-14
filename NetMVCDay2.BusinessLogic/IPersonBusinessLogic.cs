using NetMVCDay2.Models.Models;
using NetMVCDay2.Shared;

namespace NetMVCDay2.BusinessLogic;

public interface IPersonBusinessLogic {
    public Person? GetPersonById(Guid id);
    public void AddPerson(Person person);
    public void UpdatePerson(Person person);
    public void DeletePerson(Person person);
    public IEnumerable<Person> GetAllPeople();
    public IEnumerable<Person> GetPeopleByGender(GenderType gender);
    public Person? GetOldestPerson();
    public List<string> GetFullNameList();
    public IEnumerable<Person> GetPeopleByYearEqualsTo(int birthYear);
    public IEnumerable<Person> GetPeopleByYearGreaterThan(int birthYear);
    public IEnumerable<Person> GetPeopleByYearLessThan(int birthYear);
    
}