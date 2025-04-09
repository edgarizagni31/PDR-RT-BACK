using EmployeeApi.Domain.Dto;
using EmployeeApi.Domain.Entities;
using EmployeeApi.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Infrastructure.Data.Repositories
{
  public class EmployeeRepository : IEmployeeRepository
  {
    private readonly EmployeeDbContext _context;

    public EmployeeRepository(EmployeeDbContext context)
    {
      _context = context;
    }

    public async Task<List<EmployeeWhitAfpAndJob>> ListAsync()
    {

      return await _context.Employees
         .Where(e => e.Status == true)
         .Select(e => new EmployeeWhitAfpAndJob()
         {
           EmployeeId = e.Id,
           FirstName = e.FirstName,
           LastName = e.LastName,
           JobName = e.Job.Name,
           AfpName = e.Afp.Name,
           Status = e.Status,
           Salary = e.Salary,
           JobId = e.JobId,
           AfpId = e.AfpId,
           ContractDate = e.ContractDate,
           BirthDate = e.BirthDate
         }
          )
         .ToListAsync();
    }

    public async Task<EmployeeWhitAfpAndJob> GetEmployeeAsync(int id)
    {
      var employee = await _context.Employees
        .Where(e => e.Id == id && e.Status == true)
        .Select(e => new EmployeeWhitAfpAndJob()
        {
          EmployeeId = e.Id,
          FirstName = e.FirstName,
          LastName = e.LastName,
          JobName = e.Job.Name,
          AfpName = e.Afp.Name,
          Status = e.Status,
          Salary = e.Salary,
          JobId = e.JobId,
          AfpId = e.AfpId,
          ContractDate = e.ContractDate,
          BirthDate = e.BirthDate
        }
        ).FirstOrDefaultAsync() ?? throw new KeyNotFoundException("employee not found");

      return employee;
    }


    public async Task<Employee> CreateAsync(Employee employee)
    {
      _context.Employees.Add(employee);

      await _context.SaveChangesAsync();

      return employee;
    }

    public async Task<Employee> UpdateAsync(int id, UpdateEmployeeDto updateEmployeeDto)
    {
      var employee = await _context.Employees.Where(e => e.Id == id && e.Status == true).FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Empleado no encontrado.");

      if (!string.IsNullOrEmpty(updateEmployeeDto.FirstName))
      {
        employee.FirstName = updateEmployeeDto.FirstName;
      }

      if (!string.IsNullOrEmpty(updateEmployeeDto.LastName))
      {
        employee.LastName = updateEmployeeDto.LastName;
      }

      if (updateEmployeeDto.Salary.HasValue)
      {
        employee.Salary = updateEmployeeDto.Salary.Value;
      }

      if (!string.IsNullOrEmpty(updateEmployeeDto.ContractDate))
      {
        employee.ContractDate = DateTime.Parse(updateEmployeeDto.ContractDate);
      }

      if (!string.IsNullOrEmpty(updateEmployeeDto.BirthDate))
      {
        employee.BirthDate = DateTime.Parse(updateEmployeeDto.BirthDate);
      }

      if (updateEmployeeDto.JobId.HasValue)
      {
        employee.JobId = updateEmployeeDto.JobId.Value;
      }

      if (updateEmployeeDto.AfpId.HasValue)
      {
        employee.AfpId = updateEmployeeDto.AfpId.Value;
      }

      _context.Employees.Update(employee);
      await _context.SaveChangesAsync();

      return employee;
    }

    public async Task<Employee> DeleteAsync(int id)
    {
      var employee = await _context.Employees.Where(e => e.Id == id && e.Status == true).FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Empleado no encontrado.");

      employee.Status = false;

      _context.Employees.Update(employee);
      await _context.SaveChangesAsync();

      return employee;
    }
  }
}