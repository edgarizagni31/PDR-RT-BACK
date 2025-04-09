using EmployeeApi.Domain.Entities;
using EmployeeApi.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Infrastructure.Data.Repositories
{
  public class AFPRepository : IAFPRepository
  {
    private readonly EmployeeDbContext _context;

    public AFPRepository(EmployeeDbContext context)
    {
      _context = context;
    }

    public async Task<AFP> GetAFPAsync(int id)
    {
      var afp = await _context.Afps.Where((a) => a.Id == id).FirstOrDefaultAsync() ?? throw new KeyNotFoundException("AFP no esta registrada.");

      return afp;
    }

    public async Task<List<AFP>> ListAsync()
    {
      return await _context.Afps.ToListAsync();
    }
  }
}