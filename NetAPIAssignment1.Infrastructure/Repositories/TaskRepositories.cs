using Task = NetAPIAssignment1.Infrastructure.Models.Task;
namespace NetAPIAssignment1.Infrastructure.Repositories;

public class TaskRepositories : ITaskRepositories {
    private static List<Task> tasks = new List<Task> {
            new Task(".Net API Assignments Day 1", false),
            new Task(".Net API Assignments Day 2", false),
            new Task("Exercise", false),
            new Task("Finish the final project", false),
        };
    public TaskRepositories() {
        
    }
    public IEnumerable<Task> GetTasks() {
        return tasks;
    }
    public Task? GetTaskById(Guid id) {
        var selectedTask = (from task in tasks
                             where task.Id == id
                             select task).FirstOrDefault();
        return selectedTask;
    }
    public void AddTask(Task task) {
        tasks.Add(task);
    }
    public void UpdateTask(Task updatedTask) {
        var toUpdateTask = (from task in tasks
                            where task.Id == updatedTask.Id
                            select task).FirstOrDefault();
        if (toUpdateTask != null) {
            toUpdateTask.Title = updatedTask.Title;
            toUpdateTask.Completed = updatedTask.Completed;
        }
    }
    public void DeleteTask(Guid id) {
        var selectedTask = (from task in tasks
                            where task.Id == id
                            select task).FirstOrDefault();
        if (selectedTask != null)
            tasks.Remove(selectedTask);
    }
}