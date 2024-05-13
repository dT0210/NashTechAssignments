using EFCoreAssignment2.WebAPI.Models;
using EFCoreAssignment2.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreAssignment2.WebAPI.Controllers;

[ApiController]
[Route("salaries")]
public class SalariesController : ControllerBase {
    private readonly ILogger<SalariesController> _logger;
    private readonly ISalariesService _salariesService;
    public SalariesController(ILogger<SalariesController> logger, ISalariesService salariesService) {
        _logger = logger;
        _salariesService = salariesService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() {
        try {
            var salaries = await _salariesService.GetAllSalariesAsync();
            return Ok(salaries);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, "Trouble retrieving records");
        }
        
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetById(Guid id) {
        try {
            var salaries = await _salariesService.GetSalariesByIdAsync(id);
            return Ok(salaries);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, "Trouble retrieving record");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Add(SalariesRequestModel request) {
        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }
        try {
            var newSalaries = await _salariesService.InsertSalariesAsync(request);
            return CreatedAtAction(nameof(GetById), new {id = newSalaries.Id}, newSalaries);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, "Trouble adding record");
        }
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update(Guid id, SalariesRequestModel request) {
        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }
        try {
            await _salariesService.UpdateSalariesAsync(id, request);
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
            await _salariesService.DeleteSalariesAsync(id);
            return Ok("Deleted 1 record");
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, "Trouble deleting record");
        }
    }
}