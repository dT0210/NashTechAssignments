using AutoMapper;
using EFCoreAssignment2.Infrastructure.Models;
using EFCoreAssignment2.Infrastructure.Repositories;
using EFCoreAssignment2.WebAPI.Models;

namespace EFCoreAssignment2.WebAPI.Services;

public class SalariesService : ISalariesService
{
    private readonly IGenericRepository<Salaries> _salariesRepository;
    private readonly IMapper _mapper;
    public SalariesService(IGenericRepository<Salaries> salariesRepository, IMapper mapper) {
        _salariesRepository = salariesRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<SalariesResponseModel>> GetAllSalariesAsync()
    {
        var salaries = await _salariesRepository.GetAllAsync();
        return salaries.Select(_mapper.Map<SalariesResponseModel>);
    }

    public async Task<SalariesResponseModel?> GetSalariesByIdAsync(Guid id)
    {
        var salaries = await _salariesRepository.GetByIdAsync(id);
        return _mapper.Map<SalariesResponseModel>(salaries);
    }

    public async Task<Salaries> InsertSalariesAsync(SalariesRequestModel salaries)
    {
        var newSalaries = _mapper.Map<Salaries>(salaries);
        await _salariesRepository.InsertAsync(newSalaries);
        await _salariesRepository.SaveAsync();
        return newSalaries;
    }

    public async Task UpdateSalariesAsync(Guid id, SalariesRequestModel salaries)
    {
        var updatedSalaries = _mapper.Map<Salaries>(salaries);
        updatedSalaries.Id = id;
        _salariesRepository.Update(updatedSalaries);
        await _salariesRepository.SaveAsync();
    }

    public async Task DeleteSalariesAsync(Guid id)
    {
        await _salariesRepository.DeleteAsync(id);
        await _salariesRepository.SaveAsync();
    }
}