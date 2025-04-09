using EmployeeApi.Domain.Entities;
using EmployeeApi.Domain.Repositories;

namespace EmployeeApi.Application.Services
{
  public class JobService
  {
    private readonly IJobRepository _jobRepository;

    public JobService(IJobRepository jobRepository)
    {
      _jobRepository = jobRepository;
    }

    public async Task<List<Job>> ListJobAsync()
    {
      return await _jobRepository.ListAsync();
    }

    public async Task<Job> GetJobAsync(int id)
    {
      return await _jobRepository.GetJobAsync(id);
    }
  }
}