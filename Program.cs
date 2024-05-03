using CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.UseHttpsRedirection();

app.UseLogging();

app.MapGet("/", () => "Get api has been called");

app.MapPost("/", () => "Post api has been called.");

app.Run();
