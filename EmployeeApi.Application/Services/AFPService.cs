using EmployeeApi.Domain.Entities;
using EmployeeApi.Domain.Repositories;

namespace EmployeeApi.Application.Services
{
  public class AFPService
  {
    private readonly IAFPRepository _afpRepository;

    public AFPService(IAFPRepository aFPRepository)
    {
      _afpRepository = aFPRepository;
    }

    public async Task<List<AFP>> ListAFPAsync()
    {
      return await _afpRepository.ListAsync();
    }

    public async Task<AFP> GetAFPAsync(int id)
    {
      return await _afpRepository.GetAFPAsync(id);
    }
  }
}