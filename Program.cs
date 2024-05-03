using CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.UseHttpsRedirection();

app.UseLogging();

app.MapGet("/", () => "Hello world");

app.MapGet("/GetSomething", () => {return Results.Ok("Get api was called");});

app.MapPost("/PostSomething", () => {return Results.Accepted();});

app.Run();
