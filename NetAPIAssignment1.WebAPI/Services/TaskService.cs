using NetAPIAssignment1.Infrastructure.Models;
using NetAPIAssignment1.Infrastructure.Repositories;
using Task = NetAPIAssignment1.Infrastructure.Models.Task;
namespace NetAPIAssignment1.WebAPI.Services;

public class TaskService : ITaskService {
    private readonly ITaskRepositories _taskRepositories;
    public TaskService(ITaskRepositories taskRepositories) {
        _taskRepositories = taskRepositories;
    }
    public IEnumerable<Task> GetTasks() {
        return _taskRepositories.GetTasks();
    }
    public Task? GetTask(Guid id) {
        return _taskRepositories.GetTaskById(id);
    }
    public void CreateTask(Task task) {
        _taskRepositories.AddTask(task);
    }
    public void DeleteTask(Guid id) {
        _taskRepositories.DeleteTask(id);
    }
    public void UpdateTask(Task task) {
        _taskRepositories.UpdateTask(task);
    }
}