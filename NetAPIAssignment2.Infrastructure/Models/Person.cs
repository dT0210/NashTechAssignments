using NetAPIAssignment2.Shared;

namespace NetAPIAssignment2.Infrastructure.Models;

public class Person {
    public Guid Id {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public DateOnly DateOfBirth {get; set;}
    public GenderType Gender {get; set;}
    public string BirthPlace {get; set;}

    public Person(string firstName, string lastName, DateOnly dateOfBirth, GenderType gender, string birthPlace) {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        Gender = gender;
        BirthPlace = birthPlace;
    }
    public Person(){}
}