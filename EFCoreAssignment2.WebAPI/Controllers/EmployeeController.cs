using EFCoreAssignment2.WebAPI.Models;
using EFCoreAssignment2.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreAssignment2.WebAPI.Controllers;

[ApiController]
[Route("employees")]
public class EmployeeController : ControllerBase {
    private readonly ILogger<EmployeeController> _logger;
    private readonly IEmployeeService _employeeService;
    public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeService) {
        _logger = logger;
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() {
        try {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return Ok(employees);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, "Trouble retrieving records");
        }
        
    }

    [HttpGet]
    [Route("with-department")]
    public async Task<IActionResult> GetAllWithDepartment() {
        try {
            var employees = await _employeeService.GetAllEmployeesWithDepartmentAsync();
            return Ok(employees);
        } catch (Exception ex) {
            Console.WriteLine(ex);
            return StatusCode(StatusCodes.Status500InternalServerError, "Trouble retrieving records");
        }
    }

    [HttpGet]
    [Route("with-projects")]
    public async Task<IActionResult> GetAllWithProjects() {
        try {
            var employees = await _employeeService.GetAllEmployeesWithProjectsAsync();
            return Ok(employees);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, "Trouble retrieving records");
        }
    }

    [HttpGet]
    [Route("with-specific-query")]
    public async Task<IActionResult> GetAllWithQuery() {
        try {
            var employees = await _employeeService.GetEmployeesWithQueryAsync();
            return Ok(employees);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, "Trouble retrieving records");
        }
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetById(Guid id) {
        try {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            return Ok(employee);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, "Trouble retrieving record");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Add(EmployeeRequestModel request) {
        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }
        try {
            var newEmployee = await _employeeService.InsertEmployeeAsync(request);
            return CreatedAtAction(nameof(GetById), new {id = newEmployee.Id}, newEmployee);
        } catch (Exception ex) {
            Console.WriteLine(ex);
            return StatusCode(StatusCodes.Status500InternalServerError, "Trouble adding record");
        }
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update(Guid id, EmployeeRequestModel request) {
        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }
        try {
            await _employeeService.UpdateEmployeeAsync(id, request);
            return Ok("Updated 1 record");
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, "Trouble updating record");
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete(Guid id) {
        try {
            await _employeeService.DeleteEmployeeAsync(id);
            return Ok("Deleted 1 record");
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, "Trouble deleting record");
        }
    }
}