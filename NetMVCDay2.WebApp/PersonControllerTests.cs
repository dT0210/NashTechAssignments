using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NetMVCDay2.BusinessLogic;
using NetMVCDay2.Models.Models;
using NetMVCDay2.Shared;
using NetMVCDay2.WebApp.Controllers;

namespace NetMVCDay2.WebApp;

[TestFixture]
public class PersonControllerTests
{   
    private Mock<IPersonBusinessLogic> personService;
    private Mock<ILogger<PersonController>> mockLogger;
    private PersonController personController;

    [SetUp]
    public void Setup()
    {
        personService = new Mock<IPersonBusinessLogic>();
        mockLogger = new Mock<ILogger<PersonController>>();
        personController = new PersonController(mockLogger.Object, personService.Object);
    }

    [TearDown]
    public void TearDown() {
        personController.Dispose();
    }

    [Test]
    public void GetFullNameList_ReturnsViewResult()
    {
        //arrange
        var expected = new List<string> {"Thanh Nguyen", "Long Ta"};
        personService.Setup(s => s.GetFullNameList()).Returns(expected);

        //action
        var result =  personController.GetFullNameList();
        var model = result.Model as List<string>;

        //assert
        Assert.IsInstanceOf<ViewResult>(result);
        Assert.IsNotNull(model);
        Assert.That(model.Count, Is.EqualTo(2));
    }

    [Test]
    public void Index_ReturnViewResult() {
        //arrange
        var expected = new List<Person> {
            new Person {
                Id = Guid.NewGuid(),
                FirstName = "Tien",
                LastName = "Do",
                DateOfBirth = new DateOnly(2002,10,2),
                Gender = GenderType.Female,
                IsGraduated = false
            }
        };

        personService.Setup(s => s.GetPeopleByGender(GenderType.Female)).Returns(expected);

        //action
        var result = personController.Index(null, GenderType.Female);
        var model = result.Model as List<Person>;

        //assert
        Assert.IsInstanceOf<ViewResult>(result);
        Assert.IsNotNull(model);
        Assert.That(model.Count, Is.EqualTo(1));
    }

    [Test]
    public void GetPeopleBasedOnBirthYear_EqualsToNegativeBirthYear_ReturnViewResult() {
        //arrange
        var expected = new List<Person> {};
        personService.Setup(s => s.GetPeopleByYearEqualsTo(-2000)).Returns(expected);

        //action
        var result = personController.GetPeopleBasedOnBirthYear(ComparisonType.Equal, "-2000");
        personService.Verify(s => s.GetPeopleByYearEqualsTo(-2000), Times.Once());
        var model = result.Model as List<Person>;

        //assert
        Assert.IsInstanceOf<ViewResult>(result);
        Assert.IsNotNull(model);
        Assert.That(model.Count, Is.EqualTo(0));
    }

    [Test]
    public void GetPeopleBasedOnBirthYear_GreaterThanNegativeBirthYear_ReturnViewResult() {
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
        personService.Setup(s => s.GetPeopleByYearGreaterThan(-2000)).Returns(expected);

        //action
        var result = personController.GetPeopleBasedOnBirthYear(ComparisonType.Greater, "-2000");
        personService.Verify(s => s.GetPeopleByYearGreaterThan(-2000), Times.Once());
        var model = result.Model as List<Person>;

        //assert
        Assert.IsInstanceOf<ViewResult>(result);
        Assert.IsNotNull(model);
        Assert.That(model.Count, Is.EqualTo(2));
    }

    [Test]
    public void GetPeopleBasedOnBirthYear_LessThanNegativeBirthYear_ReturnViewResult() {
        //arrange
        var expected = new List<Person> {};
        personService.Setup(s => s.GetPeopleByYearLessThan(-2000)).Returns(expected);

        //action
        var result = personController.GetPeopleBasedOnBirthYear(ComparisonType.Less, "-2000");
        personService.Verify(s => s.GetPeopleByYearLessThan(-2000), Times.Once());
        var model = result.Model as List<Person>;

        //assert
        Assert.IsInstanceOf<ViewResult>(result);
        Assert.IsNotNull(model);
        Assert.That(model.Count, Is.EqualTo(0));
    }

    [Test]
    public void ExportPeopleList_ReturnFileResult() {
        //arrange

        //action
        var result = personController.ExportPeopleList();

        //assert
        Assert.IsInstanceOf<FileResult>(result);
    }

    [Test]
    public void GetPersonDetails_InvalidId_ReturnNotFoundView() {
        //arrange
        var testGuid = Guid.NewGuid();
        personService.Setup(s => s.GetPersonById(testGuid)).Returns((Person)null);
        
        //act
        var result = personController.GetPersonDetails(testGuid);

        //assert
        Assert.IsInstanceOf<ViewResult>(result);
        Assert.That(result.ViewName, Is.EqualTo("NotFound"));
    }

    [Test]
    public void AddPerson_InvalidPerson_ReturnAddView() {
        //arrange
        personController.ModelState.AddModelError("Name", "Required");
        var person = new Person {
                Id = Guid.NewGuid(),
                FirstName = "Tien",
                LastName = "Do",
                DateOfBirth = new DateOnly(2002,10,2),
                Gender = GenderType.Female,
                IsGraduated = false
            };
        
        //action
        var result = personController.AddPerson(person);

        //assert
        Assert.IsInstanceOf<ViewResult>(result);
        var viewResult = result as ViewResult;
        Assert.That(viewResult.Model, Is.EqualTo(person));
    }

    [Test]
    public void EditPerson_InvalidId_ReturnNotFoundView() {
        //arrange
        var testGuid = Guid.NewGuid();
        personService.Setup(s => s.GetPersonById(testGuid)).Returns((Person)null);
        
        //act
        var result = personController.EditPerson(testGuid);

        //assert
        Assert.IsInstanceOf<ViewResult>(result);
        Assert.That(result.ViewName, Is.EqualTo("NotFound"));
    }

    [Test]
    public void EditPerson_InvalidPerson_ReturnEditView() {
        //arrange
        personController.ModelState.AddModelError("Name", "Required");
        var person = new Person {
                Id = Guid.NewGuid(),
                FirstName = "Tien",
                LastName = "Do",
                DateOfBirth = new DateOnly(2002,10,2),
                Gender = GenderType.Female,
                IsGraduated = false
            };

        //action
        var result = personController.EditPerson(person);

        //assert
        Assert.IsInstanceOf<ViewResult>(result);
        var viewResult = result as ViewResult;
        Assert.That(viewResult.Model, Is.EqualTo(person));
    }

    [Test]
    public void DeletePerson_InvalidId_ReturnViewWithError() {
        //arrange
        var testGuid = Guid.NewGuid();
        personService.Setup(s => s.GetPersonById(testGuid)).Returns((Person)null);
        
        //action
        var result = personController.DeletePerson(testGuid);

        //assert
        Assert.IsInstanceOf<ViewResult>(result);
        Assert.That(result.ViewName, Is.EqualTo("DeleteConfirmation"));
        Assert.IsNotNull(result.ViewData["DeleteError"]);
        Assert.That(result.ViewData["DeleteError"], Is.EqualTo("Person was not found"));
    }
}