using NetMVCDay1.Models.Models;

namespace NetMVCDay1.Models.Repositories;

public class PersonRepositories : IPersonRepositories {
    private List<Person> peopleList;
    public PersonRepositories() {
        peopleList = new List<Person>{
            new Person(Guid.NewGuid(), "Thanh", "Nguyen", GenderType.Male, new DateTime(2002, 10, 02), "0123456789", "", false),
            new Person(Guid.NewGuid(), "Minh", "Pham", GenderType.Male, new DateTime(2002, 10, 03), "0123456789", "", true),
            new Person(Guid.NewGuid(), "Long", "Ta", GenderType.Male, new DateTime(2002, 03, 14), "0123456789", "", true),
            new Person(Guid.NewGuid(), "Stephen", "Curry", GenderType.Male, new DateTime(1988, 01, 01), "0123456789", "", true),
            new Person(Guid.NewGuid(), "Phuong", "Nguyen", GenderType.Female, new DateTime(1992, 07, 22), "0123456789", "", true),
            new Person(Guid.NewGuid(), "Viet", "Vo", GenderType.Male, new DateTime(2000, 07, 22), "0123456789", "", true)
        };
    }
    public IEnumerable<Person> GetAllPeople() {
        return peopleList;
    }

    public Person GetPersonById(Guid id) {
        var selectedPerson = (from person in peopleList
                          where person.Id == id
                          select person).FirstOrDefault();
        return selectedPerson;
    }

    public void AddPerson(Person person) {
        peopleList.Add(person);
    }

    public void UpdatePerson(Person updatedPerson) {
        var personToUpdate = (from person in peopleList
                          where person.Id == updatedPerson.Id
                          select person).FirstOrDefault();
        
        if (personToUpdate != null) {
            personToUpdate.FirstName = updatedPerson.FirstName;
            personToUpdate.LastName = updatedPerson.LastName;
            personToUpdate.Gender = updatedPerson.Gender;
            personToUpdate.DateOfBirth = updatedPerson.DateOfBirth;
            personToUpdate.PhoneNumber = updatedPerson.PhoneNumber;
            personToUpdate.BirthPlace = updatedPerson.BirthPlace;
            personToUpdate.IsGraduated = updatedPerson.IsGraduated;
        }
    }

    public void DeletePerson(Person person) {
        peopleList.Remove(person);
    }
}