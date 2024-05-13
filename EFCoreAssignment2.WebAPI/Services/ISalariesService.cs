using EFCoreAssignment2.Infrastructure.Models;
using EFCoreAssignment2.WebAPI.Models;

namespace EFCoreAssignment2.WebAPI.Services;

public interface ISalariesService {
    Task<IEnumerable<SalariesResponseModel>> GetAllSalariesAsync();
    Task<SalariesResponseModel?> GetSalariesByIdAsync(Guid id);
    Task<Salaries> InsertSalariesAsync(SalariesRequestModel salaries);
    Task UpdateSalariesAsync(Guid id, SalariesRequestModel salaries);
    Task DeleteSalariesAsync(Guid id);
}