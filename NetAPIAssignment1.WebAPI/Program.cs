using NetAPIAssignment1.Infrastructure.Repositories;
using NetAPIAssignment1.WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddScoped<ITaskRepositories, TaskRepositories>();
services.AddScoped<ITaskService, TaskService>();
// Add services to the container.
services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
