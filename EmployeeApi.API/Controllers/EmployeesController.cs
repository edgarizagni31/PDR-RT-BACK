using EmployeeApi.Application.Services;
using EmployeeApi.Domain.Dto;
using EmployeeApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApi.Api.Controllers
{
  [ApiController]
  [Route("/api/employees")]
  public class EmployeesController : ControllerBase
  {
    private readonly EmployeeService _employeeService;

    public EmployeesController(EmployeeService employeeService)
    {
      _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<IActionResult> ListEmployee()
    {
      var employees = await _employeeService.ListEmployeeAsync();
      var apiResponse = new ApiResponse<List<EmployeeWhitAfpAndJob>>()
      {
        Success = true,
        Message = "lista de empleados",
        Data = employees
      };

      return Ok(apiResponse);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmploye([FromBody] CreateEmployeeDto createEmployeeDto)
    {
      try
      {
        var employee = await _employeeService.CreateEmployeeAsync(createEmployeeDto);

        return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
      }
      catch (KeyNotFoundException ex)
      {
        return NotFound(new ApiResponse<string>()
        {
          Data = null,
          Success = false,
          Message = ex.Message
        }
        );
      }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployee(int id, [FromBody] UpdateEmployeeDto updateEmployeeDto)
    {
      try
      {
        var employee = await _employeeService.UpdateAsync(id, updateEmployeeDto);
        var apiResponse = new ApiResponse<Employee>()
        {
          Success = true,
          Message = "empleado actualizado con exito",
          Data = employee
        };

        return Ok(apiResponse);
      }
      catch (KeyNotFoundException ex)
      {
        return NotFound(new ApiResponse<object> { Message = ex.Message, Success = false, Data = null });
      }
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
      try
      {
        var employee = await _employeeService.DeleteAsync(id);
        var apiResponse = new ApiResponse<Employee>()
        {
          Success = true,
          Message = "empleado eliminado con exito",
          Data = employee
        };

        return Ok(apiResponse);
      }
      catch (KeyNotFoundException)
      {
        return NotFound(new ApiResponse<object> { Message = "Empleado no encontrado.", Success = false, Data = null });
      }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployeeById(int id)
    {
      try
      {
        var employee = await _employeeService.GetEmployeeAsync(id);
        var apiResponse = new ApiResponse<EmployeeWhitAfpAndJob>()
        {
          Success = true,
          Message = "empleado obteneido con exito",
          Data = employee
        };

        return Ok(apiResponse);
      }
      catch (KeyNotFoundException)
      {
        return NotFound(new ApiResponse<object> { Message = "Empleado no encontrado.", Success = false, Data = null });
      }
    }

  }
}