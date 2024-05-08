using Task = NetAPIAssignment1.Infrastructure.Models.Task;

namespace NetAPIAssignment1.Infrastructure.Repositories;

public interface ITaskRepositories {
    public IEnumerable<Task> GetTasks();
    public Task? GetTaskById(Guid id);
    public void AddTask(Task task);
    public void UpdateTask(Task task);
    public void DeleteTask(Guid id);
}