using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NetMVCDay1.BusinessLogic;
using NetMVCDay1.Models;
using OfficeOpenXml;

namespace NetMVCDay1.Controllers;
public class PersonController : Controller
{
    private readonly ILogger<PersonController> _logger;
    private readonly IPersonBusinessLogic _personBusinessLogic;

    public PersonController(ILogger<PersonController> logger, IPersonBusinessLogic personBusinessLogic)
    {
        _logger = logger;
        _personBusinessLogic = personBusinessLogic;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public JsonResult GetMaleList() {
        return Json(_personBusinessLogic.GetMalePeople());
    }
    public JsonResult GetOldestPerson() {
        return Json(_personBusinessLogic.GetOldestPerson());
    }
    public JsonResult GetFullNameList() {
        return Json(_personBusinessLogic.GetFullNameList());
    }
    public IActionResult GetPeopleBasedOnBirthYear(string comparison, string year) {
        if (string.IsNullOrEmpty(comparison)) {
            return Json(new { error = "Comparison parameter is missing (equal, greater, less)." });
        }
        
        switch (comparison) {
            case "equal":
                return Redirect($"GetPeopleByYearEqualsTo?year={year}");
            case "greater":
                return Redirect($"GetPeopleByYearGreaterThan?year={year}");
            case "less":
                return Redirect($"GetPeopleByYearLessThan?year={year}");
            default:
                return Json(new { error = "Invalid type parameter (equal, greater, less)." });
        }

    }
    public JsonResult GetPeopleByYearEqualsTo(string year) {
        if (string.IsNullOrWhiteSpace(year)) {
            return Json(new { error = "Year parameter is missing." });
        }
        if (!int.TryParse(year, out int parsedYear)) {
            return Json(new { error = "Invalid year parameter format." });
        }
        var equalsPeople = _personBusinessLogic.GetPeopleByYearEqualsTo(parsedYear);

        return Json(equalsPeople);
    }
    public JsonResult GetPeopleByYearGreaterThan(string year) {
        if (string.IsNullOrWhiteSpace(year)) {
            return Json(new { error = "Year parameter is missing." });
        }
        if (!int.TryParse(year, out int parsedYear)) {
            return Json(new { error = "Invalid year parameter format." });
        }
        var equalsPeople = _personBusinessLogic.GetPeopleByYearGreaterThan(parsedYear);

        return Json(equalsPeople);
    }
    public JsonResult GetPeopleByYearLessThan(string year) {
        if (string.IsNullOrWhiteSpace(year)) {
            return Json(new { error = "Year parameter is missing." });
        }
        if (!int.TryParse(year, out int parsedYear)) {
            return Json(new { error = "Invalid year parameter format." });
        }
        var equalsPeople = _personBusinessLogic.GetPeopleByYearLessThan(parsedYear);

        return Json(equalsPeople);
    }
    public FileResult ExportPeopleList() {
        var peopleList = _personBusinessLogic.GetAllPeople();
        using (var package = new ExcelPackage()) {
            var worksheet = package.Workbook.Worksheets.Add("Persons");

            worksheet.Cells[1,1].Value = "Id";
            worksheet.Cells[1,2].Value = "First Name";
            worksheet.Cells[1,3].Value = "Last Name";
            worksheet.Cells[1,4].Value = "Gender";
            worksheet.Cells[1,5].Value = "Date of Birth";
            worksheet.Cells[1,6].Value = "Phone Number";
            worksheet.Cells[1,7].Value = "Birth Place";
            worksheet.Cells[1,8].Value = "IsGraduated";

            int row = 2;
            foreach(var person in peopleList) {
                worksheet.Cells[row, 1].Value = person.Id;
                worksheet.Cells[row, 2].Value = person.FirstName;
                worksheet.Cells[row, 3].Value = person.LastName;
                worksheet.Cells[row, 4].Value = person.Gender;
                worksheet.Cells[row, 5].Value = person.DateOfBirth.ToShortDateString();
                worksheet.Cells[row, 6].Value = person.PhoneNumber;
                worksheet.Cells[row, 7].Value = person.BirthPlace;
                worksheet.Cells[row, 8].Value = person.IsGraduated ? "Yes" : "No";
                row++;
            }

            byte[] fileContents = package.GetAsByteArray();

            return File(fileContents, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "People.xlsx");
        }
    }
}
