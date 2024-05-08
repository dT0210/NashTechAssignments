namespace NetAPIAssignment1.Infrastructure.Models;

public class Task {
    public Guid Id {get; set;} 
    public string Title {get; set;}
    public bool Completed {get; set;}

    public Task() {
        Id = Guid.NewGuid();
        Title = "";
        Completed = false;
    }

    public Task(string title, bool completed) {
        Id = Guid.NewGuid();
        Title = title;
        Completed = completed;
    }
    public Task(Guid id, string title, bool completed) {
        Id = id;
        Title = title;
        Completed= completed;
    }
}