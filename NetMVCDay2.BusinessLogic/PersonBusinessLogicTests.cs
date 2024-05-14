using Moq;
using NetMVCDay2.Models.Models;
using NetMVCDay2.Models.Repositories;
using NetMVCDay2.Shared;

namespace NetMVCDay2.BusinessLogic;

public class PersonBusinessLogicTests
{
    private Mock<IPersonRepositories> personRepository;
    private PersonBusinessLogic personBusinessLogic;
    [SetUp]
    public void Setup()
    {
        personRepository = new Mock<IPersonRepositories>();
        personBusinessLogic = new PersonBusinessLogic(personRepository.Object);
    }

    [Test]
    public void GetAllPeople_ReturnListPerson()
    {
        //arrange
        var expected = new List<Person> {
            new Person {
                Id = Guid.NewGuid(),
                FirstName = "Tien",
                LastName = "Do",
                DateOfBirth = new DateOnly(2002,10,2),
                Gender = GenderType.Female,
                IsGraduated = false
            }, 
            new Person {
                Id = Guid.NewGuid(),
                FirstName = "Thanh",
                LastName = "Nguyen",
                DateOfBirth = new DateOnly(2002,10,2),
                Gender = GenderType.Female,
                IsGraduated = false
            }, 
        };
        personRepository.Setup(r => r.GetAllPeople()).Returns(expected);

        //act
        var result = personBusinessLogic.GetAllPeople();

        //assert
        Assert.That(result.Count(), Is.EqualTo(2));
    }

    [Test]
    public void GetPeopleByGender_InputFemaleGender_ReturnFilteredListPerson()
    {
        //arrange
        var expected = new List<Person> {
            new Person {
                Id = Guid.NewGuid(),
                FirstName = "Tien",
                LastName = "Do",
                DateOfBirth = new DateOnly(2002,10,2),
                Gender = GenderType.Female,
                IsGraduated = false
            }, 
            new Person {
                Id = Guid.NewGuid(),
                FirstName = "Thanh",
                LastName = "Nguyen",
                DateOfBirth = new DateOnly(2002,10,2),
                Gender = GenderType.Male,
                IsGraduated = false
            }, 
        };
        personRepository.Setup(r => r.GetAllPeople()).Returns(expected);

        //act
        var result = personBusinessLogic.GetPeopleByGender(GenderType.Female);

        //assert
        Assert.That(result, Is.EqualTo(new List<Person>{expected[0]}));
    }

    [Test]
    public void GetOldestPerson_ReturnNull()
    {
        //arrange
        var expected = new List<Person> {};
        personRepository.Setup(r => r.GetAllPeople()).Returns(expected);

        //act
        var result = personBusinessLogic.GetOldestPerson();

        //assert
        Assert.That(result, Is.Null);
    }

    [Test]
    public void GetOldestPerson_ReturnPerson()
    {
        //arrange
        var expected = new List<Person> {
            new Person {
                Id = Guid.NewGuid(),
                FirstName = "Tien",
                LastName = "Do",
                DateOfBirth = new DateOnly(2002,10,2),
                Gender = GenderType.Female,
                IsGraduated = false
            }, 
            new Person {
                Id = Guid.NewGuid(),
                FirstName = "Thanh",
                LastName = "Nguyen",
                DateOfBirth = new DateOnly(1990,10,2),
                Gender = GenderType.Male,
                IsGraduated = false
            }, 
        };
        personRepository.Setup(r => r.GetAllPeople()).Returns(expected);

        //act
        var result = personBusinessLogic.GetOldestPerson();

        //assert
        Assert.That(result, Is.EqualTo(expected[1]));
    }

    [Test]
    public void GetFullNameList_ReturnListString() {
        //arrange
        var expected = new List<Person> {
            new Person {
                Id = Guid.NewGuid(),
                FirstName = "Tien",
                LastName = "Do",
                DateOfBirth = new DateOnly(2002,10,2),
                Gender = GenderType.Female,
                IsGraduated = false
            }, 
            new Person {
                Id = Guid.NewGuid(),
                FirstName = "Thanh",
                LastName = "Nguyen",
                DateOfBirth = new DateOnly(1990,10,2),
                Gender = GenderType.Male,
                IsGraduated = false
            }, 
        };
        personRepository.Setup(r => r.GetAllPeople()).Returns(expected);

        //act
        var result = personBusinessLogic.GetFullNameList();

        //assert
        Assert.That(result.Count(), Is.EqualTo(2));
        Assert.That(result, Is.InstanceOf<List<string>>());
    }

    [Test]
    public void GetPeopleByYearEqualsTo_InputNegative_ReturnEmptyList() {
        //arrange
        var expected = new List<Person> {
            new Person {
                Id = Guid.NewGuid(),
                FirstName = "Tien",
                LastName = "Do",
                DateOfBirth = new DateOnly(2002,10,2),
                Gender = GenderType.Female,
                IsGraduated = false
            }, 
            new Person {
                Id = Guid.NewGuid(),
                FirstName = "Thanh",
                LastName = "Nguyen",
                DateOfBirth = new DateOnly(1990,10,2),
                Gender = GenderType.Male,
                IsGraduated = false
            }, 
        };
        personRepository.Setup(r => r.GetAllPeople()).Returns(expected);

        //act
        var result = personBusinessLogic.GetPeopleByYearEqualsTo(-2000);

        //assert
        Assert.That(result.Count(), Is.EqualTo(0));
        Assert.That(result, Is.InstanceOf<List<Person>>());
    }

    [Test]
    public void GetPeopleByYearGreaterThan_InputNegative_ReturnAllPerson() {
        //arrange
        var expected = new List<Person> {
            new Person {
                Id = Guid.NewGuid(),
                FirstName = "Tien",
                LastName = "Do",
                DateOfBirth = new DateOnly(2002,10,2),
                Gender = GenderType.Female,
                IsGraduated = false
            }, 
            new Person {
                Id = Guid.NewGuid(),
                FirstName = "Thanh",
                LastName = "Nguyen",
                DateOfBirth = new DateOnly(1990,10,2),
                Gender = GenderType.Male,
                IsGraduated = false
            }, 
        };
        personRepository.Setup(r => r.GetAllPeople()).Returns(expected);

        //act
        var result = personBusinessLogic.GetPeopleByYearGreaterThan(-2000);

        //assert
        Assert.That(result.Count(), Is.EqualTo(2));
        Assert.That(result, Is.InstanceOf<List<Person>>());
    }

    [Test]
    public void GetPeopleByYearLessThan_InputNegative_ReturnEmptyList() {
        //arrange
        var expected = new List<Person> {
            new Person {
                Id = Guid.NewGuid(),
                FirstName = "Tien",
                LastName = "Do",
                DateOfBirth = new DateOnly(2002,10,2),
                Gender = GenderType.Female,
                IsGraduated = false
            }, 
            new Person {
                Id = Guid.NewGuid(),
                FirstName = "Thanh",
                LastName = "Nguyen",
                DateOfBirth = new DateOnly(1990,10,2),
                Gender = GenderType.Male,
                IsGraduated = false
            }, 
        };
        personRepository.Setup(r => r.GetAllPeople()).Returns(expected);

        //act
        var result = personBusinessLogic.GetPeopleByYearLessThan(-2000);

        //assert
        Assert.That(result.Count(), Is.EqualTo(0));
        Assert.That(result, Is.InstanceOf<List<Person>>());
    }

    [Test]
    public void GetPersonById_InvalidId_ReturnNull() {
        //arrange
        Guid testGuid = Guid.NewGuid();
        personRepository.Setup(r => r.GetPersonById(testGuid)).Returns((Person)null);

        //act
        var result = personBusinessLogic.GetPersonById(testGuid);

        //assert
        Assert.That(result, Is.Null);
    }
}