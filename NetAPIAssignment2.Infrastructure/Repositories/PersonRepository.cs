using NetAPIAssignment2.Infrastructure.Models;
using NetAPIAssignment2.Shared;

namespace NetAPIAssignment2.Infrastructure.Repositories;

public class PersonRepository : IPersonRepository {
    public static List<Person> people = new List<Person> {
        new Person("Thanh", "Nguyen", new DateOnly(2002, 10, 2), GenderType.Male, "Ha Noi"),
        new Person("Long", "Ta", new DateOnly(2002, 3, 14), GenderType.Male, "Ha Noi"),
        new Person("Linh", "Hoang", new DateOnly(2002, 06, 9), GenderType.Male, "Ha Noi"),
        new Person("Dung", "Dao", new DateOnly(2002, 06, 9), GenderType.Male, "Phu Tho"),
    };
    public IEnumerable<Person> GetAll() {
        return people;
    }
    public Person? Get(Guid id) {
        var selectedPerson = (from person in people
                             where person.Id == id
                             select person).FirstOrDefault();
        return selectedPerson;
    }
    public void Insert(Person person) {
        people.Add(person);
    }
    public bool Update(Person updatedPerson) {
        var selectedPerson = (from person in people
                             where person.Id == updatedPerson.Id
                             select person).FirstOrDefault();
        if (selectedPerson == null) return false;
        selectedPerson.FirstName = updatedPerson.FirstName;
        selectedPerson.LastName = updatedPerson.LastName;
        selectedPerson.Gender = updatedPerson.Gender;
        selectedPerson.DateOfBirth = updatedPerson.DateOfBirth;
        selectedPerson.BirthPlace = updatedPerson.BirthPlace;
        return true;
    }
    public void Delete(Guid id) {
        var selectedPerson = (from person in people
                             where person.Id == id
                             select person).FirstOrDefault();
        if (selectedPerson != null)
            people.Remove(selectedPerson);
    }
}