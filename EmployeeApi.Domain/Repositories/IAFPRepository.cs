using EmployeeApi.Domain.Entities;

namespace EmployeeApi.Domain.Repositories
{
  public interface IAFPRepository
  {
    Task<List<AFP>> ListAsync();
    Task<AFP> GetAFPAsync(int id);
  }
}