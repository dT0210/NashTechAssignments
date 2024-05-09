using NetAPIAssignment2.Infrastructure.Models;

namespace NetAPIAssignment2.Infrastructure.Repositories;

public interface IPersonRepository {
    public IEnumerable<Person> GetAll();
    public Person? Get(Guid id);
    public void Insert(Person person);
    public bool Update(Person person);
    public void Delete(Guid id);
}