namespace NetAPIAssignment2.WebAPI.Models;

public class PersonResponseModel {
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string Gender {get; set;}
    public DateOnly DateOfBirth {get; set;}
    public string BirthPlace {get; set;}
    public PersonResponseModel(string firstName, string lastName, DateOnly dateOfBirth, string gender, string birthPlace) {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        Gender = gender;
        BirthPlace = birthPlace;
    }
    public PersonResponseModel(){}
}