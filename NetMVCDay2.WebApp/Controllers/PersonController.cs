using Microsoft.AspNetCore.Mvc;
using NetMVCDay2.BusinessLogic;
using OfficeOpenXml;
using NetMVCDay2.Shared;
using Microsoft.AspNetCore.Mvc.Rendering;
using NetMVCDay2.Models.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Reflection;
using System.Text.Json;
using NetMVCDay2.WebApp.Models;
using Microsoft.Extensions.Logging;

namespace NetMVCDay2.WebApp.Controllers;

public class PersonController : Controller {
    private readonly ILogger<PersonController> _logger;
    private readonly IPersonBusinessLogic _personBusinessLogic;
    public PersonController(ILogger<PersonController> logger, IPersonBusinessLogic personBusinessLogic) {
        _logger = logger;
        _personBusinessLogic = personBusinessLogic;
    }
    //this is to list all gender types on dropdown list
    private void GenderDropDown() {
        var genderList = Enum.GetValues(typeof(GenderType))
                         .Cast<GenderType>()
                         .Select(g => new SelectListItem {
                            Value = ((int)g).ToString(),
                            Text = g.ToString()
                         });
        ViewBag.Gender = new SelectList(genderList, "Value", "Text");
    }
    [HttpGet]
    public ViewResult Index(SortByType? sortBy, GenderType? gender) {
        GenderDropDown();

        //this is to list "Sort by" options on dropdown list
        var sortByList = Enum.GetValues(typeof(SortByType))
                         .Cast<SortByType>()
                         .Select(s => new SelectListItem {
                            Value = s.ToString(),
                            Text = s.ToString()
                         });
        ViewBag.SortBy = new SelectList(sortByList, "Value", "Text");
        
        //filter people by gender
        IEnumerable<Person> peopleList;
        if (gender != null) {
            peopleList = _personBusinessLogic.GetPeopleByGender((GenderType)gender);
        } else {
            peopleList = _personBusinessLogic.GetAllPeople();
        }

        //sort people by age
        if (sortBy != null) {
            if (sortBy == SortByType.Ascending)
                peopleList = peopleList.OrderByDescending(person => person.DateOfBirth);
            else if (sortBy == SortByType.Descending)
                peopleList = peopleList.OrderBy(person => person.DateOfBirth);
        } 

        return View(peopleList);
    }
    public ViewResult GetFullNameList() {
        return View("FullNameList", _personBusinessLogic.GetFullNameList());
    }
    public ViewResult GetPeopleBasedOnBirthYear(ComparisonType? comparison, string? birthYear) {
        if (string.IsNullOrWhiteSpace(birthYear) || !int.TryParse(birthYear, out int parsedYear)) {
            return View("BirthYearBasedList", _personBusinessLogic.GetAllPeople());
        }
        IEnumerable<Person> peopleList;
        switch (comparison) {
            case ComparisonType.Equal:
                peopleList = _personBusinessLogic.GetPeopleByYearEqualsTo(parsedYear);
                break;
            case ComparisonType.Greater:
                peopleList = _personBusinessLogic.GetPeopleByYearGreaterThan(parsedYear);
                break;
            case ComparisonType.Less:
                peopleList = _personBusinessLogic.GetPeopleByYearLessThan(parsedYear);
                break;
            default:
                peopleList = _personBusinessLogic.GetAllPeople();
                break;
        }
        return View("BirthYearBasedList", peopleList);
    }
    public FileResult ExportPeopleList() {
        var peopleList = _personBusinessLogic.GetAllPeople();
        using (var package = new ExcelPackage()) {
            var worksheet = package.Workbook.Worksheets.Add("Persons");

            worksheet.Cells[1,1].Value = "First Name";
            worksheet.Cells[1,2].Value = "Last Name";
            worksheet.Cells[1,3].Value = "Gender";
            worksheet.Cells[1,4].Value = "Date of Birth";
            worksheet.Cells[1,5].Value = "Phone Number";
            worksheet.Cells[1,6].Value = "Birth Place";
            worksheet.Cells[1,7].Value = "IsGraduated";

            int row = 2;
            foreach(var person in peopleList) {
                worksheet.Cells[row, 1].Value = person.FirstName;
                worksheet.Cells[row, 2].Value = person.LastName;
                worksheet.Cells[row, 3].Value = person.Gender;
                worksheet.Cells[row, 4].Value = person.DateOfBirth.ToShortDateString();
                worksheet.Cells[row, 5].Value = person.PhoneNumber;
                worksheet.Cells[row, 6].Value = person.BirthPlace;
                worksheet.Cells[row, 7].Value = person.IsGraduated ? "Yes" : "No";
                row++;
            }

            byte[] fileContents = package.GetAsByteArray();

            return File(fileContents, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "People.xlsx");
        }
    }
    [HttpGet]
    public ViewResult GetPersonDetails(Guid id) {
        Person? person = _personBusinessLogic.GetPersonById(id);
        if (person == null)
            return View("NotFound");
        return View("PersonDetails", person);
    }

    [HttpGet]
    public ViewResult AddPerson() {
        GenderDropDown();
        return View(new Person());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult AddPerson(Person person) {
        GenderDropDown();
        if (ModelState.IsValid) {
            _personBusinessLogic.AddPerson(person);
            return RedirectToAction("Index", "Person");
        }
        return View(person);
    }
    [HttpGet]
    public ViewResult EditPerson(Guid id) {
        GenderDropDown();
        Person? person = _personBusinessLogic.GetPersonById(id);
        if (person == null)
            return View("NotFound");
        return View(person);
    }
    [HttpPost]
    public ActionResult EditPerson(Person person) {
        GenderDropDown();
        if (ModelState.IsValid) {
            _personBusinessLogic.UpdatePerson(person);
            return RedirectToAction("Index", "Person");
        }
        return View(person);
    }
    [HttpPost]
    public ViewResult DeletePerson(Guid id) {
        try {
            var person = _personBusinessLogic.GetPersonById(id) ?? throw new Exception("Person was not found");
            _personBusinessLogic.DeletePerson(person);
            ViewBag.DeleteMessage = $"Person {person.FirstName} {person.LastName} was removed from the list successfully!";
        } catch (Exception ex) {
            ViewBag.DeleteError = ex.Message.ToString();
        }
        
        return View("DeleteConfirmation");
    }
}