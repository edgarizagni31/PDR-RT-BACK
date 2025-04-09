using EmployeeApi.Domain.Entities;
using EmployeeApi.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Infrastructure.Data.Repositories
{
  public class JobRepository : IJobRepository
  {
    private readonly EmployeeDbContext _context;

    public JobRepository(EmployeeDbContext context)
    {
      _context = context;
    }


    public async Task<Job> GetJobAsync(int id)
    {
      var job = await _context.Jobs.Where(j => j.Id == id).FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Puesto no registrado");


      return job;
    }

    public async Task<List<Job>> ListAsync()
    {
      return await _context.Jobs.ToListAsync();
    }
  }
}