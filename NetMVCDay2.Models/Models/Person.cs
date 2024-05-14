using System.ComponentModel.DataAnnotations;
using NetMVCDay2.Shared;

namespace NetMVCDay2.Models.Models;

public class Person {
    public Guid Id {get; set;}
    [Required]
    public string FirstName {get; set;}
    [Required]
    public string LastName {get; set;}
    [Required]
    public GenderType Gender {get; set;}
    [Required]
    [DataType(DataType.Date)]
    public DateOnly DateOfBirth {get; set;}
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits.")]
    public string? PhoneNumber {get; set;}
    public string? BirthPlace {get; set;}
    public bool IsGraduated {get; set;}
    public Person() {
        Id = Guid.NewGuid();
    }
    public Person(Guid id, string firstName, string lastName, GenderType gender, DateOnly dateOfBirth, string phoneNumber, string birthPlace, bool isGraduated) {
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