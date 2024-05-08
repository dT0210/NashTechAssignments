namespace NetAPIAssignment1.WebAPI.Models;

//Users dont need to input id in request body
public class TaskRequest {
    public string Title {get; set;}
    public bool Completed {get; set;}
}