using EFCoreAssignment2.Infrastructure;
using EFCoreAssignment2.Infrastructure.Repositories;
using EFCoreAssignment2.WebAPI.Common;
using EFCoreAssignment2.WebAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

// Add services to the container.
var services = builder.Services;
services.AddAutoMapper(typeof(MapperProfile));
services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
services.AddScoped<IEmployeeRepository, EmployeeRepository>();
services.AddScoped<IProjectEmployeeRepository, ProjectEmployeeRepository>();
services.AddScoped<IEmployeeService, EmployeeService>();
services.AddScoped<IDepartmentService, DepartmentService>();
services.AddScoped<ISalariesService, SalariesService>();
services.AddScoped<IProjectService, ProjectService>();
services.AddDbContext<EFDay2Context>(
    options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
);

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
