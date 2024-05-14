using System.Text.Json;
using NetMVCDay2.Models.Models;
using NetMVCDay2.Shared;

namespace NetMVCDay2.Models.Repositories;

public class PersonRepositories : IPersonRepositories {
    private List<Person> peopleList;
    
    public PersonRepositories() {
        ReadFromFile();
    }
    private void ReadFromFile() {
        string directoryPath = $"{Environment.CurrentDirectory}/Data";
        string fileName = "PeopleData.json";
        var json = File.ReadAllText(Path.Combine(directoryPath, fileName));
        peopleList = JsonSerializer.Deserialize<List<Person>>(json);
    }
    private void WriteToFile() {
        string directoryPath = $"{Environment.CurrentDirectory}/Data";
        string fileName = "PeopleData.json";
        string json = JsonSerializer.Serialize(peopleList);
        File.WriteAllText(Path.Combine(directoryPath, fileName), json);
    }
    public IEnumerable<Person> GetAllPeople() {
        return peopleList;
    }

    public Person? GetPersonById(Guid id) {
        var selectedPerson = (from person in peopleList
                          where person.Id == id
                          select person).FirstOrDefault();
        return selectedPerson;
    }

    public void AddPerson(Person person) {
        peopleList.Add(person);
        WriteToFile();
    }

    public void UpdatePerson(Person updatedPerson) {
        var personToUpdate = (from person in peopleList
                          where person.Id == updatedPerson.Id
                          select person).FirstOrDefault();
        
        if (personToUpdate == null) {
            return ;
        }
        personToUpdate.FirstName = updatedPerson.FirstName;
        personToUpdate.LastName = updatedPerson.LastName;
        personToUpdate.Gender = updatedPerson.Gender;
        personToUpdate.DateOfBirth = updatedPerson.DateOfBirth;
        personToUpdate.PhoneNumber = updatedPerson.PhoneNumber;
        personToUpdate.BirthPlace = updatedPerson.BirthPlace;
        personToUpdate.IsGraduated = updatedPerson.IsGraduated;
        WriteToFile();
    }

    public void DeletePerson(Person person) {
        peopleList.Remove(person);
        WriteToFile();
    }

    public void DeletePerson(Guid id) {
        var selectedPerson = (from person in peopleList
                          where person.Id == id
                          select person).FirstOrDefault();
        if (selectedPerson != null) 
            peopleList.Remove(selectedPerson);
    }
}