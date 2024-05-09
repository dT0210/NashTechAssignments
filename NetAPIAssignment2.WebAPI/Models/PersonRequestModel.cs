using System.ComponentModel.DataAnnotations;
using NetAPIAssignment2.Shared;

namespace NetAPIAssignment2.WebAPI.Models;

public class PersonRequestModel {
    [Required]
    public string FirstName {get; set;}

    [Required]
    public string LastName {get; set;}

    [Required]
    public GenderType Gender {get; set;}

    [Required]
    //the date string have to look like this 2002-12-31, the month is 01-12 and day is 01-31
    [RegularExpression(@"^\d{4}-(0[1-9]|1[0-2])-(0[1-9]|[12][0-9]|3[01])$")] 
    public string DateOfBirth {get; set;}

    [Required]
    public string BirthPlace {get; set;}

    public PersonRequestModel(string firstName, string lastName, string dateOfBirth, GenderType gender, string birthPlace) {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        Gender = gender;
        BirthPlace = birthPlace;
    }
    public PersonRequestModel(){}
}