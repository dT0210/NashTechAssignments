using NetMVCDay1.Models.Models;

namespace NetMVCDay1.Models.Repositories;

public interface IPersonRepositories {
    public IEnumerable<Person> GetAllPeople();

    public Person GetPersonById(Guid id);

    public void AddPerson(Person person);

    public void UpdatePerson(Person person);

    public void DeletePerson(Person person);
}