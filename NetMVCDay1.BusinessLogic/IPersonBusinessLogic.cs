using NetMVCDay1.Models.Models;

namespace NetMVCDay1.BusinessLogic;

public interface IPersonBusinessLogic {
    public IEnumerable<Person> GetAllPeople();
    public IEnumerable<Person> GetMalePeople();
    public Person GetOldestPerson();
    public List<string> GetFullNameList();
    public IEnumerable<Person> GetPeopleByYearEqualsTo(int birthYear);
    public IEnumerable<Person> GetPeopleByYearGreaterThan(int birthYear);
    public IEnumerable<Person> GetPeopleByYearLessThan(int birthYear);
}