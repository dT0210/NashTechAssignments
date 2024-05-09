using System.Net;
using Microsoft.AspNetCore.Mvc;
using NetAPIAssignment2.Infrastructure.Models;
using NetAPIAssignment2.Shared;
using NetAPIAssignment2.WebAPI.Models;
using NetAPIAssignment2.WebAPI.Services;

namespace NetAPIAssignment2.WebAPI.Controllers;

[ApiController]
[Route("/persons")]
public class PersonController : ControllerBase {
    private readonly ILogger<PersonController> _logger;
    private readonly IPersonService _personService;
    public PersonController(ILogger<PersonController> logger, IPersonService personService) {
        _logger = logger;
        _personService = personService;
    }
    [HttpGet]
    public IActionResult GetAll(string? firstName, string? lastName, GenderType? gender, string? birthPlace) {
        try {
            return Ok(_personService.GetAllPeople(firstName, lastName, gender, birthPlace));
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, "Trouble retrieving records.");
        }
        
    }
    [HttpGet]
    [Route("{id}")]
    public IActionResult GetPerson(Guid id) {
        try {
            var person = _personService.GetPerson(id);
            if (person == null) {
                return Ok("Person not found");
            }
            return Ok(person);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, "Trouble retrieving record.");
        }
        
    }
    [HttpPost]
    public IActionResult AddPerson([FromBody]PersonRequestModel person) {
        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }
        if (string.IsNullOrWhiteSpace(person.FirstName) || string.IsNullOrWhiteSpace(person.LastName)) {
            return BadRequest("Name can't be empty");
        }
        if (string.IsNullOrWhiteSpace(person.BirthPlace)) {
            return BadRequest("Birth place can't be empty");
        }
        try {
            Person newPerson = _personService.AddPerson(person);
            return CreatedAtAction(nameof(GetPerson), new {id = newPerson.Id}, newPerson);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, "Trouble inserting a new record.");
        }
    }
    [HttpPut]
    [Route("{id}")]
    public IActionResult UpdatePerson(Guid id, [FromBody]PersonRequestModel person) {
        try {
            if (_personService.UpdatePerson(id, person)) {
                return Ok("Person has been updated.");
            } else {
                return BadRequest("Person with this id was not found.");
            }
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, "Trouble updating a record");
        }
    }
    [HttpDelete]
    [Route("{id}")]
    public IActionResult DeletePerson(Guid id) {
        try {
            _personService.DeletePerson(id);
            return Ok("Person has been deleted.");
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}