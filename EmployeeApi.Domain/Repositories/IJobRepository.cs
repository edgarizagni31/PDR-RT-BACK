using EmployeeApi.Domain.Entities;

namespace EmployeeApi.Domain.Repositories
{
  public interface IJobRepository
  {
    Task<List<Job>> ListAsync();
    Task<Job> GetJobAsync(int id);
  }
}