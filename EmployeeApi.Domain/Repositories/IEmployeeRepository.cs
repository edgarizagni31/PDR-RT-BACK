using EmployeeApi.Domain.Dto;
using EmployeeApi.Domain.Entities;

namespace EmployeeApi.Domain.Repositories
{
  public interface IEmployeeRepository
  {
    Task<List<EmployeeWhitAfpAndJob>> ListAsync();
    Task<EmployeeWhitAfpAndJob> GetEmployeeAsync(int id);
    Task<Employee> CreateAsync(Employee employee);
    Task<Employee> UpdateAsync(int id, UpdateEmployeeDto updateEmployeeDto);
    Task<Employee> DeleteAsync(int id);
  }
}