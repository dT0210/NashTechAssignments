using EFCoreAssignment2.WebAPI.Models;
using EFCoreAssignment2.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreAssignment2.WebAPI.Controllers;

[ApiController]
[Route("projects")]
public class ProjectController : ControllerBase {
    private readonly ILogger<ProjectController> _logger;
    private readonly IProjectService _projectService;
    public ProjectController(ILogger<ProjectController> logger, IProjectService projectService) {
        _logger = logger;
        _projectService = projectService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() {
        try {
            var projects = await _projectService.GetAllProjectsAsync();
            return Ok(projects);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, "Trouble retrieving records");
        }
        
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetById(Guid id) {
        try {
            var project = await _projectService.GetProjectByIdAsync(id);
            return Ok(project);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, "Trouble retrieving record");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Add(ProjectRequestModel request) {
        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }
        try {
            var newProject = await _projectService.InsertProjectAsync(request);
            return CreatedAtAction(nameof(GetById), new {id = newProject.Id}, newProject);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, "Trouble adding record");
        }
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update(Guid id, ProjectRequestModel request) {
        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }
        try {
            await _projectService.UpdateProjectAsync(id, request);
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
            await _projectService.DeleteProjectAsync(id);
            return Ok("Deleted 1 record");
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, "Trouble deleting record");
        }
    }

    [HttpPost]
    [Route("{projectId}/employees")]
    public async Task<IActionResult> AddEmployee(Guid projectId, [FromBody]Guid employeeId) {
        try {
            await _projectService.AddEmployeeToProject(projectId, employeeId);
            return Ok();
        } catch (Exception ex) {
            Console.WriteLine(ex);
            return StatusCode(StatusCodes.Status500InternalServerError, "Trouble adding record");
        }
    }
}