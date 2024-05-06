namespace NetMVCDay1.Models.Models;

public class Person {
    public Guid Id {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public GenderType Gender {get; set;}
    public DateTime DateOfBirth {get; set;}
    public string PhoneNumber {get; set;}
    public string BirthPlace {get; set;}
    public bool IsGraduated {get; set;}
    public Person(Guid id, string firstName, string lastName, GenderType gender, DateTime dateOfBirth, string phoneNumber, string birthPlace, bool isGraduated) {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        BirthPlace = birthPlace;
        IsGraduated = isGraduated;
    }
}