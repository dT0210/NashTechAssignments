using Microsoft.AspNetCore.Mvc;
using NetAPIAssignment1.WebAPI.Services;
using Task = NetAPIAssignment1.Infrastructure.Models.Task;
using NetAPIAssignment1.WebAPI.Models;

namespace NetAPIAssignment1.WebAPI.Controllers;

[ApiController]
[Route("/tasks")]
public class TaskController : ControllerBase {
    private readonly ILogger<TaskController> _logger;
    private readonly ITaskService _taskService;
    public TaskController(ILogger<TaskController> logger, ITaskService taskService) {
        _logger = logger;
        _taskService = taskService;
    }
    [HttpGet]
    public IActionResult Get() {
        try {
            var tasks = _taskService.GetTasks();
            return Ok(tasks);
        } catch (Exception ex) {
            Console.WriteLine($"Error retrieving tasks: {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving tasks");
        }
        
    }
    [HttpGet]
    [Route("{id}")]
    public  IActionResult GetTask(Guid id) {
        try {
            Task? task = _taskService.GetTask(id);
            if (task != null)
                return Ok(task);
            return NotFound();
        } catch (Exception ex) {
            Console.WriteLine($"Error retrieving task: {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving task");
        }
    }
    [HttpPost]
    public IActionResult CreateTask([FromBody]TaskRequest task) {
        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }
        try {
            Task newTask = new Task(task.Title, task.Completed);
            _taskService.CreateTask(newTask);
            return  CreatedAtAction(nameof(GetTask), new {id = newTask.Id}, newTask);
        } catch (Exception ex) {
            Console.WriteLine($"Error creating task: {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, "Error creating task");
        }
        
    }
    [HttpDelete]
    [Route("{id}")]
    public IActionResult DeleteTask(Guid id) {
        try {
            _taskService.DeleteTask(id);
            return NoContent();
        } catch (Exception ex) {
            Console.WriteLine($"Error deleting task: {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting task");
        }
    }
    [HttpPut]
    [Route("{id}")]
    public IActionResult UpdateTask(Guid id, [FromBody]TaskRequest task) {
        try {
            Task newTask = new Task(id, task.Title, task.Completed);
            _taskService.UpdateTask(newTask);
            return NoContent();
        } catch (Exception ex) {
            Console.WriteLine($"Error updating task: {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, "Error updating task");
        }
        
    }
    [HttpPost]
    [Route("bulk")]
    public IActionResult CreateBulkTasks([FromBody] List<TaskRequest> tasks) {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try {
            foreach (var task in tasks) {
                Task newTask = new Task(task.Title, task.Completed);
                _taskService.CreateTask(newTask);
            }
            return Created();
        } catch (Exception ex) {
            Console.WriteLine($"Error creating bulk tasks: {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, "Error creating bulk tasks");
        }
    }
    public IActionResult DeleteBulkTasks([FromBody] List<Guid> ids) {
        try {
            foreach (Guid id in ids) {
                _taskService.DeleteTask(id);
            }
            return NoContent();
        } catch (Exception ex) {
            Console.WriteLine($"Error deleting bulk tasks: {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting bulk tasks");
        }
    }
}