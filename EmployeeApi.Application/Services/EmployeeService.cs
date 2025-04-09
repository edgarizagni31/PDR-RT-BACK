using EmployeeApi.Domain.Dto;
using EmployeeApi.Domain.Entities;
using EmployeeApi.Domain.Repositories;

namespace EmployeeApi.Application.Services
{
  public class EmployeeService
  {
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IAFPRepository _afpRepository;
    private readonly IJobRepository _jobRepostiroy;

    public EmployeeService(IEmployeeRepository employeeRepository, IJobRepository jobService, IAFPRepository afpService)
    {
      _employeeRepository = employeeRepository;
      _jobRepostiroy = jobService;
      _afpRepository = afpService;
    }

    public async Task<List<EmployeeWhitAfpAndJob>> ListEmployeeAsync()
    {
      return await _employeeRepository.ListAsync();
    }

    public async Task<EmployeeWhitAfpAndJob> GetEmployeeAsync(int id)
    {
      return await _employeeRepository.GetEmployeeAsync(id);
    }

    public async Task<Employee> CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto)
    {
      var afp = await _afpRepository.GetAFPAsync(createEmployeeDto.AfpId);
      var job = await _jobRepostiroy.GetJobAsync(createEmployeeDto.JobId);
      var employee = new Employee
      {
        FirstName = createEmployeeDto.FirstName,
        LastName = createEmployeeDto.LastName,
        ContractDate = DateTime.Parse(createEmployeeDto.ContractDate),
        BirthDate = DateTime.Parse(createEmployeeDto.BirthDate),
        Salary = createEmployeeDto.Salary,
        JobId = createEmployeeDto.JobId,
        AfpId = createEmployeeDto.AfpId,
        Job = job,
        Afp = afp,
        Status = true,
      };

      return await _employeeRepository.CreateAsync(employee);
    }

    public async Task<Employee> UpdateAsync(int id, UpdateEmployeeDto updateEmployeeDto)
    {
      return await _employeeRepository.UpdateAsync(id, updateEmployeeDto);
    }

    public async Task<Employee> DeleteAsync(int id)
    {
      return await _employeeRepository.DeleteAsync(id);
    }
  }
}