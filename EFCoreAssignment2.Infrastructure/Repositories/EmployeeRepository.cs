using EFCoreAssignment2.Infrastructure.Models;

namespace EFCoreAssignment2.Infrastructure.Repositories;

public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(EFDay2Context dbContext) : base(dbContext)
    {
    }
}