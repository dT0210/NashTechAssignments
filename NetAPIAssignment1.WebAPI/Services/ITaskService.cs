using Task = NetAPIAssignment1.Infrastructure.Models.Task;
namespace NetAPIAssignment1.WebAPI.Services;

public interface ITaskService {
    public IEnumerable<Task> GetTasks();
    
    public void CreateTask(Task task);
    public Task? GetTask(Guid id);
    public void DeleteTask(Guid id);
    public void UpdateTask(Task task);
}