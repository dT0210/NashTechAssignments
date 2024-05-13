using EFCoreAssignment2.Infrastructure.Models;
using EFCoreAssignment2.WebAPI.Models;
using EFCoreAssignment2.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreAssignment2.WebAPI.Controllers;

[ApiController]
[Route("departments")]
public class DepartmentController : ControllerBase {
    private readonly ILogger<DepartmentController> _logger;
    private readonly IDepartmentService _departmentService;

    public DepartmentController(ILogger<DepartmentController> logger, IDepartmentService departmentService) {
        _logger = logger;
        _departmentService = departmentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync() {
        try {
            var departments = await _departmentService.GetAllDepartmentsAsync();
            return Ok(departments);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, "Trouble retrieving records");
        }
        
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetById(Guid id) {
        try {
            var department = await _departmentService.GetDepartmentByIdAsync(id);
            return Ok(department);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, "Trouble retrieving record");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Add(DepartmentRequestModel request){
        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }
        try {
            var newDepartment = await _departmentService.InsertDepartmentAsync(request);
            return CreatedAtAction(nameof(GetById), new {id = newDepartment.Id}, newDepartment);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, "Trouble adding record");
        }
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update(Guid id, DepartmentRequestModel request) {
        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }
        try {
            await _departmentService.UpdateDepartmentAsync(id, request);
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
            await _departmentService.DeleteDepartmentAsync(id);
            return Ok("Deleted 1 record");
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, "Trouble deleting record");
        }
    }
}